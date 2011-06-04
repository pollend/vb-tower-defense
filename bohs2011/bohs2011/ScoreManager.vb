Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> Public Class MyScore
    Public SaveHumans As Integer
    Public Cash As Integer
    Public Name As String
    Public Sub New(ByVal name As String, ByVal cash As Integer, ByVal savedhumans As Integer)
        Me.Name = name
        Me.Cash = cash
        Me.SaveHumans = savedhumans
    End Sub
    Public Sub New()

    End Sub
End Class

Public Class ScoreManager
    Private Shared Location As String = System.Environment.CurrentDirectory & "\Score.SECURE"
    Private Shared Score As List(Of MyScore) = New List(Of MyScore)
    Public Shared Function GetScore() As List(Of MyScore)
        Return Score
    End Function
    Public Shared Function CheckifNewHighScore(ByVal MYscore As Integer) As Boolean

        Dim largestSavedHumanScore As Integer
        If (Score.Count <= 6) Then
            Return True

        End If
        For index = 0 To Score.Count - 1
            If (MYscore > Score.Item(index).SaveHumans) Then
                If (largestSavedHumanScore > Score.Item(index).SaveHumans) Then
                    Return True
                    largestSavedHumanScore = Score.Item(index).SaveHumans
                End If
            End If
        Next
        Return False
    End Function

    Public Shared Sub AddScore(ByVal name As String, ByVal savedhumans As Integer, ByVal cash As Integer)
        Dim MyScore As MyScore = New MyScore
        MyScore.Cash = cash
        MyScore.Name = name
        MyScore.SaveHumans = savedhumans


        Dim choosenLocationIndex As Integer

        For index = 0 To Score.Count - 1
            If (MyScore.SaveHumans > Score.Item(index).SaveHumans) Then

                choosenLocationIndex = index
                Exit For

            End If
        Next
    
            Score.Insert(choosenLocationIndex, MyScore)



        If (Score.Count > 6) Then
            Score.RemoveAt(Score.Count - 1)

        End If
        Dim serializer As New BinaryFormatter
        Dim fs As FileStream = New FileStream(Location, FileMode.Create)
        serializer.Serialize(fs, Score)
        'fs = File.Create(Location)
        fs.Close()



    End Sub


    Public Sub New()
        Dim fs As FileStream '= File.OpenRead(Location)
        Try
            fs = File.OpenRead(Location)
            Dim serializer As New BinaryFormatter
            Score = serializer.Deserialize(fs)
            fs.Close()

        Catch ex As Exception


            Try
                Dim serializer As New BinaryFormatter
                fs = New FileStream(Location, FileMode.OpenOrCreate)
                Score = New List(Of MyScore)
                Score.Add(New MyScore("NULL", 0, 0))
                Score.Add(New MyScore("NULL", 0, 0))
                Score.Add(New MyScore("NULL", 0, 0))
                Score.Add(New MyScore("NULL", 0, 0))
                Score.Add(New MyScore("NULL", 0, 0))

                serializer.Serialize(fs, Score)
                fs = File.Create(Location)
                fs.Close()

            Catch se As Exception

            End Try
        End Try

    End Sub


End Class
