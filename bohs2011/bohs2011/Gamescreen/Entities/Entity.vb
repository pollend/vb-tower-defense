﻿Public Class Entity

    Public Dead As Boolean = False

    'collision rectangle
    Public Size As Point
    'Location on Grid
    Public GridLocation As Point
    Public pointToGoTo As Point

    'myindex
    Public myindex As Integer

    'the set health of the entity
    Public heath As Integer

    'location with the new location
    Public location As Point = New Point(0, 0)

    Public dmg As Integer
    Public speedRedution As Integer



    Public speed As Integer
    'the set location
    Public NewLocation As Point
    Public random As Random = New Random(Now.Millisecond)

    Public locationOnCollection As Point


    Public Sub New(ByVal setLocation As Point)
        Me.NewLocation = setLocation
        Me.GridLocation = setLocation
        Me.location = PointGrid.Points.Item(setLocation.X).Item(setLocation.Y).location
        Me.NewLocation = PointGrid.Points.Item(setLocation.X).Item(setLocation.Y).location
        Me.pointToGoTo = PointGrid.Points.Item(setLocation.X).Item(setLocation.Y).location + New Point(random.Next(-50, 50))
    End Sub



    Public Overridable Sub Update(ByVal MYindex As Integer)
        If (VectorFormula.Distance(location, Me.pointToGoTo) < 5) Then
            GridLocation = PointGrid.Points.Item(GridLocation.X).Item(GridLocation.Y).NewLocationGrid.Item(0)
            Me.pointToGoTo = PointGrid.Points.Item(GridLocation.X).Item(GridLocation.Y).location + New Point(random.Next(-50, 50), random.Next(-50, 50))

        End If
        NewLocation += VectorFormula.MoveInDirection(Me.pointToGoTo, location, speed, New Point(0, 0))


        If (heath <= 0) Then
            Me.Dead = True
        End If

        'check for collisions with turret
        Dim Getturrets As List(Of Integer) = TurretManager.TurretGrid.getIndexes(New Point(Me.location.X / Grid.GridSpacing, Me.location.Y / Grid.GridSpacing))
        If Not (Getturrets Is Nothing) Then

            For index = 0 To Getturrets.Count - 1

                If (TurretManager.Turrets.Item(Getturrets.Item(index)).Dead = False) Then

                    If (New Rectangle(Me.location, Me.Size).IntersectsWith(New Rectangle(TurretManager.Turrets.Item(Getturrets.Item(index)).location, New Point(TurretManager.Turrets.Item(Getturrets.Item(index)).Size.X, TurretManager.Turrets.Item(Getturrets.Item(index)).Size.Y)))) Then
                        NewLocation = location
                        NewLocation -= VectorFormula.MoveAwayDirection(TurretManager.Turrets.Item(Getturrets.Item(index)).location + New Point((TurretManager.Turrets.Item(Getturrets.Item(index)).Size.X / 2), (TurretManager.Turrets.Item(Getturrets.Item(index)).Size.X / 2)), Me.location, 1, New Point(0, 0))

                        TurretManager.Turrets.Item(Getturrets.Item(index)).health -= Me.dmg
                        'pointToGoTo = New Point(random.Next(-20, 20), random.Next(-20, 20)) + pointToGoTo
                    End If

                End If
            Next
        End If

        'check collison with entities
        If (Me.location.X > 100 And Me.location.X < (1000 * VectorFormula.scaling) - 100) Then
            If (Me.location.Y > 100 And Me.location.Y < (1000 * VectorFormula.scaling) - 100) Then

                Dim GetEntities As List(Of Integer) = EntityManager.EntityGrid.getIndexes(New Point(Me.location.X / Grid.GridSpacing, Me.location.Y / Grid.GridSpacing))
                If Not (GetEntities Is Nothing) Then

                    For index = 0 To GetEntities.Count - 1
                        If (MYindex = GetEntities(index)) Then
                            Continue For
                        End If
                        If (EntityManager.Entities.Item(GetEntities.Item(index)).Dead = False) Then

                            If (New Rectangle(Me.location, Me.Size).IntersectsWith(New Rectangle(EntityManager.Entities.Item(GetEntities.Item(index)).location, New Point((EntityManager.Entities.Item(GetEntities.Item(index)).Size.X), (EntityManager.Entities.Item(GetEntities.Item(index)).Size.Y))))) Then
                                '  NewLocation = location
                                NewLocation -= VectorFormula.MoveAwayDirection(EntityManager.Entities.Item(GetEntities.Item(index)).location + New Point((EntityManager.Entities.Item(GetEntities.Item(index)).Size.X / 2), (EntityManager.Entities.Item(GetEntities.Item(index)).Size.Y / 2)), Me.location, 1, New Point(location.X - NewLocation.X, location.Y - NewLocation.Y))
                                'TurretManager.Turrets.Item(Getturrets.Item(index)).health -= Me.dmg
                                'pointToGoTo = New Point(random.Next(-20, 20), random.Next(-20, 20)) + pointToGoTo

                            End If

                        End If
                    Next

                End If
            End If
        End If




    End Sub
    Public Overridable Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

End Class
