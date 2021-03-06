﻿Imports System.Windows.Forms

Public Class entradaVehiculo
    Public control As ControladorVehiculo = New ControladorVehiculo
    Public plantaTmp As Integer
    Public cajaNegra As CajaNegra = New CajaNegra


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim listaVehiculosPlanta() As Vehiculo
        Dim tipoVehiculo As String
        Dim newfile As String = "bbdd.txt"
        Dim newPath As String = System.IO.Path.Combine(Application.StartupPath(), newfile)

        If RadioButton5.Checked Then
            tipoVehiculo = "coche"
        Else
            tipoVehiculo = "moto"
        End If
        'si no le decimos el lugar al que debe entrar...
        If RadioButton1.Checked = False And RadioButton2.Checked = False And RadioButton3.Checked = False And ListBox1.SelectedItem = Nothing Then
            MsgBox("No seleccionaste coordenadas")
            If cajaNegra.comprobar_entrada_usuario(Me.matriculatxt.Text, Me.RadioButton5, Me.RadioButton6, Me.textmarca.Text, Me.textmodelo.Text) Then
                Dim resultadoPosicion As Integer = Me.recalcular_posicion()
                If resultadoPosicion <> -1 Then
                    Dim vehiculo As Vehiculo = New Vehiculo(tipoVehiculo, matriculatxt.Text, Me.textmarca.Text, Me.textmodelo.Text, resultadoPosicion)
                    vehiculo.setFecha(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                    vehiculo.setHours()
                    vehiculo.setMinutes()

                    control.writeAObject(newPath, vehiculo, Me.plantaTmp)
                    control.darDeAltaVehiculosLista()
                    Select Case Me.plantaTmp
                        Case 1
                            Select Case vehiculo.getTipo
                                Case "moto"
                                    If cajaNegra.haySitioMoto(Principal.listaPlanta1) Then
                                        Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta1, 1)
                                        MsgBox("Se ha añadido con exito el vehiculo" & vehiculo.toString)
                                    Else
                                        MsgBox("No se puede añadir más vehiculos de ese tipo " & vehiculo.toString)
                                    End If
                                Case "coche"
                                    If cajaNegra.haySitioCoche(Principal.listaPlanta1) Then
                                        Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta1, 1)
                                        MsgBox("Se ha añadido con exito el vehiculo" & vehiculo.toString)
                                    Else
                                        MsgBox("No se puede añadir más vehiculos de ese tipo " & vehiculo.toString)
                                    End If
                            End Select

                        Case 2
                            Select Case vehiculo.getTipo
                                Case "moto"
                                    If cajaNegra.haySitioMoto(Principal.listaPlanta2) Then
                                        Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta2, 2)
                                        MsgBox("Se ha añadido con exito el vehiculo" & vehiculo.toString)
                                    Else
                                        MsgBox("No se puede añadir más vehiculos de ese tipo " & vehiculo.toString)
                                    End If
                                Case "coche"
                                    If cajaNegra.haySitioCoche(Principal.listaPlanta2) Then
                                        Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta2, 2)
                                        MsgBox("Se ha añadido con exito el vehiculo" & vehiculo.toString)
                                    Else
                                        MsgBox("No se puede añadir más vehiculos de ese tipo " & vehiculo.toString)
                                    End If
                            End Select

                        Case 3
                            Select Case vehiculo.getTipo
                                Case "moto"
                                    If cajaNegra.haySitioMoto(Principal.listaPlanta3) Then
                                        Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta3, 3)
                                        MsgBox("Se ha añadido con exito el vehiculo" & vehiculo.toString)
                                    Else
                                        MsgBox("No se puede añadir más vehiculos de ese tipo " & vehiculo.toString)
                                    End If
                                Case "coche"
                                    If cajaNegra.haySitioCoche(Principal.listaPlanta3) Then
                                        Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta3, 3)
                                        MsgBox("Se ha añadido con exito el vehiculo" & vehiculo.toString)
                                    Else
                                        MsgBox("No se puede añadir más vehiculos de ese tipo " & vehiculo.toString)
                                    End If
                            End Select
                    End Select

                    Principal.añadirTexto(vehiculo.toString & "creado con exito")
                Else
                    MsgBox("Estamos a tope no se puede añadir mas vehiculos!")
                End If
            Else
                MsgBox("Te faltan datos por introducir por lo que no se añade ningun vehiculo")
            End If
        Else
            If cajaNegra.comprobar_entrada_usuario(Me.matriculatxt.Text, Me.RadioButton5, Me.RadioButton6, Me.textmarca.Text, Me.textmodelo.Text) Then
                If RadioButton1.Checked Then
                    listaVehiculosPlanta = Principal.listaPlanta1
                    Dim indice As Integer = 0

                    Principal.añadirTexto("Elegiste la plaza " & Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex) & "y la planta 1")
                    Dim vehiculo As Vehiculo = New Vehiculo(tipoVehiculo, matriculatxt.Text, Me.textmarca.Text, Me.textmodelo.Text, Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
                    vehiculo.setFecha(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                    vehiculo.setHours()
                    vehiculo.setMinutes()

                    If (listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex)) Is Nothing) Then
                        If (tipoVehiculo = "moto") Then
                            If (cajaNegra.haySitioMoto(listaVehiculosPlanta) = True) Then
                                control.writeAObject(newPath, vehiculo, 1)
                                control.darDeAltaVehiculosLista()
                                Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta1, 1)
                                Principal.añadirTexto(vehiculo.toString & "creado con exito")
                            Else
                                MsgBox("No se puede añadir más vehiculos de tipo !" & tipoVehiculo)
                            End If
                        Else
                            If (cajaNegra.haySitioCoche(listaVehiculosPlanta) = True) Then
                                control.writeAObject(newPath, vehiculo, 1)
                                control.darDeAltaVehiculosLista()
                                Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta1, 1)
                                Principal.añadirTexto(vehiculo.toString & "creado con exito")
                            Else
                                MsgBox("No se puede añadir más vehiculos de tipo !" & tipoVehiculo)
                            End If
                        End If

                    Else
                        MsgBox("Esa plaza esta ocupada!")
                    End If



                ElseIf RadioButton2.Checked Then
                    listaVehiculosPlanta = Principal.listaPlanta2
                    Dim indice As Integer = 0

                    Principal.añadirTexto("Elegiste la plaza " & Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex) & "y la planta 2")
                    Dim vehiculo As Vehiculo = New Vehiculo(tipoVehiculo, matriculatxt.Text, Me.textmarca.Text, Me.textmodelo.Text, Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
                    vehiculo.setFecha(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                    vehiculo.setHours()
                    vehiculo.setMinutes()

                    If (listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex)) Is Nothing) Then
                        If (tipoVehiculo = "moto") Then
                            If (cajaNegra.haySitioMoto(listaVehiculosPlanta) = True) Then
                                control.writeAObject(newPath, vehiculo, 2)
                                control.darDeAltaVehiculosLista()
                                Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta2, 2)
                                Principal.añadirTexto(vehiculo.toString & "creado con exito")
                            Else
                                MsgBox("No se puede añadir más vehiculos de tipo !" & tipoVehiculo)
                            End If
                        Else
                            If (cajaNegra.haySitioCoche(listaVehiculosPlanta) = True) Then
                                control.writeAObject(newPath, vehiculo, 2)
                                control.darDeAltaVehiculosLista()
                                Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta2, 2)
                                Principal.añadirTexto(vehiculo.toString & "creado con exito")
                            Else
                                MsgBox("No se puede añadir más vehiculos de tipo !" & tipoVehiculo)
                            End If
                        End If
                    Else
                        MsgBox("Esa plaza esta ocupada!")
                    End If


                Else
                    listaVehiculosPlanta = Principal.listaPlanta3
                    Dim indice As Integer = 0

                    Principal.añadirTexto("Elegiste la plaza " & Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex) & "y la planta 3")
                    Dim vehiculo As Vehiculo = New Vehiculo(tipoVehiculo, matriculatxt.Text, Me.textmarca.Text, Me.textmodelo.Text, Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
                    vehiculo.setFecha(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                    vehiculo.setHours()
                    vehiculo.setMinutes()

                    If (listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex)) Is Nothing) Then
                        If (tipoVehiculo = "moto") Then
                            If (cajaNegra.haySitioMoto(listaVehiculosPlanta) = True) Then
                                control.writeAObject(newPath, vehiculo, 3)
                                control.darDeAltaVehiculosLista()
                                Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta3, 3)
                                Principal.añadirTexto(vehiculo.toString & "creado con exito")
                            Else
                                MsgBox("No se puede añadir más vehiculos de tipo !" & tipoVehiculo)
                            End If
                        Else
                            If (cajaNegra.haySitioCoche(listaVehiculosPlanta) = True) Then
                                control.writeAObject(newPath, vehiculo, 3)
                                control.darDeAltaVehiculosLista()
                                Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta3, 3)
                                Principal.añadirTexto(vehiculo.toString & "creado con exito")
                            Else
                                MsgBox("No se puede añadir más vehiculos de tipo !" & tipoVehiculo)
                            End If
                        End If
                    Else
                        MsgBox("Esa plaza esta ocupada!")
                    End If

                End If
            Else
                MsgBox("Te faltan datos por introducir por lo que no se añade ningun vehiculo")
            End If
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Function recalcular_posicion()

        For i As Integer = 0 To Principal.listaPlanta1.Length - 1
            If Principal.listaPlanta1(i) Is Nothing Then
                MsgBox("Se ha encontrado hueco en " & i & " planta 1")
                Me.plantaTmp = 1
                Return i
            End If
        Next

        For i As Integer = 0 To Principal.listaPlanta2.Length - 1
            If Principal.listaPlanta2(i) Is Nothing Then
                MsgBox("Se ha encontrado hueco en " & i & " planta 2")
                Me.plantaTmp = 2
                Return i
            End If
        Next

        For i As Integer = 0 To Principal.listaPlanta3.Length - 1
            If Principal.listaPlanta3(i) Is Nothing Then
                MsgBox("Se ha encontrado hueco en " & i & " planta 3")
                Me.plantaTmp = 3
                Return i
            End If
        Next

        Return -1
    End Function



    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles matriculatxt.TextChanged


    End Sub

    Private Sub textmarca_TextChanged(sender As Object, e As EventArgs) Handles textmarca.TextChanged

    End Sub

    Private Sub textmodelo_TextChanged(sender As Object, e As EventArgs) Handles textmodelo.TextChanged

    End Sub
End Class
