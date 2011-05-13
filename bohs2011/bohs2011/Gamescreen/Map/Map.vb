Public Class Map
    Public Map As Bitmap = New Bitmap("Gamescreen\Map\Maps\map.png")
    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(Map, New Point(0, 0))
    End Sub



End Class
