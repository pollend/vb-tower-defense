Public Class EntityManager
    Public Shared Spider As Bitmap = New Bitmap("Gamescreen\Entities\Entities\Spider\monster.png")

    'random
    Private random As Random = New Random(Now.Millisecond())

    'the entity grid
    Public Shared EntityGrid As Grid = New Grid(1000 * 1.3, 1000 * 1.3)

    Private start As List(Of Point) = New List(Of Point)

    Public Entities As List(Of Entity) = New List(Of Entity)
    Public Sub Load()
        start.Add(New Point(0, 0))
        start.Add(New Point(1, 0))





    End Sub
    Public Sub Update()
        Entities.Add(New Spider(start(random.Next(0, 2))))


        For X = 0 To Entities.Count() - 1
            Entities.Item(X).Update()
            If (Not (Entities.Item(X).NewLocation.X / 100 = Entities.Item(X).location.X / 100) And Not (Entities.Item(X).location.Y / 100 = Entities.Item(X).NewLocation.Y / 100)) Then

                EntityGrid.RemoveIndexe(X, New Point(Entities.Item(X).location.X / 100, Entities.Item(X).NewLocation.Y / 100))
                EntityGrid.AddIndex(X, New Point(Entities.Item(X).NewLocation.X / 100, Entities.Item(X).NewLocation.Y / 100))
            End If
            Entities.Item(X).location = Entities.Item(X).NewLocation
        Next

    End Sub
    Public Sub paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        For X = 0 To Entities.Count() - 1
            Entities.Item(X).Draw(e)
        Next
    End Sub

End Class
