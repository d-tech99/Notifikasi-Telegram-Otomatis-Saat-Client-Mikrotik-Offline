Imports tik4net
Imports tik4net.Objects
Imports tik4net.Objects.Ppp
Public Class Form1
    Private Connection As ITikConnection
    Private ActiveCLient As New List(Of String)
    Private TelegramToken As String = "8305487805:AAHchk1HvOui-agJSPJ7-N_NNlOnn_lNWiI"
    Private ChatId As String = "143310364"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Connection = ConnectionFactory.CreateConnection(TikConnectionType.Api)
            Connection.Open("192.168.30.1", "user1", "user1234")
            LoadPPPoeClient()
            Timer1.Interval = 5000 ' 5 detik
            Timer1.Start()
        Catch ex As Exception
            MessageBox.Show("Gagal Konek ke Mikrotik: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadPPPoeClient()
        Try
            Dim clients = Connection.LoadList(Of PppActive)()
            Dim NewActiveClient As New List(Of String)
            'DataGridView1.Rows.Clear()

            For Each c In clients
                'DataGridView1.Rows.Add(c.Name, c.Address, c.Uptime, c.CallerId)
                NewActiveClient.Add(c.Name)
            Next

            'Cek CLient yang hilang
            For Each oldClient In ActiveCLient
                If Not NewActiveClient.Contains(oldClient) Then
                    'Kirim Notifikasi ke Telegram
                    SendTelegramMessage($"Client PPPoe '{oldClient}' telah terputus.")
                End If
            Next
            ActiveCLient = NewActiveClient
            DataGridView1.DataSource = clients
        Catch ex As Exception
            MessageBox.Show("Error load data: " & ex.Message)
        End Try
    End Sub
    Private Sub SendTelegramMessage(MessageTel As String)
        Dim url As String = $"https://api.telegram.org/bot{TelegramToken}/sendMessage?chat_id={ChatId}&text={MessageTel}"
        Dim client As New Net.WebClient()
        client.DownloadString(url)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LoadPPPoeClient()
    End Sub
End Class
