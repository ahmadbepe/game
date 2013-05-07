Public Class Data
    Private Sub Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = FreeFile()
        Me.Text = "Dido's Adventure"
        FileOpen(i, Application.StartupPath & "\Pulau.txt", OpenMode.Input)
        ListBox1.Text = InputString(i, LOF(i))
        FileClose(i)
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class