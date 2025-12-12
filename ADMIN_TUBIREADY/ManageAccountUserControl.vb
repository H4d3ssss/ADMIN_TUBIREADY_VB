Public Class ManageAccountUserControl
    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick

    End Sub
    
    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        ' Create the CreateAccount user control instance
        Dim createCtrl As New CreateAccount()
        createCtrl.Dock = DockStyle.Fill

        ' Determine host: prefer a named panel on the parent, otherwise parent or this control
        Dim host As Control = Nothing
        If Me.Parent IsNot Nothing Then
            host = Me.Parent
            Dim preferredPanel As Control = Nothing
            For Each c As Control In host.Controls
                If TypeOf c Is Panel AndAlso (c.Name = "PanelMain" OrElse c.Name = "PanelContainer") Then
                    preferredPanel = c
                    Exit For
                End If
            Next
            If preferredPanel IsNot Nothing Then
                host = preferredPanel
            End If
        Else
            host = Me
        End If

        ' Remove existing CreateAccount controls from the host
        For i As Integer = host.Controls.Count - 1 To 0 Step -1
            Dim c As Control = host.Controls(i)
            If c.GetType() Is GetType(CreateAccount) Then
                host.Controls.RemoveAt(i)
                c.Dispose()
            End If
        Next

        ' If a row is selected, prepare details and try to pass them to the CreateAccount control
        If Guna2DataGridView1.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = Guna2DataGridView1.SelectedRows(0)

            ' Build a dictionary of column-name -> value
            Dim data As New Dictionary(Of String, Object)()
            For Each cell As DataGridViewCell In row.Cells
                Dim colName As String = If(cell.OwningColumn IsNot Nothing, cell.OwningColumn.Name, "Column" & cell.ColumnIndex.ToString())
                data(colName) = If(cell.Value, Nothing)
            Next

            Try
                ' Prefer calling a method named LoadAccountDetails that accepts a Dictionary
                Dim mi = createCtrl.GetType().GetMethod("LoadAccountDetails", New Type() {GetType(Dictionary(Of String, Object))})
                If mi IsNot Nothing Then
                    mi.Invoke(createCtrl, New Object() {data})
                Else
                    ' Fallback: try to set properties on the control matching column names
                    For Each kvp In data
                        Try
                            Dim prop = createCtrl.GetType().GetProperty(kvp.Key)
                            If prop IsNot Nothing AndAlso prop.CanWrite Then
                                If kvp.Value Is Nothing Then
                                    prop.SetValue(createCtrl, Nothing, Nothing)
                                Else
                                    ' Attempt to convert value to property type when possible
                                    Dim targetType = Nullable.GetUnderlyingType(prop.PropertyType)
                                    If targetType Is Nothing Then
                                        targetType = prop.PropertyType
                                    End If
                                    Dim converted = Convert.ChangeType(kvp.Value, targetType)
                                    prop.SetValue(createCtrl, converted, Nothing)
                                End If
                            End If
                        Catch
                            ' ignore individual property set failures
                        End Try
                    Next
                End If
            Catch
                ' ignore any reflection errors so UI remains responsive
            End Try
        End If

        ' Add and show the CreateAccount control
        host.Controls.Add(createCtrl)
        createCtrl.BringToFront()
    End Sub
End Class
