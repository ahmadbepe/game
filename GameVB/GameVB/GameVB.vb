Imports System.Data.OleDb

Public Class GameVB
    Public nm As String = ""

    Private Sub GameVB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblLoading.Hide()
        pbLoading.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim s As Integer

        Dim conek As OleDbConnection = Nothing

        '        Dim conekStr As String = "Provider = Microsoft.Jet.OLEDB.4.0;" & _
        '           "Data Source = \database.mdb"

        waktu.Interval = 600


        If txtNama.TextLength >= 1 Then
            waktu.Enabled = True
            waktu.Start()
            lblLoading.Show()
            pbLoading.Show()
            For s = 1 To 100
                pbLoading.Value = s
                pbLoading.Maximum = 100
            Next
        End If


        nm = txtNama.Text

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles waktu.Tick
        waktu.Stop()
        waktu.Enabled = False
        waktu.Dispose()
        Me.Hide()
        Game.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtNama.Clear()
    End Sub
End Class
