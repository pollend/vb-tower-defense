﻿
Public Class Form1
    Private CurrentScreen As IScreen
    Private Screens As Screens


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'set the screen to start at logo
        Screens = bohs2011.Screens.LogoScreen
        CurrentScreen = New Logo
        'formates the windw to fit the screen
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        Me.Size = New Size(New Point(Me.Width, Me.Height + 100))
        Me.MainMenuStrip.Visible = False
    End Sub

    Private Sub Form1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        'paints the current screen
        CurrentScreen.Paint(e)
    End Sub

    Private Sub Update_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update.Tick
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
        Screen = Me.Screens
    End Sub
End Class

Public Enum Screens
    GameScreen
    MenuScreen
    LogoScreen
End Enum