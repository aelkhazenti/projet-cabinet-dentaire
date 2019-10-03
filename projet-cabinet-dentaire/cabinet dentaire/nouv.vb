Imports MySql.Data.MySqlClient

Public Class nouv
    Dim cn As New MySqlConnection
    Dim req As New MySqlCommand
    Dim req1 As New MySqlCommand
    Dim req2 As New MySqlCommand
    Dim req3 As New MySqlCommand
    Dim datread As MySqlDataReader
    Private Shared _instance As nouv

    Dim mut As String = "NULL"
    Dim test As String
    Dim idmed As String
    Dim idrdv As String
    Dim idcah As String
    Public Shared ReadOnly Property instance As nouv
        '----------------------------
        'cree un getter pour exporter la page nouveaux dans forme 2 

        Get
            If _instance Is Nothing Then
                _instance = New nouv
            End If
            Return _instance
        End Get
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        '  TextBox8.Clear()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        TextBox3.Hide()
        TextBox4.Hide()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        TextBox3.Show()
        TextBox4.Show()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cn = New MySqlConnection
        cn.ConnectionString = "server= localhost;userid=root;password=;database=projet_vb.net"
        cn.Open()

        Dim Query As String
        Query = "select * from patient where nom_P='" & TextBox1.Text & "' and prenom_P='" & TextBox2.Text & "' "
        req3 = New MySqlCommand(Query, cn)
        datread = req3.ExecuteReader
        Dim count As Integer
        count = 0
        While datread.Read
            count = count + 1

        End While
        datread.Close()
        If count >= 1 Then
            MsgBox("ce patient et deja enregistrer ")

            Form2.Button5.PerformClick()


        Else


            '========================== mutuelle

            'si le patient n'a pas de mutuelle il mit NULL comme nom et 0 comme numero 

            'et le textbox il sera cacher (si le patient n'a pas une mutuelle)

            If RadioButton4.Checked Then

                Dim mut As New MySqlCommand("INSERT INTO `mutuelle`(`num_M`, `nom_M`) VALUES (@num,@nom)", cn)
                mut.Parameters.Add("@nom", MySqlDbType.VarChar).Value = TextBox3.Text
                mut.Parameters.Add("@num", MySqlDbType.Int16).Value = CInt(TextBox4.Text)
                mut.ExecuteNonQuery()


            Else

                Dim mut As New MySqlCommand("INSERT INTO `mutuelle`(`num_M`, `nom_M`) VALUES (@num,@nom)", cn)
                mut.Parameters.Add("@nom", MySqlDbType.VarChar).Value = "NULL"
                mut.Parameters.Add("@num", MySqlDbType.Int16).Value = 0
                mut.ExecuteNonQuery()


            End If

            Dim met As New MySqlCommand("SELECT * FROM `mutuelle` WHERE `nom_M`= @nom", cn)
            met.Parameters.Add("@nom", MySqlDbType.VarChar).Value = mut
            met.ExecuteNonQuery()
            datread = met.ExecuteReader
            If datread.Read Then

                idmed = datread.GetValue(0)

            End If
            '  MsgBox(test)

            datread.Close()

            '=============================

            Dim cahm As New MySqlCommand("INSERT INTO `cahier_med`(`maladi_CM`, `note_de_doc`) VALUES (@mal,@not)", cn)
            cahm.Parameters.Add("@mal", MySqlDbType.VarChar).Value = TextBox6.Text
            cahm.Parameters.Add("@not", MySqlDbType.VarChar).Value = TextBox5.Text
            cahm.ExecuteNonQuery()

            Dim med As New MySqlCommand("SELECT * FROM `cahier_med` WHERE `maladi_CM`= @mala", cn)
            med.Parameters.Add("@mala", MySqlDbType.VarChar).Value = TextBox6.Text
            med.ExecuteNonQuery()
            datread = med.ExecuteReader
            If datread.Read Then
                idcah = datread.GetValue(0)

            End If
            ' MsgBox(test)
            datread.Close()

            '===================================

            Dim doc As New MySqlCommand("SELECT * FROM `docteur` WHERE `nom_D`= @doc", cn)
            doc.Parameters.Add("@doc", MySqlDbType.VarChar).Value = Form1.TextBox1.Text
            doc.ExecuteNonQuery()
            datread = doc.ExecuteReader
            If datread.Read Then
                test = datread.GetValue(0)

            End If
            '  MsgBox(test)

            datread.Close()

            Dim rdv As New MySqlCommand("INSERT INTO `rdv`(`date_R`,`ID_D`) VALUES (@da,@id)", cn)
            rdv.Parameters.Add("@da", MySqlDbType.Date).Value = DateTimePicker1.Text
            rdv.Parameters.Add("@id", MySqlDbType.Int16).Value = test
            rdv.ExecuteNonQuery()

            Dim rdvv As New MySqlCommand("SELECT * FROM `rdv` WHERE `date_R`= @dattt", cn)
            rdvv.Parameters.Add("@dattt", MySqlDbType.Date).Value = DateTimePicker1.Text
            rdvv.ExecuteNonQuery()
            datread = rdvv.ExecuteReader
            If datread.Read Then
                idrdv = datread.GetValue(0)

            End If
            ' MsgBox(test)

            datread.Close()


            Dim pat As New MySqlCommand("INSERT INTO `patient`(`nom_P`, `prenom_P`, `age_P`, `sex`,`ID_R`,`ID_CM`,`ID_M`) VALUES (@no,@pre,@ag,@sex,@idr,@idcm,@idm)", cn)

            pat.Parameters.Add("@no", MySqlDbType.VarChar).Value = TextBox1.Text
            pat.Parameters.Add("@pre", MySqlDbType.VarChar).Value = TextBox2.Text
            pat.Parameters.Add("@sex", MySqlDbType.VarChar).Value = ComboBox1.Text
            pat.Parameters.Add("@ag", MySqlDbType.Int16).Value = CInt(TextBox7.Text)
            pat.Parameters.Add("@idr", MySqlDbType.VarChar).Value = idrdv
            pat.Parameters.Add("@idcm", MySqlDbType.VarChar).Value = idcah
            pat.Parameters.Add("@idm", MySqlDbType.VarChar).Value = idmed

            'MsgBox(cmn.CommandText)
            pat.ExecuteNonQuery()
            MsgBox("===ajout reussi====")

            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            ' TextBox8.Clear()
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        cn = New MySqlConnection
        '  cn.ConnectionString = "server= localhost;userid=root;password=;database=projet"
        Try
            cn.Open()
            MessageBox.Show("")
            'cn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            'cn.Dispose()


        End Try
    End Sub

    Private Sub nouv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
