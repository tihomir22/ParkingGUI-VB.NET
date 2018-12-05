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
        Principal.TextBox1.Text = Principal.TextBox1.Text & Environment.NewLine & texto
    End Function

    Public Sub Clicaso(sender As Object, e As EventArgs)
        añadirTexto("HAS CLICKEADO AL BOTON " & sender.ToString)
        Dim btn As Button = sender

        btn.BackColor = Color.DimGray
        btn.ForeColor = Color.White
        Principal.botonSeleccionadoCamara.BackColor = Color.White
        Principal.botonSeleccionadoCamara.ForeColor = Color.Black
        Principal.botonSeleccionadoCamara = btn
        Principal.Label5.Text = Principal.botonSeleccionadoCamara.Text

        Select Case Principal.Label5.Text
            Case "CAMERA 1"
                Principal.fotoActual.Image = Principal.listaImagenes(0)
            Case "CAMERA 2"
                Principal.fotoActual.Image = Principal.listaImagenes(1)
            Case "CAMERA 3"
                Principal.fotoActual.Image = Principal.listaImagenes(2)
            Case "CAMERA 4"
                Principal.fotoActual.Image = Principal.listaImagenes(3)
            Case "CAMERA 5"
                Principal.fotoActual.Image = Principal.listaImagenes(4)
            Case "CAMERA 6"
                Principal.fotoActual.Image = Principal.listaImagenes(5)
            Case "CAMERA 7"
                Principal.fotoActual.Image = Principal.listaImagenes(6)
            Case "CAMERA 8"
                Principal.fotoActual.Image = Principal.listaImagenes(7)
        End Select

        Me.añadirTexto("Mostrando " & Principal.Label5.Text)


    End Sub

    Public Function darDeAltaVehiculosLista()
        Dim newfile As String = "bbdd.txt"
        Dim newPath As String = System.IO.Path.Combine(Application.StartupPath(), newfile)
        If System.IO.File.Exists(newPath) = True Then
            Principal.listaVehiculosPlanta1 = reader(newPath, "1")
            Principal.listaVehiculosPlanta2 = reader(newPath, "2")
            Principal.listaVehiculosPlanta3 = reader(newPath, "3")

        Else
            Dim coche As Vehiculo = New Vehiculo("coche", "8814HJK", "Opel", "Corsa", 2, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 10, 10)
            Dim coche2 As Vehiculo = New Vehiculo("coche", "123456HJK", "Tesla", "Modelo X", 4, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 10, 10)
            Dim moto1 As Vehiculo = New Vehiculo("moto", "453463DAS", "PIAGIO", "DiMama", 6, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 10, 10)
            Principal.listaVehiculosPlanta1 = New List(Of Vehiculo)({coche, coche2, moto1})
            Me.writer(newPath, Principal.listaVehiculosPlanta1, 1)

            Dim coch3 As Vehiculo = New Vehiculo("coche", "123124HA", "Ford", "Mondeo", 3, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 10, 10)
            Dim moto2 As Vehiculo = New Vehiculo("moto", "44556HJK", "Harley", "Davidson", 5, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 10, 10)
            Dim moto3 As Vehiculo = New Vehiculo("moto", "453456HAQ", "Suzuki", "Yamakuza", 7, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 10, 10)
            Principal.listaVehiculosPlanta2 = New List(Of Vehiculo)({coch3, moto2, moto3})
            Me.writer(newPath, Principal.listaVehiculosPlanta2, 2)

            Dim coch4 As Vehiculo = New Vehiculo("coche", "756344VCF", "BMW", "Serie 3", 1, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 10, 10)
            Dim coche5 As Vehiculo = New Vehiculo("coche", "4565465F", "Mercedes", "Benz", 4, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 10, 10)
            Dim coche6 As Vehiculo = New Vehiculo("coche", "14881488HFG", "Lamborgini", "Murcielago", 8, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 10, 10)
            Principal.listaVehiculosPlanta3 = New List(Of Vehiculo)({coch4, coche5, coche6})
            Me.writer(newPath, Principal.listaVehiculosPlanta3, 3)
        End If

    End Function

    Function reader(ByRef newPath As String, ByVal numPlanta As String)
        Dim list As New List(Of Vehiculo)

        Using sr As New System.IO.StreamReader(newPath)
            Dim strAux As String = "Dembow"
            While sr.Peek <> -1
                strAux = sr.ReadLine()
                Dim listaItems As String() = strAux.Split(";")

                If numPlanta = listaItems(0).ToString Then
                    Dim vehiculo As Vehiculo = New Vehiculo(listaItems(1), listaItems(2), listaItems(3), listaItems(4), Convert.ToInt32(listaItems(5)), listaItems(6), listaItems(7), listaItems(8))

                    list.Add(vehiculo)
                    Me.añadirTexto("Leido vehiculo" & vehiculo.toString)

                End If

            End While
            sr.Close()
        End Using

        Return list
    End Function

    Sub writer(ByRef newPath As String, ByVal list As List(Of Vehiculo), ByVal planta As Integer)

        Using sw As New System.IO.StreamWriter(newPath, True)

            For Each item As Vehiculo In list
                sw.WriteLine(planta & ";" & item.toCSV)
            Next
            sw.Flush() ''yeap I'm the sort of person that flushes it then closes it
            sw.Close()


        End Using
    End Sub

    Sub writeAObject(ByRef newPath As String, ByVal vehiculo As Vehiculo, ByVal planta As Integer)

        Using sw As New System.IO.StreamWriter(newPath, True)

            sw.WriteLine(planta & ";" & vehiculo.toCSV)
            sw.Flush() ''yeap I'm the sort of person that flushes it then closes it
            sw.Close()


        End Using
    End Sub

    Sub writeTarifa(ByVal newPath As String, ByVal tarifa As Tarifa)
        Using sw As New System.IO.StreamWriter(newPath, True)
            sw.WriteLine(tarifa.toCSV)
            sw.Flush() ''yeap I'm the sort of person that flushes it then closes it
            sw.Close()
        End Using
    End Sub

    Sub removeObject(ByRef newPath As String, ByVal vehiculo As Vehiculo)
        Dim listaVehiculos As New List(Of Vehiculo)
        Dim listaPlantasOrdenada As New List(Of String)

        Using sr As New System.IO.StreamReader(newPath)
            Dim strAux As String = "Dembow"
            While sr.Peek <> -1
                strAux = sr.ReadLine()
                Dim listaItems As String() = strAux.Split(";")
                Dim vehiculoLeido As Vehiculo = New Vehiculo(listaItems(1), listaItems(2), listaItems(3), listaItems(4), Convert.ToInt32(listaItems(5)), listaItems(6), listaItems(7), listaItems(8))

                If vehiculo.getMatricula = vehiculoLeido.getMatricula Then
                    MsgBox("Eliminando " & vehiculo.getMatricula)
                Else
                    listaVehiculos.Add(vehiculoLeido)
                    Me.añadirTexto("Leido vehiculo" & vehiculo.toString)
                    listaPlantasOrdenada.Add(listaItems(0))
                End If
            End While
            sr.Close()
        End Using

        Using sw As New System.IO.StreamWriter(newPath)
            Dim int As Integer = 0
            For Each item As Vehiculo In listaVehiculos
                sw.WriteLine(listaPlantasOrdenada(int) & ";" & item.toCSV)
                int = int + 1
            Next
            sw.Flush() ''yeap I'm the sort of person that flushes it then closes it
            sw.Close()


        End Using




    End Sub

    Public Function devolverBotonSegunIndice(ByRef indice As Integer, ByRef planta As Integer)
        Select Case planta
            Case 1
                Return Principal.listaPlanta1Botones(indice)
            Case 2
                Return Principal.listaPlanta2Botones(indice)
            Case 3
                Return Principal.listaPlanta3Botones(indice)
        End Select
    End Function


    Public Function asignarValorABotonesPlanta(ByRef listaVehiculos() As Vehiculo, ByRef listaBotones As List(Of Button))
        'lista planta es listaVehiculos
        'listaPlanta1Botones es listabotones

        For index As Integer = 0 To listaVehiculos.Count - 1
            listaBotones(index).Tag = index
            If listaVehiculos(index) Is Nothing Then
                Dim btn As Button = listaBotones(index)
                RemoveHandler btn.Click, AddressOf Me.abrirInformacion
                btn.Image = Nothing
                btn.BackColor = ColorTranslator.FromHtml("#01FF70")
                listaVehiculos(index) = Nothing

            Else
                Dim btn As Button = listaBotones(index)
                AddHandler btn.Click, AddressOf Me.abrirInformacion
                btn.BackColor = ColorTranslator.FromHtml("#FF4136")


                If listaVehiculos(index).getTipo.ToString = "moto" Then
                    Dim imagen As Image = Image.FromFile(Application.StartupPath() & "\motorcycle.png")
                    btn.Image = imagen
                Else
                    Dim imagen As Image = Image.FromFile(Application.StartupPath() & "\car.png")
                    btn.Image = imagen
                End If
                Me.añadirTexto(listaVehiculos(index).toString & "cargado con exito")

            End If


        Next
    End Function

    Public Function abrirInformacion(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = sender
        Dim info As Informacion_coche = New Informacion_coche()
        Try


            If Principal.listaPlanta1Botones.Contains(btn) Then
                Me.añadirTexto("Se ha seleccionado " & Principal.listaPlanta1(btn.Tag).toString())

                info.TextBox1.Text = Principal.listaPlanta1(btn.Tag).toString()
            ElseIf Principal.listaPlanta2Botones.Contains(btn) Then
                Me.añadirTexto("Se ha seleccionado " & Principal.listaPlanta2(btn.Tag).toString())
                info.TextBox1.Text = Principal.listaPlanta2(btn.Tag).toString()
            ElseIf Principal.listaPlanta3Botones.Contains(btn) Then
                Me.añadirTexto("Se ha seleccionado " & Principal.listaPlanta3(btn.Tag).toString())
                info.TextBox1.Text = Principal.listaPlanta3(btn.Tag).toString()
            End If



            info.ShowDialog()
        Catch ex As Exception
            Principal.añadirTexto("Se ha intentado imprimir un boton vacio...")
        End Try
    End Function

End Class
