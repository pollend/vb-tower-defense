Public Class FastfireBullet
    Inherits Bullets
    Public Sub New()
        Me.killEntities = True
        dmg = 1
        Me.size = New Point(10 * VectorFormula.scaling, 10 * VectorFormula.scaling)
    End Sub
    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(BulletImageCollection.FastFireBullets, location)

        MyBase.Paint(e)
    End Sub

    Public Overrides Sub Update()
        Me.location += Me.direction
        Me.RegularyDmgThroughCollision()

        MyBase.Update()
    End Sub
End Class
