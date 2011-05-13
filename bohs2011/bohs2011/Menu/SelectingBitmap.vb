﻿

Public Class SelectingBitmap

    Private OnBitmap As Bitmap
    Private OffBitmap As Bitmap
    Private ActiveBitmap As Boolean = False
    Public location As Point


    Public Function getheight() As Decimal
        Return OnBitmap.Height * VectorFormula.scaling
    End Function
    Public Function getWidth() As Decimal
        Return OnBitmap.Width * VectorFormula.scaling
    End Function
    Public Sub SetSelection(ByVal selecting As Boolean)
        ActiveBitmap = selecting
    End Sub

    Public Function mouseover() As Boolean


        'coords of the button
        Dim left As Integer = location.X
        Dim right As Integer = location.X + (OnBitmap.Width * VectorFormula.scaling)
        Dim top As Integer = location.Y
        Dim bot As Integer = location.Y + (OnBitmap.Height * VectorFormula.scaling)
        'testing if the mouse if over the button
        If Form1.MousePosition.X - Form1.CameraLocation.X > left And Form1.MousePosition.X - (OnBitmap.Width * VectorFormula.scaling) - Form1.CameraLocation.X < left And Form1.MousePosition.Y - Form1.CameraLocation.Y > top And Form1.MousePosition.Y - (OnBitmap.Height * VectorFormula.scaling) - Form1.CameraLocation.Y < bot Then

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

    Public Sub New(ByVal OnBitMap As String, ByVal OffBitmap As String, ByVal location As Point)
        Me.OnBitmap = New Bitmap(OnBitMap)
        Me.OffBitmap = New Bitmap(OffBitmap)
        Me.location = location

    End Sub


End Class
