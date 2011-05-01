Public Class Turret

    'follow the specific entity
    Public TilesLinkedTo As List(Of Point) = New List(Of Point)
    Public Skip As Boolean
    Public location As Point
    Public Followed As Point
    Public CollisionRectangle As Rectangle
    Public Sub New()

    End Sub
    Public Sub New(ByRef turret As Turret)
        TilesLinkedTo = New List(Of Point)(turret.TilesLinkedTo)
        Skip = turret.Skip

        location = turret.location
        Followed = turret.Followed
        CollisionRectangle = turret.CollisionRectangle
    End Sub

    Public Overridable Sub SetTurret(ByVal Location As Point)

    End Sub
    Public Overridable Sub Update()
        CollisionRectangle = New Rectangle(location.X, location.Y, CollisionRectangle.Width, CollisionRectangle.Height)

    End Sub
    Public Sub fireBullet()

    End Sub
    'paint function
    Public Overridable Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub
End Class
