Public Class Grid
    Private grid As List(Of List(Of List(Of Integer))) = New List(Of List(Of List(Of Integer)))()
    Private width As Integer
    Private height As Integer

    Public Function GetWidth()
        Return width
    End Function
    Public Function GetHeight()
        Return height
    End Function

    Public Sub New(ByVal width As Integer, ByVal height As Integer)
        Me.width = width
        Me.height = height
        Dim X As Integer = width / 100
        Dim Y As Integer = height / 100

        For XWidth = 0 To X + 1
            grid.Add(New List(Of List(Of Integer)))

            For YHeight = 0 To Y + 1
                grid.Item(XWidth).Add(New List(Of Integer))

            Next

        Next

    End Sub

    Public Sub AddIndex(ByVal Index As Integer, ByVal Location As Point)
        grid.Item(Location.X).Item(Location.Y).Add(Index)
    End Sub

    'return a list of index
    Public Function getIndexes(ByVal Location As Point) As List(Of Integer)
        If (Location.X >= 0 And Location.X < grid.Count - 1) Then
            If (Location.Y >= 0 And Location.Y < grid.Item(0).Count - 1) Then
                Return grid.Item(Location.X).Item(Location.Y)
            End If
        End If
        'System.Diagnostics.Debug.Print("Failure finding index")
        Return Nothing
    End Function

    Public Sub RemoveIndexe(ByVal Index As Integer, ByVal Location As Point)

        For MYIndex = 0 To grid(Location.X).Item(Location.Y).Count - 1
            If (grid(Location.X).Item(Location.Y).Count - 1 <= 0 Or MYIndex > grid(Location.X).Item(Location.Y).Count - 1) Then
                Exit For
            End If
            'runs through the grid and finds the index
            If (grid(Location.X).Item(Location.Y).Item(MYIndex) = Index) Then
                grid(Location.X).Item(Location.Y).RemoveAt(MYIndex)
                Exit For
            End If

        Next

    End Sub




End Class
