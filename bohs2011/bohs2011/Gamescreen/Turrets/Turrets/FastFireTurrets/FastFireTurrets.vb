Public Class FastFireTurrets
    Inherits Turret
    Private Turret1 As Bitmap = New Bitmap("Gamescreen\Turrets\Turrets\FastFireTurrets\Assets\turret1.png")
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByRef turret As FastFireTurrets)
        MyBase.New(turret)

    End Sub

    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)

        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(location.X, location.Y, 72 * VectorFormula.scaling, 68 * VectorFormula.scaling))

        e.Graphics.DrawImage(Turret1, location)

        MyBase.Paint(e)
    End Sub
    Public Overrides Sub Update()
        MyBase.Update()
    End Sub

End Class
