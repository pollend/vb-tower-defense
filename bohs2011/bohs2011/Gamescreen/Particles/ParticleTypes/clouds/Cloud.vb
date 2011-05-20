Public Class CloudAssets
    Public Cloud As Bitmap = New Bitmap("Gamescreen\Particles\ParticleTypes\clouds\clouds.png")
End Class
Public Class Cloud
    Inherits particle
    Public Sub New()

    End Sub
    Public Overrides Sub Update()
        Me.location += New Point(Me.random.Next(5, 5), Me.random.Next(-5, 5))

        MyBase.Update()
    End Sub
    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.Paint(e)
    End Sub

End Class
