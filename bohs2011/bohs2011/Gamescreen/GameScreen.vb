﻿Public Class GameScreen
    Implements IScreen
    Private TopImage As Bitmap = New Bitmap("Gamescreen\Top\top.png")

    Private vinyet As Bitmap = New Bitmap("Gamescreen\Map\Maps\vinet.png")
    'highscore Overlay
    Private Overlay As Bitmap = New Bitmap("Gamescreen\HighScore\NewHighScore.png")
    Private HighScore_On As SelectingBitmap = New SelectingBitmap("Gamescreen\HighScore\HighScore_On.png", "Gamescreen\HighScore\HighScore_Off.png", New Point(100, 100))
    Private HigscoreText As String = ""
    Private NewHighScore As Boolean

    'particle Manager
    Public particle As ParticleManager = New ParticleManager()

    'manges the bullets
    Public bullets As BulletManager = New BulletManager()

    Private entitymanager As EntityManager = New EntityManager()
    'moves the camera
    Private cam As Camera = New Camera

    'turret manager
    Private TurretManager As TurretManager = New TurretManager()

    'spawning turret manger
    Private spawnturret As SpawnTurrets = New SpawnTurrets()

    'manages the waves
    Private wave As WaveManagment = New WaveManagment()

    Private map As New Map
    Public Sub Load() Implements IScreen.Load

        'sets points on point grid
        PointGrid.SetPoint()
        Globals.cash = 1000
        Globals.GameOver = False
        Globals.SavedHumans = 0


        'loads the entity manager
        entitymanager.Load()
        particle.Load()
        '
        TurretManager.Load()
        'adds the hombase as the first turret
        TurretManager.AddTurret(New HomeBase(), PointGrid.Points.Item(3).Item(0).location, New Point(100 * VectorFormula.scaling, 100 * VectorFormula.scaling))


    End Sub

    Public Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs) Implements IScreen.Paint


        map.Draw(e)

        'draw the entities
        entitymanager.paint(e)

        'draws the turrets
        TurretManager.Paint(e)

        'draws the bullets
        bullets.Draw(e)

        particle.Draw(e)

        e.Graphics.DrawImage(vinyet, New Point(0, 1))
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(New Point(0, -1), New Size(1000 * 1.3, 1)))

        'draw buttons always on top
        spawnturret.Draw(e)
        e.Graphics.DrawImage(TopImage, New Point((((Form1.Width) / 2) - (TopImage.Width * VectorFormula.scaling / 2)) - Form1.CameraLocation.X, 0 - Form1.CameraLocation.Y))
        e.Graphics.DrawString(Globals.SavedHumans, New Font("Arial", 10), Brushes.Black, New Point(((Form1.Width) / 2) - (TopImage.Width / 2) - Form1.CameraLocation.X + 50, 0 - Form1.CameraLocation.Y))
        e.Graphics.DrawString(Globals.cash, New Font("Arial", 10), Brushes.Black, New Point(((Form1.Width) / 2) - (TopImage.Width / 2) - Form1.CameraLocation.X + 50, 19 - Form1.CameraLocation.Y))
        If (Globals.GameOver = True) Then
            If (ScoreManager.CheckifNewHighScore(Globals.SavedHumans) = True) Then
                e.Graphics.DrawImage(Overlay, New Point(((Form1.Width) / 2) - (Overlay.Width * VectorFormula.scaling / 2) - Form1.CameraLocation.X, 100 - Form1.CameraLocation.Y - (Overlay.Height / 2)))
                e.Graphics.DrawString(Me.HigscoreText, New Font("Arial", 25), Brushes.Black, New Point(((Form1.Width) / 2) - (Overlay.Width * VectorFormula.scaling / 2) - Form1.CameraLocation.X + 30, 150 - Form1.CameraLocation.Y - (Overlay.Height / 2)))
            End If

            e.Graphics.DrawString("Hit Enter To Continue", New Font("Impact", 20), Brushes.Black, New Point(((Form1.Width) / 2) - (("Right Click To Continue".Length * 10) / 2) - Form1.CameraLocation.X, 500 - Form1.CameraLocation.Y - (Overlay.Height / 2)))

        End If



    End Sub
    Private slowDownLoop As Integer
    Public Function Update() As Screens Implements IScreen.Update
        'updates the postion
        cam.UpdatePosition()
        spawnturret.UpdateButtonPosition()
        If (Globals.GameOver = True) Then
            'the key number
            Dim mykeynumber As Integer = Form1.GetkeyPressNumber
            Dim charkey As String = Form1.GetKeyPreses
            'test if it is a new high score
            If (ScoreManager.CheckifNewHighScore(Globals.SavedHumans) = True) Then
                If (mykeynumber = Keys.Back) Then
                    Try
                        Me.HigscoreText = Me.HigscoreText.Remove(Me.HigscoreText.Length - 1, 1)
                    Catch ex As Exception

                    End Try
                Else
                    If (Me.HigscoreText.Length <= 7) Then
                        Me.HigscoreText = Me.HigscoreText & charkey
                    End If

                End If

            End If


            If (mykeynumber = Keys.Enter) Then

                If (ScoreManager.CheckifNewHighScore(Globals.SavedHumans) = True) Then
                    If (Me.HigscoreText.Length <= 0) Then
                        Me.HigscoreText = "NULL"

                    End If
                    ScoreManager.AddScore(Me.HigscoreText, Globals.SavedHumans, Globals.cash)

                End If


                Return Screens.MenuScreen

            End If

        End If
        If (Globals.GameOver = False) Then


            'updats the bullets
            bullets.Update()

            wave.Update()

            'paints the turret
            TurretManager.Update()




            'updates the turrets
            spawnturret.Update()

            entitymanager.Update()

            'update particles
            ' slowDownLoop -= 1
            '    If (slowDownLoop <= 0) Then
            particle.Update()
            '  slowDownLoop = 3
            'End If
        End If


        Return Screens.GameScreen
    End Function
End Class
