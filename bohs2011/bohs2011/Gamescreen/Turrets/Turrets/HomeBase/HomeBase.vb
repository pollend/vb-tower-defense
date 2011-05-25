Public Class HomeBaseAssets
    Public Shared Rocket(6) As Bitmap
    Public Shared Bottom As Bitmap
    Public Shared Sub SetUp()
        HomeBaseAssets.Bottom = New Bitmap("Gamescreen\Turrets\Turrets\HomeBase\bottomBase.png")

        HomeBaseAssets.Rocket(0) = New Bitmap("Gamescreen\Turrets\Turrets\HomeBase\Rocket\Blank.png")
        HomeBaseAssets.Rocket(1) = New Bitmap("Gamescreen\Turrets\Turrets\HomeBase\Rocket\RocketHomeBase1.png")
        HomeBaseAssets.Rocket(2) = New Bitmap("Gamescreen\Turrets\Turrets\HomeBase\Rocket\RocketHomeBase2.png")
        HomeBaseAssets.Rocket(3) = New Bitmap("Gamescreen\Turrets\Turrets\HomeBase\Rocket\RocketHomeBase3.png")
        HomeBaseAssets.Rocket(4) = New Bitmap("Gamescreen\Turrets\Turrets\HomeBase\Rocket\RocketHomeBase4.png")
        HomeBaseAssets.Rocket(5) = New Bitmap("Gamescreen\Turrets\Turrets\HomeBase\Rocket\RocketHomeBase5.png")
        HomeBaseAssets.Rocket(6) = New Bitmap("Gamescreen\Turrets\Turrets\HomeBase\Rocket\RocketHomeBase6.png")
    End Sub
End Class

Public Class HomeBase
    Inherits Turret
    Public TriggerAnimation As Boolean
    Public frame As Integer


    Public Sub New()

        MyBase.New()
        Me.health = 100
        Me.Dead = False

    End Sub


    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(HomeBaseAssets.Bottom, Me.location)
        e.Graphics.DrawImage(HomeBaseAssets.Rocket(frame), Me.location)
        MyBase.Paint(e)
    End Sub
    Public Overrides Sub Update(ByVal index As Integer)
        MyBase.Update(index)
        If (WaveManagment.setvalues = False) Then
            TriggerAnimation = True
        End If
        If (TriggerAnimation = True) Then
            If (frame <= 5) Then
                frame += 1
            Else
                frame = 0
                ParticleManager.AddParticle(New Rocket, Me.location)
                TriggerAnimation = False
                Globals.SavedHumans += 1000
                Globals.cash += 100
            End If
        End If

    End Sub

End Class
