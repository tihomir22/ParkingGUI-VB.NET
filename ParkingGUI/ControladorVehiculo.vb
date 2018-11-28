Public Class ControladorVehiculo
    Public TextBox1 As TextBox

    Public Function iniciarArrayImagenes(ByRef lista As List(Of Image))
        lista.Add(Image.FromFile(Application.StartupPath() & "\camera1.jpg"))
        lista.Add(Image.FromFile(Application.StartupPath() & "\camera2.jpg"))
        lista.Add(Image.FromFile(Application.StartupPath() & "\camera3.jpg"))
        lista.Add(Image.FromFile(Application.StartupPath() & "\camera4.jpg"))
        lista.Add(Image.FromFile(Application.StartupPath() & "\camera5.jpg"))
        lista.Add(Image.FromFile(Application.StartupPath() & "\camera6.jpg"))
        lista.Add(Image.FromFile(Application.StartupPath() & "\camera7.jpg"))
        lista.Add(Image.FromFile(Application.StartupPath() & "\camera8.jpg"))
        Me.añadirTexto(lista.Count & " imagenes fueron dadas de alta!")
    End Function

    Private Function añadirTexto(ByRef texto As String)
        Me.TextBox1.Text = Me.TextBox1.Text & Environment.NewLine & texto
    End Function

    Public Sub Clicaso(sender As Object, e As EventArgs)
        añadirTexto("HAS CLICKEADO AL BOTON " & sender.ToString)
        Dim btn As Button = sender

        btn.BackColor = Color.DimGray
        btn.ForeColor = Color.White
        Form1.botonSeleccionadoCamara.BackColor = Color.White
        Form1.botonSeleccionadoCamara.ForeColor = Color.Black
        Form1.botonSeleccionadoCamara = btn
        Form1.Label5.Text = Form1.botonSeleccionadoCamara.Text

        Select Case Form1.Label5.Text
            Case "CAMERA 1"
                Form1.fotoActual.Image = Form1.listaImagenes(0)
            Case "CAMERA 2"
                Form1.fotoActual.Image = Form1.listaImagenes(1)
            Case "CAMERA 3"
                Form1.fotoActual.Image = Form1.listaImagenes(2)
            Case "CAMERA 4"
                Form1.fotoActual.Image = Form1.listaImagenes(3)
            Case "CAMERA 5"
                Form1.fotoActual.Image = Form1.listaImagenes(4)
            Case "CAMERA 6"
                Form1.fotoActual.Image = Form1.listaImagenes(5)
            Case "CAMERA 7"
                Form1.fotoActual.Image = Form1.listaImagenes(6)
            Case "CAMERA 8"
                Form1.fotoActual.Image = Form1.listaImagenes(7)
        End Select

        Me.añadirTexto("Mostrando " & Form1.Label5.Text)


    End Sub

    Public Function darDeAltaVehiculosLista()
        Dim coche As Vehiculo = New Vehiculo("coche", "8814HJK", "Opel", "Corsa")
        Dim coche2 As Vehiculo = New Vehiculo("coche", "123456HJK", "Tesla", "Modelo X")
        Dim moto1 As Vehiculo = New Vehiculo("moto", "453463DAS", "PIAGIO", "DiMama")
        Form1.listaVehiculosPlanta1 = New List(Of Vehiculo)({coche, coche2, moto1})

        Dim coch3 As Vehiculo = New Vehiculo("coche", "123124HA", "Ford", "Mondeo")
        Dim moto2 As Vehiculo = New Vehiculo("moto", "44556HJK", "Harley", "Davidson")
        Dim moto3 As Vehiculo = New Vehiculo("moto", "453456HAQ", "Suzuki", "Yamakuza")
        Form1.listaVehiculosPlanta2 = New List(Of Vehiculo)({coch3, moto2, moto3})

        Dim coch4 As Vehiculo = New Vehiculo("coche", "756344VCF", "BMW", "Serie 3")
        Dim coche5 As Vehiculo = New Vehiculo("coche", "4565465F", "Mercedes", "Benz")
        Dim coche6 As Vehiculo = New Vehiculo("coche", "14881488HFG", "Lamborgini", "Murcielago")
        Form1.listaVehiculosPlanta3 = New List(Of Vehiculo)({coch4, coche5, coche6})
    End Function


    Public Function asignarValorABotonesPlanta(ByRef listaVehiculos As List(Of Vehiculo), ByRef listaBotones As List(Of Button))
        'lista planta es listaVehiculos
        'listaPlanta1Botones es listabotones

        For index As Integer = 0 To listaVehiculos.Capacity - 1
            listaBotones(index).Tag = index
            If listaVehiculos(index) Is Nothing Then

            Else
                Dim btn As Button = listaBotones(index)
                AddHandler btn.Click, AddressOf Me.abrirInformacion
                btn.BackColor = ColorTranslator.FromHtml("#FF4136")
                If listaVehiculos(index).getTipo Is "moto" Then
                    Dim imagen As Image = Image.FromFile("C:\Users\mati\source\repos\ParkingGUI-VB.NET\iconos\motorcycle.png")
                    btn.Image = imagen
                Else
                    Dim imagen As Image = Image.FromFile("C:\Users\mati\source\repos\ParkingGUI-VB.NET\iconos\car.png")
                    btn.Image = imagen
                End If
                Me.añadirTexto(listaVehiculos(index).toString & "cargado con exito")

            End If


        Next
    End Function

    Public Function abrirInformacion(sender As Object, e As EventArgs)
        Dim btn As Button = sender
        Dim info As Informacion_coche = New Informacion_coche()
        If Form1.listaPlanta1Botones.Contains(btn) Then
            Me.añadirTexto("Se ha seleccionado " & Form1.listaPlanta1(btn.Tag).toString)

            info.TextBox1.Text = Form1.listaPlanta1(btn.Tag).toString
        ElseIf Form1.listaPlanta2Botones.Contains(btn) Then
            Me.añadirTexto("Se ha seleccionado " & Form1.listaPlanta2(btn.Tag).toString)
            info.TextBox1.Text = Form1.listaPlanta2(btn.Tag).toString
        ElseIf Form1.listaPlanta3Botones.Contains(btn) Then
            Me.añadirTexto("Se ha seleccionado " & Form1.listaPlanta3(btn.Tag).toString)
            info.TextBox1.Text = Form1.listaPlanta3(btn.Tag).toString
        End If



        info.ShowDialog()

    End Function

End Class
