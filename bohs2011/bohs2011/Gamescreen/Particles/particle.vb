﻿Public Class particle
    Public location As Point
    Public size As Point
    Public dead As Boolean
    Public random As Random = New Random(Now.Millisecond * Now.Hour)
    Public topmost As Boolean = False

    Public Overridable Sub Load()

        random = New Random(Now.Millisecond * Now.Hour)
    End Sub
    Public Overridable Sub Update()
    End Sub
    Public Overridable Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub
End Class
