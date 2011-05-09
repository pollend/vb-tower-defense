Public Class Turret


    'follow the specific entity
    Public attackRadius As Rectangle
    Public TilesLinkedTo As List(Of Point) = New List(Of Point)
    Public Dead As Boolean = False
    Public location As Point
    Public EnitiyToFollow As Integer
    Public CollisionRectangle As Rectangle
    Public Sub New()

    End Sub
    Public Sub New(ByRef turret As Turret)
        TilesLinkedTo = New List(Of Point)(turret.TilesLinkedTo)
        Dead = turret.Dead

        location = turret.location

        CollisionRectangle = turret.CollisionRectangle
    End Sub

    Public Overridable Sub SetTurret(ByVal Location As Point)

    End Sub
    Public Overridable Sub Update(ByVal myindex As Integer)
        If (Dead = False) Then

            CollisionRectangle = New Rectangle(location.X, location.Y, CollisionRectangle.Width, CollisionRectangle.Height)

        End If
    End Sub

    'paint function
    Public Overridable Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
      
    End Sub
End Class
