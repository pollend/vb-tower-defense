Public Class FastFireAssets
    Public Shared Top = New Bitmap("Gamescreen\Turrets\Turrets\FastFireTurrets\Assets\FastfireTurretTop.png")
    Public Shared Bottom = New Bitmap("Gamescreen\Turrets\Turrets\FastFireTurrets\Assets\FastfireTurretBottom.png")

End Class

Public Class FastFireTurrets
    Inherits Turret
    Private timing As Integer
    Private rand As Random = New Random()
    Private pointingTo As Decimal

    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByRef turret As FastFireTurrets)
        MyBase.New(turret)

    End Sub

    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(FastFireAssets.Bottom, Me.location)
        'makes the turret follow the entity  
        e.Graphics.TranslateTransform(location.X + 15 * VectorFormula.scaling, location.Y + 15 * VectorFormula.scaling)
        e.Graphics.RotateTransform(pointingTo)
        e.Graphics.DrawImage(FastFireAssets.Top, New Point(-15 * VectorFormula.scaling, -15 * VectorFormula.scaling))
        e.Graphics.ResetTransform()
        e.Graphics.TranslateTransform(Form1.CameraLocation.X, Form1.CameraLocation.Y)
        MyBase.Paint(e)
    End Sub
    Public Overrides Sub Update(ByVal index As Integer)

        pointingTo = VectorFormula.PointTo(Me.location, Form1.MousePosition)
        timing += 1
        If (timing > 20) Then
            BulletManager.AddBullet(New FastfireBullet(), New Point(Me.location), VectorFormula.GoInDirectinalRadius(pointingTo, 20))
            timing = 0
        End If

        MyBase.Update(index)
    End Sub

End Class
