Public Class Form1
    Public vehiculo As Vehiculo
    Public vehiculo2 As Vehiculo
    Dim botonSeleccionadoCamara As Button

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.vehiculo = New Vehiculo("coche", "8814HJK", "Opel", "Corsa")
        Me.vehiculo2 = New Vehiculo("coche", "123456HJK", "Tesla", "Modelo X")
        Me.TextBox1.Text = "Cargado con exito : " & Me.ToString
        Me.cargarEventosBtnCamera()
        Me.botonSeleccionadoCamara = Me.Button36

    End Sub

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

    Private Sub Button6_MouseEnter(sender As Object, e As EventArgs) _
    Handles Button6.MouseEnter
        ToolTip1.SetToolTip(Button6, Me.vehiculo.toString())
    End Sub

    Private Sub Button7_MouseEnter(sender As Object, e As EventArgs) _
    Handles Button7.MouseEnter
        ToolTip1.SetToolTip(Button7, Me.vehiculo2.toString())
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


End Class
