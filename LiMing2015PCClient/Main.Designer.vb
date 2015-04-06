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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_ORRM))
        Me.GroupBox_Connection = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button_Com_Close = New System.Windows.Forms.Button()
        Me.Button_Connect = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RY = New System.Windows.Forms.Label()
        Me.RX = New System.Windows.Forms.Label()
        Me.LY = New System.Windows.Forms.Label()
        Me.LX = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label_XBox_Connection = New System.Windows.Forms.Label()
        Me.Label_Connection_Status = New System.Windows.Forms.Label()
        Me.ComboPort = New System.Windows.Forms.ComboBox()
        Me.Button_ConsoleSend = New System.Windows.Forms.Button()
        Me.TextBox_ConsoleSend = New System.Windows.Forms.TextBox()
        Me.TextBox_Console_Log = New System.Windows.Forms.TextBox()
        Me.GroupBox_Operation = New System.Windows.Forms.GroupBox()
        Me.Button_BK = New System.Windows.Forms.Button()
        Me.Button_RT = New System.Windows.Forms.Button()
        Me.Button_LT = New System.Windows.Forms.Button()
        Me.Button_FD = New System.Windows.Forms.Button()
        Me.Button_RR = New System.Windows.Forms.Button()
        Me.Button_LR = New System.Windows.Forms.Button()
        Me.PictureBox_Trejection = New System.Windows.Forms.PictureBox()
        Me.GroupBox_GameStatus = New System.Windows.Forms.GroupBox()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_GamePad_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_Com_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_LastInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox_Connection.SuspendLayout()
        Me.GroupBox_Operation.SuspendLayout()
        CType(Me.PictureBox_Trejection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_Connection
        '
        Me.GroupBox_Connection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_Connection.Controls.Add(Me.Button1)
        Me.GroupBox_Connection.Controls.Add(Me.Button_Com_Close)
        Me.GroupBox_Connection.Controls.Add(Me.Button_Connect)
        Me.GroupBox_Connection.Controls.Add(Me.Label3)
        Me.GroupBox_Connection.Controls.Add(Me.Label1)
        Me.GroupBox_Connection.Controls.Add(Me.RY)
        Me.GroupBox_Connection.Controls.Add(Me.RX)
        Me.GroupBox_Connection.Controls.Add(Me.LY)
        Me.GroupBox_Connection.Controls.Add(Me.LX)
        Me.GroupBox_Connection.Controls.Add(Me.Label2)
        Me.GroupBox_Connection.Controls.Add(Me.Label_XBox_Connection)
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
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(118, 77)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 21)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Text Mode"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button_Com_Close
        '
        Me.Button_Com_Close.Location = New System.Drawing.Point(11, 77)
        Me.Button_Com_Close.Name = "Button_Com_Close"
        Me.Button_Com_Close.Size = New System.Drawing.Size(72, 21)
        Me.Button_Com_Close.TabIndex = 13
        Me.Button_Com_Close.Text = "Close"
        Me.Button_Com_Close.UseVisualStyleBackColor = True
        '
        'Button_Connect
        '
        Me.Button_Connect.Location = New System.Drawing.Point(170, 51)
        Me.Button_Connect.Name = "Button_Connect"
        Me.Button_Connect.Size = New System.Drawing.Size(47, 20)
        Me.Button_Connect.TabIndex = 12
        Me.Button_Connect.Text = "COM"
        Me.Button_Connect.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(114, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 21)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "R:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 21)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "L:"
        '
        'RY
        '
        Me.RY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RY.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RY.Location = New System.Drawing.Point(151, 164)
        Me.RY.Name = "RY"
        Me.RY.Size = New System.Drawing.Size(66, 20)
        Me.RY.TabIndex = 9
        Me.RY.Text = "0"
        '
        'RX
        '
        Me.RX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RX.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RX.Location = New System.Drawing.Point(151, 141)
        Me.RX.Name = "RX"
        Me.RX.Size = New System.Drawing.Size(66, 20)
        Me.RX.TabIndex = 8
        Me.RX.Text = "0"
        '
        'LY
        '
        Me.LY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LY.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LY.Location = New System.Drawing.Point(39, 164)
        Me.LY.Name = "LY"
        Me.LY.Size = New System.Drawing.Size(66, 20)
        Me.LY.TabIndex = 7
        Me.LY.Text = "0"
        '
        'LX
        '
        Me.LX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LX.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LX.Location = New System.Drawing.Point(39, 141)
        Me.LX.Name = "LX"
        Me.LX.Size = New System.Drawing.Size(66, 20)
        Me.LX.TabIndex = 6
        Me.LX.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Xbox GamePad"
        '
        'Label_XBox_Connection
        '
        Me.Label_XBox_Connection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_XBox_Connection.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_XBox_Connection.Location = New System.Drawing.Point(6, 118)
        Me.Label_XBox_Connection.Name = "Label_XBox_Connection"
        Me.Label_XBox_Connection.Size = New System.Drawing.Size(211, 20)
        Me.Label_XBox_Connection.TabIndex = 4
        Me.Label_XBox_Connection.Text = "Label1"
        '
        'Label_Connection_Status
        '
        Me.Label_Connection_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_Connection_Status.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_Connection_Status.Location = New System.Drawing.Point(6, 22)
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
        Me.TextBox_ConsoleSend.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBox_ConsoleSend.Location = New System.Drawing.Point(6, 367)
        Me.TextBox_ConsoleSend.Name = "TextBox_ConsoleSend"
        Me.TextBox_ConsoleSend.Size = New System.Drawing.Size(181, 21)
        Me.TextBox_ConsoleSend.TabIndex = 1
        '
        'TextBox_Console_Log
        '
        Me.TextBox_Console_Log.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox_Console_Log.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TextBox_Console_Log.Location = New System.Drawing.Point(6, 191)
        Me.TextBox_Console_Log.MaxLength = 2147483647
        Me.TextBox_Console_Log.Multiline = True
        Me.TextBox_Console_Log.Name = "TextBox_Console_Log"
        Me.TextBox_Console_Log.ReadOnly = True
        Me.TextBox_Console_Log.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.TextBox_Console_Log.Size = New System.Drawing.Size(211, 170)
        Me.TextBox_Console_Log.TabIndex = 0
        '
        'GroupBox_Operation
        '
        Me.GroupBox_Operation.Controls.Add(Me.Button_BK)
        Me.GroupBox_Operation.Controls.Add(Me.Button_RT)
        Me.GroupBox_Operation.Controls.Add(Me.Button_LT)
        Me.GroupBox_Operation.Controls.Add(Me.Button_FD)
        Me.GroupBox_Operation.Controls.Add(Me.Button_RR)
        Me.GroupBox_Operation.Controls.Add(Me.Button_LR)
        Me.GroupBox_Operation.Controls.Add(Me.PictureBox_Trejection)
        Me.GroupBox_Operation.Location = New System.Drawing.Point(245, 14)
        Me.GroupBox_Operation.Name = "GroupBox_Operation"
        Me.GroupBox_Operation.Size = New System.Drawing.Size(288, 387)
        Me.GroupBox_Operation.TabIndex = 1
        Me.GroupBox_Operation.TabStop = False
        Me.GroupBox_Operation.Text = "Motions && Functions"
        '
        'Button_BK
        '
        Me.Button_BK.Location = New System.Drawing.Point(50, 355)
        Me.Button_BK.Name = "Button_BK"
        Me.Button_BK.Size = New System.Drawing.Size(56, 26)
        Me.Button_BK.TabIndex = 6
        Me.Button_BK.Text = "Back"
        Me.Button_BK.UseVisualStyleBackColor = True
        '
        'Button_RT
        '
        Me.Button_RT.Location = New System.Drawing.Point(85, 321)
        Me.Button_RT.Name = "Button_RT"
        Me.Button_RT.Size = New System.Drawing.Size(56, 26)
        Me.Button_RT.TabIndex = 5
        Me.Button_RT.Text = "Right"
        Me.Button_RT.UseVisualStyleBackColor = True
        '
        'Button_LT
        '
        Me.Button_LT.Location = New System.Drawing.Point(11, 321)
        Me.Button_LT.Name = "Button_LT"
        Me.Button_LT.Size = New System.Drawing.Size(56, 26)
        Me.Button_LT.TabIndex = 4
        Me.Button_LT.Text = "Left"
        Me.Button_LT.UseVisualStyleBackColor = True
        '
        'Button_FD
        '
        Me.Button_FD.Location = New System.Drawing.Point(50, 289)
        Me.Button_FD.Name = "Button_FD"
        Me.Button_FD.Size = New System.Drawing.Size(56, 26)
        Me.Button_FD.TabIndex = 3
        Me.Button_FD.Text = "Foward"
        Me.Button_FD.UseVisualStyleBackColor = True
        '
        'Button_RR
        '
        Me.Button_RR.Location = New System.Drawing.Point(148, 253)
        Me.Button_RR.Name = "Button_RR"
        Me.Button_RR.Size = New System.Drawing.Size(130, 30)
        Me.Button_RR.TabIndex = 2
        Me.Button_RR.Text = "Right-Rotate"
        Me.Button_RR.UseVisualStyleBackColor = True
        '
        'Button_LR
        '
        Me.Button_LR.Location = New System.Drawing.Point(11, 253)
        Me.Button_LR.Name = "Button_LR"
        Me.Button_LR.Size = New System.Drawing.Size(130, 30)
        Me.Button_LR.TabIndex = 1
        Me.Button_LR.Text = "LEFT Rotate"
        Me.Button_LR.UseVisualStyleBackColor = True
        '
        'PictureBox_Trejection
        '
        Me.PictureBox_Trejection.Location = New System.Drawing.Point(11, 22)
        Me.PictureBox_Trejection.Name = "PictureBox_Trejection"
        Me.PictureBox_Trejection.Size = New System.Drawing.Size(267, 225)
        Me.PictureBox_Trejection.TabIndex = 0
        Me.PictureBox_Trejection.TabStop = False
        '
        'GroupBox_GameStatus
        '
        Me.GroupBox_GameStatus.Location = New System.Drawing.Point(545, 14)
        Me.GroupBox_GameStatus.Name = "GroupBox_GameStatus"
        Me.GroupBox_GameStatus.Size = New System.Drawing.Size(228, 387)
        Me.GroupBox_GameStatus.TabIndex = 4
        Me.GroupBox_GameStatus.TabStop = False
        Me.GroupBox_GameStatus.Text = "Game Status"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel_GamePad_Status, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel_Com_status, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel_LastInfo})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 422)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(788, 22)
        Me.StatusStrip.TabIndex = 5
        Me.StatusStrip.Text = "System_Status"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(74, 17)
        Me.ToolStripStatusLabel2.Text = "Xbox链接："
        '
        'ToolStripStatusLabel_GamePad_Status
        '
        Me.ToolStripStatusLabel_GamePad_Status.Name = "ToolStripStatusLabel_GamePad_Status"
        Me.ToolStripStatusLabel_GamePad_Status.Size = New System.Drawing.Size(67, 17)
        Me.ToolStripStatusLabel_GamePad_Status.Text = "UNKOWN"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel4.Text = "网络链接："
        '
        'ToolStripStatusLabel_Com_status
        '
        Me.ToolStripStatusLabel_Com_status.Name = "ToolStripStatusLabel_Com_status"
        Me.ToolStripStatusLabel_Com_status.Size = New System.Drawing.Size(77, 17)
        Me.ToolStripStatusLabel_Com_status.Text = "UNKNOWN"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel5.Text = "最后信息："
        '
        'ToolStripStatusLabel_LastInfo
        '
        Me.ToolStripStatusLabel_LastInfo.Name = "ToolStripStatusLabel_LastInfo"
        Me.ToolStripStatusLabel_LastInfo.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel_LastInfo.Text = "System_Starting UP"
        '
        'Form_ORRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 444)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.GroupBox_GameStatus)
        Me.Controls.Add(Me.GroupBox_Operation)
        Me.Controls.Add(Me.GroupBox_Connection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_ORRM"
        Me.Text = "黎明杯 Joint Institute 204 Open Robot Remote Mainframe (ORRM)"
        Me.GroupBox_Connection.ResumeLayout(False)
        Me.GroupBox_Connection.PerformLayout()
        Me.GroupBox_Operation.ResumeLayout(False)
        CType(Me.PictureBox_Trejection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox_Connection As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_Operation As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox_Console_Log As System.Windows.Forms.TextBox
    Friend WithEvents Button_ConsoleSend As System.Windows.Forms.Button
    Friend WithEvents TextBox_ConsoleSend As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_GameStatus As System.Windows.Forms.GroupBox
    Friend WithEvents ComboPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label_Connection_Status As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label_XBox_Connection As System.Windows.Forms.Label
    Friend WithEvents RY As System.Windows.Forms.Label
    Friend WithEvents RX As System.Windows.Forms.Label
    Friend WithEvents LY As System.Windows.Forms.Label
    Friend WithEvents LX As System.Windows.Forms.Label
    Friend WithEvents Button_Connect As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox_Trejection As System.Windows.Forms.PictureBox
    Friend WithEvents Button_BK As System.Windows.Forms.Button
    Friend WithEvents Button_RT As System.Windows.Forms.Button
    Friend WithEvents Button_LT As System.Windows.Forms.Button
    Friend WithEvents Button_FD As System.Windows.Forms.Button
    Friend WithEvents Button_RR As System.Windows.Forms.Button
    Friend WithEvents Button_LR As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_GamePad_Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_Com_status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_LastInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Button_Com_Close As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
