Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class SacarCuentas
    Private gastosCheck As Boolean
    Private ingresosCheck As Boolean

    Private resultadoIngreso As Double
    Private resultadoPago As Double

    Private control As ControladorVehiculo = New ControladorVehiculo

    Private listaPagos As New List(Of Movimiento_contable)
    Private listaIngresos As New List(Of Movimiento_contable)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        gastosCheck = True
        Me.Gastos.Items.Clear()
        Principal.listaPagos.Clear()
        Me.listaPagos.Clear()
        Principal.listaPagos = control.readPayments(System.IO.Path.Combine(Application.StartupPath(), "pagos.txt"))
        Dim resultadoPagos As Double = 0
        For Each pago As Movimiento_contable In Principal.listaPagos
            Me.Gastos.Items.Add(pago.toString)
            Me.listaPagos.Add(pago)
            resultadoPagos = resultadoPagos + pago.getTotalImporte
        Next
        Me.TextBox1.Text = resultadoPagos & " €"
        Me.resultadoPago = resultadoPagos

        If Me.ingresosCheck And Me.gastosCheck Then
            If Me.resultadoPago > Me.resultadoIngreso Then
                Me.TextBox3.BackColor = Color.Red
                Me.TextBox3.Text = Math.Round((Me.resultadoPago - Me.resultadoIngreso), 2) & " €"
            Else
                Me.TextBox3.BackColor = Color.LightGreen
                Me.TextBox3.Text = Math.Round((Me.resultadoIngreso - Me.resultadoPago), 2) & " €"
            End If
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Me.ingresosCheck = True
        Me.Gastos.Items.Clear()
        Principal.listaIngresos.Clear()
        Me.listaIngresos.Clear()
        Principal.listaIngresos = control.readPayments(System.IO.Path.Combine(Application.StartupPath(), "ingresos.txt"))
        Dim resultadoIngresos As Double = 0
        For Each ingresos As Movimiento_contable In Principal.listaIngresos
            Me.Gastos.Items.Add(ingresos.toString)
            Me.listaIngresos.Add(ingresos)
            resultadoIngresos = resultadoIngresos + ingresos.getTotalImporte
        Next
        Me.TextBox2.Text = resultadoIngresos & " €"
        Me.resultadoIngreso = resultadoIngresos

        If Me.ingresosCheck And Me.gastosCheck Then
            If Me.resultadoPago > Me.resultadoIngreso Then
                Me.TextBox3.BackColor = Color.Red
                Me.TextBox3.Text = Math.Round((Me.resultadoPago - Me.resultadoIngreso), 2) & " €"
            Else
                Me.TextBox3.BackColor = Color.LightGreen
                Me.TextBox3.Text = Math.Round((Me.resultadoIngreso - Me.resultadoPago), 2) & " €"
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.TextBox1.Text.Length > 0 Then
            AddHandler PrintDocument1.PrintPage, AddressOf print_PrintPage
            ' indicamos que queremos imprimir
            PrintDocument1.DocumentName = "ResumenBalance"
            PrintDocument1.Print()
        Else
            MsgBox("no puedes imprimir algo que esta en blanco...")
        End If
    End Sub






    Private Sub print_PrintPage(ByVal sender As Object,
                            ByVal e As PrintPageEventArgs)
        Dim xPos As Single = e.MarginBounds.Left
        ' La fuente a usar
        Dim prFont As New Font("Arial", 16, FontStyle.Regular)
        Dim titulo As New Font("Arial", 20, FontStyle.Bold)
        ' la posición superior
        Dim yPos As Single = prFont.GetHeight(e.Graphics)
        Dim pagos As String
        Dim ingresos As String

        e.Graphics.DrawString("Pagos", titulo, Brushes.Black, xPos, yPos)
        yPos = yPos + prFont.GetHeight(e.Graphics) + prFont.GetHeight(e.Graphics)

        For Each pago As Movimiento_contable In listaPagos
            e.Graphics.DrawString(pago.toString, prFont, Brushes.Black, xPos, yPos)
            yPos = yPos + prFont.GetHeight(e.Graphics)
            MsgBox(pago.toString)
        Next

        yPos = yPos + prFont.GetHeight(e.Graphics)
        e.Graphics.DrawString("Ingresos", titulo, Brushes.Black, xPos, yPos)
        yPos = yPos + prFont.GetHeight(e.Graphics) + prFont.GetHeight(e.Graphics)
        For Each ingreso As Movimiento_contable In listaIngresos
            e.Graphics.DrawString(ingreso.toString, prFont, Brushes.Black, xPos, yPos)
            yPos = yPos + prFont.GetHeight(e.Graphics)
            MsgBox(ingreso.toString)
        Next
        'e.Graphics.DrawString("Pagos" & pagos & "Ingresos" & ingresos, prFont, Brushes.Black, xPos, yPos)

        ' indicamos que ya no hay nada más que imprimir
        ' (el valor predeterminado de esta propiedad es False)
        e.HasMorePages = False

    End Sub
End Class
