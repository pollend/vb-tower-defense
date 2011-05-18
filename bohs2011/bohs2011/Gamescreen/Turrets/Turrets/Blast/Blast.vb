Public Class BlastAssets
    Public Shared BlastAssets(10) As Bitmap
    Public Shared Bottom As Bitmap = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Bottom.png")

    Public Shared Sub SetUp()
        BlastAssets(0) = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Turret1.png")
        BlastAssets(1) = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Turret2.png")
        BlastAssets(2) = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Turret3.png")
        BlastAssets(3) = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Turret4.png")
        BlastAssets(4) = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Turret5.png")
        BlastAssets(5) = New Bitmap("Gamescreen\Turrets\Turrets\Blast\Assets\Turret6.png")

    End Sub
End Class

Public Class Blast
    Inherits Turret
    Private frame As Integer
    Private ActivateBlast As Integer
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByRef turret As Blast)
        MyBase.New(turret)

    End Sub
End Class
