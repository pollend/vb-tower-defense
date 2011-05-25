
Public Class Blocade
    Inherits Turret


    Public Sub New()
        MyBase.New()
        Me.health = 1000

    End Sub


    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(FastFireAssets.Bottom, Me.location)
        e.Graphics.DrawString(health, New Font("Arial", 5), Brushes.Black, location)

    End Sub
    Public Overrides Sub Update(ByVal index As Integer)
        If (Me.health < 0) Then
            Me.Dead = True
        End If
    End Sub

End Class
