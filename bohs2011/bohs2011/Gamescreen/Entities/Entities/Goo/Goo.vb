Public Class GooAssets
    Public Shared GooBits(4) As Bitmap
    Public Shared Sub SetUp()
        GooBits(0) = New Bitmap("Gamescreen\Entities\Entities\Goo\Goo1.png")
        GooBits(1) = New Bitmap("Gamescreen\Entities\Entities\Goo\Goo2.png")
        GooBits(2) = New Bitmap("Gamescreen\Entities\Entities\Goo\Goo3.png")
        GooBits(3) = New Bitmap("Gamescreen\Entities\Entities\Goo\Goo4.png")
        GooBits(4) = New Bitmap("Gamescreen\Entities\Entities\Goo\Goo5.png")

    End Sub
End Class
Public Class Goo
    Inherits Entity


    Private frame As Integer
    Public Sub New(ByVal setlocation As Point)
        MyBase.New(setlocation)

        Size = New Point(50, 50)
    End Sub
    Public Overrides Sub Update(ByVal index As Integer)
        If (frame >= 4) Then
            frame = 0
        End If
        frame += 1
        MyBase.Update(index)
    End Sub
    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' e.Graphics.TranslateTransform(Me.location.X, Me.location.Y)
        ' e.Graphics.RotateTransform(randomRotation)
        e.Graphics.DrawImage(GooAssets.GooBits(frame), location) ' New Point(-25, -25))
        '  e.Graphics.ResetTransform()
        ' Form1.CamTransform(e)

        MyBase.Draw(e)
    End Sub



End Class
