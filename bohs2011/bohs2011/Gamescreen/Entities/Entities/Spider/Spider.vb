Public Class SpiderAssets
    Public Shared SpiderBits(4) As Bitmap
    Public Shared Sub SetUp()

        SpiderBits(0) = New Bitmap("Gamescreen\Entities\Entities\Spider\spider2.png")
        SpiderBits(1) = New Bitmap("Gamescreen\Entities\Entities\Spider\spider3.png")
        SpiderBits(2) = New Bitmap("Gamescreen\Entities\Entities\Spider\spider4.png")
        SpiderBits(3) = New Bitmap("Gamescreen\Entities\Entities\Spider\spider5.png")

    End Sub
End Class

Public Class Spider
    Inherits Entity
    Private frame As Integer = random.Next(1, 3)
    Public Sub New(ByVal setlocation As Point)
        MyBase.New(setlocation)
        Size = New Point(50, 50)
        heath = 5

    End Sub
    Public Overrides Sub Update(ByVal index As Integer)
        If (frame >= 3) Then
            frame = 0

        End If
        frame += 1

        MyBase.Update(index)
    End Sub
    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(SpiderAssets.SpiderBits(frame), location)

        MyBase.Draw(e)
    End Sub


End Class
