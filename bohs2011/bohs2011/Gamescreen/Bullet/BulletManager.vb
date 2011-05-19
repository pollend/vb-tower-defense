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

            If bullets.Item(index).dead = True Then
                bullets.RemoveAt(index)
                index -= 1
                Continue For
            End If

            If (bullets.Item(index).location.X > Form1.Width Or bullets.Item(index).location.X < 0 Or bullets.Item(index).location.Y > Form1.Height Or bullets.Item(index).location.Y < 0) Then
                bullets.RemoveAt(index)
                index -= 1
                Continue For
            End If





        Next

    End Sub

    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        For index = 0 To bullets.Count - 1
            bullets.Item(index).Paint(e)
        Next
    End Sub
End Class
