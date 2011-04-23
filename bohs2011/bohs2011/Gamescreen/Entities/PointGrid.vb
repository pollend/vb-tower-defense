Public Class LPoint
    Public Sub New(ByVal location As Point, ByVal newLocationGrid As List(Of Point))

    End Sub

    'location points used for AI
    Public location As Point
    Public NewLocationGrid As List(Of Point)
End Class

Public Class PointGrid
    Public Shared Points As List(Of List(Of LPoint)) = New List(Of List(Of LPoint))
    Public Shared Sub SetPoint()

        For X = 0 To 1
            Points.Add(New List(Of LPoint))
            For Y = 0 To 0
                Points(X).Add(New LPoint(New Point(0, 0), New List(Of Point)))
            Next
        Next
        Dim NewGridLocation As List(Of Point) = New List(Of Point)
        NewGridLocation.Add(New Point(1, 0))
        Points(0).Item(0).NewLocationGrid = NewGridLocation

        NewGridLocation = New List(Of Point)
        NewGridLocation.Add(New Point(0, 0))
        Points(1).Item(0).NewLocationGrid = NewGridLocation
        Points(1).Item(0).location = New Point(100, 100)

    End Sub
    Public Shared Sub CheackDistance(ByVal Location As Point)


    End Sub

End Class
