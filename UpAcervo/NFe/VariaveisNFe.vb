Imports System.IO
Module VariaveisNFe

    Public ErrosNFeArray As New ArrayList

    'Variaveis para NFe
    Public LocalNomeNFeDB As String
    Public LocalExeNFe As String
    Public YearWork As String
    Public Nome_BDNFe As String
    Public LocalSchemas As String
    Public VerNFe As String
    Public DataNFe As String

    Public oX509CertPublic As New Security.Cryptography.X509Certificates.X509Certificate2()
    Public DataInicialCert As String
    Public DataFinalCert As String
    Public CertficiacadoVazio As Boolean = False
    Public LocalCertificado As String
    Public SenhaCertificado As String
    'Fim


    Public Sub ApagarArquivosNFeEmail()
        If Directory.Exists(LocalExeNFe & "\Temp\") = True Then
            Try
                Dim Arq As String = Dir(LocalExeNFe & "\Temp\*.*")
                If Arq <> "" Then
                    Kill(LocalExeNFe & "\Temp\*.*")
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub



End Module
