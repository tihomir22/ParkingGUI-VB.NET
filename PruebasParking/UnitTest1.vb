
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ParkingGUI
Imports System.Windows.Forms

<TestClass()> Public Class UnitTest1
    Dim control As ControladorVehiculo = New ControladorVehiculo()

    <TestMethod()> Public Sub comprobarLectura() ' lectura de un vehiculo
        Dim escrito As String = "1;moto;453463DAS;PIAGIO;DiMama;6;06/12/2018 12:47:13;10;10"
        Dim planta As Integer = 1
        Using sw As New System.IO.StreamWriter("pruebasCajaBlanca.txt")
            sw.WriteLine("1;moto;453463DAS;PIAGIO;DiMama;6;06/12/2018 12:47:13;10;10")
            sw.Flush() ''yeap I'm the sort of person that flushes it then closes it
            sw.Close()
        End Using

        Dim list As New List(Of Vehiculo)
        list = control.reader("pruebasCajaBlanca.txt", planta)
        Assert.AreEqual(planta.ToString() + ";" + list(0).toCSV(), escrito)
        'C:\Users\mati\source\repos\ParkingGUI-VB.NET\PruebasParking\bin\Debug\pruebasCajaBlanca.txt
    End Sub

    <TestMethod()> Public Sub comprobarEscritura() 'escritura de un vehiculo
        'Public Sub New(tipo As String, matricula As String, marca As String, modelo As String, plaza As Integer, datevar As Date, hora As Integer, minuto As Integer)
        Dim planta As Integer = 1
        Dim lista As List(Of Vehiculo) = New List(Of Vehiculo)
        Dim listaAux As List(Of Vehiculo) = New List(Of Vehiculo)
        Dim vehiculoAEscribirPrueba As Vehiculo = New Vehiculo("moto", "8304FPE", "BMW", "RX528", planta, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 20, 30)
        lista.Add(vehiculoAEscribirPrueba)

        control.writer("pruebasCajaBlanca.txt", lista, planta)

        Using sw As New System.IO.StreamReader("pruebasCajaBlanca.txt")
            While sw.Peek <> -1
                Dim strAux As String = sw.ReadLine()
                Dim listaItems As String() = strAux.Split(";")
                Dim vehiculo As Vehiculo = New Vehiculo(listaItems(1), listaItems(2), listaItems(3), listaItems(4), Convert.ToInt32(listaItems(5)), listaItems(6), listaItems(7), listaItems(8))
                listaAux.Add(vehiculo)
            End While
        End Using
        For Each vehiculo As Vehiculo In listaAux
            If (vehiculo.toCSV() = vehiculoAEscribirPrueba.toCSV()) Then
                Assert.IsTrue(True)
            End If
        Next





    End Sub



End Class