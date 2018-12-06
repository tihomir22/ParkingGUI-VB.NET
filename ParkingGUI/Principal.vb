Imports System.Threading

Public Class Principal
    Public vehiculo As Vehiculo
    Public vehiculo2 As Vehiculo
    Public listaPlanta1() As Vehiculo
    Public listaPlanta1Botones() As Button
    Public listaPlanta2() As Vehiculo
    Public listaPlanta2Botones() As Button
    Public listaPlanta3() As Vehiculo
    Public listaPlanta3Botones() As Button
    Public botonSeleccionadoCamara As Button
    Public fotoActual As PictureBox
    Public listaImagenes As List(Of Image) = New List(Of Image)
    Private trd As Thread
    Public listaVehiculosPlanta1 As List(Of Vehiculo)
    Public listaVehiculosPlanta2 As List(Of Vehiculo)
    Public listaVehiculosPlanta3 As List(Of Vehiculo)

    Public listaIngresos As New List(Of Movimiento_contable)
    Public listaPagos As New List(Of Movimiento_contable)

    Private rutaIngresos As String = System.IO.Path.Combine(Application.StartupPath(), "ingresos.txt")
    Private rutaPagos As String = System.IO.Path.Combine(Application.StartupPath(), "pagos.txt")



    Public control As ControladorVehiculo


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        control = New ControladorVehiculo
        control.TextBox1 = Me.TextBox1

        Me.TextBox1.Text = "Cargado con exito : " & Me.ToString
        Me.cargarEventosBtnCamera()
        Me.botonSeleccionadoCamara = Me.Button36
        Me.fotoActual = Me.PictureBox2
        control.iniciarArrayImagenes(Me.listaImagenes)

        control.darDeAltaVehiculosLista()
        Me.darDeAltaVehiculosPlanta(Me.listaVehiculosPlanta1, 1)
        Me.darDeAltaVehiculosPlanta(Me.listaVehiculosPlanta2, 2)
        Me.darDeAltaVehiculosPlanta(Me.listaVehiculosPlanta3, 3)

        Me.leerContabilidad()



    End Sub

    Private Sub leerContabilidad()

        If System.IO.File.Exists(rutaIngresos) Then

            listaIngresos = control.readPayments(rutaIngresos)
            Me.añadirTexto(listaIngresos.Count & " ingresos leidos con exito")

        Else
            Me.añadirTexto("No existe el fichero de ingresos...")
        End If

        If System.IO.File.Exists(rutaPagos) Then
            listaPagos = control.readPayments(rutaPagos)
            Me.añadirTexto(listaPagos.Count & " pagos leidos con exito")
        Else
            Me.añadirTexto("No existe el fichero de pagos...")
        End If
    End Sub

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




    Public Function darDeAltaVehiculosPlanta(ByVal list As List(Of Vehiculo), ByVal numPlanta As Integer)
        'implementar autoasignacion
        Select Case numPlanta
            Case 1
                Me.listaPlanta1 = New Vehiculo(9) {Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
                Me.listaPlanta1 = Me.asignarVehiculoaPlanta(Me.listaPlanta1, list)
                Me.añadirTexto("Añadido con exito vehiculos de la planta 1")
                Me.listaPlanta1Botones = New Button(9) {Button6, Button7, Button8, Button9, Button10, Button11, Button12, Button13, Button14, Button15}
                Me.añadirTexto("Añadido con exito botones de la planta 1")
                control.asignarValorABotonesPlanta(Me.listaPlanta1, Me.listaPlanta1Botones.ToList)
            Case 2
                Me.listaPlanta2 = New Vehiculo(9) {Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
                Me.listaPlanta2 = Me.asignarVehiculoaPlanta(Me.listaPlanta2, list)
                Me.añadirTexto("Añadido con exito vehiculos de la planta 2")
                Me.listaPlanta2Botones = New Button(9) {Button16, Button21, Button19, Button17, Button18, Button25, Button23, Button24, Button20, Button22}
                Me.añadirTexto("Añadido con exito botones de la planta 2")
                control.asignarValorABotonesPlanta(Me.listaPlanta2, Me.listaPlanta2Botones.ToList)
            Case 3
                Me.listaPlanta3 = New Vehiculo(9) {Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
                Me.listaPlanta3 = Me.asignarVehiculoaPlanta(Me.listaPlanta3, list)
                Me.añadirTexto("Añadido con exito vehiculos de la planta 3")
                Me.listaPlanta3Botones = New Button(9) {Button26, Button29, Button28, Button27, Button30, Button35, Button33, Button34, Button31, Button32}
                Me.añadirTexto("Añadido con exito botones de la planta 3")
                control.asignarValorABotonesPlanta(Me.listaPlanta3, Me.listaPlanta3Botones.ToList)

        End Select

    End Function


    Public Function asignarVehiculoaPlanta(ByRef listaVehiculosPlanta As Vehiculo(), ByRef listaVehiculos As List(Of Vehiculo))
        For index As Integer = 0 To listaVehiculos.Count - 1
            listaVehiculosPlanta(listaVehiculos(index).getPlaza) = listaVehiculos(index)
        Next

        Return listaVehiculosPlanta
    End Function


    Public Sub cargarEventosBtnCamera()
        AddHandler Me.Button36.Click, AddressOf Me.control.Clicaso
        AddHandler Me.Button37.Click, AddressOf Me.control.Clicaso
        AddHandler Me.Button38.Click, AddressOf Me.control.Clicaso
        AddHandler Me.Button39.Click, AddressOf Me.control.Clicaso
        AddHandler Me.Button40.Click, AddressOf Me.control.Clicaso
        AddHandler Me.Button41.Click, AddressOf Me.control.Clicaso
        AddHandler Me.Button42.Click, AddressOf Me.control.Clicaso
        AddHandler Me.Button43.Click, AddressOf Me.control.Clicaso
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

    Public Function añadirTexto(ByRef texto As String)
        Me.TextBox1.Text = Me.TextBox1.Text & Environment.NewLine & texto
    End Function

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Me.añadirTexto("Has seleccionado el modo automatico")
        Dim indice As Integer = 1
        Me.trd = New Thread(AddressOf cambiarImagen)
        trd.IsBackground = True
        trd.Start()
        Dim imagenRandom As Image = Me.listaImagenes(CInt(Math.Ceiling(Rnd() * 6)) + 1)


    End Sub
    Private Function cambiarImagen()
        Dim listaBotones As Button() = {Button36, Button37, Button38, Button39, Button40, Button41, Button42, Button43}
        While Me.RadioButton2.Checked = False
            Dim random As Integer = CInt(Math.Ceiling(Rnd() * Me.listaImagenes.Capacity - 1)) + 0
            Dim btn As Button = listaBotones(random)
            Me.Label5.Invoke(Sub() Me.Label5.Text = "CAMERA " & (random + 1))
            Me.TextBox1.Invoke(Sub() Me.TextBox1.Text = Me.TextBox1.Text & Environment.NewLine & "Cambiando a " & Me.Label5.Text)
            Me.fotoActual.Invoke(Sub() Me.fotoActual.Image = listaImagenes(random))

            btn.Invoke(Sub() btn.BackColor = Color.DimGray)
            btn.Invoke(Sub() btn.ForeColor = Color.White)

            botonSeleccionadoCamara.Invoke(Sub() botonSeleccionadoCamara.BackColor = Color.White)
            botonSeleccionadoCamara.Invoke(Sub() botonSeleccionadoCamara.ForeColor = Color.Black)
            botonSeleccionadoCamara.Invoke(Sub() botonSeleccionadoCamara = btn)

            Thread.Sleep(1000)
        End While
    End Function
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Me.añadirTexto("Has seleccionado el modo manual")
    End Sub

    Private Sub Button47_Click(sender As Object, e As EventArgs) Handles Button47.Click
        Dim soporte As SoporteTecnico = New SoporteTecnico
        soporte.Show()
    End Sub
End Class
