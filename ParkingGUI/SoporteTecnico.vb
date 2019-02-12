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
        Dim Outl As Object
        Outl = CreateObject("Outlook.Application")
        If Outl IsNot Nothing Then
            Dim omsg As Object
            omsg = Outl.CreateItem(0) '=Outlook.OlItemType.olMailItem'
            omsg.To = "tihomir_alcudia3@hotmail.com"
            omsg.subject = "Duda sobre su app / Propuesta"
            omsg.body = "The Feedback Hub app, available in Microsoft Store, is the go-to place to let us know about any problems you run into or send suggestions to help us improve your Windows experience.

After you open the app, search for feedback similar to yours and then upvote it, and even comment on it if you like. If you don’t see any, please provide new feedback in one of the listed categories so other people can upvote it. If suitable, take a screenshot of the problem and attach it to your feedback.

To take a screenshot, press the Windows logo key  + Print screen. To find the screenshot, in the search box on the taskbar, type screenshots, then select the Screenshots folder."
            'set message properties here...'
            omsg.Attachments.Add("http://somosrd.net/wp-content/uploads/2018/03/791bfe96638d89b0fe7c303cb9942c77201813223046667-777x437.jpg")
            omsg.Display(True) 'will display message to user
        End If

    End Sub
End Class
