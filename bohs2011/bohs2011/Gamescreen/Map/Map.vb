Public Class Map
    Public quad As List(Of List(Of Bitmap)) = New List(Of List(Of Bitmap))
    Public Sub Seperate()
        Dim map As Bitmap = New Bitmap("C:\Users\michael\Desktop\bohs-game\bohs2011\bohs2011\Gamescreen\Map\Maps\map.png")
        For X = 0 To (map.Width / 100)
            quad.Add(New List(Of Bitmap))

            For Y = 0 To (map.Height / 100)

                Dim basemap As Bitmap = New Bitmap(100, 100)


                quad(X).Add(basemap)


            Next
        Next

    End Sub


End Class
