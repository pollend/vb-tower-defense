Public Class Score
    Public HumansSaved As Integer
    Public Resources As Integer
    Public Name As String

End Class

Public Class HighScoreManager
    Private score As List(Of Score) = New List(Of Score)

    Private fileLocation As String = "C:\Users\Michael\Documents\Games\TowerDefense.bin"


    Public Shared Sub AddHighScore(ByVal score As Score)
        Try

            Dim fileStream As IO.FileStream = New IO.FileStream(fileLocation, IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite, IO.FileShare.ReadWrite)

            Dim binaryWriter As IO.BinaryWriter = New IO.BinaryWriter(fileStream)

        Catch ex As Exception

        End Try


    End Sub
    Public Function GetData()

    End Function
End Class
