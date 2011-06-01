Public Class ParticleManager
    Public Shared particle As List(Of particle) = New List(Of particle)

    Public Sub Load()


        particle.Clear()

        fireToSmokeAssets.SetUp()
        MedalChunkAssets.SetUp()
        SloMoParticleAssets.SetUp()

    End Sub

    Public Shared Sub AddParticle(ByVal particle As particle, ByVal location As Point, ByVal Seed As Integer)



        particle.random = New Random(Seed * Now.Millisecond)

        particle.Load()
        particle.location = location

        ParticleManager.particle.Add(particle)

    End Sub
    Public Shared Sub AddParticle(ByVal particle As particle, ByVal location As Point)



        particle.Load()
        particle.location = location

        ParticleManager.particle.Add(particle)

    End Sub
    Public Sub Update()
        For index = 0 To particle.Count - 1

            If (index < 0 Or index > particle.Count - 1) Then
                Exit For
            End If


            If (particle.Item(index).dead = True) Then
                particle.RemoveAt(index)
                index -= 1
            Else
                particle.Item(index).Update()
            End If

        Next

    End Sub
    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)

        For index = 0 To particle.Count - 1
            If (particle.Item(index).topmost = False) Then
                particle.Item(index).Paint(e)
            End If
        Next
        For index = 0 To particle.Count - 1
            If (particle.Item(index).topmost = True) Then
                particle.Item(index).Paint(e)
            End If

        Next

    End Sub

End Class
