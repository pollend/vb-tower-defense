Public Class RocketAssets
    Public Shared Rocket As Bitmap = New Bitmap("Gamescreen\Turrets\Turrets\HomeBase\Rocket\RocketHomeBase6.png")
End Class

Public Class Rocket
    Inherits particle
    Public scaling As Decimal
    Private direction As Point
    Public Overrides Sub Load()
        direction = VectorFormula.GoInDirectinalRadius(random.Next(0, 360), 10)
        size = New Point(RocketAssets.Rocket.Width * VectorFormula.scaling, RocketAssets.Rocket.Height * VectorFormula.scaling)
        scaling = 1
        MyBase.Load()
    End Sub
    Public Overrides Sub Update()
        topmost = True
        For index = 0 To 10
            Dim mylocation As Point = (New Point(Me.size.X * scaling, Me.size.Y * scaling))
            ParticleManager.AddParticle(New FireToSmoke, New Point(mylocation.X / 2, mylocation.Y / 2) + location + New Point(random.Next(-20, 20), random.Next(-10, 10)), index)
        Next
  
        scaling += 0.01

            Me.location += direction
            'checks if the rocket is out of the range of the camra
        If (Form1.CameraLocation.X > location.X Or Form1.CameraLocation.Y > location.Y) Then
            '   Me.dead = True=
            If (Form1.CameraLocation.X < location.X + Form1.Width Or Form1.CameraLocation.Y < location.Y + Form1.Height) Then
                Me.dead = True

            End If
        End If
    End Sub
    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'e.Graphics.DrawImage(RocketAssets.Rocket, Me.location)

        e.Graphics.TranslateTransform(location.X, location.Y)
        e.Graphics.ScaleTransform(scaling, scaling)
        e.Graphics.DrawImage(RocketAssets.Rocket, New Point(0, 0))
        e.Graphics.ResetTransform()
        e.Graphics.TranslateTransform(Form1.CameraLocation.X, Form1.CameraLocation.Y)
    End Sub


End Class
