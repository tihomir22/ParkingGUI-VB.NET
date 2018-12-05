Imports System.Windows.Forms

Public Class fijarPrecios
    Private porDefecto As Boolean = True
    Private ultimoRadioElegidoMoto As Boolean
    Private precioBase As Double
    Private porcentajeElegido As Double

    Private control As ControladorVehiculo = New ControladorVehiculo()

    Private tipoElegido As String
    Private beneficio As Double
    Private indiceTarifaElegida As Integer
    Private total As Double

    Dim newfile As String = "tarifa.txt"
    Dim newPath As String = System.IO.Path.Combine(Application.StartupPath(), newfile)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim tarifa As Tarifa = New Tarifa(Me.tipoElegido, Me.beneficio, ListBox1.SelectedIndex, Me.total)
        control.writeTarifa(newPath, tarifa)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub RadioButton1_Checked(sender As Object, e As EventArgs) Handles RadioButton1.Click
        If Me.porDefecto = True Then
            Me.precioBase = 0.3
            Me.porDefecto = False
        Else
            Me.precioBase = Me.precioBase - 0.1
        End If
        Me.TextBox1.Text = Me.precioBase & "€"
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        RadioButton6.Checked = False
        Me.tipoElegido = "moto"

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If Me.porDefecto = False Then
            Me.TextBox1.Text = Me.precioBase * 1.1 & "€"
            Me.porcentajeElegido = 0.1
            Me.beneficio = 0.1
        Else
            MsgBox("Debes elegir primero el tipo de tarifa")
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If Me.porDefecto = False Then
            Me.TextBox1.Text = Me.precioBase * 1.075 & "€"
            Me.porcentajeElegido = 0.075
            Me.beneficio = 0.075
        Else
            MsgBox("Debes elegir primero el tipo de tarifa")
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If Me.porDefecto = False Then
            Me.TextBox1.Text = Me.precioBase * 1.05 & "€"
            Me.porcentajeElegido = 0.05
            Me.beneficio = 0.05
        Else
            MsgBox("Debes elegir primero el tipo de tarifa")
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If Me.porDefecto = False Then
            Me.TextBox1.Text = Me.precioBase * 1.025 & "€"
            Me.porcentajeElegido = 0.025
            Me.beneficio = 0.025
        Else
            MsgBox("Debes elegir primero el tipo de tarifa")
        End If
    End Sub

    Private Sub RadioButton2_Checked(sender As Object, e As EventArgs) Handles RadioButton2.Click
        If Me.porDefecto = True Then
            Me.precioBase = 0.4
            Me.porDefecto = False
        Else
            Me.precioBase = Me.precioBase + 0.1
        End If
        Me.TextBox1.Text = Me.precioBase & "€"
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        RadioButton6.Checked = False
        Me.tipoElegido = "coche"
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If RadioButton1.Checked Or RadioButton2.Checked Then
            If RadioButton3.Checked Or RadioButton4.Checked Or RadioButton5.Checked Or RadioButton6.Checked Then
                Select Case ListBox1.SelectedIndex
                    Case 0
                        Me.TextBox1.Text = (Math.Round(Me.precioBase * (1 + Me.porcentajeElegido), 2)) & " €"
                        Me.total = (Math.Round(Me.precioBase * (1 + Me.porcentajeElegido), 2))
                    Case 1
                        Me.TextBox1.Text = (Math.Round(Me.precioBase * (1 + Me.porcentajeElegido) + 0.5 / 1.05, 2)) & " €"
                        Me.total = (Math.Round(Me.precioBase * (1 + Me.porcentajeElegido) + 0.5 / 1.05, 2))
                    Case 2
                        Me.TextBox1.Text = (Math.Round(Me.precioBase * (1 + Me.porcentajeElegido) + 0.1, 2)) & " €"
                        Me.total = (Math.Round(Me.precioBase * (1 + Me.porcentajeElegido) + 0.1, 2))
                    Case 3
                        Me.TextBox1.Text = (Math.Round(Me.precioBase * (1 + Me.porcentajeElegido) * 1.5, 2)) & " €"
                        Me.total = (Math.Round(Me.precioBase * (1 + Me.porcentajeElegido) * 1.5, 2))
                    Case 4
                        Me.TextBox1.Text = (Math.Round(Me.precioBase * (1 + Me.porcentajeElegido) + 1 * 1.5, 2)) & " €"
                        Me.total = (Math.Round(Me.precioBase * (1 + Me.porcentajeElegido) + 1 * 1.5, 2))
                End Select



            Else
                MsgBox("Debes elegir el tipo de margen")
            End If
        Else
            MsgBox("Debes elegir el tipo de vehiculo")
        End If


    End Sub
End Class
