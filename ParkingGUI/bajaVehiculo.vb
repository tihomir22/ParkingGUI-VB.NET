Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class bajaVehiculo
    Private fechaActualMov As Date
    Private numFacturaMov As Integer
    Private totalPagarMov As Double

    Private esCoche As Boolean
    Private vehiculoSeleccionado As Vehiculo
    Public plantaElegida As Integer
    Private control As ControladorVehiculo = New ControladorVehiculo()
    Dim newfile As String = "bbdd.txt"
    Dim newPath As String = System.IO.Path.Combine(Application.StartupPath(), newfile)
    Dim newPathIngresos As String = System.IO.Path.Combine(Application.StartupPath(), "ingresos.txt")

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.vehiculoSeleccionado Is Nothing Then
        Else
            If Me.RadioButton1.Checked Then
                plantaElegida = 1
            ElseIf Me.RadioButton2.Checked Then
                plantaElegida = 2
            Else
                plantaElegida = 3
            End If



            control.removeObject(newPath, vehiculoSeleccionado)
            control.darDeAltaVehiculosLista()
            Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta1, 1)
            Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta2, 2)
            Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta3, 3)
            Dim btn As Button = control.devolverBotonSegunIndice(vehiculoSeleccionado.getPlaza(), Me.plantaElegida)

            Principal.añadirTexto(vehiculoSeleccionado.toString & "eliminado con exito")
            Dim movimiento As Movimiento_contable = New Movimiento_contable("Ingreso por salida de vehiculo con matricula" & vehiculoSeleccionado.getMatricula, Me.fechaActualMov, Me.numFacturaMov, obtenerTarifa(), "efectivo", 0, Me.totalPagarMov)
            control.writePago(newPathIngresos, movimiento)
            MsgBox(movimiento.toString)
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As Object,
                                    ByVal e As EventArgs) _
                                    Handles Button1.Click
        ' ejemplo simple para imprimir en .NET
        ' Usamos una clase del tipo PrintDocument
        'Dim printDoc As New PrintDocument
        ' asignamos el método de evento para cada página a imprimir
        If Me.TextBox1.Text.Length > 0 Then
            AddHandler PrintDocument1.PrintPage, AddressOf print_PrintPage
            ' indicamos que queremos imprimir
            PrintDocument1.DocumentName = vehiculoSeleccionado.getMatricula & vehiculoSeleccionado.getMarca
            PrintDocument1.Print()
        Else
            MsgBox("no puedes imprimir algo que esta en blanco...")
        End If


    End Sub




    Private Sub print_PrintPage(ByVal sender As Object,
                            ByVal e As PrintPageEventArgs)
        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita

        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left
        ' La fuente a usar
        Dim prFont As New Font("Arial", 16, FontStyle.Regular)
        ' la posición superior
        Dim yPos As Single = prFont.GetHeight(e.Graphics)

        ' imprimimos la cadena
        Me.numFacturaMov = CInt(Math.Ceiling(Rnd() * 1000)) + 100
        e.Graphics.DrawString("************* TICKET *************" & Environment.NewLine & "Num Ticket" & numFacturaMov & Environment.NewLine & Me.TextBox1.Text & Environment.NewLine & "*************FIN TICKET *************", prFont, Brushes.Black, xPos, yPos)

        ' indicamos que ya no hay nada más que imprimir
        ' (el valor predeterminado de esta propiedad es False)
        e.HasMorePages = False

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim listaVehiculosPlanta() As Vehiculo

        If RadioButton1.Checked Then
            'MsgBox("Has clickado planta 1 plazza " & Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
            listaVehiculosPlanta = Principal.listaPlanta1

            If listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex)) Is Nothing Then
            Else
                vehiculoSeleccionado = listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
                MsgBox(vehiculoSeleccionado.toString & " Seleccionado")
                ComboBox1.Text = vehiculoSeleccionado.getMatricula
                mostrarInformacion(vehiculoSeleccionado, 1)
            End If


        ElseIf RadioButton2.Checked Then
            'MsgBox("Has clickado planta 2 plazza " & Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
            listaVehiculosPlanta = Principal.listaPlanta2

            If listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex)) Is Nothing Then
            Else
                vehiculoSeleccionado = listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
                MsgBox(vehiculoSeleccionado.toString & " Seleccionado")
                ComboBox1.Text = vehiculoSeleccionado.getMatricula
                mostrarInformacion(vehiculoSeleccionado, 2)
            End If
        ElseIf RadioButton3.Checked Then
            'MsgBox("Has clickado planta 3 plazza " & Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))

            listaVehiculosPlanta = Principal.listaPlanta3
            If listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex)) Is Nothing Then
            Else
                vehiculoSeleccionado = listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
                MsgBox(vehiculoSeleccionado.toString & " Seleccionado")
                ComboBox1.Text = vehiculoSeleccionado.getMatricula
                mostrarInformacion(vehiculoSeleccionado, 3)
            End If
        Else
            MsgBox("Debes elegir una planta")
        End If


    End Sub


    Public Function mostrarInformacion(ByRef vehiculo As Vehiculo, ByVal planta As Integer)
        Dim fechaVehiculo As Date = vehiculo.getFecha
        'Dim fechaActual As Date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Dim fechaActual As Date = DateTimePicker1.Value.ToString("yyyy/MM/dd HH:mm:ss")


        MsgBox(fechaActual)
        Dim diferenciaEnDias = fechaActual - fechaVehiculo
        Dim days As Integer = diferenciaEnDias.TotalDays
        Dim hours As Integer = diferenciaEnDias.TotalHours
        Dim minutes As Integer = diferenciaEnDias.TotalMinutes Mod 60

        Me.fechaActualMov = fechaActual


        Me.TextBox1.Text = ("Planta: " & planta & Environment.NewLine & "Plaza: " & vehiculo.getPlaza & Environment.NewLine & "Matricula:" & vehiculo.getMatricula & Environment.NewLine & "Marca : " & vehiculo.getMarca & Environment.NewLine & "Modelo:" & vehiculo.getModelo & Environment.NewLine & "Precio :" & Environment.NewLine)
        If vehiculo.getTipo = "moto" Then
            'tarifa de moto  0,30€ por 30 mins 
            Me.esCoche = False
            Me.TextBox1.Text = Me.TextBox1.Text & " tarifa de moto : " & obtenerTarifa() & "€ por 30 minutos" & Environment.NewLine
        Else
            'tarifa de coche 0,40€ por 30 mins
            Me.esCoche = True
            Me.TextBox1.Text = Me.TextBox1.Text & " tarifa de coche : " & obtenerTarifa() & "€ por 30 minutos" & Environment.NewLine
        End If
        Me.totalPagarMov = Me.TotalAPagar(days, hours, diferenciaEnDias.TotalMinutes)
        Me.TextBox1.Text = Me.TextBox1.Text & " Dias estacionado : " & days & Environment.NewLine & " Horas estacionado : " & hours & Environment.NewLine & " Minutos estacionado : " & minutes & Environment.NewLine
        Me.TextBox1.Text = Me.TextBox1.Text & "Total a pagar " & Me.totalPagarMov & "€" & Environment.NewLine

    End Function

    Public Function TotalAPagar(ByVal dias As Integer, ByVal horas As Integer, ByVal minutos As Integer)

        Dim diasAMinutos As Double = ((dias * 24) * 60)
        Dim HorasAMinutos As Double = horas * 60
        Dim Resultado As Double = diasAMinutos + HorasAMinutos + minutos

        Dim cantidadMultiplicable As Double = Resultado / 30

        If (cantidadMultiplicable > 0) Then
            If esCoche = True Then
                Return cantidadMultiplicable * obtenerTarifa()
            Else
                Return cantidadMultiplicable * obtenerTarifa()
            End If
        Else
            Return 0
        End If


    End Function


    Public Function obtenerTarifa()
        Dim newPathMoto As String = System.IO.Path.Combine(Application.StartupPath(), "tarifaMoto.txt")
        Dim newPathCoche As String = System.IO.Path.Combine(Application.StartupPath(), "tarifaCoche.txt")

        If esCoche Then
            If System.IO.File.Exists(newPathCoche) Then
                Dim tarifaCoche As Tarifa = control.leerTarifa(newPathCoche)
                Return tarifaCoche.getImporteTarifa
            Else
                Return 0.4
            End If
        Else
            If System.IO.File.Exists(newPathMoto) Then
                Dim tarifaMoto As Tarifa = control.leerTarifa(newPathMoto)
                Return tarifaMoto.getImporteTarifa
            Else
                Return 0.3
            End If

        End If


    End Function

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

    End Sub
End Class


