﻿Public Class SloMoAssets
    Public Shared SloMoBottom As Bitmap = New Bitmap("Gamescreen\Turrets\Turrets\SloMoTurret\BottomSloMo.png")
    Public Shared SloMoTop As Bitmap = New Bitmap("Gamescreen\Turrets\Turrets\SloMoTurret\TopSloMo.png")

End Class

Public Class SloMoTurret
    Inherits Turret
    Private timing As Integer
    Private rand As Random = New Random()
    Private pointingTo As Decimal

    Public Sub New()
        MyBase.New()
        Me.health = 30
    End Sub


    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(SloMoAssets.SloMoBottom, Me.location)

        'makes the turret follow the entity  
        e.Graphics.TranslateTransform(location.X + 15 * VectorFormula.scaling, location.Y + 15 * VectorFormula.scaling)
        e.Graphics.RotateTransform(pointingTo)
        e.Graphics.DrawImage(SloMoAssets.SloMoTop, New Point(-15 * VectorFormula.scaling, -15 * VectorFormula.scaling))
        e.Graphics.ResetTransform()
        e.Graphics.TranslateTransform(Form1.CameraLocation.X, Form1.CameraLocation.Y)
        MyBase.Paint(e)
    End Sub
    Public Overrides Sub Update(ByVal index As Integer)

        timing += 1
        If (timing > 30) Then
            If Not (findentity(200) = New Point(-1, -1)) Then

                pointingTo = VectorFormula.PointTo(Me.location, findentity(200))
                BulletManager.AddBullet(New SloMoBullet(), New Point(Me.location + New Point(Me.Size.X / 2, Me.Size.Y / 2)), VectorFormula.GoInDirectinalRadius(pointingTo, 20))
                timing = 0

            End If

        End If

        MyBase.Update(index)
    End Sub

End Class
