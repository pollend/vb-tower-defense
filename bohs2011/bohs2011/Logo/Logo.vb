Public Class Logo
    Implements IScreen

    Public Sub Load() Implements IScreen.Load

    End Sub

    Public Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs) Implements IScreen.Paint

    End Sub

    Public Function Update() As Screens Implements IScreen.Update
        Return Screens.GameScreen
    End Function
End Class
