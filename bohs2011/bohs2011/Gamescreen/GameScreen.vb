Public Class GameScreen
    Implements IScreen


    Private map As New Map
    Public Sub Load() Implements IScreen.Load
        'sets points on point grid
        PointGrid.SetPoint()

    End Sub

    Public Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs) Implements IScreen.Paint
        map.Draw(e)
    End Sub

    Public Function Update() As Screens Implements IScreen.Update

        Return Screens.GameScreen
    End Function
End Class
