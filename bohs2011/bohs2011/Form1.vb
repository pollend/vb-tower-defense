﻿
Public Class Form1

    Private score As ScoreManager = New ScoreManager()

    Private CurrentScreen As IScreen
    Private Screens As Screens
    Private keypresses As System.Windows.Forms.KeyPressEventArgs
    Private keydownNumber As System.Windows.Forms.KeyEventArgs
    'the camera location
    Public Shared CameraLocation As Point

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        'set the screen to start at logo
        Screens = bohs2011.Screens.LogoScreen
        CurrentScreen = New Logo
        'formates the windw to fit the screen
        '  Me.FormBorderStyle = FormBorderStyle.None
        ' Me.WindowState = FormWindowState.Maximized
        ' Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        Me.Location = New Point(0, 0)
        Me.Size = New Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)

    End Sub

    Public Shared Sub CamTransform(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.TranslateTransform(CameraLocation.X, CameraLocation.Y)

    End Sub
    Private Sub Form1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        CamTransform(e)
        'paints the current screen
        CurrentScreen.Paint(e)
        'translates the whole game 
    End Sub

    Private Sub Update_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateEvent.Tick

        Dim Screen As Screens = CurrentScreen.Update()

        'switch there screen when there not equal
        If Not (Screen = Me.Screens) Then

            Select Case Screen

                Case bohs2011.Screens.GameScreen
                    CurrentScreen = New GameScreen()

                Case bohs2011.Screens.LogoScreen
                    CurrentScreen = New Logo

                Case bohs2011.Screens.MenuScreen
                    CurrentScreen = New Menu
                Case Else

            End Select
            CurrentScreen.Load()
        End If
        Me.Screens = Screen
        'invalidates the entire screen to be drawn
        Me.Invalidate()

    End Sub

    Private Sub Form1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        keypresses = e
    End Sub


    Public Function GetkeyPressNumber() As Integer

        If (keydownNumber Is Nothing) Then
            Return -1
        End If
        Dim mynumber As Integer = New Integer
        mynumber = keydownNumber.KeyCode
        keydownNumber = Nothing

        Return mynumber


    End Function
    Public Function GetKeyPreses() As String

        If (keypresses Is Nothing) Then
            Return ""
        End If

        Dim mystring As String = keypresses.KeyChar()
        keypresses = Nothing
        Return mystring
    End Function

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        keydownNumber = e

    End Sub
End Class

Public Enum Screens
    GameScreen
    MenuScreen
    LogoScreen
End Enum
