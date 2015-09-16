Imports System.Reflection

Public Class Form1
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim adt As New AdtLib335.Adt(tbAdtFile.Text, tbWdtFile.Text)
        If Not adt.MTEX Is Nothing Then
            MsgBox("Your have " & adt.MTEX.Filenames.Count.ToString() & " different textures on this adt file.")
        Else
            MsgBox("The MTEX chunk of the adt file is empty.")
        End If
    End Sub

    Private Sub btnSearchAdt_Click(sender As Object, e As EventArgs) Handles btnSearchAdt.Click
        ofd.Filter = "Adt files|*.adt"
        Dim result As DialogResult = ofd.ShowDialog()
        If result = DialogResult.OK Then
            tbAdtFile.Text = ofd.FileName
        End If
    End Sub

    Private Sub btnSearchWdt_Click(sender As Object, e As EventArgs) Handles btnSearchWdt.Click
        ofd.Filter = "Wdt files|*.wdt"
        Dim result As DialogResult = ofd.ShowDialog()
        If result = DialogResult.OK Then
            tbWdtFile.Text = ofd.FileName
        End If
    End Sub
End Class
