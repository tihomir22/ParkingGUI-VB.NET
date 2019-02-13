Imports System.Text.RegularExpressions

Public Class CajaNegra


    Public Function comprobarMatricula(ByVal matricula As String)
        'se comprobarán si las matriculas coinciden con los formatos actuales y historicos de España
        'https://es.wikipedia.org/wiki/Matr%C3%ADculas_automovil%C3%ADsticas_de_Espa%C3%B1a
        Dim arrayMatri() As String = matricula.Trim().Split("-"c)
        'formato 1900-1971 XX-00000 \ X-00000 \ X-000000
        If (arrayMatri.Count() = 2) Then
            If (arrayMatri(0).Length() = 1 Or arrayMatri(0).Length() = 2) Then
                If (arrayMatri(1).Length() = 5 Or arrayMatri(1).Length() = 6) Then
                    MsgBox("Detectado 1900-1971")
                    Return True
                End If
            End If

            'formato 1971-2000 XX-0000-X \ X-0000-XX \ X-0000-XX \ X-0000-XX
        ElseIf (arrayMatri.Count() = 3) Then
            If (arrayMatri(0).Length() = 1 Or arrayMatri(0).Length() = 2) Then
                If (arrayMatri(1).Length() = 4) Then
                    If (arrayMatri(2).Length() = 1 Or arrayMatri(2).Length() = 2) Then
                        MsgBox("Detectado 1971 - 2000")
                        Return True
                    End If

                End If
            End If
        Else
            Dim arrayMatri2000() As String = matricula.Split(" "c)
            'formato 2000 en adelante 0000 XXX
            If (arrayMatri2000.Count() = 2) Then
                If (arrayMatri2000(0).Length() = 4) Then
                    If (arrayMatri2000(1).Length() = 3) Then
                        MsgBox("Detectado 2000 en adelante")
                        Return True
                    End If
                End If
            ElseIf (matricula.Length() = 7) Then 'tambien se podria escribir todo junto 0000XXX
                Dim num As String = matricula.Substring(0, 4)
                Dim numInt As Integer
                Dim sufijo As String = matricula.Substring(4)
                If Integer.TryParse(num, numInt) Then
                    'el primer parametro es un numero
                    If (CheckForAlphaCharacters(sufijo)) Then
                        'para comprobar si el sufijo son todo caracteres
                        MsgBox("Detectado 2000 en adelante")
                        Return True
                    Else
                        MsgBox("Introducido matricula incorrecta | Ejemplos : BI-51452 \ AB-1134-D \ 9999 BBB")
                        Return False
                    End If
                Else
                    MsgBox("Introducido matricula incorrecta | Ejemplos : BI-51452 \ AB-1134-D \ 9999 BBB")
                    Return False
                End If
            Else
                MsgBox("Introducido matricula incorrecta | Ejemplos : BI-51452 \ AB-1134-D \ 9999 BBB \ 9999BBB")
                Return False
            End If
        End If





    End Function

    Function CheckForAlphaCharacters(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If Not Char.IsLetter(StringToCheck.Chars(i)) Then
                Return False
            End If
        Next

        Return True 'Return true if all elements are characters
    End Function

    Public Function comprobarLongitud25(ByVal valor As String)
        If (valor.Length() < 25) Then
            Return True
        Else
            MsgBox("Has introducido una cadena demasiado larga " & valor)
            Return False
        End If
    End Function

    Public Function esNumerico(ByRef valor As String)
        If (Regex.IsMatch(valor, "^[0-9 ]+$")) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function haySitioMoto(ByRef listaVehiculosArray() As Vehiculo)
        Dim listaVehiculos As List(Of Vehiculo) = listaVehiculosArray.ToList
        Dim contadorMoto As Integer = 0
        For index As Integer = 0 To listaVehiculos.Count - 1
            If (listaVehiculos(index) Is Nothing) Then

            Else
                If listaVehiculos(index).getTipo.ToString = "moto" Then
                    contadorMoto = contadorMoto + 1
                End If
            End If

        Next
        If contadorMoto >= 3 Then
            Return False
        End If
        Return True

    End Function

    Public Function haySitioCoche(ByRef listaVehiculosArray() As Vehiculo)
        Dim listaVehiculos As List(Of Vehiculo) = listaVehiculosArray.ToList
        Dim contadorCoches As Integer = 0
        For index As Integer = 0 To listaVehiculos.Count - 1

            If (listaVehiculos(index) Is Nothing) Then

            Else
                If listaVehiculos(index).getTipo.ToString = "coche" Then
                    contadorCoches = contadorCoches + 1
                End If
            End If


        Next
        If contadorCoches >= 7 Then
            Return False
        End If
        Return True

    End Function

    Public Function comprobar_entrada_usuario(ByRef matricula As String, ByRef radioMoto As RadioButton, ByRef radioCoche As RadioButton, ByRef marca As String, ByRef modelo As String)

        If matricula.Length > 0 And (radioMoto.Checked Or radioCoche.Checked) And marca.Length > 0 And modelo.Length > 0 Then
            Principal.añadirTexto("Llego 1 ")
            ' Principal.añadirTexto(comprobarLongitud25(entradaVehiculo.matriculatxt.Text) And comprobarLongitud25(entradaVehiculo.textmarca.Text) And comprobarLongitud25(entradaVehiculo.textmodelo.Text))
            If (comprobarMatricula(matricula) And comprobarLongitud25(matricula) And comprobarLongitud25(marca) And comprobarLongitud25(modelo)) Then
                Principal.añadirTexto("Llego 2 ")
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function


End Class
