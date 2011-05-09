Public Class GameScreen
    Implements IScreen
    'manges the bullets
    Public bullets As BulletManager = New BulletManager()

    Private entitymanager As EntityManager = New EntityManager()
    'moves the camera
    Private cam As Camera = New Camera

    'turret manager
    Private TurretManager As TurretManager = New TurretManager()

    'spawning turret manger
    Private spawnturret As SpawnTurrets = New SpawnTurrets()

    Private map As New Map
    Public Sub Load() Implements IScreen.Load
        'sets points on point grid
        PointGrid.SetPoint()

        'loads the entity manager
        entitymanager.Load()

        '
    End Sub

    Public Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs) Implements IScreen.Paint

        map.Draw(e)

        'draw buttons
        spawnturret.Draw(e)

        'draws the bullets
        bullets.Draw(e)
        'draw the entities
        entitymanager.paint(e)

        'draws the turrets
        TurretManager.Paint(e)

    End Sub

    Public Function Update() As Screens Implements IScreen.Update
        'paints the turret
        TurretManager.Update()

        entitymanager.Update()
        'updates the postion
        cam.UpdatePosition()
        'updats the bullets
        bullets.Update()

        'updates the turrets
        spawnturret.Update()
        Return Screens.GameScreen
    End Function
End Class
