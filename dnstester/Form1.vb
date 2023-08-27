Imports System.Net
Imports DnsClient
Imports System.Diagnostics ' Required for Stopwatch

Public Class Form1

    ' List of preconfigured domains
    Private domainsToTest As List(Of String) = New List(Of String)() From {
        "google.com",
        "facebook.com",
        "twitter.com",
        "microsoft.com",
        "apple.com"
    }

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill the ComboBox with predefined DNS servers
        cmbDnsServers.Items.Add("8.8.8.8") ' Google
        cmbDnsServers.Items.Add("1.1.1.1") ' Cloudflare
        cmbDnsServers.Items.Add("208.67.222.222") ' OpenDNS
        '... add more if necessary ...
    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim dnsServer As String = cmbDnsServers.Text.Trim()
        If String.IsNullOrEmpty(dnsServer) Then
            MessageBox.Show("Please select or enter a DNS server.")
            Return
        End If

        Dim lookupClient As New LookupClient(IPAddress.Parse(dnsServer))
        txtOutput.Clear()

        Dim totalSuccessfulResolutions As Integer = 0
        Dim totalTime As Double = 0

        For Each domain In domainsToTest
            Dim success As Boolean = False
            For i As Integer = 1 To 5 ' We'll test each domain 5 times
                Try
                    Dim watch As Stopwatch = Stopwatch.StartNew() ' Start timing
                    Dim result = lookupClient.Query(domain, QueryType.A)
                    watch.Stop() ' Stop timing

                    If result.Answers.Count > 0 Then
                        totalTime += watch.Elapsed.TotalMilliseconds ' Add the time it took for this resolution
                        totalSuccessfulResolutions += 1
                        success = True
                        Exit For ' Exit the loop once we get a successful resolution
                    End If
                Catch ex As Exception
                    ' If there's an error, just continue to the next iteration
                End Try
            Next

            If success Then
                txtOutput.AppendText($"{domain}........ok{Environment.NewLine}")
            Else
                txtOutput.AppendText($"{domain}........timed out{Environment.NewLine}")
            End If
        Next

        Dim averageTime As Double = totalTime / totalSuccessfulResolutions ' Calculate average time for successful resolutions
        txtOutput.AppendText($"Average speed: {averageTime:0.##}ms{Environment.NewLine}")
    End Sub

End Class
