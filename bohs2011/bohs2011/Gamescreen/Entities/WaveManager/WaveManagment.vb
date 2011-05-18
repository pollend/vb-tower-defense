Public Enum TypesOfEntity
    Mech
    Spider

End Enum


Public Class WaveManagment
    Private TimeBetweenWaves As Integer = 20

    Private WaveLength As Integer = 50
    Private currentWaveLenght As Integer = 50

    Private timeBetweenSpawn As Integer = 9

    Private setvalues As Boolean = False


    Private Random As Random = New Random(Now.Millisecond + Now.Minute + (Now.Minute * Now.Millisecond))

    'values in spawns and items
    Private EntitesInWave As List(Of TypesOfEntity) = New List(Of TypesOfEntity)
    Private percentofEnemyInwave As List(Of Integer) = New List(Of Integer)

    Private start As List(Of Point) = New List(Of Point)
    Private PercentOfStartSpawn As List(Of Integer) = New List(Of Integer)

    Private WaveTime As Boolean
    Public Sub New()
        start.Add(New Point(0, 0))
        start.Add(New Point(1, 0))
    End Sub
    Private Sub SetUpEntitySpawn()

        'clears the collection
        percentofEnemyInwave.Clear()
        PercentOfStartSpawn.Clear()
        EntitesInWave.Clear()

        'intial set up of a new wave
        Dim myinexToReach As Integer = Random.Next(0, 4)
        For index = 0 To myinexToReach
            Select Case Random.Next(1, 3)
                Case 1
                    EntitesInWave.Add(TypesOfEntity.Mech)

                Case 2
                    EntitesInWave.Add(TypesOfEntity.Spider)
                Case Else

            End Select
        Next

        'the percent that an entity will spawn on a path
        Dim PercentLeft As Integer = 1000
        For index = 0 To start.Count - 1

            If (index >= start.Count - 1) Then
                PercentOfStartSpawn.Add(PercentLeft)
                Exit For
            Else
                Dim MyRandomPrecent As Integer = Random.Next(0, PercentLeft)
                PercentLeft -= MyRandomPrecent
                PercentOfStartSpawn.Add(MyRandomPrecent)
            End If
        Next

        'the percent of the enemy in the wave
        Dim PercentLeftForentiesInWave As Integer = 1000
        For index = 0 To EntitesInWave.Count - 1

            If (index >= EntitesInWave.Count - 1) Then
                percentofEnemyInwave.Add(PercentLeft)
                Exit For
            Else
                Dim MyRandomPercent As Integer = Random.Next(0, PercentLeft)
                PercentLeftForentiesInWave -= MyRandomPercent
                percentofEnemyInwave.Add(MyRandomPercent)
            End If
        Next


    End Sub
    Private Sub SpawnEntities()
        Dim SetEntity As Integer = 0
        Dim SetPoint As Integer = 0

        Dim choosenpoint As Integer = Random.Next(0, 1000)
        Dim choosenEntity As Integer = Random.Next(0, 1000)
        For index = 0 To start.Count - 1
            If (index = 0) Then
                If (choosenpoint < PercentOfStartSpawn.Item(index) And choosenpoint > 0) Then
                    SetPoint = index
                End If
            Else
                If (choosenpoint > PercentOfStartSpawn.Item(index - 1) And (choosenpoint < PercentOfStartSpawn.Item(index))) Then
                    SetPoint = index
                End If
            End If
        Next

        For index = 0 To EntitesInWave.Count - 1
            If (index = 0) Then
                If (choosenpoint < percentofEnemyInwave.Item(index) And choosenpoint > 0) Then
                    SetEntity = index
                End If
            Else
                If (choosenpoint > percentofEnemyInwave.Item(index - 1) And (choosenpoint < percentofEnemyInwave.Item(index))) Then
                    SetEntity = index

                End If
            End If
        Next

        Select Case EntitesInWave.Item(SetEntity)
            Case TypesOfEntity.Spider
                EntityManager.AddEntity(New Spider(start(SetPoint)))

            Case TypesOfEntity.Mech

                EntityManager.AddEntity(New Mech(start(SetPoint)))
            Case Else

        End Select


    End Sub

    Public Sub Update()
        If (TimeBetweenWaves <= 0) Then
            If (WaveLength >= 0) Then
                'spawning of entities
                'spawns entites depending on intervals
                SpawnEntities()
                WaveLength -= 1
            Else
                TimeBetweenWaves = 20
                setvalues = False
            End If
        Else
            'sets up the entity spawn
            TimeBetweenWaves -= 1
            If (setvalues = False) Then

                SetUpEntitySpawn()
                currentWaveLenght += 1
                WaveLength = currentWaveLenght
                WaveLength += 1
                setvalues = True
            End If
        End If
    End Sub

End Class
