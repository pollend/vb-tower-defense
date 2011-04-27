

Public Class SelectingBitmap

    Private OnBitmap As Bitmap
    Private OffBitmap As Bitmap
    Private ActiveBitmap As Boolean = False
    Private location As Point

    Public Sub SetSelection(ByVal selecting As Boolean)
        ActiveBitmap = selecting
    End Sub

    Public Function mouseover() As Boolean


        'coords of the button
        Dim left As Integer = location.X
        Dim right As Integer = location.X + OnBitmap.Width
        Dim top As Integer = location.Y
        Dim bot As Integer = location.Y + OnBitmap.Height



        If Form1.MousePosition.X > left And Form1.MousePosition.Y > top And Form1.MousePosition.Y < bot And Form1.MousePosition.X < right Then
            Return True

        Else
            Return False

        End If


    End Function
    Public Function MouseLeftClick() As Boolean
        If (Form1.MouseButtons = MouseButtons.Left) Then
            Return True
        End If
        Return False

    End Function
    Public Function MouseRightClick() As Boolean
        If (Form1.MouseButtons = MouseButtons.Right) Then
            Return True
        End If
        Return False

    End Function


    Public Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)



        If ActiveBitmap = True Then

            e.Graphics.DrawImage(OnBitmap, location)



        ElseIf ActiveBitmap = False Then

            e.Graphics.DrawImage(OffBitmap, location)

        End If



    End Sub


    Public Sub AssignNewBit(ByVal OnBitMap As Bitmap, ByVal OffBitmap As Bitmap)
        Me.OnBitmap = OnBitMap
        Me.OffBitmap = OffBitmap
    End Sub

    Public Sub New(ByVal OnBitMap As Bitmap, ByVal OffBitmap As Bitmap)
        Me.OnBitmap = OnBitMap
        Me.OffBitmap = OffBitmap

    End Sub


End Class
