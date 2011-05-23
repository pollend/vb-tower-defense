Public Class MedalChunkAssets
    Public Shared MedalChunks(4) As Bitmap
    Public Shared Sub SetUp()
        MedalChunks(0) = New Bitmap("Gamescreen\Particles\ParticleTypes\Chunks\MedalChunks\Assets\chunk3.png")
        MedalChunks(1) = New Bitmap("Gamescreen\Particles\ParticleTypes\Chunks\MedalChunks\Assets\MedalChunk.png")
        MedalChunks(2) = New Bitmap("Gamescreen\Particles\ParticleTypes\Chunks\MedalChunks\Assets\MedalChunk1.png")
        MedalChunks(3) = New Bitmap("Gamescreen\Particles\ParticleTypes\Chunks\MedalChunks\Assets\MedalChunk2.png")

    End Sub
End Class

Public Class MedalChunks
    Inherits particle

    Private direction As Point
    Private rotation As Integer
    Private rotationVector As Integer
    Private life As Integer
    Private fram As Integer

    Public Overrides Sub Load()
        life = random.Next(0, 20)
        size = New Point(20 * 1.3, 20 * 1.3)
        Me.rotation = random.Next(0, 360)
        Me.rotationVector = random.Next(-5, 5)
        direction = VectorFormula.GoInDirectinalRadius(random.Next(0, 360), 10)
        fram = random.Next(0, 3)

        MyBase.Load()
    End Sub
    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.TranslateTransform(location.X, location.Y)
        e.Graphics.RotateTransform(rotation)
        e.Graphics.DrawImage(MedalChunkAssets.MedalChunks(fram), New Point(-(size.X / 2), -(size.Y / 2)))

        e.Graphics.ResetTransform()
        e.Graphics.TranslateTransform(Form1.CameraLocation.X, Form1.CameraLocation.Y)

        MyBase.Paint(e)
    End Sub
    Public Overrides Sub Update()
        rotation += rotationVector
        location += direction



        ParticleManager.AddParticle(New FireToSmoke, location + New Point(random.Next(-10, 10), random.Next(-10, 10)), 0)

        life -= 1
        If (life < 0) Then
            dead = True
        End If


        MyBase.Update()
    End Sub

End Class
