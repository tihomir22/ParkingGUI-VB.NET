Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class GestionGastos
    Private comision As Double
    Private precioBruto As Double
    Private precioNeto As Double
    Private metodoPago As String
    Private control As ControladorVehiculo = New ControladorVehiculo()
    Dim newPathPagos As String = System.IO.Path.Combine(Application.StartupPath(), "pagos.txt")

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TextBox1.TextLength > 0 And TextBox2.TextLength > 0 And TextBox3.TextLength > 0 And TextBox4.TextLength > 0 And TextBox5.TextLength > 0 Then
            If RadioButton1.Checked Or RadioButton2.Checked Or RadioButton3.Checked Or RadioButton4.Checked Then
                Dim movimiento As Movimiento_contable = New Movimiento_contable(Me.TextBox1.Text, Me.DateTimePicker1.Value.Date, Me.TextBox2.Text, Me.TextBox3.Text, Me.metodoPago, Me.comision, Me.precioNeto)
                MsgBox(movimiento.toString & "dado con exito")
                control.writePago(newPathPagos, movimiento)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("Te olvidaste de seleccionar una opcion de pago")
            End If
        Else
            MsgBox("Te olvidas de algun campo de texto")
        End If


    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave

        If Regex.IsMatch(TextBox3.Text, "^[0-9 ]+$") Then
            TextBox2.Text = CInt(Math.Ceiling(Rnd() * 1000)) + 100
            precioBruto = TextBox3.Text
            TextBox3.Text = TextBox3.Text & "€"
        Else
            MsgBox("Introduciste un importe incorrecto")
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox4.Text = "10%"
        Me.comision = 0.1
        Me.precioNeto = precioBruto * (1 + Me.comision)
        TextBox5.Text = precioBruto * (1 + Me.comision) & " €"
        Me.metodoPago = RadioButton1.Tag
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox4.Text = "15%"
        Me.comision = 0.15
        Me.precioNeto = precioBruto * (1 + Me.comision)
        TextBox5.Text = precioBruto * (1 + Me.comision) & " €"
        Me.metodoPago = RadioButton2.Tag
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        TextBox4.Text = "0%"
        Me.comision = 0.0
        Me.precioNeto = precioBruto * (1 + Me.comision)
        TextBox5.Text = precioBruto * (1 + Me.comision) & " €"
        Me.metodoPago = RadioButton4.Tag
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        TextBox4.Text = "50%"
        Me.comision = 0.5
        Me.precioNeto = precioBruto * (1 + Me.comision)
        TextBox5.Text = precioBruto * (1 + Me.comision) & " €"
        Me.metodoPago = RadioButton3.Tag
    End Sub
End Class
