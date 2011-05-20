Public Class HomeBase
    Inherits Turret
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByRef turret As FastFireTurrets)
        MyBase.New(turret)
        Me.health = 100

    End Sub

    Public Overrides Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.Paint(e)
    End Sub
    Public Overrides Sub Update(ByVal index As Integer)
        MyBase.Update(index)
    End Sub

End Class
