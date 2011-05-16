Public Class GooAssets
    Public Shared GooBits(4) As Bitmap
    Public Shared Sub SetUp()
        GooBits(0) = New Bitmap("Gamescreen\Entities\Entities\Goo\Goo1.png")
        GooBits(1) = New Bitmap("Gamescreen\Entities\Entities\Goo\Goo2.png")
        GooBits(2) = New Bitmap("Gamescreen\Entities\Entities\Goo\Goo3.png")
        GooBits(3) = New Bitmap("Gamescreen\Entities\Entities\Goo\Goo4.png")
        GooBits(4) = New Bitmap("Gamescreen\Entities\Entities\Goo\Goo5.png")

    End Sub
End Class
Public Class Goo
    Inherits Entity

    Public Sub New(ByVal setlocation As Point)
        MyBase.New(setlocation)

        Size = New Point(50, 50)
    End Sub



End Class
