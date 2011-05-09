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
            If (index >= bullets.Count - 1) Then
                Exit For
            End If
            If (bullets.Item(index).location.X > Form1.Width) Then
                bullets.RemoveAt(index)


                Continue For

            End If
            Dim entities As List(Of Integer) = EntityManager.EntityGrid.getIndexes(New Point(bullets.Item(index).location.X / 100, bullets.Item(index).location.Y / 100))
            If Not (entities Is Nothing) Then
     
                For Entitiyindex = 0 To entities.Count - 1
                    If (EntityManager.Entities.Item(entities(Entitiyindex)).Dead = False) Then

                        If (New Rectangle(EntityManager.Entities.Item(entities(Entitiyindex)).location, EntityManager.Entities.Item(entities(Entitiyindex)).Size)).IntersectsWith(New Rectangle(bullets.Item(index).location, bullets.Item(index).size)) Then
                            bullets.RemoveAt(index)
                            EntityManager.KillEntiy(entities(Entitiyindex), EntityManager.Entities.Item(entities(Entitiyindex)).location)
                            Continue For

                        End If

                    End If

                Next
            End If
      
            bullets.Item(index).Update()


        Next

    End Sub

    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        For index = 0 To bullets.Count - 1
            bullets.Item(index).Paint(e)
        Next
    End Sub
End Class
