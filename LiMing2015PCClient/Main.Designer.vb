﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.components = New System.ComponentModel.Container()
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
        Me.ProgressBar_Unload = New System.Windows.Forms.ProgressBar()
        Me.Button_Loader_Unload = New System.Windows.Forms.Button()
        Me.Button_Loader_Down = New System.Windows.Forms.Button()
        Me.Button_Loader_Up = New System.Windows.Forms.Button()
        Me.Button_BK = New System.Windows.Forms.Button()
        Me.Button_RT = New System.Windows.Forms.Button()
        Me.Button_LT = New System.Windows.Forms.Button()
        Me.Button_FD = New System.Windows.Forms.Button()
        Me.Button_RR = New System.Windows.Forms.Button()
        Me.Button_LR = New System.Windows.Forms.Button()
        Me.PictureBox_Trejection = New System.Windows.Forms.PictureBox()
        Me.GroupBox_GameStatus = New System.Windows.Forms.GroupBox()
        Me.Label_Timer_Suspend = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label_Timer_Game = New System.Windows.Forms.Label()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_GamePad_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_Com_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_LastInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PictureBox_Crane = New System.Windows.Forms.PictureBox()
        Me.GroupBox_Crane = New System.Windows.Forms.GroupBox()
        Me.Button_Crane_Back = New System.Windows.Forms.Button()
        Me.Button_Crane_Forward = New System.Windows.Forms.Button()
        Me.Button_Crane_Holder = New System.Windows.Forms.Button()
        Me.Button_Crane_Down = New System.Windows.Forms.Button()
        Me.Button_Crane_UP = New System.Windows.Forms.Button()
        Me.Timer_Game = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Suspend = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox_Connection.SuspendLayout()
        Me.GroupBox_Operation.SuspendLayout()
        CType(Me.PictureBox_Trejection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_GameStatus.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.PictureBox_Crane, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_Crane.SuspendLayout()
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
        Me.GroupBox_Connection.Location = New System.Drawing.Point(15, 18)
        Me.GroupBox_Connection.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_Connection.Name = "GroupBox_Connection"
        Me.GroupBox_Connection.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_Connection.Size = New System.Drawing.Size(297, 492)
        Me.GroupBox_Connection.TabIndex = 0
        Me.GroupBox_Connection.TabStop = False
        Me.GroupBox_Connection.Text = "Connection Status"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(157, 96)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 26)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Text Mode"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button_Com_Close
        '
        Me.Button_Com_Close.Location = New System.Drawing.Point(15, 96)
        Me.Button_Com_Close.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Com_Close.Name = "Button_Com_Close"
        Me.Button_Com_Close.Size = New System.Drawing.Size(96, 26)
        Me.Button_Com_Close.TabIndex = 13
        Me.Button_Com_Close.Text = "Close"
        Me.Button_Com_Close.UseVisualStyleBackColor = True
        '
        'Button_Connect
        '
        Me.Button_Connect.Location = New System.Drawing.Point(227, 64)
        Me.Button_Connect.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Connect.Name = "Button_Connect"
        Me.Button_Connect.Size = New System.Drawing.Size(63, 25)
        Me.Button_Connect.TabIndex = 12
        Me.Button_Connect.Text = "COM"
        Me.Button_Connect.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(152, 188)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 27)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "R:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 188)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 27)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "L:"
        '
        'RY
        '
        Me.RY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RY.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RY.Location = New System.Drawing.Point(201, 205)
        Me.RY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.RY.Name = "RY"
        Me.RY.Size = New System.Drawing.Size(88, 25)
        Me.RY.TabIndex = 9
        Me.RY.Text = "0"
        '
        'RX
        '
        Me.RX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RX.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RX.Location = New System.Drawing.Point(201, 176)
        Me.RX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.RX.Name = "RX"
        Me.RX.Size = New System.Drawing.Size(88, 25)
        Me.RX.TabIndex = 8
        Me.RX.Text = "0"
        '
        'LY
        '
        Me.LY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LY.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LY.Location = New System.Drawing.Point(52, 205)
        Me.LY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LY.Name = "LY"
        Me.LY.Size = New System.Drawing.Size(88, 25)
        Me.LY.TabIndex = 7
        Me.LY.Text = "0"
        '
        'LX
        '
        Me.LX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LX.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LX.Location = New System.Drawing.Point(52, 176)
        Me.LX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LX.Name = "LX"
        Me.LX.Size = New System.Drawing.Size(88, 25)
        Me.LX.TabIndex = 6
        Me.LX.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 126)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Xbox GamePad"
        '
        'Label_XBox_Connection
        '
        Me.Label_XBox_Connection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_XBox_Connection.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_XBox_Connection.Location = New System.Drawing.Point(8, 148)
        Me.Label_XBox_Connection.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_XBox_Connection.Name = "Label_XBox_Connection"
        Me.Label_XBox_Connection.Size = New System.Drawing.Size(281, 25)
        Me.Label_XBox_Connection.TabIndex = 4
        Me.Label_XBox_Connection.Text = "Label1"
        '
        'Label_Connection_Status
        '
        Me.Label_Connection_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_Connection_Status.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_Connection_Status.Location = New System.Drawing.Point(8, 28)
        Me.Label_Connection_Status.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Connection_Status.Name = "Label_Connection_Status"
        Me.Label_Connection_Status.Size = New System.Drawing.Size(281, 25)
        Me.Label_Connection_Status.TabIndex = 3
        Me.Label_Connection_Status.Text = "Label1"
        '
        'ComboPort
        '
        Me.ComboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboPort.FormattingEnabled = True
        Me.ComboPort.IntegralHeight = False
        Me.ComboPort.Location = New System.Drawing.Point(8, 64)
        Me.ComboPort.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboPort.Name = "ComboPort"
        Me.ComboPort.Size = New System.Drawing.Size(209, 23)
        Me.ComboPort.TabIndex = 1
        '
        'Button_ConsoleSend
        '
        Me.Button_ConsoleSend.Location = New System.Drawing.Point(252, 458)
        Me.Button_ConsoleSend.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_ConsoleSend.Name = "Button_ConsoleSend"
        Me.Button_ConsoleSend.Size = New System.Drawing.Size(37, 28)
        Me.Button_ConsoleSend.TabIndex = 2
        Me.Button_ConsoleSend.Text = "TX"
        Me.Button_ConsoleSend.UseVisualStyleBackColor = True
        '
        'TextBox_ConsoleSend
        '
        Me.TextBox_ConsoleSend.AcceptsTab = True
        Me.TextBox_ConsoleSend.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBox_ConsoleSend.Location = New System.Drawing.Point(8, 459)
        Me.TextBox_ConsoleSend.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_ConsoleSend.Name = "TextBox_ConsoleSend"
        Me.TextBox_ConsoleSend.Size = New System.Drawing.Size(240, 25)
        Me.TextBox_ConsoleSend.TabIndex = 1
        '
        'TextBox_Console_Log
        '
        Me.TextBox_Console_Log.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox_Console_Log.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TextBox_Console_Log.Location = New System.Drawing.Point(8, 239)
        Me.TextBox_Console_Log.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Console_Log.MaxLength = 2147483647
        Me.TextBox_Console_Log.Multiline = True
        Me.TextBox_Console_Log.Name = "TextBox_Console_Log"
        Me.TextBox_Console_Log.ReadOnly = True
        Me.TextBox_Console_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox_Console_Log.Size = New System.Drawing.Size(280, 212)
        Me.TextBox_Console_Log.TabIndex = 0
        '
        'GroupBox_Operation
        '
        Me.GroupBox_Operation.Controls.Add(Me.ProgressBar_Unload)
        Me.GroupBox_Operation.Controls.Add(Me.Button_Loader_Unload)
        Me.GroupBox_Operation.Controls.Add(Me.Button_Loader_Down)
        Me.GroupBox_Operation.Controls.Add(Me.Button_Loader_Up)
        Me.GroupBox_Operation.Controls.Add(Me.Button_BK)
        Me.GroupBox_Operation.Controls.Add(Me.Button_RT)
        Me.GroupBox_Operation.Controls.Add(Me.Button_LT)
        Me.GroupBox_Operation.Controls.Add(Me.Button_FD)
        Me.GroupBox_Operation.Controls.Add(Me.Button_RR)
        Me.GroupBox_Operation.Controls.Add(Me.Button_LR)
        Me.GroupBox_Operation.Controls.Add(Me.PictureBox_Trejection)
        Me.GroupBox_Operation.Location = New System.Drawing.Point(327, 18)
        Me.GroupBox_Operation.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_Operation.Name = "GroupBox_Operation"
        Me.GroupBox_Operation.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_Operation.Size = New System.Drawing.Size(384, 484)
        Me.GroupBox_Operation.TabIndex = 1
        Me.GroupBox_Operation.TabStop = False
        Me.GroupBox_Operation.Text = "Motions && Loader"
        '
        'ProgressBar_Unload
        '
        Me.ProgressBar_Unload.Location = New System.Drawing.Point(149, 446)
        Me.ProgressBar_Unload.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBar_Unload.Name = "ProgressBar_Unload"
        Me.ProgressBar_Unload.Size = New System.Drawing.Size(221, 29)
        Me.ProgressBar_Unload.TabIndex = 10
        '
        'Button_Loader_Unload
        '
        Me.Button_Loader_Unload.BackColor = System.Drawing.SystemColors.Control
        Me.Button_Loader_Unload.Enabled = False
        Me.Button_Loader_Unload.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button_Loader_Unload.Location = New System.Drawing.Point(197, 405)
        Me.Button_Loader_Unload.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Loader_Unload.Name = "Button_Loader_Unload"
        Me.Button_Loader_Unload.Size = New System.Drawing.Size(145, 35)
        Me.Button_Loader_Unload.TabIndex = 9
        Me.Button_Loader_Unload.Text = "Reset"
        Me.Button_Loader_Unload.UseVisualStyleBackColor = True
        '
        'Button_Loader_Down
        '
        Me.Button_Loader_Down.BackColor = System.Drawing.Color.Gainsboro
        Me.Button_Loader_Down.Location = New System.Drawing.Point(149, 361)
        Me.Button_Loader_Down.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Loader_Down.Name = "Button_Loader_Down"
        Me.Button_Loader_Down.Size = New System.Drawing.Size(108, 35)
        Me.Button_Loader_Down.TabIndex = 8
        Me.Button_Loader_Down.Text = "Loader Down"
        Me.Button_Loader_Down.UseVisualStyleBackColor = False
        '
        'Button_Loader_Up
        '
        Me.Button_Loader_Up.BackColor = System.Drawing.Color.Gainsboro
        Me.Button_Loader_Up.Location = New System.Drawing.Point(265, 361)
        Me.Button_Loader_Up.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Loader_Up.Name = "Button_Loader_Up"
        Me.Button_Loader_Up.Size = New System.Drawing.Size(111, 35)
        Me.Button_Loader_Up.TabIndex = 7
        Me.Button_Loader_Up.Text = "Loader Up"
        Me.Button_Loader_Up.UseVisualStyleBackColor = False
        '
        'Button_BK
        '
        Me.Button_BK.Location = New System.Drawing.Point(48, 441)
        Me.Button_BK.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_BK.Name = "Button_BK"
        Me.Button_BK.Size = New System.Drawing.Size(75, 32)
        Me.Button_BK.TabIndex = 6
        Me.Button_BK.Text = "Back"
        Me.Button_BK.UseVisualStyleBackColor = True
        '
        'Button_RT
        '
        Me.Button_RT.Location = New System.Drawing.Point(97, 401)
        Me.Button_RT.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_RT.Name = "Button_RT"
        Me.Button_RT.Size = New System.Drawing.Size(75, 32)
        Me.Button_RT.TabIndex = 5
        Me.Button_RT.Text = "Right"
        Me.Button_RT.UseVisualStyleBackColor = True
        '
        'Button_LT
        '
        Me.Button_LT.Location = New System.Drawing.Point(15, 401)
        Me.Button_LT.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_LT.Name = "Button_LT"
        Me.Button_LT.Size = New System.Drawing.Size(75, 32)
        Me.Button_LT.TabIndex = 4
        Me.Button_LT.Text = "Left"
        Me.Button_LT.UseVisualStyleBackColor = True
        '
        'Button_FD
        '
        Me.Button_FD.Location = New System.Drawing.Point(48, 361)
        Me.Button_FD.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_FD.Name = "Button_FD"
        Me.Button_FD.Size = New System.Drawing.Size(75, 32)
        Me.Button_FD.TabIndex = 3
        Me.Button_FD.Text = "Foward"
        Me.Button_FD.UseVisualStyleBackColor = True
        '
        'Button_RR
        '
        Me.Button_RR.Location = New System.Drawing.Point(197, 316)
        Me.Button_RR.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_RR.Name = "Button_RR"
        Me.Button_RR.Size = New System.Drawing.Size(173, 38)
        Me.Button_RR.TabIndex = 2
        Me.Button_RR.Text = "Right-Rotate"
        Me.Button_RR.UseVisualStyleBackColor = True
        '
        'Button_LR
        '
        Me.Button_LR.Location = New System.Drawing.Point(15, 316)
        Me.Button_LR.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_LR.Name = "Button_LR"
        Me.Button_LR.Size = New System.Drawing.Size(173, 38)
        Me.Button_LR.TabIndex = 1
        Me.Button_LR.Text = "LEFT Rotate"
        Me.Button_LR.UseVisualStyleBackColor = True
        '
        'PictureBox_Trejection
        '
        Me.PictureBox_Trejection.Location = New System.Drawing.Point(15, 28)
        Me.PictureBox_Trejection.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox_Trejection.Name = "PictureBox_Trejection"
        Me.PictureBox_Trejection.Size = New System.Drawing.Size(356, 281)
        Me.PictureBox_Trejection.TabIndex = 0
        Me.PictureBox_Trejection.TabStop = False
        '
        'GroupBox_GameStatus
        '
        Me.GroupBox_GameStatus.Controls.Add(Me.Label_Timer_Suspend)
        Me.GroupBox_GameStatus.Controls.Add(Me.Button4)
        Me.GroupBox_GameStatus.Controls.Add(Me.Button3)
        Me.GroupBox_GameStatus.Controls.Add(Me.Button2)
        Me.GroupBox_GameStatus.Controls.Add(Me.Label_Timer_Game)
        Me.GroupBox_GameStatus.Location = New System.Drawing.Point(731, 379)
        Me.GroupBox_GameStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_GameStatus.Name = "GroupBox_GameStatus"
        Me.GroupBox_GameStatus.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_GameStatus.Size = New System.Drawing.Size(304, 131)
        Me.GroupBox_GameStatus.TabIndex = 4
        Me.GroupBox_GameStatus.TabStop = False
        Me.GroupBox_GameStatus.Text = "Game Status"
        '
        'Label_Timer_Suspend
        '
        Me.Label_Timer_Suspend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_Timer_Suspend.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_Timer_Suspend.ForeColor = System.Drawing.Color.Red
        Me.Label_Timer_Suspend.Location = New System.Drawing.Point(85, 86)
        Me.Label_Timer_Suspend.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Timer_Suspend.Name = "Label_Timer_Suspend"
        Me.Label_Timer_Suspend.Size = New System.Drawing.Size(49, 32)
        Me.Label_Timer_Suspend.TabIndex = 10
        Me.Label_Timer_Suspend.Text = "60"
        Me.Label_Timer_Suspend.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(184, 90)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(100, 29)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Reset"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(184, 56)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 29)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Suspend"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(184, 21)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 29)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Start"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label_Timer_Game
        '
        Me.Label_Timer_Game.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_Timer_Game.Font = New System.Drawing.Font("宋体", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label_Timer_Game.Location = New System.Drawing.Point(59, 25)
        Me.Label_Timer_Game.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Timer_Game.Name = "Label_Timer_Game"
        Me.Label_Timer_Game.Size = New System.Drawing.Size(95, 46)
        Me.Label_Timer_Game.TabIndex = 6
        Me.Label_Timer_Game.Text = "180"
        '
        'StatusStrip
        '
        Me.StatusStrip.AllowMerge = False
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel_GamePad_Status, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel_Com_status, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel_LastInfo})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 531)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1051, 24)
        Me.StatusStrip.SizingGrip = False
        Me.StatusStrip.TabIndex = 5
        Me.StatusStrip.Text = "System_Status"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 19)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(92, 19)
        Me.ToolStripStatusLabel2.Text = "Xbox链接："
        '
        'ToolStripStatusLabel_GamePad_Status
        '
        Me.ToolStripStatusLabel_GamePad_Status.Name = "ToolStripStatusLabel_GamePad_Status"
        Me.ToolStripStatusLabel_GamePad_Status.Size = New System.Drawing.Size(81, 19)
        Me.ToolStripStatusLabel_GamePad_Status.Text = "UNKOWN"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(84, 19)
        Me.ToolStripStatusLabel4.Text = "网络链接："
        '
        'ToolStripStatusLabel_Com_status
        '
        Me.ToolStripStatusLabel_Com_status.Name = "ToolStripStatusLabel_Com_status"
        Me.ToolStripStatusLabel_Com_status.Size = New System.Drawing.Size(93, 19)
        Me.ToolStripStatusLabel_Com_status.Text = "UNKNOWN"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(84, 19)
        Me.ToolStripStatusLabel5.Text = "最后信息："
        '
        'ToolStripStatusLabel_LastInfo
        '
        Me.ToolStripStatusLabel_LastInfo.Name = "ToolStripStatusLabel_LastInfo"
        Me.ToolStripStatusLabel_LastInfo.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.ToolStripStatusLabel_LastInfo.Size = New System.Drawing.Size(151, 19)
        Me.ToolStripStatusLabel_LastInfo.Text = "System_Starting UP"
        '
        'PictureBox_Crane
        '
        Me.PictureBox_Crane.Location = New System.Drawing.Point(8, 25)
        Me.PictureBox_Crane.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox_Crane.Name = "PictureBox_Crane"
        Me.PictureBox_Crane.Size = New System.Drawing.Size(288, 184)
        Me.PictureBox_Crane.TabIndex = 7
        Me.PictureBox_Crane.TabStop = False
        '
        'GroupBox_Crane
        '
        Me.GroupBox_Crane.Controls.Add(Me.Button_Crane_Back)
        Me.GroupBox_Crane.Controls.Add(Me.Button_Crane_Forward)
        Me.GroupBox_Crane.Controls.Add(Me.Button_Crane_Holder)
        Me.GroupBox_Crane.Controls.Add(Me.Button_Crane_Down)
        Me.GroupBox_Crane.Controls.Add(Me.Button_Crane_UP)
        Me.GroupBox_Crane.Controls.Add(Me.PictureBox_Crane)
        Me.GroupBox_Crane.Location = New System.Drawing.Point(731, 22)
        Me.GroupBox_Crane.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox_Crane.Name = "GroupBox_Crane"
        Me.GroupBox_Crane.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox_Crane.Size = New System.Drawing.Size(304, 349)
        Me.GroupBox_Crane.TabIndex = 5
        Me.GroupBox_Crane.TabStop = False
        Me.GroupBox_Crane.Text = "Crane"
        '
        'Button_Crane_Back
        '
        Me.Button_Crane_Back.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button_Crane_Back.Location = New System.Drawing.Point(157, 301)
        Me.Button_Crane_Back.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Crane_Back.Name = "Button_Crane_Back"
        Me.Button_Crane_Back.Size = New System.Drawing.Size(127, 35)
        Me.Button_Crane_Back.TabIndex = 12
        Me.Button_Crane_Back.Text = "Crane Back"
        Me.Button_Crane_Back.UseVisualStyleBackColor = False
        '
        'Button_Crane_Forward
        '
        Me.Button_Crane_Forward.BackColor = System.Drawing.Color.Gainsboro
        Me.Button_Crane_Forward.Location = New System.Drawing.Point(8, 301)
        Me.Button_Crane_Forward.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Crane_Forward.Name = "Button_Crane_Forward"
        Me.Button_Crane_Forward.Size = New System.Drawing.Size(127, 35)
        Me.Button_Crane_Forward.TabIndex = 11
        Me.Button_Crane_Forward.Text = "Crane Foward"
        Me.Button_Crane_Forward.UseVisualStyleBackColor = False
        '
        'Button_Crane_Holder
        '
        Me.Button_Crane_Holder.BackColor = System.Drawing.Color.PaleGreen
        Me.Button_Crane_Holder.Location = New System.Drawing.Point(157, 234)
        Me.Button_Crane_Holder.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Crane_Holder.Name = "Button_Crane_Holder"
        Me.Button_Crane_Holder.Size = New System.Drawing.Size(127, 45)
        Me.Button_Crane_Holder.TabIndex = 10
        Me.Button_Crane_Holder.Text = "Object Released"
        Me.Button_Crane_Holder.UseVisualStyleBackColor = False
        '
        'Button_Crane_Down
        '
        Me.Button_Crane_Down.BackColor = System.Drawing.Color.Gainsboro
        Me.Button_Crane_Down.Location = New System.Drawing.Point(8, 259)
        Me.Button_Crane_Down.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Crane_Down.Name = "Button_Crane_Down"
        Me.Button_Crane_Down.Size = New System.Drawing.Size(127, 35)
        Me.Button_Crane_Down.TabIndex = 9
        Me.Button_Crane_Down.Text = "Crane Down"
        Me.Button_Crane_Down.UseVisualStyleBackColor = False
        '
        'Button_Crane_UP
        '
        Me.Button_Crane_UP.BackColor = System.Drawing.Color.Gainsboro
        Me.Button_Crane_UP.Location = New System.Drawing.Point(8, 216)
        Me.Button_Crane_UP.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Crane_UP.Name = "Button_Crane_UP"
        Me.Button_Crane_UP.Size = New System.Drawing.Size(127, 35)
        Me.Button_Crane_UP.TabIndex = 8
        Me.Button_Crane_UP.Text = "Crane Up"
        Me.Button_Crane_UP.UseVisualStyleBackColor = False
        '
        'Timer_Game
        '
        Me.Timer_Game.Interval = 1000
        '
        'Timer_Suspend
        '
        Me.Timer_Suspend.Interval = 1000
        '
        'Form_ORRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 555)
        Me.Controls.Add(Me.GroupBox_Crane)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.GroupBox_GameStatus)
        Me.Controls.Add(Me.GroupBox_Operation)
        Me.Controls.Add(Me.GroupBox_Connection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_ORRM"
        Me.Text = "黎明杯 Joint Institute 204 Open Robot Remote Mainframe (ORRM)"
        Me.GroupBox_Connection.ResumeLayout(False)
        Me.GroupBox_Connection.PerformLayout()
        Me.GroupBox_Operation.ResumeLayout(False)
        CType(Me.PictureBox_Trejection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_GameStatus.ResumeLayout(False)
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.PictureBox_Crane, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_Crane.ResumeLayout(False)
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
    Friend WithEvents PictureBox_Crane As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox_Crane As System.Windows.Forms.GroupBox
    Friend WithEvents Button_Loader_Unload As System.Windows.Forms.Button
    Friend WithEvents Button_Loader_Down As System.Windows.Forms.Button
    Friend WithEvents Button_Loader_Up As System.Windows.Forms.Button
    Friend WithEvents Button_Crane_Holder As System.Windows.Forms.Button
    Friend WithEvents Button_Crane_Down As System.Windows.Forms.Button
    Friend WithEvents Button_Crane_UP As System.Windows.Forms.Button
    Friend WithEvents ProgressBar_Unload As System.Windows.Forms.ProgressBar
    Friend WithEvents Button_Crane_Back As System.Windows.Forms.Button
    Friend WithEvents Button_Crane_Forward As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label_Timer_Game As System.Windows.Forms.Label
    Friend WithEvents Timer_Game As System.Windows.Forms.Timer
    Friend WithEvents Label_Timer_Suspend As System.Windows.Forms.Label
    Friend WithEvents Timer_Suspend As System.Windows.Forms.Timer

End Class
