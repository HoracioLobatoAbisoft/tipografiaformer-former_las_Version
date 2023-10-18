#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.4.18.19488 
'Author: Diego Lunadei
'Date: 18/09/2013 
#End Region

Imports FormerLib
Imports System.IO
Imports System.Drawing
Imports FormerConfig
Imports FormerLib.FormerEnum
''' <summary>
'''Entity Class for table T_modellicommessa
''' </summary>
''' <remarks>
'''Write your custom method and property here
''' </remarks>

Public Class ModelloCommessa
    Inherits _ModelloCommessa
    Implements IModelloCommessa
    Implements IVoceComboConImmagine, ICloneable

    Public Sub New(myRecord As IDataRecord)
        MyBase.New(myRecord)
    End Sub

#Region "Logic Field"

    Private _FormatoMacchina As Formato = Nothing
    Public ReadOnly Property FormatoMacchina As Formato
        Get
            If _FormatoMacchina Is Nothing Then
                _FormatoMacchina = New Formato
                _FormatoMacchina.Read(IdFormatoMacchina)
            End If

            Return _FormatoMacchina
        End Get
    End Property

    Public ReadOnly Property AttivoStr As String
        Get
            Dim Ris As String = "Si"

            If Disattivo = FormerEnum.enSiNo.Si Then
                Ris = "No"
            End If

            Return Ris
        End Get
    End Property

    Public Sub New()
        FormatiProdotto = New List(Of ModComFormProd)
        FormatiCarta = New List(Of FormatoCarta)
    End Sub

    Private _CategoriaModello As CategoriaModelloCommessa
    Public Property CategoriaModello As CategoriaModelloCommessa
        Get
            If _CategoriaModello Is Nothing Then
                _CategoriaModello = New CategoriaModelloCommessa
                _CategoriaModello.Read(_IdCatModello)
            End If
            Return _CategoriaModello
        End Get
        Set(value As CategoriaModelloCommessa)
            _CategoriaModello = value
        End Set
    End Property

    Private _FormatiCarta As List(Of FormatoCarta) = Nothing
    Public Property FormatiCarta As List(Of FormatoCarta)
        Get
            If _FormatiCarta Is Nothing Then
                CaricaFormatiCarta()
            End If

            If _FormatiCarta Is Nothing Then
                _FormatiCarta = New List(Of FormatoCarta)
            End If
            Return _FormatiCarta
        End Get
        Set(value As List(Of FormatoCarta))
            _FormatiCarta = value
        End Set
    End Property

    Private _FormatiProdotto As List(Of ModComFormProd) = Nothing
    Public Property FormatiProdotto As List(Of ModComFormProd)
        Get
            If _FormatiProdotto Is Nothing Then
                CaricaFormatiProdotto()
            End If
            Return _FormatiProdotto
        End Get
        Set(value As List(Of ModComFormProd))
            _FormatiProdotto = value
        End Set
    End Property

    Private _Macchinario As Macchinario = Nothing
    Public ReadOnly Property Macchinario As Macchinario
        Get
            If IdMacchinarioDef Then
                If _Macchinario Is Nothing Then
                    _Macchinario = New Macchinario
                    _Macchinario.Read(IdMacchinarioDef)
                End If
            End If
            Return _Macchinario
        End Get
    End Property

    Public ReadOnly Property MacchinarioNome As String
        Get
            Dim ris As String = String.Empty

            If Not Macchinario Is Nothing Then
                ris = Macchinario.Descrizione
            End If

            Return ris
        End Get
    End Property

    Private _TotFormatiCarta As Integer = 0
    Public ReadOnly Property TotFormatiCarta As Integer
        Get
            _TotFormatiCarta = FormatiCarta.Count
            Return _TotFormatiCarta
        End Get
    End Property

    Public ReadOnly Property FronteRetroStr As String
        Get
            Dim ris As String = String.Empty
            If FronteRetro = enSiNo.Si Then
                ris = "Si"
            Else
                ris = "No"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property FRSuSeStessaStr As String
        Get
            Dim ris As String = String.Empty
            If FRSuSeStessa = enSiNo.Si Then
                ris = "Si"
            Else
                ris = "No"
            End If

            Return ris
        End Get
    End Property

    Public ReadOnly Property FormatiProdottoStr As String
        Get
            Return FormatiProdotto.Count
        End Get
    End Property
    Public ReadOnly Property NomeCategoria As String
        Get
            Return CategoriaModello.CatModello
        End Get
    End Property

    Public ReadOnly Property Id As Integer Implements IVoceComboConImmagine.Id
        Get
            Return _IdModello
        End Get
    End Property

    Public ReadOnly Property Text As String Implements IVoceComboConImmagine.Text
        Get
            Return _Nome
        End Get
    End Property

    Public ReadOnly Property Description As String Implements IVoceComboConImmagine.Description
        Get
            Return _Descrizione & vbNewLine & "(Spazi: " & _NumSpazi & ")"
        End Get
    End Property

    Private _ImageAnteprimaLista As Image = Nothing
    Public ReadOnly Property ImageAnteprimaLista As Image
        Get
            Dim Img As Image = Nothing
            If _ImageAnteprima Is Nothing Then
                Try
                    If _Anteprima.Length Then
                        If File.Exists(_Anteprima) Then
                            Dim ImgInt As New Bitmap(_Anteprima)

                            Dim width As Integer = 0, height As Integer = 0
                            Dim MargineY As Integer = 0
                            Dim MargineX As Integer = 0

                            If ImgInt.Width > ImgInt.Height Then
                                width = 80
                                height = (80 * ImgInt.Height) / ImgInt.Width
                                MargineY = 0 '(80 - height) / 2
                            ElseIf ImgInt.Width < ImgInt.Height Then
                                height = 80
                                width = (80 * ImgInt.Width) / ImgInt.Height
                                MargineX = (80 - width) / 2
                            Else
                                width = 80
                                height = 80
                            End If

                            Dim ImgNew As New Bitmap(ImgInt, New Size(width, height))
                            Img = New Bitmap(80, 80)

                            Using GraphicsObject As Graphics = Graphics.FromImage(Img)
                                GraphicsObject.DrawImage(ImgNew, MargineX, MargineY)
                            End Using
                            _ImageAnteprimaLista = Img
                        End If

                    End If

                Catch ex As Exception
                    Dim str As String = ex.Message
                End Try
            Else
                Img = _ImageAnteprimaLista
            End If

            Return Img
        End Get
    End Property

    Private _ImageAnteprima As Image = Nothing
    Public ReadOnly Property ImageAnteprima As Image Implements IVoceComboConImmagine.Image
        Get
            Dim Img As Image = Nothing
            If _ImageAnteprima Is Nothing Then

                Try
                    If _Anteprima.Length Then
                        If File.Exists(_Anteprima) Then
                            Dim ImgInt As New Bitmap(_Anteprima)

                            Dim width As Integer = 0, height As Integer = 0

                            If ImgInt.Width > ImgInt.Height Then
                                width = 80
                                height = 60
                            ElseIf ImgInt.Width < ImgInt.Height Then
                                width = 60
                                height = 80
                            Else
                                width = 80
                                height = 80
                            End If

                            Dim ImgNew = New Bitmap(ImgInt, New Size(width, height))

                            Img = ImgNew
                            _ImageAnteprima = Img
                        End If

                    End If

                Catch ex As Exception
                    Dim str As String = ex.Message
                End Try
            Else
                Img = _ImageAnteprima
            End If

            Return Img
            'Dim Img As Image = Nothing
            'Try

            '    Img = Image.FromFile(_Anteprima)
            'Catch ex As Exception

            'End Try
            'Return Img
        End Get
    End Property

