Public Class Spider
    Inherits Entity
    Public random As Random = New Random()
    Public Sub New(ByVal setlocation As Point)

        MyBase.New(setlocation)


    End Sub
    Public Overrides Sub Update()


        MyBase.Update()
    End Sub
    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(EntityManager.Spider, location)

        MyBase.Draw(e)
    End Sub


End Class
