Public Class Turret

    'follow the specific entity
    Public TilesLinkedTo As List(Of Point)
    Public Skip As Boolean
    Public location As Point
    Public Followed As Point
    Public CollisionRectangle As Rectangle
    Public Overridable Sub SetTurret(ByVal Location As Point)

    End Sub
    Public Overridable Sub Update()

    End Sub
    Public Sub fireBullet()

    End Sub
    'paint function
    Public Overridable Sub Paint()

    End Sub
End Class
