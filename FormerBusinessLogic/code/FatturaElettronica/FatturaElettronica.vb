Imports System.Xml.Serialization
Imports System.Xml

<Serializable>
<XmlRoot([Namespace]:="http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")>
Public Class FatturaElettronica
    <XmlAttribute("versione")>
    Public versione As String
    <XmlElement([Namespace]:="")>
    Public FatturaElettronicaHeader As FatturaElettronicaHeader
    <XmlElement([Namespace]:="")>
    Public FatturaElettronicaBody As FatturaElettronicaBody
End Class