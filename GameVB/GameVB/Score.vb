Public Class Score

    Private Sub Score_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OleDbDataAdapter1.Fill(DataSet1)
        DataGrid1.SetDataBinding(DataSet1, "nilai")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    End Sub
End Class