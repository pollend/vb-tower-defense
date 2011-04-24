Public Class Spider
    Inherits Entity
    Public Sub New()
        MyBase.New()
        GridLocation = New Point(0, 0)

    End Sub
    Public Overrides Sub Update()
        NewLocation += VectorFormula.MoveInDirection(PointGrid.Points.Item(GridLocation.X).Item(GridLocation.Y).location, location, 3, New Point(0, 0))


        MyBase.Update()
    End Sub
    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(EntityManager.Spider, location)

        MyBase.Draw(e)
    End Sub


End Class
