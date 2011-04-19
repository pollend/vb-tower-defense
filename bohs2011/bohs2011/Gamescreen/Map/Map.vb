Public Class Map
    Public quad As List(Of List(Of Bitmap)) = New List(Of List(Of Bitmap))
    Public Sub Seperate()
        Dim map As Bitmap = New Bitmap("bohs2011\Gamescreen\Map\Maps\map.png")
        For X = 0 To (map.Width / 100)
            quad.Add(New Object)

            For Y = 0 To (map.Height / 100)


            Next
        Next

    End Sub


End Class
