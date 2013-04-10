Public Class GameVB

    Private Sub GameVB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblLoading.Hide()
        pbLoading.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim s As Integer

        lblLoading.Show()
        pbLoading.Show()
        For s = 1 To 100
            pbLoading.Value = s
            pbLoading.Maximum = 100
        Next
        Game.Show()
    End Sub
End Class
