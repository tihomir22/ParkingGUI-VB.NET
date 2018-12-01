Public Class Vehiculo
    Private tipo As String
    Private plaza As Integer
    Private matricula As String
    Private marca As String
    Private modelo As String
    Private fechaEntrada As Date
    Private hora As Integer
    Private minutos As Integer

    Public Sub New(tipo As String, matricula As String, marca As String, modelo As String, plaza As Integer)
        Me.tipo = tipo
        Me.plaza = plaza
        Me.matricula = matricula
        Me.marca = marca
        Me.modelo = modelo
    End Sub

    Public Sub New(tipo As String, matricula As String, marca As String, modelo As String, plaza As Integer, datevar As Date, hora As Integer, minuto As Integer)
        Me.tipo = tipo
        Me.plaza = plaza
        Me.matricula = matricula
        Me.marca = marca
        Me.modelo = modelo
        Me.fechaEntrada = datevar
        Me.hora = hora
        Me.minutos = minuto
    End Sub

    Public Function getTipo()
        Return Me.tipo
    End Function

    Public Function getFecha()
        Return Me.fechaEntrada
    End Function

    Public Function getMatricula()
        Return Me.matricula
    End Function

    Public Function getMarca()
        Return Me.marca
    End Function

    Public Function getModelo()
        Return Me.modelo
    End Function

    Public Function getPlaza()
        Return Me.plaza
    End Function
    Public Function setFecha(ByVal fecha As Date)
        Me.fechaEntrada = fecha.ToString
    End Function

    Public Function setHours()
        Me.hora = DateTime.Now.TimeOfDay.Hours
    End Function

    Public Function setMinutes()
        Me.minutos = DateTime.Now.TimeOfDay.Minutes
    End Function


    Public Function toString()
        Return Me.tipo & " " & Me.matricula & " " & Me.marca & " " & Me.modelo & Me.plaza & " " & " " & Me.fechaEntrada & " " & Me.hora & " " & Me.minutos
    End Function

    Public Function toCSV()
        Return Me.tipo & ";" & Me.matricula & ";" & Me.marca & ";" & Me.modelo & ";" & Me.plaza & ";" & Me.fechaEntrada & ";" & Me.hora & ";" & Me.minutos
    End Function
End Class
