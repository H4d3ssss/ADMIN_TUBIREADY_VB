Public Class AlertsUserControl

    Private Sub txtBroadcastMessage_TextChanged(sender As Object, e As EventArgs) Handles txtBroadcastMessage.TextChanged
        lblCharCount.Text = txtBroadcastMessage.Text.Length.ToString() & " Characters"
    End Sub

    Private Sub AlertsUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Avoid running at design time
        If Me.DesignMode Then
            Return
        End If

        ' Attempt to find the flow layout panel by a set of common names
        Dim flp As FlowLayoutPanel = Nothing
        Dim candidateNames As String() = {"flowLayoutPanelAlerts", "flpAlerts", "FlowLayoutPanel1", "flowLayoutPanel1", "FlowLayoutPanelAlerts"}

        For Each n In candidateNames
            Dim found() As Control = Me.Controls.Find(n, True)
            If found IsNot Nothing AndAlso found.Length > 0 AndAlso TypeOf found(0) Is FlowLayoutPanel Then
                flp = CType(found(0), FlowLayoutPanel)
                Exit For
            End If
        Next

        ' If not found by name, fall back to first FlowLayoutPanel in the control tree
        If flp Is Nothing Then
            Dim allControls As New List(Of Control)
            allControls.AddRange(Me.Controls.Cast(Of Control)())
            ' recursive search
            Dim stack As New Stack(Of Control)(allControls)
            While stack.Count > 0 AndAlso flp Is Nothing
                Dim c As Control = stack.Pop()
                If TypeOf c Is FlowLayoutPanel Then
                    flp = CType(c, FlowLayoutPanel)
                    Exit While
                End If
                For Each child As Control In c.Controls
                    stack.Push(child)
                Next
            End While
        End If

        ' If still nothing, abort
        If flp Is Nothing Then
            Return
        End If

        ' Create and add 3 instances of UserControlAlert for testing
        Dim count As Integer = 3
        For i As Integer = 1 To count
            Dim uc As New UserControlAlerts()
            uc.Name = "UserControlAlert" & i.ToString()
            uc.Margin = New Padding(6) ' slight spacing for visual clarity
            ' Optionally set a visible test value if the child exposes one:
            ' If uc.Controls.Find("lblTitle", True).Length > 0 Then
            '     CType(uc.Controls.Find("lblTitle", True)(0), Label).Text = "Test Alert " & i
            ' End If
            flp.Controls.Add(uc)
        Next
    End Sub

End Class
