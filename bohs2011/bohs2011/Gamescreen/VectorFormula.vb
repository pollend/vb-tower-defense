Public Class VectorFormula
    Public Shared scaling As Decimal = 1.3
    Public Shared ScalePoint
    Public Shared Function ToRadians(ByVal Value As Decimal) As Decimal

        Return (Math.PI * Value) / 180
    End Function
    Public Shared Function ToDegrees(ByVal Value As Decimal) As Decimal

        Return (Value * 180) / Math.PI
    End Function
    Public Shared Function Distance(ByVal Location1 As Point, ByVal Location2 As Point) As Decimal
        Dim value As Decimal = ((Location1.X - Location2.X) * (Location1.X - Location2.X)) + ((Location1.Y - Location2.Y) * (Location1.Y - Location2.Y))
        Return Math.Sqrt(value)
    End Function
    Public Shared Function PointTo(ByVal location As Point, ByVal PointToGoTo As Point) As Decimal
        'rotates the turret head
        Dim mydist As Decimal = Distance(location, PointToGoTo)
        Dim ydist As Decimal = (location.X - PointToGoTo.X)
        If (ydist = 0) Then
            Return Decimal.Zero
        End If

        Dim myrot As Decimal = Math.Acos(ydist / mydist)
        If (location.Y < PointToGoTo.Y) Then

            Return ToDegrees((myrot + Math.PI / 2.0)) * -1
        Else
            Return ToDegrees(myrot - Math.PI / 2.0)
        End If
        Return Decimal.Zero
    End Function
    Public Shared Function MoveInDirection(ByVal ToPoint As Point, ByVal Location As Point, ByVal Scaler As Integer, ByVal currentVelocity As Point) As Point
        'moves in the direction
        Dim DesiredVelocity As Point = Normalize(ToPoint - Location)
        DesiredVelocity = New Point(DesiredVelocity.X * Scaler, DesiredVelocity.Y * Scaler)

        Return (DesiredVelocity - currentVelocity)

    End Function
    Public Shared Function MoveAwayDirection(ByVal ToPoint As Point, ByVal entity As Point, ByVal Scaler As Decimal, ByVal currentVelocity As Point) As Point
        Dim DesiredVelocity As Point = Normalize(ToPoint - entity)
        DesiredVelocity = New Point(DesiredVelocity.X * Scaler, DesiredVelocity.Y * Scaler)

        Return (DesiredVelocity + currentVelocity)

    End Function
    Public Shared Function Magnitude(ByVal Vector As Point) As Decimal
        Return Math.Sqrt((Vector.X * Vector.X) + (Vector.Y * Vector.Y))
    End Function
    Public Shared Function Normalize(ByVal vector As Point) As Point
        If Not (Magnitude(vector) = 0) Then

            Return New Point(vector.X / Magnitude(vector), vector.Y / Magnitude(vector))
        End If
    End Function

    Public Shared Function GoInDirectinalRadius(ByVal radius As Integer, ByVal scaling As Integer) As Point
        Dim checklocation As Decimal = ToRadians(radius - 90)
        Return New Point(Math.Cos(checklocation) * scaling, Math.Sin(checklocation) * scaling)
    End Function

End Class

