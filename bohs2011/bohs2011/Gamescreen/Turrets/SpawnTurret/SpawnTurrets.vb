Public Enum Turretype
    fastfire
    Blast
End Enum

Public Class SpawnTurrets
    Private bottom As Bitmap = New Bitmap("Gamescreen\Turrets\SpawnTurret\Bottom\itemselect.png")
    Public SelectedTurrets As Turretype

    'button clases
    Public FastFire As SelectingBitmap = New SelectingBitmap("Gamescreen\Turrets\SpawnTurret\Buttons\FastFire\FastFire_On.png", "Gamescreen\Turrets\SpawnTurret\Buttons\FastFire\FastFire_Off.png", New Point(0, 0))
    Public Blast As SelectingBitmap = New SelectingBitmap("Gamescreen\Turrets\SpawnTurret\Buttons\FastFire\FastFire_On.png", "Gamescreen\Turrets\SpawnTurret\Buttons\FastFire\FastFire_Off.png", New Point(0, 0))

    Public Sub New()

    End Sub

    Public Sub Update()

        'MouseOver
        If (FastFire.mouseover() = True Or SelectedTurrets = Turretype.fastfire) Then


            FastFire.SetSelection(True)
            If (FastFire.MouseLeftClick = True) Then
                SelectedTurrets = Turretype.fastfire
            End If
        Else
            FastFire.SetSelection(False)
        End If

        If (Blast.mouseover() = True Or SelectedTurrets = Turretype.Blast) Then
            Blast.SetSelection(True)
            If (Blast.MouseLeftClick = True) Then
                SelectedTurrets = Turretype.Blast
            End If
        Else
            Blast.SetSelection(False)
        End If

        'set Location
        FastFire.location = New Point(-Form1.CameraLocation.X + (Form1.Width / 2) - 200, Form1.Height - FastFire.getheight - Form1.CameraLocation.Y)
        Blast.location = New Point(-Form1.CameraLocation.X + (Form1.Width / 2) - 100, Form1.Height - FastFire.getheight - Form1.CameraLocation.Y)



        If (Form1.MouseButtons = MouseButtons.Left) Then

            Dim Locationrelativetoboard As Point = New Point(Form.MousePosition.X - Form1.CameraLocation.X, Form.MousePosition.Y - Form1.CameraLocation.Y)

            Select Case SelectedTurrets
                Case Turretype.fastfire
                    If (Globals.cash >= 50) Then
                        Globals.cash -= 50
                        TurretManager.AddTurret(New FastFireTurrets, New Point(Locationrelativetoboard.X - (29 * VectorFormula.scaling / 2), Locationrelativetoboard.Y - (30 * VectorFormula.scaling / 2)), New Rectangle(0, 0, 29 * VectorFormula.scaling, 30 * VectorFormula.scaling))

                    End If
                Case Turretype.Blast
                    If (Globals.cash >= 100) Then
                        Globals.cash -= 50
                        TurretManager.AddTurret(New Blast, New Point(Locationrelativetoboard.X - (50 * VectorFormula.scaling / 2), Locationrelativetoboard.Y - (50 * VectorFormula.scaling / 2)), New Rectangle(0, 0, 50 * VectorFormula.scaling, 50 * VectorFormula.scaling))
                    End If
                Case Else

            End Select


        End If



    End Sub

    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        'draw rectangle
        Dim Locationrelativetoboard As Point = New Point(Form.MousePosition.X - Form1.CameraLocation.X, Form.MousePosition.Y - Form1.CameraLocation.Y)


        Select Case SelectedTurrets
            Case Turretype.fastfire
                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(Locationrelativetoboard.X - (29 / 2), Locationrelativetoboard.Y - (30 / 2), 29, 30))
            Case Turretype.Blast
                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(Locationrelativetoboard.X - (50 / 2), Locationrelativetoboard.Y - (50 / 2), 50, 50))
            Case Else

        End Select
        e.Graphics.DrawImage(bottom, New Point(-Form1.CameraLocation.X + (-(bottom.Width * VectorFormula.scaling) / 2) + (Form1.Width() / 2), -Form1.CameraLocation.Y + Form1.Height - (bottom.Height * VectorFormula.scaling)))
        'DRAW
        FastFire.Draw(e)
        Blast.Draw(e)
    End Sub
End Class
