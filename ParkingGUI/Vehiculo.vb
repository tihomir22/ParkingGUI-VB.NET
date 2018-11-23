Public Class Vehiculo
    Private tipo As String
    Private matricula As String
    Private marca As String
    Private modelo As String

    Public Sub New(tipo As String, matricula As String, marca As String, modelo As String)
        Me.tipo = tipo
        Me.matricula = matricula
        Me.marca = marca
        Me.modelo = modelo
    End Sub

    Public Function getTipo()
        Return Me.tipo
    End Function

    Public Function toString()
        Return Me.tipo & " " & Me.matricula & " " & Me.marca & " " & Me.modelo
    End Function
End Class
