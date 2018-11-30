Imports System.Windows.Forms

Public Class entradaVehiculo


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim listaVehiculosPlanta As List(Of Vehiculo)
        Dim tipoVehiculo As String

        If RadioButton1.Checked Then
            listaVehiculosPlanta = Principal.listaPlanta1.ToList

            Principal.añadirTexto("Elegiste la planta 1 ")
        ElseIf RadioButton2.Checked Then
            listaVehiculosPlanta = Principal.listaVehiculosPlanta2.ToList
            Principal.añadirTexto("Elegiste la planta 2 ")
        Else
            listaVehiculosPlanta = Principal.listaVehiculosPlanta3.ToList
            Principal.añadirTexto("Elegiste la planta 3 ")
        End If

        If RadioButton5.Checked Then
            tipoVehiculo = "moto"
        Else
            tipoVehiculo = "coche"
        End If

        If (listaVehiculosPlanta(Me.CheckedListBox1.GetItemText(Me.CheckedListBox1.SelectedIndex)) Is Nothing) Then
            Principal.añadirTexto("Elegiste la plaza " & Me.CheckedListBox1.GetItemText(Me.CheckedListBox1.SelectedIndex))

            Dim vehiculo As Vehiculo = New Vehiculo(tipoVehiculo, matriculatxt.Text, Me.textmarca.Text, Me.textmodelo.Text, Me.CheckedListBox1.GetItemText(Me.CheckedListBox1.SelectedIndex))
            Principal.listaPlanta1(Me.CheckedListBox1.GetItemText(Me.CheckedListBox1.SelectedIndex)) = vehiculo
            Principal.añadirTexto(Principal.listaPlanta1(Me.CheckedListBox1.GetItemText(Me.CheckedListBox1.SelectedIndex)).toString)
            Principal.añadirTexto(vehiculo.toString & "creado con exito")
        Else
            Principal.añadirTexto("Esa plaza esta ocupada")
        End If




        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles matriculatxt.TextChanged

    End Sub
End Class
