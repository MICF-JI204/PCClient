﻿Partial Public Class Form_ORRM
    Private Sub PictureBox_Trejection_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox_Trejection.Paint
        Dim PenRect As New System.Drawing.Pen(Color.Black, 2.0)
        Dim PenWheel As New System.Drawing.Pen(Color.Purple, 3.0)
        Dim PenDash As New System.Drawing.Pen(Color.DarkGreen, 2)
        Dim PenArcForward As New System.Drawing.Pen(Color.Green, 3)
        Dim PenArcBack As New System.Drawing.Pen(Color.Red, 3)
        PenArcForward.DashStyle = Drawing2D.DashStyle.Dash
        PenArcBack.DashStyle = Drawing2D.DashStyle.Dash
        PenDash.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Dim FontWarning As New Font(Me.Font.FontFamily.Name, 25, FontStyle.Bold)

        '===========================================================================================
        '===================================下方是绘制轨迹预测线的内容==============================
        '===========================================================================================
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
        Dim RectArcL As New Rectangle(Global_Var.Graph_Trejection_Graph_CentreX - 0.5 * Global_Var.Graph_RoboWidth - 2 * Global_Var.Graph_Trejection_Radius, _
                                             Global_Var.Graph_Trejection_Graph_CentreY - Global_Var.Graph_Trejection_Radius, _
                                             2 * Global_Var.Graph_Trejection_Radius, _
                                             2 * Global_Var.Graph_Trejection_Radius)
        Dim RectArcLL As New Rectangle(Global_Var.Graph_Trejection_Graph_CentreX - 1.5 * Global_Var.Graph_RoboWidth - 2 * Global_Var.Graph_Trejection_Radius, _
                     Global_Var.Graph_Trejection_Graph_CentreY - Global_Var.Graph_Trejection_Radius - Global_Var.Graph_RoboWidth, _
                     2 * Global_Var.Graph_Trejection_Radius + 2 * Global_Var.Graph_RoboWidth, _
                     2 * Global_Var.Graph_Trejection_Radius + 2 * Global_Var.Graph_RoboWidth)
        Dim RectArcR As New Rectangle(Global_Var.Graph_Trejection_Graph_CentreX + 0.5 * Global_Var.Graph_RoboWidth, _
                     Global_Var.Graph_Trejection_Graph_CentreY - Global_Var.Graph_Trejection_Radius, _
                     2 * Global_Var.Graph_Trejection_Radius, _
                     2 * Global_Var.Graph_Trejection_Radius)
        Dim RectArcRL As New Rectangle(Global_Var.Graph_Trejection_Graph_CentreX - 0.5 * Global_Var.Graph_RoboWidth, _
                     Global_Var.Graph_Trejection_Graph_CentreY - Global_Var.Graph_Trejection_Radius - Global_Var.Graph_RoboWidth, _
                     2 * Global_Var.Graph_Trejection_Radius + 2 * Global_Var.Graph_RoboWidth, _
                     2 * Global_Var.Graph_Trejection_Radius + 2 * Global_Var.Graph_RoboWidth)
        e.Graphics.DrawRectangle(PenRect, RectRobo)
        e.Graphics.DrawRectangle(PenWheel, RectWheelL)
        e.Graphics.DrawRectangle(PenWheel, RectWheelR)
        e.Graphics.DrawLine(PenDash, New Point(0, Global_Var.Graph_Trejection_Graph_CentreY), _
                            New Point(2 * Global_Var.Graph_Trejection_Graph_CentreX, Global_Var.Graph_Trejection_Graph_CentreY))
        Select Case Global_Var.Graph_Trejection_Direction
            Case Global_Var.Graph_Trejection_Dir.Dir_Null
                e.Graphics.DrawLine(PenArcBack, New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                              - 0.5 * Global_Var.Graph_RoboWidth, _
                                              Global_Var.Graph_Trejection_Graph_CentreY), _
                                           New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                              - 0.5 * Global_Var.Graph_RoboWidth, 0))
                e.Graphics.DrawLine(PenArcBack, New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                          - 0.5 * Global_Var.Graph_RoboWidth, _
                                          Global_Var.Graph_Trejection_Graph_CentreY), _
                                       New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                          - 0.5 * Global_Var.Graph_RoboWidth, _
                                          2 * Global_Var.Graph_Trejection_Graph_CentreY))
                e.Graphics.DrawLine(PenArcBack, New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                              + 0.5 * Global_Var.Graph_RoboWidth, _
                                              Global_Var.Graph_Trejection_Graph_CentreY), _
                                           New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                              + 0.5 * Global_Var.Graph_RoboWidth, 0))
                e.Graphics.DrawLine(PenArcBack, New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                          + 0.5 * Global_Var.Graph_RoboWidth, _
                                          Global_Var.Graph_Trejection_Graph_CentreY), _
                                       New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                          + 0.5 * Global_Var.Graph_RoboWidth, _
                                          2 * Global_Var.Graph_Trejection_Graph_CentreY))
            Case Global_Var.Graph_Trejection_Dir.Forward_Left
                Try
                    e.Graphics.DrawArc(PenArcForward, RectArcL, 0, -180)
                    e.Graphics.DrawArc(PenArcBack, RectArcL, 0, 180)
                    e.Graphics.DrawArc(PenArcForward, RectArcLL, 0, -180)
                    e.Graphics.DrawArc(PenArcBack, RectArcLL, 0, 180)
                Catch
                End Try

            Case Global_Var.Graph_Trejection_Dir.Forward_Right
                Try
                    e.Graphics.DrawArc(PenArcForward, RectArcR, 0, -180)
                    e.Graphics.DrawArc(PenArcBack, RectArcR, 0, 180)
                    e.Graphics.DrawArc(PenArcForward, RectArcRL, 0, -180)
                    e.Graphics.DrawArc(PenArcBack, RectArcRL, 0, 180)
                Catch
                End Try

            Case Global_Var.Graph_Trejection_Dir.BackWard_Left
                Try
                    e.Graphics.DrawArc(PenArcBack, RectArcL, 0, -180)
                    e.Graphics.DrawArc(PenArcForward, RectArcL, 0, 180)
                    e.Graphics.DrawArc(PenArcBack, RectArcLL, 0, -180)
                    e.Graphics.DrawArc(PenArcForward, RectArcLL, 0, 180)
                Catch
                End Try
            Case Global_Var.Graph_Trejection_Dir.BackWard_Right
                Try
                    e.Graphics.DrawArc(PenArcBack, RectArcR, 0, -180)
                    e.Graphics.DrawArc(PenArcForward, RectArcR, 0, 180)
                    e.Graphics.DrawArc(PenArcBack, RectArcRL, 0, -180)
                    e.Graphics.DrawArc(PenArcForward, RectArcRL, 0, 180)
                Catch
                End Try

            Case Global_Var.Graph_Trejection_Dir.Forward
                e.Graphics.DrawLine(PenArcForward, New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                              - 0.5 * Global_Var.Graph_RoboWidth, _
                              Global_Var.Graph_Trejection_Graph_CentreY), _
                           New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                              - 0.5 * Global_Var.Graph_RoboWidth, 0))
                e.Graphics.DrawLine(PenArcBack, New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                          - 0.5 * Global_Var.Graph_RoboWidth, _
                                          Global_Var.Graph_Trejection_Graph_CentreY), _
                                       New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                          - 0.5 * Global_Var.Graph_RoboWidth, _
                                          2 * Global_Var.Graph_Trejection_Graph_CentreY))
                e.Graphics.DrawLine(PenArcForward, New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                              + 0.5 * Global_Var.Graph_RoboWidth, _
                                              Global_Var.Graph_Trejection_Graph_CentreY), _
                                           New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                              + 0.5 * Global_Var.Graph_RoboWidth, 0))
                e.Graphics.DrawLine(PenArcBack, New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                          + 0.5 * Global_Var.Graph_RoboWidth, _
                                          Global_Var.Graph_Trejection_Graph_CentreY), _
                                       New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                          + 0.5 * Global_Var.Graph_RoboWidth, _
                                          2 * Global_Var.Graph_Trejection_Graph_CentreY))

            Case Global_Var.Graph_Trejection_Dir.Backward
                e.Graphics.DrawLine(PenArcBack, New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                              - 0.5 * Global_Var.Graph_RoboWidth, _
                              Global_Var.Graph_Trejection_Graph_CentreY), _
                           New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                              - 0.5 * Global_Var.Graph_RoboWidth, 0))
                e.Graphics.DrawLine(PenArcForward, New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                          - 0.5 * Global_Var.Graph_RoboWidth, _
                                          Global_Var.Graph_Trejection_Graph_CentreY), _
                                       New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                          - 0.5 * Global_Var.Graph_RoboWidth, _
                                          2 * Global_Var.Graph_Trejection_Graph_CentreY))
                e.Graphics.DrawLine(PenArcBack, New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                              + 0.5 * Global_Var.Graph_RoboWidth, _
                                              Global_Var.Graph_Trejection_Graph_CentreY), _
                                           New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                              + 0.5 * Global_Var.Graph_RoboWidth, 0))
                e.Graphics.DrawLine(PenArcForward, New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                          + 0.5 * Global_Var.Graph_RoboWidth, _
                                          Global_Var.Graph_Trejection_Graph_CentreY), _
                                       New Point(Global_Var.Graph_Trejection_Graph_CentreX _
                                          + 0.5 * Global_Var.Graph_RoboWidth, _
                                          2 * Global_Var.Graph_Trejection_Graph_CentreY))
        End Select
        '===========================================================================================
        '===================================上方是绘制轨迹预测线的内容==============================
        '===========================================================================================

        '================================下方绘制原地转向的Overide 内容============================
        If Global_Var.Robot_LTurn_Override Then
            e.Graphics.DrawString("LEFT TURN", FontWarning, Brushes.Red, New PointF(0.4 * Global_Var.Graph_Trejection_Graph_CentreX, Global_Var.Graph_Trejection_Graph_CentreY - 35))
            e.Graphics.DrawString("OVERRIDED", FontWarning, Brushes.Red, New PointF(0.4 * Global_Var.Graph_Trejection_Graph_CentreX, Global_Var.Graph_Trejection_Graph_CentreY + 15))
        End If
        If Global_Var.Robot_Rturn_Override Then
            e.Graphics.DrawString("RIGHT TRN", FontWarning, Brushes.Red, New PointF(0.4 * Global_Var.Graph_Trejection_Graph_CentreX, Global_Var.Graph_Trejection_Graph_CentreY - 35))
            e.Graphics.DrawString("OVERRIDED", FontWarning, Brushes.Red, New PointF(0.4 * Global_Var.Graph_Trejection_Graph_CentreX, Global_Var.Graph_Trejection_Graph_CentreY + 15))
        End If
        '================================上方绘制原地转向的Overide 内容============================

        '================================下方输出Debugging Info =====================================
        Dim FontInfo As New Font(Me.Font.FontFamily.Name, 9, FontStyle.Regular)
        e.Graphics.DrawString("LMotor Output:" & Str(Global_Var.SpeedCoeffientL * Global_Var.Robot_Wheel_MaxSpeed), _
                              FontInfo, Brushes.Black, New PointF(0, 0))
        e.Graphics.DrawString("RMotor Output:" & Str(Global_Var.SpeedcoeffientR * Global_Var.Robot_Wheel_MaxSpeed), _
                      FontInfo, Brushes.Black, New PointF(0, 15))
        Dim t As Integer = My.Computer.Clock.TickCount()
        e.Graphics.DrawString("delay(ms):" & (t - Global_Var.TimeLastFame_Trej), _
              FontInfo, Brushes.Black, New PointF(0, 30))
        Global_Var.TimeLastFame_Trej = t
        'e.Graphics.DrawString("spd(ms):" & (Global_Var.spd), FontInfo, Brushes.Black, New PointF(0, 45))
        'e.Graphics.DrawString("ratio(ms):" & (Global_Var.ratio), FontInfo, Brushes.Black, New PointF(0, 60))
        '=================================/OVER=================================================
    End Sub
End Class
