Public Class VectorFormula
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
    Public Shared Function MoveInDirection(ByVal ToPoint As Point, ByVal entity As Point, ByVal Scaler As Integer, ByVal currentVelocity As Point) As Point
        Dim DesiredVelocity As Point = Normalize(ToPoint - entity)
        DesiredVelocity = New Point(DesiredVelocity.X * Scaler, DesiredVelocity.Y * Scaler)

        Return (DesiredVelocity - currentVelocity)

    End Function
    Public Shared Function Magnitude(ByVal Vector As Point) As Decimal
        Return Math.Sqrt((Vector.X * Vector.X) + (Vector.Y * Vector.Y))
    End Function
    Public Shared Function Normalize(ByVal vector As Point) As Point
        Return New Point(vector.X / Magnitude(vector), vector.Y / Magnitude(vector))

    End Function

End Class

