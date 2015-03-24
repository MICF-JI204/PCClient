<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextBox_Connection_log
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox_Connection = New System.Windows.Forms.GroupBox()
        Me.GroupBox_Motion = New System.Windows.Forms.GroupBox()
        Me.GroupBox_Functions = New System.Windows.Forms.GroupBox()
        Me.TextBox_ConsoleLog = New System.Windows.Forms.TextBox()
        Me.TextBox_ConsoleSend = New System.Windows.Forms.TextBox()
        Me.Button_ConsoleSend = New System.Windows.Forms.Button()
        Me.Label_LastLine = New System.Windows.Forms.Label()
        Me.GroupBox_Connection.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_Connection
        '
        Me.GroupBox_Connection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_Connection.Controls.Add(Me.Button_ConsoleSend)
        Me.GroupBox_Connection.Controls.Add(Me.TextBox_ConsoleSend)
        Me.GroupBox_Connection.Controls.Add(Me.TextBox_ConsoleLog)
        Me.GroupBox_Connection.Location = New System.Drawing.Point(11, 14)
        Me.GroupBox_Connection.Name = "GroupBox_Connection"
        Me.GroupBox_Connection.Size = New System.Drawing.Size(223, 394)
        Me.GroupBox_Connection.TabIndex = 0
        Me.GroupBox_Connection.TabStop = False
        Me.GroupBox_Connection.Text = "Connection Status"
        '
        'GroupBox_Motion
        '
        Me.GroupBox_Motion.Location = New System.Drawing.Point(251, 14)
        Me.GroupBox_Motion.Name = "GroupBox_Motion"
        Me.GroupBox_Motion.Size = New System.Drawing.Size(297, 394)
        Me.GroupBox_Motion.TabIndex = 1
        Me.GroupBox_Motion.TabStop = False
        Me.GroupBox_Motion.Text = "Motions"
        '
        'GroupBox_Functions
        '
        Me.GroupBox_Functions.Location = New System.Drawing.Point(562, 196)
        Me.GroupBox_Functions.Name = "GroupBox_Functions"
        Me.GroupBox_Functions.Size = New System.Drawing.Size(211, 212)
        Me.GroupBox_Functions.TabIndex = 2
        Me.GroupBox_Functions.TabStop = False
        Me.GroupBox_Functions.Text = "Functions"
        '
        'TextBox_ConsoleLog
        '
        Me.TextBox_ConsoleLog.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox_ConsoleLog.Location = New System.Drawing.Point(6, 191)
        Me.TextBox_ConsoleLog.Multiline = True
        Me.TextBox_ConsoleLog.Name = "TextBox_ConsoleLog"
        Me.TextBox_ConsoleLog.ReadOnly = True
        Me.TextBox_ConsoleLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox_ConsoleLog.Size = New System.Drawing.Size(211, 170)
        Me.TextBox_ConsoleLog.TabIndex = 0
        '
        'TextBox_ConsoleSend
        '
        Me.TextBox_ConsoleSend.AcceptsTab = True
        Me.TextBox_ConsoleSend.Location = New System.Drawing.Point(6, 367)
        Me.TextBox_ConsoleSend.Name = "TextBox_ConsoleSend"
        Me.TextBox_ConsoleSend.Size = New System.Drawing.Size(181, 21)
        Me.TextBox_ConsoleSend.TabIndex = 1
        '
        'Button_ConsoleSend
        '
        Me.Button_ConsoleSend.Location = New System.Drawing.Point(189, 366)
        Me.Button_ConsoleSend.Name = "Button_ConsoleSend"
        Me.Button_ConsoleSend.Size = New System.Drawing.Size(28, 22)
        Me.Button_ConsoleSend.TabIndex = 2
        Me.Button_ConsoleSend.Text = "TX"
        Me.Button_ConsoleSend.UseVisualStyleBackColor = True
        '
        'Label_LastLine
        '
        Me.Label_LastLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_LastLine.Location = New System.Drawing.Point(13, 416)
        Me.Label_LastLine.Name = "Label_LastLine"
        Me.Label_LastLine.Size = New System.Drawing.Size(761, 19)
        Me.Label_LastLine.TabIndex = 3
        Me.Label_LastLine.Text = "System Status: Not Started"
        '
        'TextBox_Connection_log
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 444)
        Me.Controls.Add(Me.Label_LastLine)
        Me.Controls.Add(Me.GroupBox_Functions)
        Me.Controls.Add(Me.GroupBox_Motion)
        Me.Controls.Add(Me.GroupBox_Connection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TextBox_Connection_log"
        Me.Text = "黎明杯 Joint Institute 204 Open Robot Remote Mainframe (ORRM)"
        Me.GroupBox_Connection.ResumeLayout(False)
        Me.GroupBox_Connection.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox_Connection As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_Motion As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_Functions As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox_ConsoleLog As System.Windows.Forms.TextBox
    Friend WithEvents Button_ConsoleSend As System.Windows.Forms.Button
    Friend WithEvents TextBox_ConsoleSend As System.Windows.Forms.TextBox
    Friend WithEvents Label_LastLine As System.Windows.Forms.Label

End Class
