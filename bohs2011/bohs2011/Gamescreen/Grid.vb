Public Class Grid
    Private grid As List(Of List(Of List(Of Integer))) = New List(Of List(Of List(Of Integer)))()

    Public Sub AddIndex(ByVal Index As Integer, ByVal Location As Point)
        grid.Item(Location.X).Item(Location.Y).Add(Index)
    End Sub

    'return a list of index
    Public Function getIndexes(ByVal Location As Point) As List(Of Integer)
        Return grid.Item(Location.X).Item(Location.Y)
    End Function

    Public Sub RemoveIndexe(ByVal Index As Integer, ByVal Location As Point)

        For Index = 0 To grid(Location.X).Item(Location.Y).Count - 1
            'runs through the grid and finds the index
            If (grid(Location.X).Item(Location.Y).Item(Index) = Index) Then
                grid(Location.X).Item(Location.Y).RemoveAt(Index)
                Exit For
            End If
        Next

    End Sub




End Class
