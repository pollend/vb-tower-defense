Public Class GameScreen
    Implements IScreen
    Private TopImage As Bitmap = New Bitmap("Gamescreen\Top\top.png")

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


        'draw buttons always on top
        spawnturret.Draw(e)
        e.Graphics.DrawImage(TopImage, New Point((((Form1.Width) / 2) - (TopImage.Width / 2)) - Form1.CameraLocation.X, 0 - Form1.CameraLocation.Y))
        e.Graphics.DrawString(Globals.SavedHumans, New Font("Arial", 5), Brushes.Black, New Point(((Form1.Width) / 2) - (TopImage.Width / 2) - Form1.CameraLocation.X + 50, 0 - Form1.CameraLocation.Y))
        e.Graphics.DrawString(Globals.cash, New Font("Arial", 5), Brushes.Black, New Point(((Form1.Width) / 2) - (TopImage.Width / 2) - Form1.CameraLocation.X + 50, 15 - Form1.CameraLocation.Y))

    End Sub
    Private slowDownLoop As Integer
    Public Function Update() As Screens Implements IScreen.Update
        'updates the postion
        cam.UpdatePosition()
        spawnturret.UpdateButtonPosition()

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
