Partial Public Class Form_ORRM

    Public Sub ChangeUIText(ByVal tb As Control, ByVal Content As String, ByVal Color As System.Drawing.Color)
        Try
            tb.BeginInvoke(New ChangeUITextDelegate(AddressOf ChangeUITextInvoke), New Object() {tb, Content, Color})
        Catch
        End Try
    End Sub

    Public Sub ChangeStatusLabel(ByRef lb As ToolStripStatusLabel, ByVal Content As String, ByVal Color As System.Drawing.Color)
        StatusStrip.BeginInvoke(New ChangeStatusLabelDelegate(AddressOf ChangeStatusLabelInvoke), New Object() {lb, Content, Color})
    End Sub

    Public Sub AddItemCombo(ByRef dest As ComboBox, ByVal item As String)
        dest.BeginInvoke(New AddItemComboDelegate(AddressOf AddItemComboInvoke), New Object() {dest, item})
    End Sub

    Public Sub RemoveItemCombo(ByRef source As ComboBox, ByVal item As Object)
        source.BeginInvoke(New RemoveItemComboDelegate(AddressOf RemoveItemComboInvoke), New Object() {source, item})

    End Sub

    Public Sub Update_ProgressBar(ByVal value As Integer)
        ProgressBar_Unload.BeginInvoke(New Update_ProgressDelegate(AddressOf ProgressBarInvoke), New Object() {value})
    End Sub

    Public Function GetSelectedItemCombo(ByRef source As ComboBox) As String
        Try
            Return source.Invoke(New GetSelectedItemComboDelegate(AddressOf GetSelectedItemComboInvoke), New Object() {source})
        Catch
            Return ""
        End Try
    End Function

    Public Sub Update_Trejectory()
        PictureBox_Trejection.BeginInvoke(New Update_PictureBoxDelegate(AddressOf Update_Trejectory_UI))
    End Sub

    Public Sub Update_Crane()
        PictureBox_Crane.BeginInvoke(New Update_PictureBoxDelegate(AddressOf Update_Crane_Graph_UI))
    End Sub

    Public Sub Enable_Control(ByRef button As Control, ByVal IsEnabled As Boolean)
        button.BeginInvoke(New EnableControlDelegate(AddressOf EnableControlInvoke), New Object() {button, IsEnabled})
    End Sub

    Public Sub Log(ByVal info As String)
        Dim t As Long = My.Computer.Clock.TickCount() - Global_Var.StartUpTime
        Dim prefix As String = "[" & Math.Round(t / 1000, 5) & "s]:"
        If TextBox_Console_Log.InvokeRequired Then
            TextBox_Console_Log.BeginInvoke(New LogDelegate(AddressOf LogInvoke), New Object() {prefix & info & vbCrLf})
        Else
            TextBox_Console_Log.AppendText(prefix & info & vbCrLf)
        End If
        If StatusStrip.InvokeRequired() Then
            ChangeStatusLabel(ToolStripStatusLabel_LastInfo, info, Color.Black)
        Else
            ToolStripStatusLabel_LastInfo.Text = info
        End If
    End Sub

    '============================================上方接口===================================================
    '========================================下方委托等等定义===============================================

    Private Delegate Sub ChangeUITextDelegate(ByVal tb As Control, ByVal Conetnt As String, ByVal Color As System.Drawing.Color)
    Private Delegate Sub LogDelegate(ByRef Conetnt As String)
    Private Delegate Sub ChangeStatusLabelDelegate(ByVal lb As ToolStripStatusLabel, ByVal Conetnt As String, ByVal Color As System.Drawing.Color)
    Private Delegate Sub Update_PictureBoxDelegate()
    Private Delegate Sub RemoveItemComboDelegate(ByRef dest As ComboBox, ByVal item As Object)
    Private Delegate Function GetSelectedItemComboDelegate(ByRef source As ComboBox) As String
    Private Delegate Sub AddItemComboDelegate(ByRef source As ComboBox, ByVal item As String)
    Private Delegate Sub EnableControlDelegate(ByRef dest As Control, ByVal IsEnabled As Boolean)
    Private Delegate Sub Update_ProgressDelegate(ByVal value As Integer)

    Private Sub Update_Trejectory_UI()
        PictureBox_Trejection.Refresh()
    End Sub

    Private Sub Update_Crane_Graph_UI()
        PictureBox_Crane.Refresh()
    End Sub

    Private Sub ChangeUITextInvoke(ByVal tb As Control, ByVal Content As String, ByVal Color As System.Drawing.Color)
        tb.Text = Content
        tb.ForeColor = Color
    End Sub

    Private Sub ChangeStatusLabelInvoke(ByVal tb As ToolStripStatusLabel, ByVal Content As String, ByVal Color As System.Drawing.Color)
        Content = Content.Replace(vbCrLf, "\n")
        tb.Text = Content
        tb.ForeColor = Color
    End Sub

    Private Sub AddItemComboInvoke(ByRef dest As ComboBox, ByVal item As String)
        If Not dest.Items.Contains(item) Then
            dest.Items.Add(item)
            If dest.SelectedText = "" Then
                dest.SelectedItem = item
            End If
            dest.Refresh()
        End If
    End Sub

    Private Sub RemoveItemComboInvoke(ByRef source As ComboBox, ByVal item As Object)
        source.Items.Remove(item)
        source.Refresh()
        'source.Items.Clear()
    End Sub

    Private Sub EnableControlInvoke(ByRef button As Control, ByVal IsEnabled As Boolean)
        button.Enabled = IsEnabled
    End Sub

    Private Function GetSelectedItemComboInvoke(ByRef source As ComboBox)
        Return source.SelectedItem.ToString
    End Function

    Private Sub LogInvoke(ByRef str As String)
        TextBox_Console_Log.AppendText(str)
    End Sub

    Private Sub ProgressBarInvoke(ByVal value As Integer)
        ProgressBar_Unload.Value = value
    End Sub

End Class
