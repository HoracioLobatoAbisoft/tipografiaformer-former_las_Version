#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region

Imports System.Drawing
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

''' <summary>
'''Entity Class for table T_magaz
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class MovimentoMagazzino
    Inherits _MovimentoMagazzino
    Implements IMovimentoMagazzino

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"

    Public ReadOnly Property ImageRif As Image
        Get
            Dim ris As Image = Nothing
            If Not Risorsa Is Nothing Then
                ris = Risorsa.ImageRif
            Else
                ris = My.Resources.no_image
            End If
            Return ris
        End Get
    End Property

    Private _Fattura As Costo = Nothing
    Public ReadOnly Property Fattura As Costo
        Get
            If IdFat Then
                If _Fattura Is Nothing Then
                    _Fattura = New Costo
                    _Fattura.Read(IdFat)
                End If
            End If
            Return _Fattura
        End Get
    End Property

    Private _CaricoMagazzino As CaricoDiMagazzino = Nothing
    Public ReadOnly Property CaricoMagazzino As CaricoDiMagazzino
        Get
            If IdCaricoMagazzino Then
                If _CaricoMagazzino Is Nothing Then
                    _CaricoMagazzino = New CaricoDiMagazzino
                    _CaricoMagazzino.Read(IdCaricoMagazzino)
                End If
            End If
            Return _CaricoMagazzino
        End Get
    End Property

    Public ReadOnly Property UltimoFornStr As String
        Get
            Dim ris As String = String.Empty

            If Not Risorsa.UltimoCaricoMagazzino Is Nothing Then
                ris = Risorsa.UltimoCaricoMagazzino.FornitoreStr
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoStr As String
        Get
            Dim ris As String = String.Empty

            ris = FormerLib.FormerEnum.FormerEnumHelper.TipoMovimentoMagazzinoStr(TipoMov)

            Return ris
        End Get
    End Property

    Public ReadOnly Property UrgenteStr As String
        Get
            Dim ris As String = "No"
            If Urgenza = enSiNo.Si Then
                ris = "SI"
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property Totale As String
        Get
            Dim ris As String = String.Empty

            ris = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(Prezzo)

            Return ris
        End Get
    End Property

    Public ReadOnly Property IdComStr As String
        Get
            Dim ris As String = IdCom
            Return ris
        End Get
    End Property

    Public ReadOnly Property OperatoreStr As String
        Get
            Dim ris As String = String.Empty

            If IdUt Then
                Using o As New Utente
                    o.Read(IdUt)
                    ris = o.Login
                End Using
            End If
            Return ris
        End Get
    End Property

    Public ReadOnly Property RisorsaStr As String
        Get
            Dim ris As String = String.Empty

            If Not Risorsa Is Nothing Then
                ris = Risorsa.Descrizione
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = "-"
            If IdCarMag Then
                ris = Risorsa.Descrizione & " Qta " & Qta & " (" & OperatoreStr & ")"
            End If
            Return ris
        End Get
    End Property

    Private _Fornitore As VoceRubrica = Nothing
    Public ReadOnly Property Fornitore As VoceRubrica
        Get
            If _Fornitore Is Nothing Then
                _Fornitore = New VoceRubrica
                If IdForn Then
                    _Fornitore.Read(IdForn)
                End If

            End If
            Return _Fornitore
        End Get
    End Property

    Public ReadOnly Property FornitoreStr As String
        Get
            Dim ris As String = String.Empty

            If Not Fornitore Is Nothing Then
                ris = Fornitore.RagSocNome
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property FatturaStr As String
        Get
            Dim ris As String = String.Empty

            If Not Fattura Is Nothing Then
                ris = Fattura.Numero & "-" & Fattura.AnnoStr
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property PrezzoAlKgStr As String
        Get
            Dim ris As String = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(PrezzoAlKg)
            Return ris
        End Get
    End Property

    Public ReadOnly Property PrezzoAlKg As Decimal
        Get
            Dim ris As Decimal = 0

            If Prezzo Then
                If Qta Then
                    ris = MgrPreventivazioneB.CalcolaPrezzoAlKgCarta(Risorsa.Lunghezza,
                                                                   Risorsa.Larghezza,
                                                                   Risorsa.Grammatura,
                                                                   Qta,
                                                                   Prezzo)
                End If
            End If

            Return ris
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IMovimentoMagazzino.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        Return Ris
    End Function

    Public Overrides Function Read(Id As Integer) As Integer Implements IMovimentoMagazzino.Read
        Dim Ris As Integer = MyBase.Read(Id)
        Return Ris
    End Function

    Public Overrides Function Save() As Integer Implements IMovimentoMagazzino.Save
        Dim Ris As Integer = 0

        'If IdCarMag = 0 Then
        'primo salvataggio quindi qui devo anche aggiornare la qta 

        Ris = MyBase.Save()

        Using mgr As New MagazzinoDAO
            mgr.AggiornaQta(Me)
        End Using
        'End If

        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

#End Region

End Class



''' <summary>
'''Interface for table T_magaz
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IMovimentoMagazzino
    Inherits _IMovimentoMagazzino

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface