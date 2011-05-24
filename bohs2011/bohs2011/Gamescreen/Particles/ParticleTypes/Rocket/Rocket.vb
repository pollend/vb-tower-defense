Public Class RocketAssets
    Public Shared Rocket As Bitmap = New Bitmap("Gamescreen\Turrets\Turrets\HomeBase\Rocket\RocketHomeBase6.png")
End Class

Public Class Rocket
    Inherits particle
    Public scaling As Decimal
    Private direction As Point
    Public Overrides Sub Load()
        direction = VectorFormula.GoInDirectinalRadius(random.Next(0, 360), 5)
        size = New Point(RocketAssets.Rocket.Width * VectorFormula.scaling, RocketAssets.Rocket.Height * VectorFormula.scaling)

        MyBase.Load()
    End Sub
    Public Overrides Sub Update()
        topmost = True
        For index = 0 To 10

            ParticleManager.AddParticle(New FireToSmoke, Me.location + New Point(size.X / 2, size.Y / 2), index)
        Next
  
        scaling += 0.1
        Me.size = New Point((RocketAssets.Rocket.Width * VectorFormula.scaling) * scaling, (RocketAssets.Rocket.Height * VectorFormula.scaling) * scaling)

            Me.location += direction
            'checks if the rocket is out of the range of the camra
            If (Camera.GetXCam < location.X + 100 Or Camera.GetYCam < location.Y + 100) Then
                If (Camera.GetXCam + Form1.Width > location.X - 100 Or Camera.GetYCam + Form1.Height > location.Y - 100) Then
                    '   Me.dead = True
                End If
            End If
    End Sub
    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'e.Graphics.DrawImage(RocketAssets.Rocket, Me.location)

        e.Graphics.TranslateTransform(location.X, location.Y)
        e.Graphics.ScaleTransform(scaling, scaling)
        e.Graphics.DrawImage(RocketAssets.Rocket, New Point(-((size.X / 2)), -((size.Y / 2))))
        e.Graphics.ResetTransform()
        e.Graphics.TranslateTransform(Form1.CameraLocation.X, Form1.CameraLocation.Y)
    End Sub


End Class
