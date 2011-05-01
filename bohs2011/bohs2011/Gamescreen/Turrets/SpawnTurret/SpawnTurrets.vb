Public Enum Turretype
    fastfire
End Enum

Public Class SpawnTurrets

    Public Turrets As Turretype
    Public SelectedTurret As Turretype
    'button clases
    Public turretA As SelectingBitmap = New SelectingBitmap("Gamescreen\Turrets\SpawnTurret\Buttons\Tower1\TurretAon.png", "Gamescreen\Turrets\SpawnTurret\Buttons\Tower1\TurretAoff.png", New Point(0, 0))
    Public Sub New()

    End Sub

    Public Sub Update()
        'set Location
        turretA.location = New Point(-Form1.CameraLocation.X, -Form1.CameraLocation.Y)

        If (Form1.MouseButtons = MouseButtons.Left) Then
            Try

                Select Case Turrets
                    Case Turretype.fastfire
                        TurretManager.AddTurret(New FastFireTurrets, New Point(Form.MousePosition.X, Form.MousePosition.Y), New Rectangle(0, 0, 100, 100))


                    Case Else

                End Select

            Catch ex As Exception

            End Try
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
