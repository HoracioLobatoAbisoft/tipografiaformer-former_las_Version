Imports System.IO
Imports Org.BouncyCastle.Cms
Imports Org.BouncyCastle.X509.Store

Public Class MgrFatturePAEx


    Public Shared Function ReadXmlSigned(ByVal filePath As String,
                                    ByVal Optional validateSignature As Boolean = True) As String
        Using inputStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
            Dim signedFile As CmsSignedData = New CmsSignedData(inputStream)

            If validateSignature Then
                Dim certStore As IX509Store = signedFile.GetCertificates("Collection")
                Dim certs As ICollection = certStore.GetMatches(New X509CertStoreSelector())
                Dim signerStore As SignerInformationStore = signedFile.GetSignerInfos()
                Dim signers As ICollection = signerStore.GetSigners()

                For Each tempCertification As Object In certs
                    Dim certification As Org.BouncyCastle.X509.X509Certificate = TryCast(tempCertification, Org.BouncyCastle.X509.X509Certificate)

                    For Each tempSigner As Object In signers
                        Dim signer As SignerInformation = TryCast(tempSigner, SignerInformation)

                        If Not signer.Verify(certification.GetPublicKey()) Then
                            'MessageBox.Show("Errore")
                            Throw New ApplicationException("SignatureException")
                            'Throw New FatturaElettronicaSignatureException(Resources.ErrorMessages.SignatureException)
                        End If
                    Next
                Next
            End If

            Dim outFile As String = filePath & ".source.xml"

            Using fileStream = New FileStream(outFile, FileMode.Create, FileAccess.Write)
                signedFile.SignedContent.Write(fileStream)
            End Using

            Return outFile

        End Using
    End Function

End Class
