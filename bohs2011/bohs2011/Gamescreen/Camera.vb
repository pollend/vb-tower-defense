Public Class Camera

    Public Sub UpdatePosition()

        If (Form1.MousePosition.X >= Form1.Width - 1) Then
            Form1.CameraLocation.X -= 5
        ElseIf (Form1.MousePosition.Y >= Form1.Height - 1) Then
            Form1.CameraLocation.Y -= 5
        End If

        If (Form1.MousePosition.X <= Form1.Location.X) Then
            Form1.CameraLocation.X += 5
        ElseIf (Form1.MousePosition.Y <= Form1.Location.Y) Then
            Form1.CameraLocation.Y += 5
        End If

    End Sub
    Public Shared Function GetXCam() As Integer
        Return Form1.CameraLocation.X
    End Function
    Public Shared Function GetYCam() As Integer
        Return Form1.CameraLocation.Y
    End Function
End Class
