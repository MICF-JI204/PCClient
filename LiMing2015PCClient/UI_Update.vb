Partial Public Class Form_ORRM

    Private Sub ChangeText(ByVal tb As TextBox, ByVal Content As String, ByVal Color As System.Drawing.Color)
        tb.BeginInvoke(New ChangeTextDelegate(AddressOf ChangeTextInvoke), New Object() {tb, Content, Color})
    End Sub

    Private Sub ChangeLabel(ByRef lb As Label, ByVal Content As String, ByVal Color As System.Drawing.Color)
        lb.Invoke(New ChangeLabelDelegate(AddressOf ChangeLabelInvoke), New Object() {lb, Content, Color})
    End Sub

    '============================================上方接口===================================================
    '========================================下方委托等等定义===============================================

    Private Delegate Sub ChangeTextDelegate(ByVal tb As TextBox, ByVal Conetnt As String, ByVal Color As System.Drawing.Color)
    Private Delegate Sub ChangeLabelDelegate(ByVal lb As Label, ByVal Conetnt As String, ByVal Color As System.Drawing.Color)

    Private Sub ChangeTextInvoke(ByVal tb As TextBox, ByVal Content As String, ByVal Color As System.Drawing.Color)
        tb.Text = Content
        tb.ForeColor = Color
    End Sub

    Private Sub ChangeLabelInvoke(ByVal tb As Label, ByVal Content As String, ByVal Color As System.Drawing.Color)
        tb.Text = Content
        tb.ForeColor = Color
    End Sub

End Class
