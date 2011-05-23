Public Class ParticleManager
    Public Shared particle As List(Of particle) = New List(Of particle)

    Public Sub Load()
        fireToSmokeAssets.SetUp()
        MedalChunkAssets.SetUp()
        SloMoParticleAssets.SetUp()

    End Sub
    Public Shared Sub AddParticle(ByVal particle As particle, ByVal location As Point, ByVal Seed As Integer)

        particle.random = New Random(Seed * Now.Millisecond + location.X * location.Y)

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
            particle.Item(index).Paint(e)

        Next

    End Sub

End Class
