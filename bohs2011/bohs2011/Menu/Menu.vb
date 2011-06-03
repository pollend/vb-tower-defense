Public Class Menu
    Implements IScreen
    Private logo As Bitmap = New Bitmap("Menu\Assets\logo.png")
    'first screen
    Private start As SelectingBitmap = New SelectingBitmap("Menu\Assets\Start\Start.png", "Menu\Assets\Start\Start.png", New Point(350, 200))
    Private Instructions As SelectingBitmap = New SelectingBitmap("Menu\Assets\Help\Help.png", "Menu\Assets\Help\Help.png", New Point(350, 300))
    Private HighScore As SelectingBitmap = New SelectingBitmap("Menu\Assets\Options\HighScore.png", "Menu\Assets\Options\HighScore.png", New Point(350, 400))
    Private Quit As SelectingBitmap = New SelectingBitmap("Menu\Assets\Quit\Exit.png", "Menu\Assets\Quit\Exit.png", New Point(350, 500))
    Private back As Bitmap = New Bitmap("Menu\back.png")
    Private cursor As Bitmap = New Bitmap("Menu\Assets\Cursor.png")
    Private locationofCursor As Point = New Point(-100, -100)
    Private fliker As Boolean = True

    Private states As Menu_States = Menu_States.start

    Private frame As Integer
    Private overlay(14) As Bitmap
    Private enablestatic As Boolean = False
    Private staticOverlay(21) As Bitmap

    'instructions arrows
    Private Instruction_Images(5) As Bitmap
    Private leftArrow As SelectingBitmap = New SelectingBitmap("Menu\Instruction\LArrow\LeftArrow_On.png", "Menu\Instruction\LArrow\LeftArrow_Off.png", New Point(300, 500))
    Private RightArrow As SelectingBitmap = New SelectingBitmap("Menu\Instruction\RArrow\RightArrow_On.png", "Menu\Instruction\RArrow\RightArrow_Off.png", New Point(700, 500))
    Private pause As Integer
    Private instructionindex As Integer


    Public Enum Menu_States
        options
        help
        start
    End Enum

    Private Function GetImageThreeDigit(ByVal location As String, ByVal index As Integer) As String


        If (index > 99) Then
            Return location & index & ".png"
        ElseIf (index > 9) Then
            Return location & "0" & index & ".png"
        Else
            Return location & "00" & index & ".png"
        End If
    End Function
    Private Function GetImagetwoDigit(ByVal location As String, ByVal index As Integer) As String

        If (index > 9) Then
            Return location & "" & index & ".png"
        Else
            Return location & "0" & index & ".png"
        End If
    End Function
    Public Sub Load() Implements IScreen.Load
        'instuctional images
        Instruction_Images(0) = New Bitmap("Menu\Instruction\instructions.png")
        Instruction_Images(1) = New Bitmap("Menu\Instruction\T1.png")
        Instruction_Images(2) = New Bitmap("Menu\Instruction\T2.png")
        Instruction_Images(3) = New Bitmap("Menu\Instruction\T3.png")
        Instruction_Images(4) = New Bitmap("Menu\Instruction\T4.png")




        For index = 1 To 14

            overlay(index - 1) = New Bitmap(GetImageThreeDigit("Menu\Background\Overlay ", index))
        Next
        For index = 1 To 22

            staticOverlay(index - 1) = New Bitmap(GetImagetwoDigit("Menu\Assets\Static\Static ", index))
        Next

    End Sub

    Public Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs) Implements IScreen.Paint
        Form1.CameraLocation = New Point(0, 0)
        e.Graphics.ScaleTransform(Form1.Width / (820 * VectorFormula.scaling), Form1.Height / (615 * VectorFormula.scaling))
        e.Graphics.DrawImage(back, New Point(0, 0))

        If (fliker = True) Then
            e.Graphics.DrawImage(cursor, locationofCursor)
            fliker = False
        Else
            fliker = True
        End If
        Select Case states
            Case Menu_States.options
                leftArrow.Draw(e)

                e.Graphics.DrawString("Name", New Font("Impact", 20), Brushes.White, New Point(400, 240))
                e.Graphics.DrawString("PeopleSaved", New Font("Impact", 20), Brushes.White, New Point(500, 240))
                e.Graphics.DrawString("Cash", New Font("Impact", 20), Brushes.White, New Point(700, 240))

                For index = 0 To ScoreManager.GetScore.Count - 1

        

                    e.Graphics.DrawString(ScoreManager.GetScore.Item(index).Name, New Font("Impact", 20), Brushes.White, New Point(400, 280 + index * 40))
                    e.Graphics.DrawString(ScoreManager.GetScore.Item(index).SaveHumans, New Font("Impact", 20), Brushes.White, New Point(500, 280 + index * 40))
                    e.Graphics.DrawString(ScoreManager.GetScore.Item(index).Cash, New Font("Impact", 20), Brushes.White, New Point(700, 280 + index * 40))

                Next

            Case Menu_States.help
                e.Graphics.DrawImage(Instruction_Images(instructionindex), New Point(0, 0))

                leftArrow.Draw(e)
                RightArrow.Draw(e)
            Case Menu_States.start

                start.Draw(e)
                HighScore.Draw(e)
                Quit.Draw(e)
                Instructions.Draw(e)
        End Select

        If (enablestatic) Then
            e.Graphics.DrawImage(staticOverlay(frame), New Point(0, 0))
        Else
            e.Graphics.DrawImage(overlay(frame), New Point(0, 0))
        End If
    End Sub

    Public Function Update() As Screens Implements IScreen.Update

        Select Case states
            Case Menu_States.options
                If (leftArrow.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
                    leftArrow.SetSelection(True)
                    If (leftArrow.MouseLeftClick()) Then
                        Me.states = Menu_States.start
                        enablestatic = True

                    End If
                Else
                    leftArrow.SetSelection(False)
                End If
            Case Menu_States.help

                If (pause < 0) Then


                    If (leftArrow.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
                        leftArrow.SetSelection(True)
                        If (leftArrow.MouseLeftClick()) Then
                            instructionindex -= 1
                            enablestatic = True
                            pause = 20
                        End If
                    Else
                        leftArrow.SetSelection(False)
                    End If

                    If (RightArrow.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
                        RightArrow.SetSelection(True)
                        If (RightArrow.MouseLeftClick()) Then
                            instructionindex += 1
                            enablestatic = True
                            pause = 20
                        End If
                    Else
                        RightArrow.SetSelection(False)
                    End If
                Else
                    pause -= 1
                End If
                If (instructionindex < 0 Or instructionindex >= Me.Instruction_Images.Count - 1) Then
                    instructionindex = 0
                    states = Menu_States.start
                End If

            Case Menu_States.start

                If (start.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
                    locationofCursor = start.location + New Point(start.getWidth, 0)
                    If (start.MouseLeftClick()) Then
                        Return Screens.GameScreen
                    End If
                End If

                If (HighScore.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
                    locationofCursor = HighScore.location + New Point(HighScore.getWidth, 0)
                    HighScore.SetSelection(True)
                    If (HighScore.MouseLeftClick) Then
                        enablestatic = True
                        states = Menu_States.options
                        locationofCursor = New Point(-100, -100)
                    End If
                End If
                If (Quit.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
                    If (Quit.MouseLeftClick) Then
                        Form1.Close()
                    End If
                    locationofCursor = Quit.location + New Point(Quit.getWidth, 0)
                End If

                If (Instructions.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
                    locationofCursor = Instructions.location + New Point(Instructions.getWidth, 0)
                    If (Instructions.MouseLeftClick()) Then
                        enablestatic = True
                        states = Menu_States.help
                        locationofCursor = New Point(-100, -100)
                    End If
                End If
        End Select
        'static animtions
        If (enablestatic = True) Then
            If (frame > 20) Then
                frame = 0
                enablestatic = False
            End If
            frame += 1
        Else
            If (frame > 12) Then
                frame = 0
            End If
            frame += 1
        End If

        Return Screens.MenuScreen
    End Function
End Class
