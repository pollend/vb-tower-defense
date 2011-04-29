Public Class TurretInfo
    Public turret As Turret
    Public overlay As Rectangle
End Class
Public Class SpawnTurrets

    Public Turrets(0) As TurretInfo
    Public SelectedTurret As TurretInfo
    Public turretA As SelectingBitmap = New SelectingBitmap("Gamescreen\Turrets\SpawnTurret\Buttons\Tower1\TurretAon.png", "Gamescreen\Turrets\SpawnTurret\Buttons\Tower1\TurretAoff.png", New Point(0, 0))
    Public Sub New()
        Turrets(0).
    End Sub

    Public Sub Update()
        'set Location
        turretA.location = New Point(-Form1.CameraLocation.X, -Form1.CameraLocation.Y)



        'MouseOver
        If (turretA.mouseover() = True) Then
            turretA.SetSelection(True)
            If (turretA.MouseLeftClick = True) Then

            End If
        Else
            turretA.SetSelection(False)
        End If
    End Sub
    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        'DRAW
        turretA.Draw(e)
    End Sub
End Class
