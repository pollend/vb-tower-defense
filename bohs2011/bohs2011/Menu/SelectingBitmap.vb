

Public Class SelectingBitmap

    Private bitmap As Bitmap



    Private location As Point
    Public Function mouseover() As Boolean


        'coords of the button
        Dim left As Integer
        Dim right As Integer
        Dim top As Integer
        Dim bot As Integer



        If Form1.MousePosition.X > left And Form1.MousePosition.Y > top And Form1.MousePosition.Y < bot And Form1.MousePosition.X < right Then



            Return True

        Else
            Return False

        End If


    End Function


    Public Function Drawbitmap(ByVal e As Bitmap)


        If mouseover() = True Then


        ElseIf mouseover() = False Then



        End If



    End Function


    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)



        If mouseover() = True Then

            e.Graphics.DrawImage(bitmap, location)



        ElseIf mouseover() = False Then

            e.Graphics.DrawImage(bitmap, location)

        End If



    End Sub



    Public Sub New()
        Dim onbitmap As Bitmap
        Dim offbitmap As Bitmap









    End Sub


    Public Function onoffbitmap() As Boolean


        If mouseover() = True Then



        ElseIf mouseover() = False Then



        End If

    End Function
End Class
