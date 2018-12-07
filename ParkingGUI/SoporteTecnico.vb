Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Net.Mail

Public Class SoporteTecnico



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(LinkLabel1.Text.ToString)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim SmtpServer As New SmtpClient("smtp.gmail.com", 465)
            SmtpServer.EnableSsl = True
            SmtpServer.Credentials = New Net.NetworkCredential("entrenamientovikingo1488@gmail.com", "guarilla12")
            Dim mail As New MailMessage("entrenamientovikingo1488@gmail.com", "jarvanjarvencio@gmail.com", "titutlo", "contenido")
            SmtpServer.Send(mail)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class
