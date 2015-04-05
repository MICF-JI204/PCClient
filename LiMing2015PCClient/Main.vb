
Public Class Form_ORRM

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Thread_Connection.Start()
        Thread_GamePad.Start()
        PictureBox_Trejection.Refresh()
    End Sub

    Private Sub PictureBox_Trejection_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox_Trejection.Paint
        Dim PenRect As New System.Drawing.Pen(Color.Black, 2.0)
        Dim PenWheel As New System.Drawing.Pen(Color.Purple, 3.0)
        Dim PenDash As New System.Drawing.Pen(Color.DarkGreen, 2)
        PenDash.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Dim RectRobo As New System.Drawing.Rectangle(Global_Var.Graph_Trejection_Graph_CentreX - 0.5 * Global_Var.Graph_RoboWidth, _
                                                     Global_Var.Graph_Trejection_Graph_CentreY - 0.5 * Global_Var.Graph_RoboHeight, _
                                                     Global_Var.Graph_RoboWidth, _
                                                     Global_Var.Graph_RoboHeight)
        Dim RectWheelL As New System.Drawing.Rectangle(Global_Var.Graph_Trejection_Graph_CentreX - 0.5 * Global_Var.Graph_RoboWidth - 0.5 * Global_Var.Graph_Wheel_Width, _
                                                     Global_Var.Graph_Trejection_Graph_CentreY - 0.5 * Global_Var.Graph_Wheel_Height, _
                                                     Global_Var.Graph_Wheel_Width, _
                                                     Global_Var.Graph_Wheel_Height)
        Dim RectWheelR As New System.Drawing.Rectangle(Global_Var.Graph_Trejection_Graph_CentreX + 0.5 * Global_Var.Graph_RoboWidth - 0.5 * Global_Var.Graph_Wheel_Width, _
                                                     Global_Var.Graph_Trejection_Graph_CentreY - 0.5 * Global_Var.Graph_Wheel_Height, _
                                                     Global_Var.Graph_Wheel_Width, _
                                                     Global_Var.Graph_Wheel_Height)
        e.Graphics.DrawRectangle(PenRect, RectRobo)
        e.Graphics.DrawRectangle(PenWheel, RectWheelL)
        e.Graphics.DrawRectangle(PenWheel, RectWheelR)
        e.Graphics.DrawLine(PenDash, New Point(0, Global_Var.Graph_Trejection_Graph_CentreY), _
                            New Point(2 * Global_Var.Graph_Trejection_Graph_CentreX, Global_Var.Graph_Trejection_Graph_CentreY))
    End Sub

End Class
