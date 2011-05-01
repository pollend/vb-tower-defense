Public Class Grid
    Private grid As List(Of List(Of List(Of Integer))) = New List(Of List(Of List(Of Integer)))()

    Public Sub New(ByVal width As Integer, ByVal height As Integer)
        Dim X As Integer = width / 100
        Dim Y As Integer = height / 100

        For XWidth = 0 To X
            grid.Add(New List(Of List(Of Integer)))

            For YHeight = 0 To Y
                grid.Item(XWidth).Add(New List(Of Integer))

            Next

        Next

    End Sub

    Public Sub AddIndex(ByVal Index As Integer, ByVal Location As Point)
        grid.Item(Location.X).Item(Location.Y).Add(Index)
    End Sub

    'return a list of index
    Public Function getIndexes(ByVal Location As Point) As List(Of Integer)
        Try

            Return grid.Item(Location.X).Item(Location.Y)
        Catch ex As Exception

        End Try
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
