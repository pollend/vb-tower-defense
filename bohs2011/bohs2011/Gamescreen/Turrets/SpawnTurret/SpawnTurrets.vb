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
                Dim Locationrelativetoboard As Point = New Point(Form.MousePosition.X - Form1.CameraLocation.X, Form.MousePosition.Y - Form1.CameraLocation.Y)

                Select Case Turrets
                    Case Turretype.fastfire

                        TurretManager.AddTurret(New FastFireTurrets, New Point(Locationrelativetoboard.X - 50, Locationrelativetoboard.Y - 50), New Rectangle(0, 0, 74 * VectorFormula.scaling, 75 * VectorFormula.scaling))


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
        'draw rectangle
        Dim Locationrelativetoboard As Point = New Point(Form.MousePosition.X - Form1.CameraLocation.X, Form.MousePosition.Y - Form1.CameraLocation.Y)
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(Locationrelativetoboard.X - 50, Locationrelativetoboard.Y - 50, 100, 100))

        'DRAW
        turretA.Draw(e)
    End Sub
End Class
