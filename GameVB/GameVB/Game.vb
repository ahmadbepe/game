Imports System.Data.OleDb

Public Class Game

    Dim LB() As Label
    Public klik As String
    Dim Kesempatan As Integer
    Dim mTemp1 As String
    Dim mtemp2 As String = " "
    Public m As String

    Private Sub btnQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQ.Click
        btnQ.Hide()
        klik = "q"
    End Sub

    Private Sub btnW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnW.Click
        btnW.Hide()
    End Sub

    Private Sub btnE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnE.Click
        btnE.Hide()
        klik = "e"
    End Sub

    Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnR.Click
        btnR.Hide()
    End Sub

    Private Sub btnT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnT.Click
        btnT.Hide()
    End Sub

    Private Sub btnY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnY.Click
        btnY.Hide()
    End Sub

    Private Sub btnU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnU.Click
        btnU.Hide()
    End Sub

    Private Sub btnI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnI.Click
        btnI.Hide()
    End Sub

    Private Sub btnO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnO.Click
        btnO.Hide()
    End Sub

    Private Sub btnP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP.Click
        btnP.Hide()
    End Sub

    Private Sub btnA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnA.Click
        btnA.Hide()
    End Sub

    Private Sub btnS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnS.Click
        btnS.Hide()
    End Sub

    Private Sub btnD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnD.Click
        btnD.Hide()
    End Sub

    Private Sub btnF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF.Click
        btnF.Hide()
    End Sub

    Private Sub btnG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnG.Click
        btnG.Hide()
    End Sub

    Private Sub btnH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnH.Click
        btnH.Hide()
    End Sub

    Private Sub btnJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJ.Click
        btnJ.Hide()
    End Sub

    Private Sub btnK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnK.Click
        btnK.Hide()
    End Sub

    Private Sub btnL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnL.Click
        btnL.Hide()
    End Sub

    Private Sub btnZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZ.Click
        btnZ.Hide()
    End Sub

    Private Sub btnX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnX.Click
        btnX.Hide()
    End Sub

    Private Sub btnC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC.Click
        btnC.Hide()
    End Sub

    Private Sub btnV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnV.Click
        btnV.Hide()
    End Sub

    Private Sub btnB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnB.Click
        btnB.Hide()
    End Sub

    Private Sub btnN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnN.Click
        btnN.Hide()
    End Sub

    Private Sub btnM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnM.Click
        btnM.Hide()
    End Sub

    Private Sub Game_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjConn As OleDbConnection
        Dim ObjCommand As OleDbCommand
        Dim ObjDataAdapter As OleDbDataReader
        Dim StrConn, StrSQL As String

        StrConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\AHMAD\Documents\Visual Studio 2010\Projects\GameVB\GameVB\obj\x86\Debug\MyDB.mdb" 
        StrSQL = "select * from soal"
        ObjConn = New OleDbConnection(StrConn)
        ObjCommand = New OleDbCommand(StrSQL, ObjConn)
        ObjConn.Open()
        ObjDataAdapter = ObjCommand.ExecuteReader

        'definisikan sebuah string temporer untuk menampung data 
        

        'baca data berulang-ulang 
        Do While ObjDataAdapter.Read() = True
            'isi dataadapter dengan data yang telah dibaca 
            mTemp1 = ObjDataAdapter("soal")
            'tampilkan data dalam listbox 
            Label1.Text = mTemp1
            m = mtemp2
            mtemp2 = ObjDataAdapter("jawaban")

        Loop

        Dim i As Integer

        If IsNothing(LB) = False Then
            For i = 0 To UBound(LB)
                LB(i).Dispose()
            Next
        End If
        ReDim LB(Len(mtemp2) - 1)
        For i = 0 To UBound(LB) 'proses membuat label
            LB(i) = New Label
            LB(i).TextAlign = ContentAlignment.MiddleCenter
            LB(i).BorderStyle = BorderStyle.FixedSingle
            LB(i).Width = 25
            LB(i).Top = 180

            If i = 0 Then
                LB(i).Left = 80
            Else
                LB(i).Left = LB(i - 1).Left + 30
            End If

            If Mid(mtemp2, i + 1, 1) = " " Then 'jk spasi
                LB(i).Text = " "
                LB(i).BackColor = Color.FromArgb(200, 200, 200)
            Else
                LB(i).BackColor = Color.White
            End If

            Me.Controls.Add(LB(i))
        Next

        Dim huruf As Integer = 0

        Do While huruf < m.Length = True
            Label1.Text = Label1.Text & "x"
            huruf += 1
        Loop
        'tutup dataadapter dan koneksi 
        ObjDataAdapter.Close()
        ObjConn.Close()
    End Sub
End Class