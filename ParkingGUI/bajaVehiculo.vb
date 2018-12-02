Imports System.Windows.Forms

Public Class bajaVehiculo
    Private esCoche As Boolean
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDocument1.Print()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim listaVehiculosPlanta() As Vehiculo

        If RadioButton1.Checked Then
            'MsgBox("Has clickado planta 1 plazza " & Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
            listaVehiculosPlanta = Principal.listaPlanta1

            If listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex)) Is Nothing Then
            Else
                Dim vehiculo As Vehiculo = listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
                MsgBox(vehiculo.toString & " Seleccionado")
                ComboBox1.Text = vehiculo.getMatricula
                mostrarInformacion(vehiculo, 1)
            End If


        ElseIf RadioButton2.Checked Then
            'MsgBox("Has clickado planta 2 plazza " & Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
            listaVehiculosPlanta = Principal.listaPlanta2

            If listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex)) Is Nothing Then
            Else
                Dim vehiculo As Vehiculo = listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
                MsgBox(vehiculo.toString & " Seleccionado")
                ComboBox1.Text = vehiculo.getMatricula
                mostrarInformacion(vehiculo, 2)
            End If
        ElseIf RadioButton3.Checked Then
            'MsgBox("Has clickado planta 3 plazza " & Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))

            listaVehiculosPlanta = Principal.listaPlanta3
            If listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex)) Is Nothing Then
            Else
                Dim vehiculo As Vehiculo = listaVehiculosPlanta(Me.ListBox1.GetItemText(Me.ListBox1.SelectedIndex))
                MsgBox(vehiculo.toString & " Seleccionado")
                ComboBox1.Text = vehiculo.getMatricula
                mostrarInformacion(vehiculo, 3)
            End If
        Else
            MsgBox("Debes elegir una planta")
        End If


    End Sub


    Public Function mostrarInformacion(ByRef vehiculo As Vehiculo, ByVal planta As Integer)
        Dim fechaVehiculo As Date = vehiculo.getFecha
        Dim fechaActual As Date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Dim diferenciaEnDias = fechaActual - fechaVehiculo
        Dim days As Integer = diferenciaEnDias.TotalDays
        Dim hours As Integer = diferenciaEnDias.TotalHours
        Dim minutes As Integer = diferenciaEnDias.TotalMinutes Mod 60



        Me.TextBox1.Text = ("Planta: " & planta & Environment.NewLine & "Plaza: " & vehiculo.getPlaza & Environment.NewLine & "Matricula:" & vehiculo.getMatricula & Environment.NewLine & "Marca : " & vehiculo.getMarca & Environment.NewLine & "Modelo:" & vehiculo.getModelo & Environment.NewLine & "Precio :" & Environment.NewLine)
        If vehiculo.getTipo = "moto" Then
            'tarifa de moto  0,30€ por 30 mins 
            Me.esCoche = False
            Me.TextBox1.Text = Me.TextBox1.Text & " tarifa de moto : 0,30€ por 30 minutos" & Environment.NewLine
        Else
            'tarifa de coche 0,40€ por 30 mins
            Me.esCoche = True
            Me.TextBox1.Text = Me.TextBox1.Text & " tarifa de coche : 0,40€ por 30 minutos" & Environment.NewLine
        End If
        Me.TextBox1.Text = Me.TextBox1.Text & " Dias estacionado : " & days & Environment.NewLine & " Horas estacionado : " & hours & Environment.NewLine & " Minutos estacionado : " & minutes & Environment.NewLine
        Me.TextBox1.Text = Me.TextBox1.Text & "Total a pagar " & Me.TotalAPagar(days, hours, diferenciaEnDias.TotalMinutes) & "€" & Environment.NewLine

    End Function

    Public Function TotalAPagar(ByVal dias As Integer, ByVal horas As Integer, ByVal minutos As Integer)

        Dim diasAMinutos As Double = ((dias * 24) * 60)
        Dim HorasAMinutos As Double = horas * 60
        Dim Resultado As Double = diasAMinutos + HorasAMinutos + minutos

        Dim cantidadMultiplicable As Double = Resultado / 30

        If (cantidadMultiplicable > 0) Then
            If esCoche = True Then
                Return cantidadMultiplicable * 0.4
            Else
                Return cantidadMultiplicable * 0.3
            End If
        Else
            Return "Gratis"
        End If


    End Function

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim reportFont As Font = New Drawing.Font("Times New Roman", 14)
        e.Graphics.DrawString("Factura informativa ", reportFont, Brushes.Black, 100, 100)
        e.Graphics.DrawString("Cuerpo del documento ", reportFont, Brushes.Black, 100, 100)
    End Sub
End Class


