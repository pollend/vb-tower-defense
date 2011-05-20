Public Class ParticleManager
    Public particle As List(Of particle) = New List(Of particle)

    Public Sub Load()

    End Sub
    Public Sub AddParticle(ByVal particle As particle, ByVal location As Point)
        Dim Myparticle As particle = New particle()
        Myparticle.Load()
        Myparticle.location = location
        Me.particle.Add(Myparticle)
    End Sub
    Public Sub Update()
        For index = 0 To particle.Count - 1
            particle.Item(index).Update()

            If (particle.Item(index).dead = True) Then
                index -= 1
                particle.RemoveAt(index)
                If (index < 0) Then
                    Exit For
                End If
                Continue For
            End If

        Next

    End Sub
    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        For index = 0 To particle.Count - 1
            particle.Item(index).Paint(e)

        Next

    End Sub

End Class
