Public Class SloMoBulletAssets
    Public Shared SloMo(2) As Bitmap
    Public Shared Sub SetUp()
        SloMo(0) = New Bitmap("Gamescreen\Bullet\Bullets\SloMO\Bl1.png")
        SloMo(1) = New Bitmap("Gamescreen\Bullet\Bullets\SloMO\Bl2.png")
        SloMo(2) = New Bitmap("Gamescreen\Bullet\Bullets\SloMO\Bl3.png")

    End Sub
End Class

Public Class SloMoBullet
    Inherits Bullets
    Private Frame As Integer
    Public Sub New()
        Me.killEntities = True
        dmg = 0
        Me.size = New Point(10 * VectorFormula.scaling, 10 * VectorFormula.scaling)
    End Sub
    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(SloMoBulletAssets.SloMo(Frame), location)

        MyBase.Paint(e)
    End Sub

    Public Overrides Sub Update()
        Me.location += Me.direction
        'Me.RegularyDmgThroughCollision()
        If (Frame >= 2) Then
            Frame = 0
        Else
            Frame += 1
        End If


        Dim entities As List(Of Integer) = EntityManager.EntityGrid.getIndexes(New Point((location.X + (size.X / 2)) / Grid.GridSpacing, (location.Y + (size.Y / 2)) / Grid.GridSpacing))
        If Not (entities Is Nothing) Then
            For Entitiyindex = 0 To entities.Count - 1
                If (EntityManager.Entities.Item(entities(Entitiyindex)).Dead = False) Then
                    If (New Rectangle(EntityManager.Entities.Item(entities(Entitiyindex)).location, EntityManager.Entities.Item(entities(Entitiyindex)).Size)).IntersectsWith(New Rectangle(location, size)) Then
                        Me.dead = True
                        ParticleManager.AddParticle(New SloMo(), Me.location, Entitiyindex)

                        Dim SearchLocation = New Point(Me.location.X + (size.X / 2), Me.location.Y + (size.Y / 2))

                        For X = (SearchLocation.X - 100) / Grid.GridSpacing To (SearchLocation.X + 100) / Grid.GridSpacing
                            For Y = (SearchLocation.Y - 100) / Grid.GridSpacing To (SearchLocation.Y + 100) / Grid.GridSpacing

                                Dim EntitiesWithinTile As List(Of Integer) = EntityManager.EntityGrid.getIndexes(New Point(X, Y))

                                'test entites within the entiy index with distance and produce splash dmg
                                If Not (EntitiesWithinTile Is Nothing) Then
                                    Dim count As Integer = 0
                                    For index = 0 To EntitiesWithinTile.Count - 1

                                        If (VectorFormula.Distance(EntityManager.Entities.Item(EntitiesWithinTile(index)).location, Me.location) < 100) Then
                                            EntityManager.Entities.Item(EntitiesWithinTile(index)).speedRedution = 1
                                            count += 1
                                            If (count > 10) Then
                                                Exit For
                                            End If
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
