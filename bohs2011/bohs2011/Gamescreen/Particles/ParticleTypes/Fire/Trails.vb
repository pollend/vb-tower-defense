Public Class Trails
    Inherits particle
    Public newlocation As Point
    Public life As Integer
    Public Sub New(ByVal newLocation As Point)
        Me.newlocation = newLocation
    End Sub
    Public Overrides Sub Load()

        life = random.Next(0, 3)
        MyBase.Load()
    End Sub
    Public Overrides Sub Update()
        MyBase.Update()

        life -= 1
        If (life < 0) Then
            Me.dead = True
        End If
    End Sub
    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)

        e.Graphics.DrawLine(Pens.Orange, newlocation, location)
        MyBase.Paint(e)
    End Sub

End Class
