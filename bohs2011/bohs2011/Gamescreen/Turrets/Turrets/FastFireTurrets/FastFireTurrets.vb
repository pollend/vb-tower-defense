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
        Me.health = 200

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

        timing += 1
        If (timing > 10) Then
            If Not (findentity(200) = New Point(-1, -1)) Then

                pointingTo = VectorFormula.PointTo(Me.location, findentity(200))
                BulletManager.AddBullet(New FastfireBullet(), New Point(Me.location + New Point(Me.Size.X / 2, Me.Size.Y / 2)), VectorFormula.GoInDirectinalRadius(pointingTo, 20))
                timing = 0

            End If

        End If

        MyBase.Update(index)
    End Sub

End Class
