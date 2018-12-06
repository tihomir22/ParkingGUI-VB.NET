Public Class Movimiento_contable

    Private concepto As String
    Private fecha As Date
    Private numFactura As Integer
    Private precio As Double
    Private metodoPago As String
    Private comision As Double
    Private totalImporte As Double

    Public Sub New(concepto As String, fecha As Date, numFactura As Integer, precio As Double, metodoPago As String, comision As Double, totalImporte As Double)
        Me.concepto = concepto
        Me.fecha = fecha
        Me.numFactura = numFactura
        Me.precio = precio
        Me.metodoPago = metodoPago
        Me.comision = comision
        Me.totalImporte = totalImporte
    End Sub

    Public Function toString()
        Return Me.concepto & " " & Me.fecha & " " & Me.numFactura & " " & Me.precio & " " & Me.metodoPago & " " & Me.comision & " " & Me.totalImporte
    End Function

    Public Function toCSV()
        Return Me.concepto & ";" & Me.fecha & ";" & Me.numFactura & ";" & Me.precio & ";" & Me.metodoPago & ";" & Me.comision & ";" & Me.totalImporte
    End Function

    Public Function getTotalImporte()
        Return Me.totalImporte
    End Function

End Class
