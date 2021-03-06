﻿Public Class Turret


    'follow the specific entity
    Public attackRadius As Rectangle
    Public TilesLinkedTo As List(Of Point) = New List(Of Point)
    Public Dead As Boolean = False
    Public location As Point
    Public EnitiyToFollow As Integer
    Public health As Integer
    Public Size As Point


    Private maxHealth As Integer

    Public Sub New()

    End Sub

    Public Overridable Sub SetTurret(ByVal Location As Point)

    End Sub
    Protected Function findentity(ByVal distance As Integer) As Point
        Dim IndexDistance As Integer = (distance / Grid.GridSpacing)
        Dim myloc As Point = New Point(Me.location.X / Grid.GridSpacing, Me.location.Y / Grid.GridSpacing)
        Dim random As Random = New Random()

        For X = myloc.X - IndexDistance To myloc.X + IndexDistance + IndexDistance

            For Y = myloc.Y - IndexDistance To myloc.Y + IndexDistance + IndexDistance
                Dim myindexs As List(Of Integer) = EntityManager.EntityGrid.getIndexes(New Point(X, Y))

                If Not (myindexs Is Nothing) Then

                    If Not (myindexs.Count - 1 < 0) Then
                        Dim myrandomindex As Integer = random.Next(0, myindexs.Count)
                        If EntityManager.Entities.Item(myindexs.Item(myrandomindex)).Dead = False Then

                            If (VectorFormula.Distance(EntityManager.Entities.Item(myindexs.Item(myrandomindex)).location, Me.location) < distance) Then
                                Return EntityManager.Entities.Item(myindexs.Item(myrandomindex)).location
                            End If
                        End If

                    End If
                End If

            Next
        Next
        Return New Point(-1, -1)



    End Function

    Public Overridable Sub Update(ByVal myindex As Integer)
 
        If (health <= 0) Then
            Dim random As Random = New Random()
            For index = 1 To 10
                ParticleManager.AddParticle(New MedalChunks, Me.location + New Point(random.Next(0, Me.Size.X), random.Next(0, Me.Size.Y)), index)


            Next

            Me.Dead = True
        End If


    End Sub

    'paint function
    Public Overridable Sub Paint(ByVal e As System.Windows.Forms.PaintEventArgs)
      
    End Sub
End Class
