Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json.Linq

Public Class AlertsUserControl

    Public Async Function SendOtpSMS(phone As String, otp As String) As Task(Of Boolean)
        Dim baseUrl As String = "https://www.iprogsms.com/api/v1/sms_messages"

        ' Construct the query params
        Dim apiToken As String = "8391dc35a8be121f396e2d1756cbf2f2999a2e59"
        Dim query As String =
    $"api_token={Uri.EscapeDataString(apiToken)}" &
    $"&phone_number=63{phone}" &
    $"&message={Uri.EscapeDataString("Your verification code is: " & otp)}" &
    $"&sms_provider=0"

        Dim url As String = $"{baseUrl}?{query}"

        Using client As New HttpClient()
            Dim response As HttpResponseMessage = Await client.PostAsync(url, Nothing)
            Dim json As String = Await response.Content.ReadAsStringAsync()

            Dim data As JObject = JObject.Parse(json)

            Dim statusObj = data("status")

            Dim status As Integer = -1
            If Integer.TryParse(statusObj.ToString(), status) Then
                ' status is numeric
            Else
                ' API returned a string error
                Throw New Exception(statusObj.ToString())

            End If

            If status <> 200 Then
                Throw New Exception(data("message")?.ToString())
            End If

            If data("status") Is Nothing OrElse data("status").ToObject(Of Integer)() <> 200 Then
                Throw New Exception(data("message")?.ToString() Or "IPROG SMS failed")

            End If

            Console.WriteLine("SMS sent successfully: " & data("message_id")?.ToString())
            Return True
        End Using
    End Function


    Private Sub txtBroadcastMessage_TextChanged(sender As Object, e As EventArgs) Handles txtBroadcastMessage.TextChanged
        ' ts just changes the character count label as you type
        lblCharCount.Text = txtBroadcastMessage.Text.Length.ToString() & " Characters"
    End Sub

    Private Sub AlertsUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TODO ADD CONNECTION TO DATABASE TO PULL SEARCH RESULTS
        ' REMOVE THIS AND POPULATE WITH ACTUAL DATA FROM DATABASE

        ' Avoid running at design time
        If Me.DesignMode Then
            Return
        End If

        ' Prefer the known FlowLayoutPanel name "flpContacts"
        Dim flp As FlowLayoutPanel = Nothing
        Dim found() As Control = Me.Controls.Find("flpContact", True)
        If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is FlowLayoutPanel Then
            flp = CType(found(0), FlowLayoutPanel)
        Else
            ' Known name not present - nothing to do
            Return
        End If

        ' Create and add 3 instances of UserControlAlerts for testing
        Dim count As Integer = 3
        For i As Integer = 1 To count
            Dim uc As New UserControlAlerts()
            uc.Name = "UserControlAlert" & i.ToString()
            uc.Margin = New Padding(6) ' slight spacing for visual clarity
            flp.Controls.Add(uc)
        Next
    End Sub

    Private Async Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Try
            Dim phone As String = "09065867926"
            Dim otp As String = "123456"

            Dim success = Await SendOtpSMS(phone, otp)

            If success Then
                MessageBox.Show("SMS sent!" + otp)

            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Class
