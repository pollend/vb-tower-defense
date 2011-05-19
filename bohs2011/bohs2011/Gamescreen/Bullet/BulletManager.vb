Public Class BulletManager
    Public Shared bullets As List(Of Bullets) = New List(Of Bullets)
    Public Shared Sub AddBullet(ByVal bullet As Bullets, ByVal location As Point, ByVal direction As Point)
        Dim bLt As Bullets = bullet
        bLt.location = location
        bLt.direction = direction
        bullets.Add(bLt)
    End Sub
    Public Sub Update()

        For index = 0 To bullets.Count - 1
            If (index < 0 Or index > bullets.Count - 1) Then
                Continue For
            End If
            bullets.Item(index).Update()

            If (bullets.Item(index).location.X > Form1.Width Or bullets.Item(index).location.X < 0 Or bullets.Item(index).location.Y > Form1.Height Or bullets.Item(index).location.Y < 0) Then
                bullets.RemoveAt(index)

                index -= 1

                Continue For
            End If

            Dim entities As List(Of Integer) = EntityManager.EntityGrid.getIndexes(New Point((bullets.Item(index).location.X + (bullets.Item(index).size.X / 2)) / Grid.GridSpacing, (bullets.Item(index).location.Y + (bullets.Item(index).size.Y / 2)) / Grid.GridSpacing))
            If Not (entities Is Nothing) Then
                For Entitiyindex = 0 To entities.Count - 1
                    If (Entitiyindex > 0 And Entitiyindex < entities.Count - 1) Then

                        If (index < 0 Or index >= bullets.Count - 1) Then
                            Continue For
                        End If

                        If (EntityManager.Entities.Item(entities(Entitiyindex)).Dead = False) Then

                            If (New Rectangle(EntityManager.Entities.Item(entities(Entitiyindex)).location, EntityManager.Entities.Item(entities(Entitiyindex)).Size)).IntersectsWith(New Rectangle(bullets.Item(index).location, bullets.Item(index).size)) Then
                                bullets.RemoveAt(index)
                                EntityManager.Entities(entities(Entitiyindex)).heath -= bullets.Item(index).dmg
                                index -= 1
                                Continue For

                            End If

                        End If

                    End If

                Next
            End If



        Next

    End Sub

    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        For index = 0 To bullets.Count - 1
            bullets.Item(index).Paint(e)
        Next
    End Sub
End Class
