Imports System.Net
Imports DnsClient
Imports System.Diagnostics ' Required for Stopwatch
Imports System.IO
Imports System.Xml.Serialization


Public Class Form1

    ' List of preconfigured domains
    Private domainsToTest As List(Of String) = New List(Of String)() From {
        "google.com",
        "facebook.com",
        "twitter.com",
        "microsoft.com",
        "apple.com"
    }

    ' Dictionary of DNS servers and their associated names
    Private dnsServers As Dictionary(Of String, String) = New Dictionary(Of String, String)() From {
        {"1.1.1.1", "Cloudflare"},
        {"8.8.8.8", "Google"},
        {"45.90.28.180", "NextDNS"},
        {"9.9.9.9", "Quad9"},
        {"208.67.222.222", "OpenDNS"},
        {"94.140.14.14", "Adguard"},
        {"77.88.8.8", "Yandex DNS"},
        {"8.26.56.26", "Comodo Secure DNS"},
        {"76.76.2.0", "ControlD"}
    }

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill the ComboBox with predefined DNS servers
        For Each kvp In dnsServers
            cmbDnsServers.Items.Add($"{kvp.Key} ({kvp.Value})")
        Next
    End Sub

    Public Class DnsTestResult
        Public Property Server As String
        Public Property Name As String
        Public Property AverageSpeed As Double
        Public Property DateTimeGroup As DateTime
    End Class



    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim selectedItem As String = cmbDnsServers.Text.Trim()
        If String.IsNullOrEmpty(selectedItem) Then
            MessageBox.Show("Please select or enter a DNS server.")
            Return
        End If

        ' Extract just the IP from the selected item for the DNS lookup
        Dim dnsServer As String = selectedItem.Split(" ")(0)

        Dim serverName As String = dnsServers(dnsServer)

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

        Dim newResult As New DnsTestResult With {
    .Server = dnsServer,
    .Name = serverName,
    .AverageSpeed = averageTime,
    .DateTimeGroup = DateTime.Now
}

        Dim currentResults As List(Of DnsTestResult) = LoadResults()
        currentResults.Add(newResult)
        SaveResults(currentResults)

    End Sub

    Private Sub btnTestAll_Click(sender As Object, e As EventArgs)
        txtOutput.Clear()

        ' Estimation of the maximum width for the speed results.
        ' This includes the server's IP address, name, and the format ":.................".
        Dim estimatedMaxLengthWithoutMs = dnsServers.Max(Function(kvp) kvp.Key.Length + kvp.Value.Length + 3)

        For Each kvp In dnsServers
            Dim dnsServer = kvp.Key
            Dim serverName = kvp.Value
            Dim label As String = $"{dnsServer} ({serverName}):"

            Dim lookupClient As New LookupClient(IPAddress.Parse(dnsServer))

            Dim totalSuccessfulResolutions As Integer = 0
            Dim totalTime As Double = 0

            For Each domain In domainsToTest
                For i As Integer = 1 To 5 ' We'll test each domain 5 times
                    Try
                        Dim watch As Stopwatch = Stopwatch.StartNew() ' Start timing
                        Dim result = lookupClient.Query(domain, QueryType.A)
                        watch.Stop() ' Stop timing

                        If result.Answers.Count > 0 Then
                            totalTime += watch.Elapsed.TotalMilliseconds ' Add the time it took for this resolution
                            totalSuccessfulResolutions += 1
                            Exit For ' Exit the loop once we get a successful resolution
                        End If
                    Catch ex As Exception
                        ' If there's an error, just continue to the next iteration
                    End Try
                Next
            Next

            ' Calculate the average time for successful resolutions
            Dim averageTime As Double = totalTime / totalSuccessfulResolutions
            Dim newResult As New DnsTestResult With {
            .Server = dnsServer,
            .Name = serverName,
            .AverageSpeed = averageTime,
            .DateTimeGroup = DateTime.Now
        }

            Dim currentResults As List(Of DnsTestResult) = LoadResults()
            currentResults.Add(newResult)
            SaveResults(currentResults)

            ' Update the user with the test result for the DNS server
            If totalSuccessfulResolutions > 0 Then
                Dim averageTimeString As String = $"{averageTime:0.##}ms" ' Format the already calculated averageTime

                Dim totalCharsForDots = estimatedMaxLengthWithoutMs - label.Length
                Dim dotsString = New String("."c, totalCharsForDots)
                txtOutput.AppendText($"{label}{dotsString}{averageTimeString}{Environment.NewLine}")
            Else
                Dim totalCharsForDots = estimatedMaxLengthWithoutMs - label.Length
                Dim dotsString = New String("."c, totalCharsForDots)
                txtOutput.AppendText($"{label}{dotsString}Timed out{Environment.NewLine}")
            End If
        Next
    End Sub


    Public Sub SaveResults(results As List(Of DnsTestResult))
        Dim serializer As New Xml.Serialization.XmlSerializer(GetType(List(Of DnsTestResult)))
        Using writer As New StreamWriter("results.xml")
            serializer.Serialize(writer, results)
        End Using
    End Sub

    Public Function LoadResults() As List(Of DnsTestResult)
        If File.Exists("results.xml") Then
            Dim serializer As New Xml.Serialization.XmlSerializer(GetType(List(Of DnsTestResult)))
            Using reader As New StreamReader("results.xml")
                Return CType(serializer.Deserialize(reader), List(Of DnsTestResult))
            End Using
        Else
            Return New List(Of DnsTestResult)()
        End If
    End Function

    Public Sub DisplayResults()
        Try
            Dim results As List(Of DnsTestResult) = LoadResults()
            rtbResultsLog.Clear()
            For Each result In results
                Dim dtg As String = result.DateTimeGroup.ToString("MM/dd/yy (HHmm)")
                rtbResultsLog.AppendText($"{dtg} {result.Server} ({result.Name}): {result.AverageSpeed:0.##}ms{Environment.NewLine}")
            Next
        Catch ex As Exception
            MessageBox.Show("Error displaying results: " & ex.Message)
        End Try
    End Sub



    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Home.SelectedIndexChanged
        If Home.SelectedIndex = 1 Then ' Assuming the second tab's index is 1 (0-based index)
            DisplayResults()
        End If
    End Sub



End Class
