Public Class FastfireBullet
    Inherits Bullets
    Public Sub New()
        Me.killEntities = True
        Me.size = New Point(20 * VectorFormula.scaling, 20 * VectorFormula.scaling)
    End Sub
    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(BulletImageCollection.Bullet1, location)
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(Me.location, Me.size))
        MyBase.Paint(e)
    End Sub

    Public Overrides Sub Update()
        Me.location += Me.direction
        MyBase.Update()
    End Sub
End Class
