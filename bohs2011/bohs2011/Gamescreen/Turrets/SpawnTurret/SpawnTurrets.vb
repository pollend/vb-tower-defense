Public Enum Turretype
    fastfire

End Enum

Public Class SpawnTurrets

    Public Turrets As Turretype
    Private AllowsToBeSet As Boolean
    Public SelectedTurret As Turretype
    'button clases
    Public turretA As SelectingBitmap = New SelectingBitmap("Gamescreen\Turrets\SpawnTurret\Buttons\Tower1\TurretAon.png", "Gamescreen\Turrets\SpawnTurret\Buttons\Tower1\TurretAoff.png", New Point(0, 0))
    Public Sub New()

    End Sub

    Public Sub Update()
        AllowsToBeSet = True
        'MouseOver
        If (turretA.mouseover() = True) Then
            AllowsToBeSet = False

            turretA.SetSelection(True)
            If (turretA.MouseLeftClick = True) Then

            End If

        End If

        'set Location
        turretA.location = New Point(-Form1.CameraLocation.X + (Form1.Width / 2), Form1.Height - turretA.getheight - Form1.CameraLocation.Y)
        If (AllowsToBeSet = True) Then

            If (Form1.MouseButtons = MouseButtons.Left) Then

                Dim Locationrelativetoboard As Point = New Point(Form.MousePosition.X - Form1.CameraLocation.X, Form.MousePosition.Y - Form1.CameraLocation.Y)

                Select Case Turrets
                    Case Turretype.fastfire

                        TurretManager.AddTurret(New FastFireTurrets, New Point(Locationrelativetoboard.X - (29 / 2), Locationrelativetoboard.Y - (30 / 2)), New Rectangle(0, 0, 29 * VectorFormula.scaling, 30 * VectorFormula.scaling))


                    Case Else

                End Select

               
            End If

        End If


    End Sub

    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        'draw rectangle
        Dim Locationrelativetoboard As Point = New Point(Form.MousePosition.X - Form1.CameraLocation.X, Form.MousePosition.Y - Form1.CameraLocation.Y)
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(Locationrelativetoboard.X - (29 / 2), Locationrelativetoboard.Y - (30 / 2), 29, 30))

        'DRAW
        turretA.Draw(e)
    End Sub
End Class
