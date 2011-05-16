Public Class Menu
    Implements IScreen
    Private logo As Bitmap = New Bitmap("Menu\Assets\logo.png")
    'first screen
    Private start As SelectingBitmap = New SelectingBitmap("Menu\Assets\Start\Start.png", "Menu\Assets\Start\Start.png", New Point(350, 200))
    Private Instructions As SelectingBitmap = New SelectingBitmap("Menu\Assets\Help\Help.png", "Menu\Assets\Help\Help.png", New Point(350, 300))
    Private Options As SelectingBitmap = New SelectingBitmap("Menu\Assets\Options\Options.png", "Menu\Assets\Options\Options.png", New Point(350, 400))
    Private Quit As SelectingBitmap = New SelectingBitmap("Menu\Assets\Quit\Exit.png", "Menu\Assets\Quit\Exit.png", New Point(350, 500))
    Private back As Bitmap = New Bitmap("Menu\back.png")
    Private cursor As Bitmap = New Bitmap("Menu\Assets\Cursor.png")
    Private locationofCursor As Point = New Point(-100, -100)
    Private fliker As Boolean = True

    Private states As Menu_States = Menu_States.start

    Private frame As Integer
    Private overlay(14) As Bitmap
    Private enablestice As Boolean = False
    Private staticOverlay(21) As Bitmap

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
        For index = 1 To 14

            overlay(index - 1) = New Bitmap(GetImageThreeDigit("Menu\Background\Overlay ", index))
        Next
        For index = 1 To 22

            staticOverlay(index - 1) = New Bitmap(GetImagetwoDigit("Menu\Assets\Static\Static ", index))
        Next

    End Sub

    Public Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs) Implements IScreen.Paint
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

            Case Menu_States.help

            Case Menu_States.start
 
                start.Draw(e)
                Options.Draw(e)
                Quit.Draw(e)
                Instructions.Draw(e)
        End Select

        If (enablestice) Then
            e.Graphics.DrawImage(staticOverlay(frame), New Point(0, 0))
        Else
            e.Graphics.DrawImage(overlay(frame), New Point(0, 0))
        End If
    End Sub

    Public Function Update() As Screens Implements IScreen.Update

        Select Case states
            Case Menu_States.options

            Case Menu_States.help

            Case Menu_States.start

                If (start.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
                    locationofCursor = start.location + New Point(start.getWidth, 0)
                    If (start.MouseLeftClick()) Then
                        Return Screens.GameScreen
                    End If
                End If

                If (Options.mouseover(Form1.Width / (800 * VectorFormula.scaling), Form1.Height / (600 * VectorFormula.scaling))) Then
                    locationofCursor = Options.location + New Point(Options.getWidth, 0)
                    Options.SetSelection(True)
                    If (Options.MouseLeftClick) Then
                        enablestice = True
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
                End If
        End Select
        'static animtions
        If (enablestice = True) Then
            If (frame > 20) Then
                frame = 0
                enablestice = False
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
