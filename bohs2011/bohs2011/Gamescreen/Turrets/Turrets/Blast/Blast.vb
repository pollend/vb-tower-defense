Public Class BlastAssets
    Public Shared BlastAssets(5) As Bitmap
    Public Shared Bottom As Bitmap = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Bottom.png")

    Public Shared Sub SetUp()
        BlastAssets(0) = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Turret1.png")
        BlastAssets(1) = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Turret2.png")
        BlastAssets(2) = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Turret3.png")
        BlastAssets(3) = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Turret4.png")
        BlastAssets(4) = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Turret5.png")
        BlastAssets(5) = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Turret6.png")

    End Sub
End Class

Public Class Blast
    Inherits Turret
    Private timing As Integer
    Private rand As Random = New Random()
    Private pointingTo As Decimal
    Private frame As Integer
    Private StartAnimation As Boolean

    Public Sub New()
        MyBase.New()
        Me.health = 50
    End Sub


    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(BlastAssets.Bottom, Me.location)
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(Me.location, Me.Size))
        'makes the turret follow the entity  
        e.Graphics.TranslateTransform(location.X + 25 * VectorFormula.scaling, location.Y + 25 * VectorFormula.scaling)
        e.Graphics.RotateTransform(pointingTo)
        e.Graphics.DrawImage(BlastAssets.BlastAssets(frame), New Point(-25 * VectorFormula.scaling, -25 * VectorFormula.scaling))
        e.Graphics.ResetTransform()
        e.Graphics.TranslateTransform(Form1.CameraLocation.X, Form1.CameraLocation.Y)
        MyBase.Paint(e)
    End Sub
    Public Overrides Sub Update(ByVal index As Integer)
        If (StartAnimation = True) Then
            If (frame > 4) Then
                frame = 0
                StartAnimation = False
            Else
                frame += 1
            End If
        End If
        timing += 1
        If (timing > 30) Then
            If Not (findentity(300) = New Point(-1, -1)) Then

                pointingTo = VectorFormula.PointTo(Me.location, findentity(300))
                BulletManager.AddBullet(New BlastBullets(), New Point(Me.location + New Point(Me.Size.X / 2, Me.Size.Y / 2)), VectorFormula.GoInDirectinalRadius(pointingTo, 20))
                timing = 0
                StartAnimation = True
            End If

        End If

        MyBase.Update(index)
    End Sub
End Class
