Imports System.Net.Sockets
Imports System.Net
Public Class Form1

    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click

        Control.CheckForIllegalCrossThreadCalls = False 'Now you can Add items through a thread
        For i As Integer = nudStart.Value To nudStop.Value
            Dim tmpThread As New System.Threading.Thread(AddressOf ScanPort)
            tmpThread.IsBackground = True
            tmpThread.Start(i) 'i represents the current port 
        Next
    End Sub

    Private Sub ScanPort(ByVal port As Integer)
        Try 'Always put your code [or more complicated code] in a Try Catch Block :]
            Dim tmpClient As New TcpClient()
            Dim tmpEndPoint As New IPEndPoint(IPAddress.Parse(TextBox1.Text), port)
            tmpClient.Connect(tmpEndPoint)
            Threading.Thread.Sleep(1000) '50 is the Timeout in ms.
            If tmpClient.Connected = True Then
                lbPorts.Items.Add("Open Port: " & port) 'If Connected then it will be an open port
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lbPorts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbPorts.SelectedIndexChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strIPAddress As String
        Dim strHostName As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        TextBox1.Text = strIPAddress
        Label5.Text = strHostName
        Label7.Text = strIPAddress


    End Sub

    
End Class
