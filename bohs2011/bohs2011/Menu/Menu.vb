Public Class Menu
    Implements IScreen

    Public Enum Menu_Parts
        options

    End Enum


    Public Sub Load() Implements IScreen.Load

    End Sub

    Public Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs) Implements IScreen.Paint

    End Sub

    Public Function Update() As Screens Implements IScreen.Update
        Return Screens.MenuScreen
    End Function
End Class
