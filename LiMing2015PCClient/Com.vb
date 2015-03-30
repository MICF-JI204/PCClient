Partial Public Class Form_ORRM
    Private Thread_Connection As New Threading.Thread(AddressOf Com_Connection)

    Private Sub Com_Connection()
        While Not Me.IsHandleCreated
        End While
        ChangeLabel(Label_Connection_Status, "Serching For Ports...", Drawing.Color.Green)

    End Sub
End Class
