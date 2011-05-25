Public Class TurretManager
    Public Shared TurretGrid As Grid = New Grid(1000 * 1.3, 1000 * 1.3)
    Public Shared Turrets As List(Of Turret) = New List(Of Turret)
    Public Shared DeadTurrets As List(Of Integer) = New List(Of Integer)
    ' the timer before the game locks the player out
    Private pausetimer As Integer = 10

    Public Sub New()

    End Sub
    Public Sub Load()

        'sets up the homebase items
        HomeBaseAssets.SetUp()
        'sets up the blast assets
        BlastAssets.SetUp()


    End Sub
    Public Shared Sub AddDeadTurret(ByVal index As Integer)
        Turrets.Item(index).Dead = True

        For linkedto = 0 To Turrets.Item(index).TilesLinkedTo.Count - 1
            TurretGrid.RemoveIndexe(index, Turrets.Item(index).TilesLinkedTo.Item(linkedto))
        Next

        DeadTurrets.Add(index)
    End Sub

    Public Shared Function AddTurret(ByVal typeofturret As Turret, ByVal location As Point, ByVal size As Point) As Boolean
        If Not (location.X > 0 And location.X < TurretGrid.GetWidth And location.Y > 0 And location.Y < TurretGrid.GetHeight) Then
            'wont allow a turret to be placed outside the map
            Return False

        End If


        Dim TilesOn(3) As Point
        TilesOn(0) = New Point(location.X / Grid.GridSpacing, location.Y / Grid.GridSpacing)
        TilesOn(1) = New Point((location.X + size.X) / Grid.GridSpacing, location.Y / Grid.GridSpacing)
        TilesOn(2) = New Point(location.X / Grid.GridSpacing, (location.Y + size.Y) / Grid.GridSpacing)
        TilesOn(3) = New Point((location.X + size.X) / Grid.GridSpacing, (location.Y + size.Y) / Grid.GridSpacing)
        'weeds out duplicate indexes
        '   Dim emptypoint As Point = New Point(-1, -1)
        '     For SelectedTile = 0 To TilesOn.Length - 1
        '     For index = 0 To TilesOn.Length - 1
        '      If index = SelectedTile Then
        'Continue For
        '    End If
        '      If Not (emptypoint.Equals(TilesOn(index))) Then

        ''       If (TilesOn(SelectedTile).Equals(TilesOn(index))) Then
        '        TilesOn(index) = emptypoint

        ' End If
        '
        '        End If
        '     Next
        '  Next
        'check if it is possible to place turret

        For index = 0 To TilesOn.Length - 1
            If Not (TilesOn(index) = New Point(-1, -1)) Then



                Dim TurretGridValues As List(Of Integer) = TurretGrid.getIndexes(TilesOn(index))
                Dim entitygridvalues As List(Of Integer) = EntityManager.EntityGrid.getIndexes(TilesOn(index))
                'test if entity is in location
                For CompareEntites = 0 To entitygridvalues.Count - 1
                    If (EntityManager.Entities.Item(entitygridvalues.Item(CompareEntites)).Dead = False) Then

                        If (EntityManager.GetCollisionRect(entitygridvalues.Item(CompareEntites)).IntersectsWith(New Rectangle(location.X, location.Y, size.X, size.Y))) Then
                            'found the location invalid because of entity
                            Return False
                        End If
                    End If
                Next
                For CompareTurrets = 0 To TurretGridValues.Count - 1
                    'test if turret is in location
                    If (Turrets.Item(TurretGridValues.Item(CompareTurrets)).Dead = False) Then

                        If (New Rectangle(Turrets.Item(TurretGridValues.Item(CompareTurrets)).location, Turrets.Item(TurretGridValues.Item(CompareTurrets)).Size).IntersectsWith(New Rectangle(location.X, location.Y, size.X, size.Y))) Then

                            'found the loction is invalid becasue of turret
                            Return False
                        End If
                    End If

                Next


            End If
        Next

        Dim myindexoncollection = 0

        typeofturret.location = location
        typeofturret.Size = size
        If (DeadTurrets.Count - 1 > 0) Then
            Turrets.Item(DeadTurrets.Item(0)) = typeofturret
            myindexoncollection = DeadTurrets.Item(0)
            DeadTurrets.RemoveAt(0)
        Else
            Turrets.Add(typeofturret)
            myindexoncollection = Turrets.Count - 1
        End If
        'assignes them to the list
        For X = TilesOn(0).X To TilesOn(1).X

            For Y = TilesOn(0).Y To TilesOn(2).Y

                Turrets.Item(myindexoncollection).TilesLinkedTo.Add(New Point(X, Y))
                TurretGrid.AddIndex(myindexoncollection, New Point(X, Y))
            Next
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
        'checks homebase since its always ZERo
        If (Turrets.Item(0).health <= 0) Then

            For index = 1 To 20
                Dim rand As Random = New Random(Now.Millisecond + index)
                ParticleManager.AddParticle(New FireToSmoke, Turrets.Item(0).location + New Point(rand.Next(0, Turrets.Item(0).Size.X), rand.Next(0, Turrets.Item(0).Size.Y)), index + Now.Minute)
                ParticleManager.AddParticle(New MedalChunks, Turrets.Item(0).location + New Point(rand.Next(0, Turrets.Item(0).Size.X), rand.Next(0, Turrets.Item(0).Size.Y)), index + Now.Minute)
            Next
            Me.pausetimer -= 1
            If (pausetimer < 0) Then
                Globals.GameOver = True
            End If

        End If

        For index = 0 To Turrets.Count - 1
            If (Turrets(index).Dead = False) Then

                Turrets(index).Update(index)

            End If


        Next
    End Sub
End Class
