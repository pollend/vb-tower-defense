Public Class TurretInfo
    Public Sub New(ByVal turrets As Turret, ByVal collisionRect As Rectangle, ByVal overlay As Bitmap)
        Me.turret = turrets
        Me.CollisionRect = collisionRect
        Me.overlay = overlay
    End Sub
    Public turret As Turret
    Public CollisionRect As Rectangle
    Public overlay As Bitmap
End Class
Public Class SpawnTurrets

    Public Turrets(0) As TurretInfo
    Public SelectedTurret As TurretInfo
    Public turretA As SelectingBitmap = New SelectingBitmap("Gamescreen\Turrets\SpawnTurret\Buttons\Tower1\TurretAon.png", "Gamescreen\Turrets\SpawnTurret\Buttons\Tower1\TurretAoff.png", New Point(0, 0))
    Public Sub New()
        Turrets(0) = New TurretInfo(New FastFireTurrets(), New Rectangle(0, 0, 100, 100), New Bitmap("Gamescreen\Entities\Entities\Spider\TANK.PNG"))

    End Sub

    Public Sub Update()
        'set Location
        turretA.location = New Point(-Form1.CameraLocation.X, -Form1.CameraLocation.Y)

        If (Form1.MouseButtons = MouseButtons.Left) Then
            TurretManager.AddTurret(Turrets(0).turret, New Point(Form1.MousePosition.X, Form1.MousePosition.Y), Turrets(0).CollisionRect)

        End If

        'MouseOver
        If (turretA.mouseover() = True) Then
            turretA.SetSelection(True)
            If (turretA.MouseLeftClick = True) Then

            End If

        End If
    End Sub

    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        'DRAW
        turretA.Draw(e)
    End Sub
End Class
