Public Class Menu
    Implements IScreen
    Private logo As Bitmap = New Bitmap("Menu\Assets\logo.png")

    Private start As SelectingBitmap = New SelectingBitmap("Menu\Assets\Start\start_On.png", "Menu\Assets\Start\start_Off.png", New Point(250, 200))
    Private Instructions As SelectingBitmap = New SelectingBitmap("C:\Users\Michael pollind\Desktop\bohs-game\bohs2011\bohs2011\Menu\Assets\instructions\instrutions_On.png", "C:\Users\Michael pollind\Desktop\bohs-game\bohs2011\bohs2011\Menu\Assets\instructions\instrutions_off.png", New Point(250, 200))
    Private Help As SelectingBitmap = New SelectingBitmap("Menu\Assets\Start\start_On.png", "Menu\Assets\Start\start_Off.png", New Point(250, 200))
    Private Quit As SelectingBitmap = New SelectingBitmap("Menu\Assets\Start\start_On.png", "Menu\Assets\Start\start_Off.png", New Point(250, 200))


    Private frame As Integer
    Private Background(107) As Bitmap

    Public Enum Menu_Parts
        Start
        Instruction
        Quit

    End Enum


    Public Sub Load() Implements IScreen.Load

        For index = 1 To 105


            If (index > 99) Then
                Background(index - 1) = New Bitmap("Menu\Background\Background " & index & ".png")
            ElseIf (index > 9) Then
                Background(index - 1) = New Bitmap("Menu\Background\Background 0" & index & ".png")
            Else
                Background(index - 1) = New Bitmap("Menu\Background\Background 00" & index & ".png")
            End If
        Next

    End Sub

    Public Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs) Implements IScreen.Paint
        e.Graphics.ScaleTransform(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))

        e.Graphics.DrawImage(Background(frame), New Point(0, 0))
        e.Graphics.DrawImage(logo, New Point(150, 0))
        start.Draw(e)
        Help.Draw(e)
        Quit.Draw(e)
        Instructions.Draw(e)
    End Sub

    Public Function Update() As Screens Implements IScreen.Update
        If (frame > 103) Then
            frame = 0
        End If
        frame += 1
        Return Screens.MenuScreen
    End Function
End Class
