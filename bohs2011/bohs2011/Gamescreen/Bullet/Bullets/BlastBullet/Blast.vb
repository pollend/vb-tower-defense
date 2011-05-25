Public Class BlastBullets
    Inherits Bullets
    Public Sub New()
        Me.killEntities = True
        dmg = 5
        Me.size = New Point(15 * VectorFormula.scaling, 15 * VectorFormula.scaling)
    End Sub
    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(BulletImageCollection.BlastAssets, location)

        MyBase.Paint(e)
    End Sub

    Public Overrides Sub Update()
        Me.location += Me.direction
        Dim entities As List(Of Integer) = EntityManager.EntityGrid.getIndexes(New Point((location.X + (size.X / 2)) / Grid.GridSpacing, (location.Y + (size.Y / 2)) / Grid.GridSpacing))
        If Not (entities Is Nothing) Then
            For Entitiyindex = 0 To entities.Count - 1
                If (EntityManager.Entities.Item(entities(Entitiyindex)).Dead = False) Then
                    If (New Rectangle(EntityManager.Entities.Item(entities(Entitiyindex)).location, EntityManager.Entities.Item(entities(Entitiyindex)).Size)).IntersectsWith(New Rectangle(location, size)) Then
                        Me.dead = True

                        For index = 0 To 20

                            ParticleManager.AddParticle(New FireToSmoke(), Me.location, index)
                        Next
                        Dim SearchLocation = New Point(Me.location.X + (size.X / 2), Me.location.Y + (size.Y / 2))

                        For X = (SearchLocation.X - 50) / Grid.GridSpacing To (SearchLocation.X + 50) / Grid.GridSpacing
                            For Y = (SearchLocation.Y - 50) / Grid.GridSpacing To (SearchLocation.Y + 50) / Grid.GridSpacing

                                Dim EntitiesWithinTile As List(Of Integer) = EntityManager.EntityGrid.getIndexes(New Point(X, Y))

                                'test entites within the entiy index with distance and produce splash dmg
                                If Not (EntitiesWithinTile Is Nothing) Then

                                    For index = 0 To EntitiesWithinTile.Count - 1
                                        If (VectorFormula.Distance(EntityManager.Entities.Item(EntitiesWithinTile(index)).location, Me.location) < 100) Then
                                            EntityManager.Entities.Item(EntitiesWithinTile(index)).health -= dmg

                                        End If

                                    Next
                                End If
                            Next
                        Next



        End If
                End If

            Next
        End If
        MyBase.Update()
    End Sub


End Class
