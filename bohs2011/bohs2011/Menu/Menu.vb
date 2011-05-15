Public Class Menu
    Implements IScreen
    Private logo As Bitmap = New Bitmap("Menu\Assets\logo.png")

    Private start As SelectingBitmap = New SelectingBitmap("Menu\Assets\Start\start_On.png", "Menu\Assets\Start\start_Off.png", New Point(350, 200))
    Private Instructions As SelectingBitmap = New SelectingBitmap("Menu\Assets\instructions\instrutions_On.png", "Menu\Assets\instructions\instrutions_off.png", New Point(350, 300))
    Private Help As SelectingBitmap = New SelectingBitmap("Menu\Assets\Help\help_On.png", "Menu\Assets\Help\help_Off.png", New Point(350, 400))
    Private Quit As SelectingBitmap = New SelectingBitmap("Menu\Assets\Quit\quite_on.png", "Menu\Assets\Quit\quite_Off.png", New Point(350, 500))


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

        If (start.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
            start.SetSelection(True)
            If (start.MouseLeftClick()) Then
                Return Screens.GameScreen
            End If
        Else
            start.SetSelection(False)
        End If
        If (Help.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
            Help.SetSelection(True)
        Else
            Help.SetSelection(False)
        End If
        If (Quit.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
            Quit.SetSelection(True)
        Else
            Quit.SetSelection(False)
        End If
        If (Instructions.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
            Instructions.SetSelection(True)
        Else
            Instructions.SetSelection(False)
        End If
        Return Screens.MenuScreen
    End Function
End Class
