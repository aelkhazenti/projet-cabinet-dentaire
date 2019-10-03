Imports MySql.Data.MySqlClient

Public Class modif
    Dim cn As New MySqlConnection
    Dim datread As MySqlDataReader
    Dim idcah As String
    Dim idm As String
    Dim idrdv As String
    Private Shared _instance As modif
    Public Shared ReadOnly Property instance As modif
        '----------------------------
        'cree un getter pour exporter la page modifier dans forme 2 

        Get
            If _instance Is Nothing Then
                _instance = New modif
            End If
            Return _instance
        End Get
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cn = New MySqlConnection
        cn.ConnectionString = "server= localhost;userid=root;password=;database=projet_vb.net"
        cn.Open()

        Dim met As New MySqlCommand("SELECT * FROM `patient` WHERE `nom_P`= @nom and `prenom_P`=@pre", cn)
        met.Parameters.Add("@nom", MySqlDbType.VarChar).Value = TextBox1.Text
        met.Parameters.Add("@pre", MySqlDbType.VarChar).Value = TextBox2.Text
        met.ExecuteNonQuery()
        datread = met.ExecuteReader
        If datread.Read Then

            'on enregistremment des cles étrangère de la table rendez-vous et cahier medical et mutuelle
            'dans les variables idrdv, idcah et idm 
            'pour utilisé dans la partie recherche  

            idrdv = datread.GetValue(5)
            idcah = datread.GetValue(6)
            idm = datread.GetValue(7)

        End If
        datread.Close()

        '--------------------

        If RadioButton1.Checked Then
            Dim table As New DataTable
            Dim adapt As New MySqlDataAdapter("SELECT `nom_P`,`prenom_P`,`age_P`,`sex` FROM `patient` WHERE  `nom_P`= '" & TextBox1.Text & "' and `prenom_P`= '" & TextBox2.Text & "'", cn)
            ' MsgBox(adapt)
            adapt.Fill(table)
            DataGridView1.DataSource = table
        End If

        '-------------------

        If RadioButton2.Checked Then
            Dim table As New DataTable
            Dim adapt As New MySqlDataAdapter("SELECT `date_R` FROM `rdv` WHERE `ID_R`= '" & idrdv & "'", cn)
            ' MsgBox(adapt)
            adapt.Fill(table)
            DataGridView1.DataSource = table
        End If

        '------------------

        If RadioButton3.Checked Then
            Dim table As New DataTable
            Dim adapt As New MySqlDataAdapter("SELECT `maladi_CM`,`note_de_doc` FROM `cahier_med` WHERE `ID_CM`= '" & idcah & "'", cn)
            ' MsgBox(adapt)
            adapt.Fill(table)
            DataGridView1.DataSource = table
        End If

        '------------------

        If RadioButton4.Checked Then
            Dim table As New DataTable
            Dim adapt As New MySqlDataAdapter("SELECT `nom_M`,`num_M` FROM `mutuelle` WHERE `ID_M`= '" & idm & "'", cn)
            ' MsgBox(adapt)
            adapt.Fill(table)
            DataGridView1.DataSource = table
        End If

    End Sub

    Private Sub modif_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
