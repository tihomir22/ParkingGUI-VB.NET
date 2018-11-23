﻿Public Class Form1
    Public vehiculo As Vehiculo
    Public vehiculo2 As Vehiculo
    Public listaPlanta1() As Vehiculo
    Public listaPlanta1Botones() As Button
    Dim botonSeleccionadoCamara As Button
    Dim fotoActual As PictureBox
    Dim listaImagenes As List(Of Image) = New List(Of Image)


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.TextBox1.Text = "Cargado con exito : " & Me.ToString
        Me.cargarEventosBtnCamera()
        Me.botonSeleccionadoCamara = Me.Button36
        Me.fotoActual = Me.PictureBox2
        Me.iniciarArrayImagenes(Me.listaImagenes)
        Me.darDeAltaVehiculosPlanta1()

    End Sub
    Public Function darDeAltaVehiculosPlanta1()
        Dim coche As Vehiculo = New Vehiculo("coche", "8814HJK", "Opel", "Corsa")
        Dim coche2 As Vehiculo = New Vehiculo("coche", "123456HJK", "Tesla", "Modelo X")
        Dim moto1 As Vehiculo = New Vehiculo("moto", "453463DAS", "PIAGIO", "DiMama")
        Me.listaPlanta1 = New Vehiculo(9) {Nothing, coche, moto1, Nothing, Nothing, Nothing, Nothing, coche2, Nothing, Nothing}
        Me.añadirTexto("Añadido con exito vehiculos de la planta 1")
        Me.cargarBotonesPlanta1()
    End Function

    Public Function cargarBotonesPlanta1()
        Me.listaPlanta1Botones = New Button(9) {Button6, Button7, Button8, Button9, Button10, Button11, Button12, Button13, Button14, Button15}
        Me.añadirTexto("Añadido con exito botones de la planta 1")
        Me.asignarValorABotonesPlanta1()
    End Function

    Public Function asignarValorABotonesPlanta1()
        For index As Integer = 0 To Me.listaPlanta1.Length - 1
            Me.listaPlanta1Botones(index).Tag = index
            If Me.listaPlanta1(index) Is Nothing Then

            Else
                Dim btn As Button = Me.listaPlanta1Botones(index)
                AddHandler btn.Click, AddressOf Me.abrirInformacion
                btn.BackColor = ColorTranslator.FromHtml("#FF4136")
                If Me.listaPlanta1(index).getTipo Is "moto" Then
                    Dim imagen As Image = Image.FromFile("C:\Users\mati\source\repos\ParkingGUI-VB.NET\iconos\motorcycle.png")
                    btn.Image = imagen
                Else
                    Dim imagen As Image = Image.FromFile("C:\Users\mati\source\repos\ParkingGUI-VB.NET\iconos\car.png")
                    btn.Image = imagen
                End If
                Me.añadirTexto(Me.listaPlanta1(index).toString & "cargado con exito")

            End If


        Next
    End Function

    Public Function abrirInformacion(sender As Object, e As EventArgs)
        Dim btn As Button = sender
        Me.añadirTexto("Se ha seleccionado " & Me.listaPlanta1(btn.Tag).toString)
        Dim info As Informacion_coche = New Informacion_coche()
        info.TextBox1.Text = Me.listaPlanta1(btn.Tag).toString
        info.ShowDialog()

    End Function


    Public Function iniciarArrayImagenes(ByRef lista As List(Of Image))
        lista.Add(Image.FromFile("C:\Users\mati\source\repos\ParkingGUI-VB.NET\iconos\camera1.jpg"))
        lista.Add(Image.FromFile("C:\Users\mati\source\repos\ParkingGUI-VB.NET\iconos\camera2.jpg"))
        lista.Add(Image.FromFile("C:\Users\mati\source\repos\ParkingGUI-VB.NET\iconos\camera3.jpg"))
        lista.Add(Image.FromFile("C:\Users\mati\source\repos\ParkingGUI-VB.NET\iconos\camera4.jpg"))
        lista.Add(Image.FromFile("C:\Users\mati\source\repos\ParkingGUI-VB.NET\iconos\camera5.jpg"))
        lista.Add(Image.FromFile("C:\Users\mati\source\repos\ParkingGUI-VB.NET\iconos\camera6.jpg"))
        lista.Add(Image.FromFile("C:\Users\mati\source\repos\ParkingGUI-VB.NET\iconos\camera7.jpg"))
        lista.Add(Image.FromFile("C:\Users\mati\source\repos\ParkingGUI-VB.NET\iconos\camera8.jpg"))
        Me.añadirTexto(Me.listaImagenes.Count & " imagenes fueron dadas de alta!")
    End Function

    Public Sub cargarEventosBtnCamera()
        AddHandler Me.Button36.Click, AddressOf Me.Clicaso
        AddHandler Me.Button37.Click, AddressOf Me.Clicaso
        AddHandler Me.Button38.Click, AddressOf Me.Clicaso
        AddHandler Me.Button39.Click, AddressOf Me.Clicaso
        AddHandler Me.Button40.Click, AddressOf Me.Clicaso
        AddHandler Me.Button41.Click, AddressOf Me.Clicaso
        AddHandler Me.Button42.Click, AddressOf Me.Clicaso
        AddHandler Me.Button43.Click, AddressOf Me.Clicaso
    End Sub


    Private Sub Clicaso(sender As Object, e As EventArgs)
        añadirTexto("HAS CLICKEADO AL BOTON " & sender.ToString)
        Dim btn As Button = sender

        btn.BackColor = Color.DimGray
        btn.ForeColor = Color.White
        Me.botonSeleccionadoCamara.BackColor = Color.White
        Me.botonSeleccionadoCamara.ForeColor = Color.Black
        Me.botonSeleccionadoCamara = btn
        Me.Label5.Text = botonSeleccionadoCamara.Text

        Select Case Me.Label5.Text
            Case "CAMERA 1"
                Me.fotoActual.Image = Me.listaImagenes(0)
            Case "CAMERA 2"
                Me.fotoActual.Image = Me.listaImagenes(1)
            Case "CAMERA 3"
                Me.fotoActual.Image = Me.listaImagenes(2)
            Case "CAMERA 4"
                Me.fotoActual.Image = Me.listaImagenes(3)
            Case "CAMERA 5"
                Me.fotoActual.Image = Me.listaImagenes(4)
            Case "CAMERA 6"
                Me.fotoActual.Image = Me.listaImagenes(5)
            Case "CAMERA 7"
                Me.fotoActual.Image = Me.listaImagenes(6)
            Case "CAMERA 8"
                Me.fotoActual.Image = Me.listaImagenes(7)
        End Select

        Me.añadirTexto("Mostrando " & Me.Label5.Text)


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim entrada As entradaVehiculo = New entradaVehiculo
        Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
        entrada.TextBox2.Text = todaysdate
        entrada.Show()
        añadirTexto("Abriendo entrada vehiculo " & entrada.ToString)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim salida As bajaVehiculo = New bajaVehiculo
        salida.Show()
        añadirTexto("Abriendo baja vehiculo " & salida.ToString)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fijarPrecios As fijarPrecios = New fijarPrecios
        fijarPrecios.Show()
        añadirTexto("Abriendo fijar precios " & fijarPrecios.ToString)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim gestion As GestionGastos = New GestionGastos
        gestion.Show()
        añadirTexto("Abriendo gestion gastos " & gestion.ToString)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sacar As SacarCuentas = New SacarCuentas
        sacar.Show()
        añadirTexto("Abriendo sacar cuentas " & sacar.ToString)
    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Function añadirTexto(ByRef texto As String)
        Me.TextBox1.Text = Me.TextBox1.Text & Environment.NewLine & texto
    End Function

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Me.añadirTexto("Has seleccionado el modo automatico")
        Dim indice As Integer = 1


        Dim imagenRandom As Image = Me.listaImagenes(CInt(Math.Ceiling(Rnd() * 6)) + 1)


    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Me.añadirTexto("Has seleccionado el modo manual")
    End Sub

    Private Sub Button47_Click(sender As Object, e As EventArgs) Handles Button47.Click
        Dim soporte As SoporteTecnico = New SoporteTecnico
        soporte.Show()
    End Sub
End Class
