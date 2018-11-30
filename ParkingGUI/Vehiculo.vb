Public Class Vehiculo
    Private tipo As String
    Private plaza As Integer
    Private matricula As String
    Private marca As String
    Private modelo As String

    Public Sub New(tipo As String, matricula As String, marca As String, modelo As String, plaza As Integer)
        Me.tipo = tipo
        Me.plaza = plaza
        Me.matricula = matricula
        Me.marca = marca
        Me.modelo = modelo
    End Sub

    Public Function getTipo()
        Return Me.tipo
    End Function

    Public Function getPlaza()
        Return Me.plaza
    End Function

    Public Function toString()
        Return Me.tipo & " " & Me.matricula & " " & Me.marca & " " & Me.modelo & Me.plaza & " "
    End Function

    Public Function toCSV()
        Return Me.tipo & ";" & Me.matricula & ";" & Me.marca & ";" & Me.modelo & ";" & Me.plaza
    End Function
End Class
