Public Class TurretManager
    Public Shared TurretGrid As Grid = New Grid(1000, 1000)
    Private Shared Turrets As List(Of Turret) = New List(Of Turret)

    Public Shared Function AddTurret(ByVal typeofturret As Turret, ByVal location As Point, ByVal rect As Rectangle) As Boolean
        Dim TilesOn(3) As Point
        TilesOn(0) = New Point(location.X / 100, location.Y / 100)
        TilesOn(1) = New Point(location.X + rect.Width / 100, location.Y / 100)
        TilesOn(2) = New Point(location.X / 100, location.Y + rect.Height / 100)
        TilesOn(3) = New Point(location.X + rect.Width / 100, location.Y + rect.Height / 100)
        'weeds out duplicate indexes
        For SelectedTile = 0 To TilesOn.Length - 1
            For index = 1 To TilesOn.Length - 1
                If (TilesOn(SelectedTile) = TilesOn(index)) Then
                    TilesOn(index) = New Point(-1, -1)
                End If
            Next
        Next
        'check if it is possible to place turret

        For index = 0 To TilesOn.Length - 1
            If Not (TilesOn(index) = New Point(-1, -1)) Then
                Dim TurretGridValues As List(Of Integer) = TurretGrid.getIndexes(TilesOn(index))

                For CompareTurrets = 0 To TurretGridValues.Count - 1
                    If (Turrets.Item(TurretGridValues.Item(CompareTurrets)).CollisionRectangle.IntersectsWith(typeofturret.CollisionRectangle)) Then
                        'found the location invalid
                        Return False
                    End If
                Next

            End If
        Next

        'turret.ReferenceEquals()


        typeofturret.location = location
        typeofturret.CollisionRectangle = rect

        Turrets.Add(typeofturret)
        'assignes them to the list
        For SelectedTile = 0 To TilesOn.Length - 1
            If Not (TilesOn(SelectedTile) = New Point(-1, -1)) Then
                Turrets.Item(Turrets.Count - 1).TilesLinkedTo.Add(TilesOn(SelectedTile))
                TurretGrid.AddIndex(Turrets.Count - 1, TilesOn(SelectedTile))
            End If
        Next
        Return True
    End Function
    'paints all the turrets
    Public Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)

        For index = 0 To Turrets.Count - 1
            Turrets(index).Paint(e)
        Next

    End Sub
    'updates all the turrets
    Public Sub Update()
        For index = 0 To Turrets.Count - 1
            Turrets(index).Update()
        Next
    End Sub
End Class
