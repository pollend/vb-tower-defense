Public Enum Turretype
    fastfire
    Blast
    SloMo
End Enum

Public Class SpawnTurrets
    Private bottom As Bitmap = New Bitmap("Gamescreen\Turrets\SpawnTurret\Bottom\itemselect.png")
    Public SelectedTurrets As Turretype

    'button clases
    Public FastFire As SelectingBitmap = New SelectingBitmap("Gamescreen\Turrets\SpawnTurret\Buttons\FastFire\FastFire_On.png", "Gamescreen\Turrets\SpawnTurret\Buttons\FastFire\FastFire_Off.png", New Point(0, 0))
    Public Blast As SelectingBitmap = New SelectingBitmap("Gamescreen\Turrets\SpawnTurret\Buttons\Blast\BlastTurret_On.png", "Gamescreen\Turrets\SpawnTurret\Buttons\Blast\BlastTurret_Off.png", New Point(0, 0))
    Public SloMo As SelectingBitmap = New SelectingBitmap("Gamescreen\Turrets\SpawnTurret\Buttons\SloMo\SloMoTurret_On.png", "Gamescreen\Turrets\SpawnTurret\Buttons\SloMo\SloMoTurret_Off.png", New Point(0, 0))

    Public Sub New()

    End Sub

    Public Sub Update()

        'MouseOver

        If (SloMo.mouseover() = True Or SelectedTurrets = Turretype.SloMo) Then
            SloMo.SetSelection(True)
            If (SloMo.MouseLeftClick = True) Then
                SelectedTurrets = Turretype.SloMo
            End If
        Else
            SloMo.SetSelection(False)
        End If

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
        Blast.location = New Point(-Form1.CameraLocation.X + (Form1.Width / 2) - 125, Form1.Height - FastFire.getheight - Form1.CameraLocation.Y)
        SloMo.location = New Point(-Form1.CameraLocation.X + (Form1.Width / 2) - 53, Form1.Height - FastFire.getheight - Form1.CameraLocation.Y)

        If Not (Form1.MousePosition.Y > Form1.Height - (bottom.Height * VectorFormula.scaling)) Then

            If (Form1.MouseButtons = MouseButtons.Left) Then

                Dim Locationrelativetoboard As Point = New Point(Form.MousePosition.X - Form1.CameraLocation.X, Form.MousePosition.Y - Form1.CameraLocation.Y)
                'have the selected turret
                Select Case SelectedTurrets
                    Case Turretype.fastfire
                        If (Globals.cash >= 50) Then


                            If (TurretManager.AddTurret(New FastFireTurrets, New Point(Locationrelativetoboard.X - (29 * VectorFormula.scaling / 2), Locationrelativetoboard.Y - (30 * VectorFormula.scaling / 2)), New Point(29 * VectorFormula.scaling, 30 * VectorFormula.scaling)) = True) Then
                                Globals.cash -= 50
                            End If

                        End If
                    Case Turretype.Blast
                        If (Globals.cash >= 100) Then

                            If (TurretManager.AddTurret(New Blast, New Point(Locationrelativetoboard.X - (50 * VectorFormula.scaling / 2), Locationrelativetoboard.Y - (50 * VectorFormula.scaling / 2)), New Point(50 * VectorFormula.scaling, 50 * VectorFormula.scaling)) = True) Then
                                Globals.cash -= 100
                            End If
                        End If
                    Case Turretype.SloMo
                        If (Globals.cash >= 300) Then


                            If (TurretManager.AddTurret(New SloMoTurret(), New Point(Locationrelativetoboard.X - (29 * VectorFormula.scaling / 2), Locationrelativetoboard.Y - (30 * VectorFormula.scaling / 2)), New Point(29 * VectorFormula.scaling, 30 * VectorFormula.scaling)) = True) Then
                                Globals.cash -= 300
                            End If

                        End If
                    Case Else

                End Select


            End If
        End If


    End Sub

    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        'draw rectangle
        Dim Locationrelativetoboard As Point = New Point(Form.MousePosition.X - Form1.CameraLocation.X, Form.MousePosition.Y - Form1.CameraLocation.Y)


        Select Case SelectedTurrets
            Case Turretype.fastfire
                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(Locationrelativetoboard.X - (29 / 2), Locationrelativetoboard.Y - (30 / 2), 29, 30))

            Case Turretype.SloMo
                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(Locationrelativetoboard.X - (29 / 2), Locationrelativetoboard.Y - (30 / 2), 29, 30))
            Case Turretype.Blast
                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(Locationrelativetoboard.X - (50 / 2), Locationrelativetoboard.Y - (50 / 2), 50, 50))
            Case Else

        End Select
        e.Graphics.DrawImage(bottom, New Point(-Form1.CameraLocation.X + (-(bottom.Width * VectorFormula.scaling) / 2) + (Form1.Width() / 2), -Form1.CameraLocation.Y + Form1.Height - (bottom.Height * VectorFormula.scaling)))
        'DRAW the buttons
        FastFire.Draw(e)
        Blast.Draw(e)
        SloMo.Draw(e)
    End Sub
End Class
