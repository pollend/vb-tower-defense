Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> Public Class MyScore
    Public SaveHumans As Integer
    Public Cash As Integer
    Public Name As String
End Class

Public Class ScoreManager
    Private Shared Location As String = System.Environment.CurrentDirectory & "/Score.bin"
    Private Shared Score As List(Of MyScore) = New List(Of MyScore)
    Public Shared Sub AddScore(ByVal name As String, ByVal savedhumans As Integer, ByVal cash As Integer)
        Dim MyScore As MyScore = New MyScore
        MyScore.Cash = cash
        MyScore.Name = name
        MyScore.SaveHumans = savedhumans
        Score.Add(MyScore)

        Dim choosenLocationIndex As Integer
        Dim largestSavedHumanScore As Integer
        For index = 0 To Score.Count - 1
            If (savedhumans > Score.Item(index).SaveHumans) Then
                If (largestSavedHumanScore > Score.Item(index).SaveHumans) Then
                    choosenLocationIndex = index
                    largestSavedHumanScore = Score.Item(index).SaveHumans
                End If
            End If
        Next

        Dim serializer As New BinaryFormatter
        Dim fs As FileStream = File.Create(Location)
        Score = serializer.Deserialize(fs)

    End Sub


    Public Sub New()
        Try
            Dim fs As FileStream = File.OpenRead(Location)
            Dim serializer As New BinaryFormatter
            Score = serializer.Deserialize(fs)
        Catch ex As Exception

        End Try

    End Sub


End Class
