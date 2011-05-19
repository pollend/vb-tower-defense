Public Class GameScreen
    Implements IScreen
    Private TopImage As Bitmap = New Bitmap("Gamescreen\Top\top.png")


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

        'loads the entity manager
        entitymanager.Load()

        '
        TurretManager.Load()
    End Sub

    Public Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs) Implements IScreen.Paint

        map.Draw(e)

        'draw the entities
        entitymanager.paint(e)

        'draws the turrets
        TurretManager.Paint(e)

        'draws the bullets
        bullets.Draw(e)

        'draw buttons
        spawnturret.Draw(e)
        e.Graphics.DrawImage(TopImage, New Point((((Form1.Width) / 2) - (TopImage.Width / 2)) - Form1.CameraLocation.X, 0 - Form1.CameraLocation.Y))
        e.Graphics.DrawString(Globals.cash, New Font("Arial", 5), Brushes.Black, New Point(((Form1.Width) / 2) - (TopImage.Width / 2) - Form1.CameraLocation.X + 50, 0 - Form1.CameraLocation.Y))
        e.Graphics.DrawString(Globals.cash, New Font("Arial", 5), Brushes.Black, New Point(((Form1.Width) / 2) - (TopImage.Width / 2) - Form1.CameraLocation.X + 50, 15 - Form1.CameraLocation.Y))

    End Sub

    Public Function Update() As Screens Implements IScreen.Update
        'updats the bullets
        bullets.Update()

        wave.Update()

        'paints the turret
        TurretManager.Update()


        'updates the postion
        cam.UpdatePosition()
    

        'updates the turrets
        spawnturret.Update()

        entitymanager.Update()
        Return Screens.GameScreen
    End Function
End Class
