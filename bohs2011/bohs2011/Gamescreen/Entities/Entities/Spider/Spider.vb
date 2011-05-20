Public Class SpiderAssets
    Public Shared SpiderBits(4) As Bitmap
    Public Shared Sub SetUp()

        SpiderBits(0) = New Bitmap("Gamescreen\Entities\Entities\Spider\spider2.png")
        SpiderBits(1) = New Bitmap("Gamescreen\Entities\Entities\Spider\spider3.png")
        SpiderBits(2) = New Bitmap("Gamescreen\Entities\Entities\Spider\spider4.png")
        SpiderBits(3) = New Bitmap("Gamescreen\Entities\Entities\Spider\spider5.png")

    End Sub
End Class

Public Class Spider
    Inherits Entity
    Private pointingto As Integer
    Private frame As Integer = random.Next(1, 3)
    Public Sub New(ByVal setlocation As Point)
        MyBase.New(setlocation)
        Size = New Point(26 * VectorFormula.scaling, 23 * VectorFormula.scaling)
        heath = 30
        Me.dmg = 1
        Me.speed = 2
    End Sub
    Public Overrides Sub Update(ByVal index As Integer)
        If (frame >= 3) Then
            frame = 0

        End If
        frame += 1

        pointingto = VectorFormula.PointTo(Me.location, Me.pointToGoTo)
        MyBase.Update(index)
    End Sub
    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)


        e.Graphics.TranslateTransform(location.X + 15 * VectorFormula.scaling, location.Y + 15 * VectorFormula.scaling)
        e.Graphics.RotateTransform(pointingTo)
        e.Graphics.DrawImage(SpiderAssets.SpiderBits(frame), New Point(-25, -25))
        e.Graphics.ResetTransform()
        e.Graphics.TranslateTransform(Form1.CameraLocation.X, Form1.CameraLocation.Y)
        MyBase.Draw(e)
    End Sub


End Class
