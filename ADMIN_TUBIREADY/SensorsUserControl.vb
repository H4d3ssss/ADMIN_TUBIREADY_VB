Imports System.Net.Http
Imports System.Timers

Public Class SensorsUserControl
    Private updateTimer As System.Timers.Timer
    Private receiverIP As String = "192.168.254.119" ' Your Receiver IP
    Private http As New HttpClient()

    Private Sub SensorsUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateTimer = New System.Timers.Timer(3000)
        updateTimer.SynchronizingObject = Me    ' marshals Elapsed to UI thread once handle exists
        AddHandler updateTimer.Elapsed, AddressOf UpdateSensorData
        ' Option A: start here if handle is guaranteed created
        ' Option B (safer): start in OnHandleCreated override

        ' Set initial date/time immediately on load
        lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM, dd, yyyy - HH:mm tt")
    End Sub

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)
        tmrUpdate?.Start()
    End Sub

    Private Async Sub UpdateSensorData(source As Object, e As ElapsedEventArgs)
        Try
            Dim temp As String = Await GetDataAsync("temp")
            Dim humid As String = Await GetDataAsync("humidity")

            ' Update UI including date/time
            Me.Invoke(Sub()
                          lblTemp.Text = temp & "°C"
                          lblHumid.Text = humid & "%"
                          lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM, dd, yyyy - HH:mm tt")
                      End Sub)

        Catch ex As Exception
            ' Error fallback - still update date/time
            Me.Invoke(Sub()
                          lblTemp.Text = "ERR"
                          lblHumid.Text = "ERR"
                          lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM, dd, yyyy - HH:mm tt")
                      End Sub)
        End Try
    End Sub

    Private Async Function GetDataAsync(endpoint As String) As Task(Of String)
        Dim url As String = $"http://{receiverIP}/{endpoint}"
        Dim response As HttpResponseMessage = Await http.GetAsync(url)
        response.EnsureSuccessStatusCode()

        Dim content As String = Await response.Content.ReadAsStringAsync()
        Return content.Trim()
    End Function
End Class