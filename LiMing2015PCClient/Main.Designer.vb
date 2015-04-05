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
        Me.PictureBox_Trejection = New System.Windows.Forms.PictureBox()
        Me.Label_LastLine = New System.Windows.Forms.Label()
        Me.GroupBox_GameStatus = New System.Windows.Forms.GroupBox()
        Me.GroupBox_Connection.SuspendLayout()
        Me.GroupBox_Operation.SuspendLayout()
        CType(Me.PictureBox_Trejection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox_Connection
        '
        Me.GroupBox_Connection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.Label3.Location = New System.Drawing.Point(114, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 21)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "R:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 21)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "L:"
        '
        'RY
        '
        Me.RY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RY.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RY.Location = New System.Drawing.Point(151, 147)
        Me.RY.Name = "RY"
        Me.RY.Size = New System.Drawing.Size(66, 20)
        Me.RY.TabIndex = 9
        Me.RY.Text = "0"
        '
        'RX
        '
        Me.RX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RX.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RX.Location = New System.Drawing.Point(151, 124)
        Me.RX.Name = "RX"
        Me.RX.Size = New System.Drawing.Size(66, 20)
        Me.RX.TabIndex = 8
        Me.RX.Text = "0"
        '
        'LY
        '
        Me.LY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LY.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LY.Location = New System.Drawing.Point(39, 147)
        Me.LY.Name = "LY"
        Me.LY.Size = New System.Drawing.Size(66, 20)
        Me.LY.TabIndex = 7
        Me.LY.Text = "0"
        '
        'LX
        '
        Me.LX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LX.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LX.Location = New System.Drawing.Point(39, 124)
        Me.LX.Name = "LX"
        Me.LX.Size = New System.Drawing.Size(66, 20)
        Me.LX.TabIndex = 6
        Me.LX.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Xbox GamePad"
        '
        'Label_XBox_Connection
        '
        Me.Label_XBox_Connection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_XBox_Connection.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_XBox_Connection.Location = New System.Drawing.Point(6, 101)
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
        'GroupBox_Operation
        '
        Me.GroupBox_Operation.Controls.Add(Me.PictureBox_Trejection)
        Me.GroupBox_Operation.Location = New System.Drawing.Point(245, 14)
        Me.GroupBox_Operation.Name = "GroupBox_Operation"
        Me.GroupBox_Operation.Size = New System.Drawing.Size(288, 387)
        Me.GroupBox_Operation.TabIndex = 1
        Me.GroupBox_Operation.TabStop = False
        Me.GroupBox_Operation.Text = "Motions & Functions"
        '
        'PictureBox_Trejection
        '
        Me.PictureBox_Trejection.Location = New System.Drawing.Point(11, 22)
        Me.PictureBox_Trejection.Name = "PictureBox_Trejection"
        Me.PictureBox_Trejection.Size = New System.Drawing.Size(267, 225)
        Me.PictureBox_Trejection.TabIndex = 0
        Me.PictureBox_Trejection.TabStop = False
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
        Me.GroupBox_GameStatus.Location = New System.Drawing.Point(545, 14)
        Me.GroupBox_GameStatus.Name = "GroupBox_GameStatus"
        Me.GroupBox_GameStatus.Size = New System.Drawing.Size(228, 387)
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox_Connection As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_Operation As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox_Console_Log As System.Windows.Forms.TextBox
    Friend WithEvents Button_ConsoleSend As System.Windows.Forms.Button
    Friend WithEvents TextBox_ConsoleSend As System.Windows.Forms.TextBox
    Friend WithEvents Label_LastLine As System.Windows.Forms.Label
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

End Class
