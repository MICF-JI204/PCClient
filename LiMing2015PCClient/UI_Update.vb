Partial Public Class Form_ORRM

    Private Sub ChangeText(ByVal tb As TextBox, ByVal Content As String, ByVal Color As System.Drawing.Color)
        tb.BeginInvoke(New ChangeTextDelegate(AddressOf ChangeTextInvoke), New Object() {tb, Content, Color})
    End Sub

    Private Sub ChangeLabel(ByRef lb As Label, ByVal Content As String, ByVal Color As System.Drawing.Color)
        lb.BeginInvoke(New ChangeLabelDelegate(AddressOf ChangeLabelInvoke), New Object() {lb, Content, Color})
    End Sub

    Private Sub ChangeStatusLabel(ByRef lb As ToolStripStatusLabel, ByVal Content As String, ByVal Color As System.Drawing.Color)
        StatusStrip.BeginInvoke(New ChangeStatusLabelDelegate(AddressOf ChangeStatusLabelInvoke), New Object() {lb, Content, Color})
    End Sub

    Private Sub AddItemCombo(ByRef dest As ComboBox, ByVal item As Object)
        dest.Invoke(New AddItemComboDelegate(AddressOf AddItemComboInvoke), New Object() {dest, item})
    End Sub

    Private Sub RemoveItemCombo(ByRef source As ComboBox, ByVal item As Object)
        source.Invoke(New RemoveItemComboDelegate(AddressOf RemoveItemComboInvoke), New Object() {source, item})
    End Sub

    Private Sub Update_Trejectory()
        PictureBox_Trejection.BeginInvoke(New Update_PictureBoxDelegate(AddressOf Update_Trejectory_UI))
    End Sub

    '============================================上方接口===================================================
    '========================================下方委托等等定义===============================================

    Private Delegate Sub ChangeTextDelegate(ByVal tb As TextBox, ByVal Conetnt As String, ByVal Color As System.Drawing.Color)
    Private Delegate Sub ChangeLabelDelegate(ByVal lb As Label, ByVal Conetnt As String, ByVal Color As System.Drawing.Color)
    Private Delegate Sub ChangeStatusLabelDelegate(ByVal lb As ToolStripStatusLabel, ByVal Conetnt As String, ByVal Color As System.Drawing.Color)
    Private Delegate Sub Update_PictureBoxDelegate()
    Private Delegate Sub RemoveItemComboDelegate(ByRef dest As ComboBox, ByVal item As Object)
    Private Delegate Sub AddItemComboDelegate(ByRef source As ComboBox, ByVal item As Object)

    Private Sub Update_Trejectory_UI()
        PictureBox_Trejection.Refresh()
    End Sub

    Private Sub ChangeTextInvoke(ByVal tb As TextBox, ByVal Content As String, ByVal Color As System.Drawing.Color)
        tb.Text = Content
        tb.ForeColor = Color
    End Sub

    Private Sub ChangeLabelInvoke(ByVal tb As Label, ByVal Content As String, ByVal Color As System.Drawing.Color)
        tb.Text = Content
        tb.ForeColor = Color
    End Sub

    Private Sub ChangeStatusLabelInvoke(ByVal tb As ToolStripStatusLabel, ByVal Content As String, ByVal Color As System.Drawing.Color)
        tb.Text = Content
        tb.ForeColor = Color
    End Sub

    Private Sub AddItemComboInvoke(ByRef dest As ComboBox, ByVal item As Object)
        dest.Items.Add(item)
        If dest.SelectedText = "" Then
            dest.SelectedItem = item
        End If
        dest.Refresh()
    End Sub

    Private Sub RemoveItemComboInvoke(ByRef source As ComboBox, ByVal item As Object)
        source.Items.Remove(item)
        source.Refresh()

    End Sub

End Class
