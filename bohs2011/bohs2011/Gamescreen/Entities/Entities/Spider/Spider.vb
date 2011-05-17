Public Class Spider
    Inherits Entity

    Public Sub New(ByVal setlocation As Point)
        MyBase.New(setlocation)
        Size = New Point(50, 50)



    End Sub
    Public Overrides Sub Update(ByVal index As Integer)



        MyBase.Update(index)
    End Sub
    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        'e.Graphics.DrawImage(EntityManager.Spider, location)
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(Me.location, New Point(10, 10)))
        MyBase.Draw(e)
    End Sub


End Class
