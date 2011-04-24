Public Class Entity

    Public Dead As Boolean

    'Location on Grid
    Public GridLocation As Point

    'the set health of the entity
    Public heath As Integer

    'location with the new location
    Public location As Point = New Point(0, 0)
    'the set location
    Public NewLocation As Point



    Public Sub SetNewEntity(ByVal location As Point, ByVal bitmap As Bitmap, ByVal gridlocation As Point)
        'creates and set a new entity
        Me.GridLocation = gridlocation
        Me.NewLocation = location
    End Sub



    Public Overridable Sub Update()

    End Sub
    Public Overridable Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

End Class
