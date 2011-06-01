Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> Public Class MyScore
    Public SaveHumans As Integer
    Public Cash As Integer
    Public Name As String
End Class

Public Class ScoreManager

    Private Shared Score As List(Of MyScore) = New List(Of MyScore)
    Public Sub AddScore(ByVal myscore As MyScore)
        Score.Add(myscore)
        Dim serializer As New BinaryFormatter
        serializer.Serialize(FileStream, Score)

    End Sub

    Private FileStream As IO.FileStream = New IO.FileStream("C:\Users\Michael\Desktop\Vbproj\bohs2011\bohs2011\Score.bin", IO.FileMode.OpenOrCreate)

    Public Sub New()
        Try
            Dim serializer As New BinaryFormatter
            Score = serializer.Deserialize(FileStream)
        Catch ex As Exception
            Dim serializer As New BinaryFormatter
            serializer.Serialize(FileStream, Score)
        End Try

    End Sub


End Class
