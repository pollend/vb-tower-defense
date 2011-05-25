Public Class MechAssets
    Public Shared MechBits(7) As Bitmap
    Public Shared Sub SetUp()
        MechBits(0) = New Bitmap("Gamescreen\Entities\Entities\Mech\Mech1.png")
        MechBits(1) = New Bitmap("Gamescreen\Entities\Entities\Mech\Mech2.png")
        MechBits(2) = New Bitmap("Gamescreen\Entities\Entities\Mech\Mech3.png")
        MechBits(3) = New Bitmap("Gamescreen\Entities\Entities\Mech\Mech4.png")
        MechBits(4) = New Bitmap("Gamescreen\Entities\Entities\Mech\Mech5.png")
        MechBits(5) = New Bitmap("Gamescreen\Entities\Entities\Mech\Mech6.png")
        MechBits(6) = New Bitmap("Gamescreen\Entities\Entities\Mech\Mech7.png")
        MechBits(7) = New Bitmap("Gamescreen\Entities\Entities\Mech\Mech8.png")


    End Sub
End Class


Public Class Mech
    Inherits Entity
    Private frame As Integer = random.Next(1, 3)
    Private pointingto As Integer
    Public Sub New(ByVal setlocation As Point)
        MyBase.New(setlocation)
        Size = New Point(30, 30)
        Me.health = 50
        cash = 10
        Me.dmg = 20
        Me.speed = 3

    End Sub
    Public Overrides Sub Update(ByVal index As Integer)
        If (frame >= 6) Then
            frame = 0

        End If
        frame += 1



        pointingto = VectorFormula.PointTo(Me.location, Me.pointToGoTo)

        MyBase.Update(index)
    End Sub
    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)


        e.Graphics.TranslateTransform(location.X + 15 * VectorFormula.scaling, location.Y + 15 * VectorFormula.scaling)
        e.Graphics.RotateTransform(pointingTo)
        e.Graphics.DrawImage(MechAssets.MechBits(frame), New Point(-25, -25))
        e.Graphics.ResetTransform()
        e.Graphics.TranslateTransform(Form1.CameraLocation.X, Form1.CameraLocation.Y)
        MyBase.Draw(e)
    End Sub


End Class
