Public Class Spider
    Inherits Entity
    Public randomGenerator As Random = New Random()
    Public Sub New(ByVal setlocation As Point)
        MyBase.New(setlocation)
        Size = New Point(50, 50)



    End Sub
    Public Overrides Sub Update(ByVal index As Integer)

        'check for collisions with turret
        Dim Getturrets As List(Of Integer) = TurretManager.TurretGrid.getIndexes(New Point(Me.location.X / Grid.GridSpacing, Me.location.Y / Grid.GridSpacing))
        If Not (Getturrets Is Nothing) Then

            For index = 0 To Getturrets.Count - 1
                If (index > Getturrets.Count - 1) Then
                    Exit For
                End If
                If (TurretManager.Turrets.Item(Getturrets.Item(index)).Dead = False) Then

                    If (TurretManager.Turrets.Item(Getturrets.Item(index)).CollisionRectangle.IntersectsWith(New Rectangle(location, New Size(20 * VectorFormula.scaling, 20 * VectorFormula.scaling)))) Then
                        NewLocation -= VectorFormula.MoveAwayDirection(TurretManager.Turrets.Item(Getturrets.Item(index)).location + New Point((TurretManager.Turrets.Item(Getturrets.Item(index)).CollisionRectangle.Width / 2), (TurretManager.Turrets.Item(Getturrets.Item(index)).CollisionRectangle.Height / 2)), Me.location, 5, New Point(0, 0))
                        TurretManager.AddDeadTurret(Getturrets.Item(index))
                        pointToGoTo = New Point(randomGenerator.Next(-5, 5), randomGenerator.Next(-5, 5)) + pointToGoTo
                    End If

                End If
            Next
        End If


        MyBase.Update(index)
    End Sub
    Public Overrides Sub Draw(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawImage(EntityManager.Spider, location)
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(Me.location, New Point(10, 10)))
        MyBase.Draw(e)
    End Sub


End Class
