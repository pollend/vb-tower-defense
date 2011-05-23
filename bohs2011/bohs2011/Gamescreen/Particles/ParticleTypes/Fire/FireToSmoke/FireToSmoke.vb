Public Class fireToSmokeAssets
    Public Shared Explosion(6, 1) As Bitmap

    Public Shared Sub SetUp()
        Explosion(0, 0) = New Bitmap("Gamescreen\Particles\ParticleTypes\Fire\FireToSmoke\set1\Explosion1.png")
        Explosion(1, 0) = New Bitmap("Gamescreen\Particles\ParticleTypes\Fire\FireToSmoke\set1\Explosion2.png")
        Explosion(2, 0) = New Bitmap("Gamescreen\Particles\ParticleTypes\Fire\FireToSmoke\set1\Explosion3.png")
        Explosion(3, 0) = New Bitmap("Gamescreen\Particles\ParticleTypes\Fire\FireToSmoke\set1\Explosion4.png")
        Explosion(4, 0) = New Bitmap("Gamescreen\Particles\ParticleTypes\Fire\FireToSmoke\set1\Explosion5.png")
        Explosion(5, 0) = New Bitmap("Gamescreen\Particles\ParticleTypes\Fire\FireToSmoke\set1\Explosion6.png")

        Explosion(0, 1) = New Bitmap("Gamescreen\Particles\ParticleTypes\Fire\FireToSmoke\Set2\explosion1.png")
        Explosion(1, 1) = New Bitmap("Gamescreen\Particles\ParticleTypes\Fire\FireToSmoke\Set2\explosion2.png")
        Explosion(2, 1) = New Bitmap("Gamescreen\Particles\ParticleTypes\Fire\FireToSmoke\Set2\explosion3.png")
        Explosion(3, 1) = New Bitmap("Gamescreen\Particles\ParticleTypes\Fire\FireToSmoke\Set2\explosion4.png")
        Explosion(4, 1) = New Bitmap("Gamescreen\Particles\ParticleTypes\Fire\FireToSmoke\Set2\explosion5.png")
        Explosion(5, 1) = New Bitmap("Gamescreen\Particles\ParticleTypes\Fire\FireToSmoke\Set2\explosion6.png")

    End Sub
End Class

Public Class FireToSmoke
    Inherits particle

    Private direction As Point
    Private rotation As Integer
    Private rotationVector As Integer
    Private life As Integer
    Private fram As Integer
    Private FramSet As Integer
    Private freezeFrame As Boolean

    Public Overrides Sub Load()

        life = random.Next(0, 50)

        size = New Point(20 * 1.3, 20 * 1.3)

        Me.rotation = random.Next(0, 360)
        Me.rotationVector = random.Next(-10, 10)
        direction = VectorFormula.GoInDirectinalRadius(random.Next(0, 360), 1)
        If (random.Next(0, 100) > 50) Then
            FramSet = 0
        Else
            FramSet = 1
        End If

        MyBase.Load()
    End Sub
    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.TranslateTransform(location.X, location.Y)

        e.Graphics.DrawImage(fireToSmokeAssets.Explosion(fram, FramSet), New Point(-(size.X / 2), -(size.Y / 2)))
        e.Graphics.RotateTransform(rotation)
        e.Graphics.ResetTransform()
        e.Graphics.TranslateTransform(Form1.CameraLocation.X, Form1.CameraLocation.Y)

        MyBase.Paint(e)
    End Sub
    Public Overrides Sub Update()
        rotation += rotationVector
        location += direction

        life -= 1
        If (life < 0) Then
            dead = True
        End If

        If (freezeFrame = False) Then


            If (fram <= 4) Then
                fram += 1
            Else
                fram = 5
                freezeFrame = True
            End If
        End If

        MyBase.Update()
    End Sub
End Class
