Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Net
Imports System.Text
Imports System.IO

Public Class DashboardUserControl

    ' ---------------- SENSOR CLASS (simulation only for status/signal) ----------------
    Public Class SensorSimulation
        Public Property Name As String
        Public Property IsActive As Boolean = True
        Public Property Signal As String = "Strong"
        Public Property Battery As Integer = 100

        Private rand As New Random()

        Public Sub Tick()
            ' Random active/inactive
            If rand.Next(0, 100) < 3 Then
                IsActive = Not IsActive
            End If

            ' Battery drift
            Battery += rand.Next(-1, 2)
            Battery = Math.Max(5, Math.Min(100, Battery))

            ' Signal variations
            Dim s = rand.Next(0, 100)
            If s > 75 Then Signal = "Strong"
            If s > 50 AndAlso s <= 75 Then Signal = "Medium"
            If s > 25 AndAlso s <= 50 Then Signal = "Weak"
            If s <= 25 Then Signal = "Low"
        End Sub
    End Class


    Private Sub DashboardUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub


    ' ---------------- TIMER LOOP ----------------
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        For Each s In sensors
            s.Tick()
        Next

        UpdateDashboard()
    End Sub


    ' ---------------- MAIN DASHBOARD UPDATE ----------------
    Private Sub UpdateDashboard()

        Dim activeCount = sensors.Where(Function(s) s.IsActive).Count()
        Dim offlineCount = sensors.Count - activeCount

        lbl_sensors_active.Text = activeCount.ToString()
        lbl_sensors_offline.Text = offlineCount.ToString()

        lblTimestamp.Text = "As of " & DateTime.Now.ToString("h:mm tt, MMMM d, yyyy")


        ' ---------------- REAL WATER LEVEL FROM RECEIVER ----------------
        Dim water = GetWaterDataFromReceiver()

        Dim meter As Double = water.level / 1000.0
        lbl_waterlevel.Text = meter.ToString("0.00")

        lblOverallWaterStatus.Text = water.status
        lblOverallWaterStatus.ForeColor =
            If(water.status = "SAFE", Color.Green,
            If(water.status = "WARNING", Color.Orange, Color.Red))


        ' ---------------- Dummy population ----------------
        Static safe As Integer = 0
        Static unsafe As Integer = 30
        safe += 1
        unsafe -= 1
        If unsafe < 0 Then unsafe = 0

        lbl_safe_residents.Text = safe.ToString()
        lbl_unsafe_residents.Text = unsafe.ToString()


        ' ---------------- Update sensor cards ----------------
        UpdateSensorCard(sensors(0), lblS1Status, lblS1Signal, lblS1Battery, dotS1)
        UpdateSensorCard(sensors(1), lblS2Status, lblS2Signal, lblS2Battery, dotS2)

    End Sub


    ' ---------------- DOT RENDERING ----------------
    Private dotPaintAttached As New HashSet(Of Control)()

    Private Sub SetDotFillColor(dotControl As Control, fillColor As Color)
        dotControl.Tag = fillColor

        If Not dotPaintAttached.Contains(dotControl) Then
            AddHandler dotControl.Paint, AddressOf DotControl_Paint
            dotPaintAttached.Add(dotControl)

            Try
                dotControl.BackColor = dotControl.Parent.BackColor
            Catch
            End Try
        End If

        dotControl.Invalidate()
    End Sub

    Private Sub DotControl_Paint(sender As Object, e As PaintEventArgs)
        Dim c = TryCast(sender, Control)
        If c Is Nothing Then Return

        Dim fill As Color = If(TypeOf c.Tag Is Color, CType(c.Tag, Color), c.BackColor)

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = c.ClientRectangle
        rect.Inflate(-2, -2)

        If rect.Width <= 0 Or rect.Height <= 0 Then Return

        Using brush As New SolidBrush(fill)
            e.Graphics.FillEllipse(brush, rect)
        End Using

        Using pen As New Pen(Color.FromArgb(100, Color.Black), 1)
            e.Graphics.DrawEllipse(pen, rect)
        End Using
    End Sub



    ' ---------------- SENSOR CARD UPDATE ----------------
    Private Sub UpdateSensorCard(s As SensorSimulation,
                                 lblStatus As Label,
                                 lblSignal As Label,
                                 lblBattery As Label,
                                 dotControl As Control)

        lblStatus.Text = If(s.IsActive, "Active", "Offline")
        lblSignal.Text = s.Signal
        lblBattery.Text = s.Battery.ToString() & "%"

        SetDotFillColor(dotControl, If(s.IsActive, Color.LimeGreen, Color.Red))
    End Sub



    ' ---------------- SENSOR SIM LIST ----------------
    Private sensors As New List(Of SensorSimulation) From {
        New SensorSimulation With {.Name = "Alley 18 Station"},
        New SensorSimulation With {.Name = "Entry 1 (Upstream)"}
    }



    ' ---------------- SEND BUZZER COMMAND ----------------
    Private Sub SendCommandToESP(endpoint As String)
        Try
            Dim espIP As String = "http://10.237.203.199"
            Dim url As String = espIP & endpoint

            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "GET"
            request.Timeout = 3000

            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Using reader As New StreamReader(response.GetResponseStream())
                    Console.WriteLine("ESP Response: " & reader.ReadToEnd())
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Failed to send command to ESP32: " & ex.Message)
        End Try
    End Sub


    Private buzzerState As Boolean = False

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click

        If buzzerState = False Then
            SendCommandToESP("/buzzer_on")
            Label4.Text = "Deactivate Buzzer"
            Guna2Button11.Text = "TURN BUZZER OFF"
            buzzerState = True

        Else
            SendCommandToESP("/buzzer_off")
            Label4.Text = "Activate Buzzer"
            Guna2Button11.Text = "TURN BUZZER ON"
            buzzerState = False

        End If
    End Sub



    ' ---------------- GET WATER LEVEL FROM RECEIVER ----------------
    Private Function GetWaterDataFromReceiver() As (level As Double, status As String)
        Try
            Dim espIP As String = "http://10.237.203.199"
            Dim url As String = espIP & "/waterlevel"

            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "GET"
            request.Timeout = 2000

            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Using reader As New StreamReader(response.GetResponseStream())

                    Dim raw As String = reader.ReadToEnd().Trim()
                    ' Example raw receiver output:
                    ' "RX Water -> L:3488 meter | RSSI:-89 | SNR: 8"

                    Dim level As Double = 0
                    Dim status As String = "SAFE"

                    ' ---------- Extract number after "L:" ----------
                    Dim pos = raw.IndexOf("L:")
                    If pos >= 0 Then
                        Dim numStr As String = ""

                        For i = pos + 2 To raw.Length - 1
                            If Char.IsDigit(raw(i)) Then
                                numStr &= raw(i)
                            Else
                                Exit For
                            End If
                        Next

                        level = Val(numStr)
                    End If

                    ' ---------- Determine status based on level ----------
                    If level < 2000 Then
                        status = "SAFE"
                    ElseIf level < 4000 Then
                        status = "WARNING"
                    Else
                        status = "DANGER"
                    End If

                    Return (level, status)

                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine("Receiver error: " & ex.Message)
            Return (0, "UNKNOWN")
        End Try
    End Function

End Class
