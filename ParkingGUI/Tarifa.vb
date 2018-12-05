Public Class Tarifa
    Private tipo As String
    Private beneficio As Double
    Private indiceTarifa As Integer
    Private importeTarifa As Double

    Public Sub New(tipo As String, beneficio As Double, indiceTarifa As Integer, importeTarifa As Double)
        Me.tipo = tipo
        Me.beneficio = beneficio
        Me.indiceTarifa = indiceTarifa
        Me.importeTarifa = importeTarifa
    End Sub

    Public Function toCSV()
        Return Me.tipo & ";" & Me.beneficio & ";" & Me.indiceTarifa & ";" & Me.importeTarifa
    End Function

    Public Function toString()
        Return Me.tipo & " " & Me.beneficio & " " & Me.indiceTarifa & " " & Me.importeTarifa
    End Function
End Class
