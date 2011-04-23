Public Class Spider
    Inherits Entity
    Public Sub New()
        MyBase.New()

    End Sub
    Public Overrides Sub Update()


        MyBase.Update()
    End Sub
    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(EntityManager.Spider, location)

        MyBase.Draw(e)
    End Sub


End Class
