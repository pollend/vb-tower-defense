Public Class Bullets
    Public direction As Point
    Public location As Point
    Public size As Point
    Public dead As Boolean
    Public collisionRect As Rectangle
    Public killEntities As Boolean
    Public KillTurrets As Boolean
    Public dmg As Integer

    Public Overridable Sub Update()

    End Sub
    Public Overridable Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub
    Protected Sub RegularyDmgThroughCollision()

        Dim entities As List(Of Integer) = EntityManager.EntityGrid.getIndexes(New Point((location.X + (size.X / 2)) / Grid.GridSpacing, (location.Y + (size.Y / 2)) / Grid.GridSpacing))
        If Not (entities Is Nothing) Then
            For Entitiyindex = 0 To entities.Count - 1


                If (EntityManager.Entities.Item(entities(Entitiyindex)).Dead = False) Then

                    If (New Rectangle(EntityManager.Entities.Item(entities(Entitiyindex)).location, EntityManager.Entities.Item(entities(Entitiyindex)).Size)).IntersectsWith(New Rectangle(location, size + New Point(20, 20))) Then
                        EntityManager.Entities(entities(Entitiyindex)).health -= dmg

                        For index = 0 To 3

                            ParticleManager.AddParticle(New FireParticles(), Me.location, index * Now.Millisecond)
                        Next
                        dead = True
                    End If
                End If

            Next
        End If

    End Sub
End Class