#End Region

#Region "Method"

    Public Overrides Function IsValid() As Boolean Implements IModelloCommessa.IsValid
        'RETURN TRUE IF THE OBJECT IS READY FOR SAVE
        'RETURN FALSE IF LOGIC CONTROL FAIL
        'INTERNALISVALID FUNCTION MADE SIMPLE DB CONTROL
        Dim Ris As Boolean = InternalIsValid()
        'PUT YOUR LOGIC VALIDATION CODE HERE
        If _Nome.Length = 0 Then Ris = False
        'If _Anteprima.Length = 0 Then Ris = False
        If _Job.Length = 0 Then Ris = False
        'If _NumSpazi = 0 Then Ris = False
        Return Ris
    End Function

    Public Sub CaricaFormatiProdotto()
        Using mgr As New ModComFormProdDAO
            _FormatiProdotto = mgr.FindAll(New LUNA.LunaSearchParameter("IdModCom", Id))
        End Using

    End Sub

    Public Sub CaricaFormatiCarta()
        For Each F As ModComFormProd In FormatiProdotto
            Dim fp As New FormatoProdotto
            fp.Read(F.IdFormProd)
            'If Not fp Is Nothing Then
            Try
                If _FormatiCarta Is Nothing Then _FormatiCarta = New List(Of FormatoCarta)
                If _FormatiCarta.Find(Function(item) item.IdFormCarta = fp.IdFormCarta) Is Nothing Then
                    _FormatiCarta.Add(fp.FormatoCarta)
                End If
            Catch ex As Exception

            End Try

            'End If
        Next
    End Sub

    Public Overrides Function Read(Id As Integer) As Integer Implements IModelloCommessa.Read
        Dim Ris As Integer = MyBase.Read(Id)

        CaricaFormatiProdotto()
        Return Ris
    End Function

    Public Function GetNumSpaziFormatoProdotto(IdFormatoProdotto As Integer) As Integer
        Dim Ris As Integer = 0

        Using mgr As New ModelliCommessaDAO
            Ris = mgr.GetSpaziFormatoProdotto(IdModello, IdFormatoProdotto)
        End Using
        If FRSuSeStessa = enSiNo.Si Then
            Ris /= 2
        End If
        Return Ris
    End Function

    Public Function GetNumSpaziFormatoCarta(IdFormatoCarta As Integer) As Integer
        Dim Ris As Integer = 0

        Using mgr As New ModelliCommessaDAO
            Ris = mgr.GetSpaziFormatoCarta(IdModello, IdFormatoCarta)
        End Using

        Return Ris
    End Function


    Public Overrides Function Save() As Integer Implements IModelloCommessa.Save
        Dim Ris As Integer = MyBase.Save()
        Using mgr As New ModComFormProdDAO
            mgr.DeletebyIdModCom(Ris)
        End Using
        For Each m As ModComFormProd In FormatiProdotto
            m.IdModComFormP = 0 ' lo devo riazzerare per forza
            m.IdModCom = Ris
            m.Save()
        Next

        Return Ris
    End Function

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function
    Public ReadOnly Property RiepilogoHTML() As String
        Get
            Dim bufferhtml As String = "<html><head><style>BODY {font-family: 'Segoe UI';}</style></head><body>"

            bufferhtml &= "<b>" & Nome & "</b><br><br>"

            If Anteprima.Length Then
                bufferhtml &= "<img src=""" & Anteprima & """ border=0><br>"
            End If


            If AnteprimaR.Length Then
                bufferhtml &= "<img src=""" & AnteprimaR & """ border=0><br>"
            End If

            bufferhtml &= "<br><b>Formato: " & FormatoMacchina.Formato & "</b><br><br>"

            bufferhtml &= "</body></html>"
            Dim Sr As StreamWriter, PathFileStampa As String = FormerPath.PathStampaTemp & FormerHelper.File.GetNomeFileTemp(".htm")
            Sr = New System.IO.StreamWriter(PathFileStampa, False)

            Sr.Write(bufferhtml)

            Sr.Close()

            Return PathFileStampa

        End Get
    End Property

#End Region

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
End Class



''' <summary>
'''Interface for table T_modellicommessa
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface IModelloCommessa
    Inherits _IModelloCommessa

#Region "Method"

    Function Read(Id As Integer) As Integer

    Function Save() As Integer

    Function IsValid() As Boolean

#End Region

End Interface