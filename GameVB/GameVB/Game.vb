Imports System.Data.OleDb

Public Class Game

    Dim LB() As Label
    Dim BT(25) As Button 'membuat tombol A-Z
    Dim Data As New System.Collections.Specialized.StringCollection
    Dim DataSekarang As String
    Dim Kesempatan As Integer
    Dim nilai As Integer = 0

    Sub MasukkanData() 'menulis data pulau
        Dim i As Integer = FreeFile()
        FileOpen(i, Application.StartupPath & "\Pulau.txt", OpenMode.Output)
        PrintLine(i, "Sumatera" & vbCrLf & "Jawa" & vbCrLf & "Madura" & vbCrLf & "Bali" & vbCrLf & "Kalimantan")
        PrintLine(i, "Sulawesi" & vbCrLf & "Bangka" & vbCrLf & "Riau" & vbCrLf & "Maluku" & vbCrLf & "Seribu")
        FileClose(i)
    End Sub

    Sub RefreshData()
        Dim i As Integer, ar() As String

        If IO.File.Exists(Application.StartupPath & "\Pulau.txt") = False Then MasukkanData()

ulang:
        i = FreeFile()
        FileOpen(i, Application.StartupPath & "\Pulau.txt", OpenMode.Input)
        ar = Split(InputString(i, LOF(i)), vbCrLf)
        FileClose(i)

        Data.Clear()
        For i = 0 To UBound(ar)
            If Trim(ar(i)) <> "" Then Data.Add(Trim(ar(i)))
        Next

        If Data.Count = 0 Then
            MasukkanData()
            GoTo ulang
        End If
    End Sub

    Sub MulaiBaru()
        Dim i As Integer

        If IsNothing(LB) = False Then
            For i = 0 To UBound(LB)
                LB(i).Dispose()
            Next
        End If
        Randomize()
        DataSekarang = Data(Rnd() * (Data.Count - 1)) 'mengacak data yg muncul

        ReDim LB(Len(DataSekarang) - 1) 'mengatur ulang jumlah huruf

        For i = 0 To UBound(LB) 'membuat label
            LB(i) = New Label
            LB(i).TextAlign = ContentAlignment.MiddleCenter
            LB(i).BorderStyle = BorderStyle.FixedSingle
            LB(i).Width = 25
            LB(i).Top = 50

            If i = 0 Then
                LB(i).Left = 180
            Else
                LB(i).Left = LB(i - 1).Left + 25
            End If

            If Mid(DataSekarang, i + 1, 1) = " " Then 'spasi
                LB(i).Text = " "
                LB(i).BackColor = Color.FromArgb(200, 200, 200)
            Else
                LB(i).BackColor = Color.White
            End If

            Me.Controls.Add(LB(i))
        Next

        For i = 0 To 25 'meng enable semua button
            BT(i).Enabled = True
        Next

        Kesempatan = 7 'jml kesempatan 
        lblKesempatan.Text = "Kesempatan : " & Kesempatan
    End Sub

    Function Jawaban() As String
        Dim i As Integer, s As String
        For i = 0 To UBound(LB)
            s &= LB(i).Text
        Next
        Jawaban = s
    End Function

    Sub BT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SendKeys.Send(CType(sender.Text, String))
    End Sub

    Private Sub Game_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim i As Integer

        i = Asc(UCase(e.KeyChar)) - Asc("A")

        If i >= 0 And i <= 25 Then
            If BT(i).Enabled = False Then Exit Sub 'keluar dr prosedur jk tombol sdh pernah ditekan

            BT(i).Enabled = False
        End If


        If (InStr(UCase(DataSekarang), UCase(e.KeyChar)) <> 0) Then 'jika benar ada di data

            For i = 0 To Len(DataSekarang) - 1
                If Mid(UCase(DataSekarang), i + 1, 1) = UCase(e.KeyChar) Then LB(i).Text = UCase(e.KeyChar)
            Next

            If UCase(DataSekarang) = UCase(Jawaban) Then 'jika sudah komplit
                MsgBox("Anda Benar" & vbCrLf & UCase(DataSekarang), vbInformation)
                nilai += 10
                MulaiBaru()
            End If

        Else 'jika salah
            Kesempatan -= 1 'mengurangi kesempatan
            lblKesempatan.Text = "Kesempatan : " & Kesempatan
            'lblKesempatan.Text = "Kesempatan Anda sebanyak : " & Kesempatan

            If Kesempatan = 0 Then 'jika kesempatan habis
                MsgBox("Kesempatan Habis" & vbCrLf & "Kata yang benar adalah " & UCase(DataSekarang) & vbCrLf & " Nilai Anda " & nilai)
            End If

        End If
    End Sub

    Private Sub Game_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer

        Me.Text = "D'Adventure"
        For i = 0 To 25 'proses pembuatan tombol A-Z
            BT(i) = New Button
            BT(i).Text = Chr(Asc("A") + i)
            BT(i).Top = 100
            BT(i).Width = 30

            If i = 0 Then
                BT(i).Left = 180
            Else
                BT(i).Left = BT(i - 1).Left + 30
                If i >= 10 Then
                    BT(i).Top += 40
                    If i = 10 Then
                        BT(i).Left = 200
                    End If
                    BT(i).Left += 1
                    If i >= 19 Then
                        BT(i).Top += 40
                        If i = 19 Then
                            BT(i).Left = 220
                        End If
                        BT(i).Left += 1
                    End If
                End If
            End If


            AddHandler BT(i).Click, AddressOf BT_Click 'menambahakan event click

            Me.Controls.Add(BT(i))
        Next

        RefreshData()
        MulaiBaru()
    End Sub

    Private Sub Game_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MulaiBaru()
        Me.Hide()
        Start.Show()
    End Sub
End Class