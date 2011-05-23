Public Class SloMoParticleAssets
    Public Shared SloMo(9) As Bitmap
    Public Shared Sub SetUp()
        SloMo(0) = New Bitmap("Gamescreen\Particles\ParticleTypes\SloMoEffect\Assets\SLoMO 01.png")
        SloMo(1) = New Bitmap("Gamescreen\Particles\ParticleTypes\SloMoEffect\Assets\SLoMO 02.png")
        SloMo(2) = New Bitmap("Gamescreen\Particles\ParticleTypes\SloMoEffect\Assets\SLoMO 04.png")
        SloMo(3) = New Bitmap("Gamescreen\Particles\ParticleTypes\SloMoEffect\Assets\SLoMO 05.png")
        SloMo(4) = New Bitmap("Gamescreen\Particles\ParticleTypes\SloMoEffect\Assets\SLoMO 06.png")
        SloMo(5) = New Bitmap("Gamescreen\Particles\ParticleTypes\SloMoEffect\Assets\SLoMO 07.png")
        SloMo(6) = New Bitmap("Gamescreen\Particles\ParticleTypes\SloMoEffect\Assets\SLoMO 08.png")
        SloMo(7) = New Bitmap("Gamescreen\Particles\ParticleTypes\SloMoEffect\Assets\SLoMO 09.png")
        SloMo(8) = New Bitmap("Gamescreen\Particles\ParticleTypes\SloMoEffect\Assets\SLoMO 10.png")
    End Sub
End Class
Public Class SloMo
    Inherits particle
    Public frame As Integer
    Public lockFram As Boolean

    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(SloMoParticleAssets.SloMo(frame), location - New Point(50 * 1.3, 50 * 1.3))


        MyBase.Paint(e)
    End Sub
    Public Overrides Sub Load()
        frame = 0
        MyBase.Load()
    End Sub
    Public Overrides Sub Update()
        If (lockFram = False) Then
            If (frame <= 7) Then
                frame += 1
            Else
                lockFram = True
                frame = 8

            End If
        Else
            If (frame >= 7) Then
                dead = True
                frame = 8
            Else
                frame += 1
            End If
        End If
        MyBase.Update()
    End Sub

End Class
