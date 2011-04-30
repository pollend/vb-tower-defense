Public Class TurretManager
    Public Shared TurretGrid As Grid
    Private Shared Turrets As List(Of Turret) = New List(Of Turret)

    Public Shared Sub AddTurret(ByVal typeofturret As Turret)
        Dim TilesOn(3) As Point
        Turrets.Add(typeofturret)
        TilesOn(0) = New Point(typeofturret.location.X / 100, typeofturret.location.Y / 100)
        TilesOn(1) = New Point(typeofturret.location.X + typeofturret.CollisionRectangle.Width / 100, typeofturret.location.Y / 100)
        TilesOn(2) = New Point(typeofturret.location.X / 100, typeofturret.location.Y + typeofturret.CollisionRectangle.Height / 100)
        TilesOn(3) = New Point(typeofturret.location.X + typeofturret.CollisionRectangle.Width / 100, typeofturret.location.Y + typeofturret.CollisionRectangle.Height / 100)
        'weeds out duplicate indexes
        For SelectedTile = 0 To TilesOn.Length
            For index = 1 To TilesOn.Length
                If (TilesOn(SelectedTile) = TilesOn(index)) Then
                    TilesOn(index) = New Point(-1, -1)
                End If
            Next

        Next

        'assignes them to the list
        For SelectedTile = 0 To TilesOn.Length
            If Not (TilesOn(SelectedTile) = New Point(-1, -1)) Then
                Turrets.Item(Turrets.Count - 1).TilesLinkedTo.Add(TilesOn(SelectedTile))

                TurretGrid.AddIndex(Turrets.Count - 1, TilesOn(SelectedTile))
            End If
        Next
    End Sub
End Class
