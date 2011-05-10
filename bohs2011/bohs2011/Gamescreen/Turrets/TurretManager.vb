Public Class TurretManager
    Public Shared TurretGrid As Grid = New Grid(1000 * 1.3, 1000 * 1.3)
    Public Shared Turrets As List(Of Turret) = New List(Of Turret)
    Public Shared DeadTurrets As List(Of Integer) = New List(Of Integer)
    Public Shared Sub AddDeadTurret(ByVal index As Integer)
        Turrets.Item(index).Dead = True
        DeadTurrets.Add(index)
    End Sub

    Public Shared Function AddTurret(ByVal typeofturret As Turret, ByVal location As Point, ByVal rect As Rectangle) As Boolean
        Dim TilesOn(3) As Point
        TilesOn(0) = New Point(location.X / 100, location.Y / 100)
        TilesOn(1) = New Point((location.X + rect.Width) / 100, location.Y / 100)
        TilesOn(2) = New Point(location.X / 100, (location.Y + rect.Height) / 100)
        TilesOn(3) = New Point((location.X + rect.Width) / 100, (location.Y + rect.Height) / 100)
        'weeds out duplicate indexes
        Dim emptypoint As Point = New Point(-1, -1)
        For SelectedTile = 0 To TilesOn.Length - 1
            For index = 0 To TilesOn.Length - 1
                If index = SelectedTile Then
                    Continue For
                End If
                If Not (emptypoint.Equals(TilesOn(index))) Then

                    If (TilesOn(SelectedTile).Equals(TilesOn(index))) Then
                        TilesOn(index) = emptypoint

                    End If

                End If
            Next
        Next
        'check if it is possible to place turret

        For index = 0 To TilesOn.Length - 1
            If Not (TilesOn(index) = New Point(-1, -1)) Then
                Dim TurretGridValues As List(Of Integer) = TurretGrid.getIndexes(TilesOn(index))
                Dim entitygridvalues As List(Of Integer) = EntityManager.EntityGrid.getIndexes(TilesOn(index))

                For CompareEntites = 0 To entitygridvalues.Count - 1
                    If (EntityManager.GetCollisionRect(entitygridvalues.Item(CompareEntites)).IntersectsWith(New Rectangle(location.X, location.Y, rect.Width, rect.Height))) Then
                        'found the location invalid because of entity
                        Return False
                    End If
                Next
                For CompareTurrets = 0 To TurretGridValues.Count - 1
                    If (Turrets.Item(TurretGridValues.Item(CompareTurrets)).Dead = False) Then
                        If (Turrets.Item(TurretGridValues.Item(CompareTurrets)).CollisionRectangle.IntersectsWith(New Rectangle(location.X, location.Y, rect.Width, rect.Height))) Then
                            'found the loction is invalid becasue of turret
                            Return False
                        End If

                    End If
                Next


            End If
        Next



        typeofturret.location = location
        typeofturret.CollisionRectangle = rect
        If (DeadTurrets.Count - 1 > 0) Then
            Turrets.Item(DeadTurrets.Item(DeadTurrets.Count - 1)) = typeofturret
            DeadTurrets.RemoveAt(DeadTurrets.Count - 1)
        Else
            Turrets.Add(typeofturret)
        End If
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
            If (Turrets.Item(index).Dead = False) Then

                Turrets(index).Paint(e)

            End If
        Next

    End Sub
    'updates all the turrets
    Public Sub Update()
        For index = 0 To Turrets.Count - 1
            If (Turrets(index).Dead = False) Then

                Turrets(index).Update(index)

            End If
        Next
    End Sub
End Class
