
Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        Me.Size = New Size(New Point(Me.Width, Me.Height + 100))
        Me.MainMenuStrip.Visible = False
    End Sub

    Private Sub Form1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

    End Sub
End Class

Public Enum Screens
    GameScreen
    MenuScreen
    LogoScreen
End Enum
