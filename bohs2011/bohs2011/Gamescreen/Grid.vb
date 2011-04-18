Public Class Grid
    Private grid As List(Of List(Of List(Of Integer))) = New List(Of List(Of List(Of Integer)))()

    Public Sub AddIndex(ByVal Index As Integer, ByVal Location As Point)
        grid.Item(Location.X).Item(Location.Y).Add(Index)
    End Sub

    'return a list of index
    Public Function getIndexes(ByVal Location As Point) As List(Of Integer)
        Return grid.Item(Location.X).Item(Location.Y)
    End Function

    Public Sub RemoveIndexes(ByVal Index As Integer, ByVal Location As Point)

    End Sub




End Class
