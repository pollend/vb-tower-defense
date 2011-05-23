Public Class FireParticles
    Inherits particle
    Public direction As Point
    Public life As Integer
    Public enabletrail As Boolean
    Public Overrides Sub Load()
        direction = VectorFormula.GoInDirectinalRadius(random.Next(0, 360), 20)
        life = 5
        If (random.Next(0, 100) > 60) Then
            enabletrail = True
        Else
            enabletrail = False
        End If
        MyBase.Load()
    End Sub
    Public Overrides Sub Update()
        MyBase.Update()
        Me.location += direction
        If (enabletrail = True) Then

            ParticleManager.AddParticle(New Trails(Me.location + Me.direction), Me.location)
        End If
        life -= 1
        If (life < 0) Then
            Me.dead = True
        End If
    End Sub
    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.FillRectangle(Brushes.Orange, New Rectangle(location, New Size(4, 4)))
        MyBase.Paint(e)
    End Sub

End Class
