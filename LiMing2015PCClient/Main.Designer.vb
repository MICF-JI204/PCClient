<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_ORRM
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
        Me.Label_Connection_Status = New System.Windows.Forms.Label()
        Me.ComboPort = New System.Windows.Forms.ComboBox()
        Me.Button_ConsoleSend = New System.Windows.Forms.Button()
        Me.TextBox_ConsoleSend = New System.Windows.Forms.TextBox()
        Me.TextBox_Console_Log = New System.Windows.Forms.TextBox()
        Me.GroupBox_Motion = New System.Windows.Forms.GroupBox()
        Me.GroupBox_Functions = New System.Windows.Forms.GroupBox()
        Me.Label_LastLine = New System.Windows.Forms.Label()
        Me.GroupBox_GameStatus = New System.Windows.Forms.GroupBox()
        Me.GroupBox_Connection.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_Connection
        '
        Me.GroupBox_Connection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_Connection.Controls.Add(Me.Label_Connection_Status)
        Me.GroupBox_Connection.Controls.Add(Me.ComboPort)
        Me.GroupBox_Connection.Controls.Add(Me.Button_ConsoleSend)
        Me.GroupBox_Connection.Controls.Add(Me.TextBox_ConsoleSend)
        Me.GroupBox_Connection.Controls.Add(Me.TextBox_Console_Log)
        Me.GroupBox_Connection.Location = New System.Drawing.Point(11, 14)
        Me.GroupBox_Connection.Name = "GroupBox_Connection"
        Me.GroupBox_Connection.Size = New System.Drawing.Size(223, 394)
        Me.GroupBox_Connection.TabIndex = 0
        Me.GroupBox_Connection.TabStop = False
        Me.GroupBox_Connection.Text = "Connection Status"
        '
        'Label_Connection_Status
        '
        Me.Label_Connection_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_Connection_Status.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_Connection_Status.Location = New System.Drawing.Point(6, 24)
        Me.Label_Connection_Status.Name = "Label_Connection_Status"
        Me.Label_Connection_Status.Size = New System.Drawing.Size(211, 20)
        Me.Label_Connection_Status.TabIndex = 3
        Me.Label_Connection_Status.Text = "Label1"
        '
        'ComboPort
        '
        Me.ComboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboPort.FormattingEnabled = True
        Me.ComboPort.IntegralHeight = False
        Me.ComboPort.Location = New System.Drawing.Point(6, 51)
        Me.ComboPort.Name = "ComboPort"
        Me.ComboPort.Size = New System.Drawing.Size(158, 20)
        Me.ComboPort.TabIndex = 1
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
        'TextBox_ConsoleSend
        '
        Me.TextBox_ConsoleSend.AcceptsTab = True
        Me.TextBox_ConsoleSend.Location = New System.Drawing.Point(6, 367)
        Me.TextBox_ConsoleSend.Name = "TextBox_ConsoleSend"
        Me.TextBox_ConsoleSend.Size = New System.Drawing.Size(181, 21)
        Me.TextBox_ConsoleSend.TabIndex = 1
        '
        'TextBox_Console_Log
        '
        Me.TextBox_Console_Log.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox_Console_Log.Location = New System.Drawing.Point(6, 191)
        Me.TextBox_Console_Log.Multiline = True
        Me.TextBox_Console_Log.Name = "TextBox_Console_Log"
        Me.TextBox_Console_Log.ReadOnly = True
        Me.TextBox_Console_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox_Console_Log.Size = New System.Drawing.Size(211, 170)
        Me.TextBox_Console_Log.TabIndex = 0
        '
        'GroupBox_Motion
        '
        Me.GroupBox_Motion.Location = New System.Drawing.Point(251, 14)
        Me.GroupBox_Motion.Name = "GroupBox_Motion"
        Me.GroupBox_Motion.Size = New System.Drawing.Size(264, 194)
        Me.GroupBox_Motion.TabIndex = 1
        Me.GroupBox_Motion.TabStop = False
        Me.GroupBox_Motion.Text = "Motions"
        '
        'GroupBox_Functions
        '
        Me.GroupBox_Functions.Location = New System.Drawing.Point(251, 222)
        Me.GroupBox_Functions.Name = "GroupBox_Functions"
        Me.GroupBox_Functions.Size = New System.Drawing.Size(264, 180)
        Me.GroupBox_Functions.TabIndex = 2
        Me.GroupBox_Functions.TabStop = False
        Me.GroupBox_Functions.Text = "Functions"
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
        'GroupBox_GameStatus
        '
        Me.GroupBox_GameStatus.Location = New System.Drawing.Point(523, 18)
        Me.GroupBox_GameStatus.Name = "GroupBox_GameStatus"
        Me.GroupBox_GameStatus.Size = New System.Drawing.Size(250, 383)
        Me.GroupBox_GameStatus.TabIndex = 4
        Me.GroupBox_GameStatus.TabStop = False
        Me.GroupBox_GameStatus.Text = "Game Status"
        '
        'Form_ORRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 444)
        Me.Controls.Add(Me.GroupBox_GameStatus)
        Me.Controls.Add(Me.Label_LastLine)
        Me.Controls.Add(Me.GroupBox_Functions)
        Me.Controls.Add(Me.GroupBox_Motion)
        Me.Controls.Add(Me.GroupBox_Connection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_ORRM"
        Me.Text = "黎明杯 Joint Institute 204 Open Robot Remote Mainframe (ORRM)"
        Me.GroupBox_Connection.ResumeLayout(False)
        Me.GroupBox_Connection.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox_Connection As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_Motion As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_Functions As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox_Console_Log As System.Windows.Forms.TextBox
    Friend WithEvents Button_ConsoleSend As System.Windows.Forms.Button
    Friend WithEvents TextBox_ConsoleSend As System.Windows.Forms.TextBox
    Friend WithEvents Label_LastLine As System.Windows.Forms.Label
    Friend WithEvents GroupBox_GameStatus As System.Windows.Forms.GroupBox
    Friend WithEvents ComboPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Connection_Status As System.Windows.Forms.Label

End Class
