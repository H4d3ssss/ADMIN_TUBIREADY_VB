Imports System.Net.Http
Imports System.Web
Module SMSservice

    Public ReadOnly baseUrl As String = "https://www.iprogsms.com/api/v1/sms_messages"
    Public ReadOnly client As HttpClient = New HttpClient()

    Public Async Function SendOtpSMS(phone As String, otp As String) As Task(Of Boolean)
        ' Build the parameters
        Dim query As New List(Of String) From {
            "api_token=" & HttpUtility.UrlEncode(Environment.GetEnvironmentVariable("IPROG_KEY")),
            "phone_number=63" & phone,
            "message=" & HttpUtility.UrlEncode($"Your verification code is: {otp}"),
            "sms_provider=0"
        }

        Dim url As String = baseUrl & "?" & String.Join("&", query)

        ' Send request
        Dim response As HttpResponseMessage = Await client.PostAsync(url, Nothing)
        Dim json As String = Await response.Content.ReadAsStringAsync()

        ' Parse JSON
        Dim data = Newtonsoft.Json.Linq.JObject.Parse(json)

        ' Check status
        If data("status") Is Nothing OrElse CInt(data("status")) <> 200 Then
            Throw New Exception(data("message")?.ToString() Or "IPROG SMS failed")
        End If

        Console.WriteLine("SMS sent successfully: " & data("message_id").ToString())
        Return True
    End Function

End Module
