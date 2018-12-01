Imports System.Windows.Forms

Public Class entradaVehiculo
    Public control As ControladorVehiculo = New ControladorVehiculo

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
                    If (Principal.haySitioMoto(listaVehiculosPlanta) = True) Then
                        control.writeAObject(newPath, vehiculo, 1)
                        control.darDeAltaVehiculosLista()
                        Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta1, 1)
                        Principal.añadirTexto(vehiculo.toString & "creado con exito")
                    Else
                        MsgBox("No se puede añadir más vehiculos de tipo !" & tipoVehiculo)
                    End If
                Else
                    If (Principal.haySitioCoche(listaVehiculosPlanta) = True) Then
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
                    If (Principal.haySitioMoto(listaVehiculosPlanta) = True) Then
                        control.writeAObject(newPath, vehiculo, 2)
                        control.darDeAltaVehiculosLista()
                        Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta2, 2)
                        Principal.añadirTexto(vehiculo.toString & "creado con exito")
                    Else
                        MsgBox("No se puede añadir más vehiculos de tipo !" & tipoVehiculo)
                    End If
                Else
                    If (Principal.haySitioCoche(listaVehiculosPlanta) = True) Then
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
                    If (Principal.haySitioMoto(listaVehiculosPlanta) = True) Then
                        control.writeAObject(newPath, vehiculo, 3)
                        control.darDeAltaVehiculosLista()
                        Principal.darDeAltaVehiculosPlanta(Principal.listaVehiculosPlanta3, 3)
                        Principal.añadirTexto(vehiculo.toString & "creado con exito")
                    Else
                        MsgBox("No se puede añadir más vehiculos de tipo !" & tipoVehiculo)
                    End If
                Else
                    If (Principal.haySitioCoche(listaVehiculosPlanta) = True) Then
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

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles matriculatxt.TextChanged

    End Sub
End Class
