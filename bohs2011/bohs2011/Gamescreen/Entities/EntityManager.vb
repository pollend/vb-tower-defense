Public Class EntityManager
    Public Shared Spider As Bitmap = New Bitmap("Gamescreen\Entities\Entities\Spider\monster.png")

    'random
    Private random As Random = New Random(Now.Millisecond())

    'listed dead entities
    Public Shared DeadEntites As List(Of Integer) = New List(Of Integer)
    'the entity grid
    Public Shared EntityGrid As Grid = New Grid(1000 * 1.3, 1000 * 1.3)

    Private start As List(Of Point) = New List(Of Point)

    Public Shared Entities As List(Of Entity) = New List(Of Entity)
    Public Sub Load()
        start.Add(New Point(0, 0))
        start.Add(New Point(1, 0))
    End Sub

    Public Shared Function GetCollisionRect(ByVal index As Integer) As Rectangle
        Return New Rectangle(Entities.Item(index).location, Entities.Item(index).Size)

    End Function
    Public Sub AddEntity(ByVal entity As Entity)
        Entities.Add(entity)
        If (0 < DeadEntites.Count - 1) Then
            Entities(DeadEntites.Item(0)) = entity
            Entities(DeadEntites.Item(0)).Dead = False
            DeadEntites.RemoveAt(0)
        Else
            Entities.Add(entity)

        End If
    End Sub
    Public Shared Sub KillEntiy(ByVal index As Integer)
        DeadEntites.Add(index)
        EntityGrid.RemoveIndexe(index, Entities.Item(index).locationOnCollection)
        Entities(index).Dead = True
    End Sub
    Public Sub Update()

        AddEntity(New Spider(New Point(0, 0)))

        For X = 0 To Entities.Count() - 1
            If (Entities.Item(X).Dead = False) Then


                Entities.Item(X).Update(X)
                Dim newloc As Point = New Point(Entities.Item(X).NewLocation.X / 100, Entities.Item(X).location.Y / 100)

                EntityGrid.RemoveIndexe(X, Entities.Item(X).locationOnCollection)
                Entities.Item(X).locationOnCollection = newloc
                EntityGrid.AddIndex(X, Entities.Item(X).locationOnCollection)


                Entities.Item(X).location = Entities.Item(X).NewLocation
            End If
        Next

    End Sub
    Public Sub paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        For X = 0 To Entities.Count() - 1
            If (Entities.Item(X).Dead = False) Then
                Entities.Item(X).Draw(e)
            End If
        Next
    End Sub

End Class
