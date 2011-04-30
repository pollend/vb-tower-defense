Public Class GameScreen
    Implements IScreen
    Public entitymanager As EntityManager = New EntityManager()
    'moves the camera
    Private cam As Camera = New Camera

    'turret manager
    Private TurretManager As TurretManager

    'spawning turret manger
    Private spawnturret As SpawnTurrets = New SpawnTurrets()

    Private map As New Map
    Public Sub Load() Implements IScreen.Load
        'sets points on point grid
        PointGrid.SetPoint()

        'loads the entity manager
        entitymanager.Load()

    End Sub

    Public Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs) Implements IScreen.Paint
        'draw buttons
        spawnturret.Draw(e)

        map.Draw(e)
        'draw the entities
        entitymanager.paint(e)

    End Sub

    Public Function Update() As Screens Implements IScreen.Update

        entitymanager.Update()
        'updates the postion
        cam.UpdatePosition()

        'updates the turrets
        spawnturret.Update()
        Return Screens.GameScreen
    End Function
End Class
