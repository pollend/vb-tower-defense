Public Class Entity

    Public Dead As Boolean

    'collision rectangle

    'Location on Grid
    Public GridLocation As Point
    Public pointToGoTo As Point

    'the set health of the entity
    Public heath As Integer

    'location with the new location
    Public location As Point = New Point(0, 0)

    'the set location
    Public NewLocation As Point
    Public random As Random = New Random(Now.Millisecond)


    Public Sub New(ByVal setLocation As Point)
        Me.NewLocation = setLocation
        Me.GridLocation = setLocation
        Me.location = PointGrid.Points.Item(setLocation.X).Item(setLocation.Y).location
        Me.NewLocation = PointGrid.Points.Item(setLocation.X).Item(setLocation.Y).location
        Me.pointToGoTo = PointGrid.Points.Item(setLocation.X).Item(setLocation.Y).location + New Point(random.Next(-50, 50))
    End Sub



    Public Overridable Sub Update()
        If (VectorFormula.Distance(location, Me.pointToGoTo) < 5) Then
            GridLocation = PointGrid.Points.Item(GridLocation.X).Item(GridLocation.Y).NewLocationGrid.Item(0)
            Me.pointToGoTo = PointGrid.Points.Item(GridLocation.X).Item(GridLocation.Y).location + New Point(random.Next(-50, 50), random.Next(-50, 50))

        End If
        NewLocation += VectorFormula.MoveInDirection(Me.pointToGoTo, location, 3, New Point(0, 0))




        'check for collisions with turret
        Dim Getturrets As List(Of Integer) = TurretManager.TurretGrid.getIndexes(New Point(Me.location.X / 100, Me.location.Y / 100))
        If Not (Getturrets Is Nothing) Then

            For index = 0 To Getturrets.Count - 1
                If (TurretManager.Turrets.Item(Getturrets.Item(index)).CollisionRectangle.IntersectsWith(New Rectangle(location, New Size(20 * VectorFormula.scaling, 20 * VectorFormula.scaling)))) Then
                    NewLocation = location
                End If
            Next
        End If



    End Sub
    Public Overridable Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

End Class
