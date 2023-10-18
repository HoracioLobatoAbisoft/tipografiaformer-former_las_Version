#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.18.3.31 
'Author: Diego Lunadei
'Date: 08/03/2018 
#End Region

Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports System.Reflection

Namespace LUNA

    Public Enum enLogicOperator
        enAND = 0
        enOR
    End Enum

    Public Enum enTransactionBoxState
        Active = 0
        Destroyed = 1
    End Enum

    Public Class LunaTransactionBox
        Implements IDisposable

        Public Sub New(CallerFunctionRif As String, CurrentThread As Integer)
            _CallerFunction = CallerFunctionRif
            _ThreadId = CurrentThread
            _CreationTime = Now.ToOADate
        End Sub

        Private _CreationTime As Double = 0
        Friend ReadOnly Property CreationTime As Double
            Get
                Return _CreationTime
            End Get
        End Property

        Public Property State As enTransactionBoxState = enTransactionBoxState.Active

        Private _DbConnection As IDbConnection

        Public ReadOnly Property DbConnection As IDbConnection
            Get
                If _DbConnection Is Nothing Then
                    _DbConnection = LUNA.LunaContext.GetDbConnection()
                End If
                Return _DbConnection
            End Get
        End Property

        Private _ThreadId As Integer = 0
        Public ReadOnly Property ThreadId As Integer
            Get
                Return _ThreadId
            End Get
        End Property

        Private _CallerFunction As String = String.Empty
        Public ReadOnly Property CallerFunction As String
            Get
                Return _CallerFunction
            End Get
        End Property

        Private _Transaction As IDbTransaction
        Public ReadOnly Property Transaction As IDbTransaction
            Get
                Return _Transaction
            End Get
        End Property

        Public Property TransactionCall As Integer = 0

        Public Sub TransactionBegin()
            If Not DbConnection Is Nothing Then
                If _Transaction Is Nothing Then
                    _Transaction = DbConnection.BeginTransaction(LunaContext.IsolationLevel)
                End If
                TransactionCall += 1
            End If
        End Sub

        Public Sub TransactionCommit()
            If Not _Transaction Is Nothing Then
                If TransactionCall = 1 Then
                    _Transaction.Commit()
                    DestroyTransaction()
                End If
                TransactionCall -= 1
            End If
        End Sub

        Public Sub TransactionRollBack()

            If Not _Transaction Is Nothing Then
                If TransactionCall = 1 Then
                    _Transaction.Rollback()
                    DestroyTransaction()
                End If
                TransactionCall -= 1
            End If
        End Sub

        Private Sub DestroyTransaction()
            Try
                _Transaction.Dispose()
            Catch ex As Exception

            End Try
            Try
                _Transaction = Nothing
            Catch ex As Exception

            End Try
        End Sub

        Private Sub DestroyConnection()
            _DbConnection.Close()
            _DbConnection.Dispose()
            _DbConnection = Nothing
        End Sub

        Private Sub DestroyBox()
            If TransactionCall = 0 Then
                State = enTransactionBoxState.Destroyed
                Try
                    If Not _Transaction Is Nothing Then
                        DestroyTransaction()
                    End If

                    If Not _DbConnection Is Nothing Then
                        If LUNA.LunaContext.ShareConnection = False Then DestroyConnection()
                    End If
                Catch ex As Exception

                End Try
                LUNA.LunaContext.DestroyTransactionBox(Me)
            End If
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: eliminare lo stato gestito (oggetti gestiti).
                    DestroyBox()
                End If

                ' TODO: liberare risorse non gestite (oggetti non gestiti) ed eseguire sotto l'override di Finalize().
                ' TODO: impostare campi di grandi dimensioni su Null.
            End If
            disposedValue = True
        End Sub

        ' TODO: eseguire l'override di Finalize() solo se Dispose(disposing As Boolean) include il codice per liberare risorse non gestite.
        'Protected Overrides Sub Finalize()
        '    ' Non modificare questo codice. Inserire sopra il codice di pulizia in Dispose(disposing As Boolean).
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' Questo codice viene aggiunto da Visual Basic per implementare in modo corretto il criterio Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire sopra il codice di pulizia in Dispose(disposing As Boolean).
            Dispose(True)
            ' TODO: rimuovere il commento dalla riga seguente se è stato eseguito l'override di Finalize().
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Friend Class LunaTools

        Friend Class StringTools
            Friend Shared Function Ap(ByVal Valore) As String
                Dim str As String = String.Empty
                If TypeOf Valore Is String Then
                    str = Valore.ToString
                    str = str.Replace("'", "''")
                    str = " '" & str & "'"
                ElseIf TypeOf Valore Is Date Then
                    Dim dateRif As Date = Valore
                    str = " CONVERT(datetime,'" & dateRif.Year & "-" & dateRif.Month.ToString("00") & "-" & dateRif.Day.ToString("00") & " " & dateRif.Hour.ToString("00") & ":" & dateRif.Minute.ToString("00") & ":" & dateRif.Second.ToString("00") & "',121)"
                ElseIf TypeOf Valore Is [Enum] Then
                    str = " " & Valore
                ElseIf Valore Is Nothing Then
                    str = " NULL "
                ElseIf TypeOf Valore Is Single Or TypeOf Valore Is Double Or TypeOf Valore Is Decimal Then
                    str = " " & Valore.ToString.Replace(",", ".")
                Else
                    str = " " & Valore.ToString
                End If
                Return str
            End Function

            Friend Shared Function ApN(ByVal Testo) As String
                Dim str As String = String.Empty
                str = Testo.ToString
                str = str.Replace(",", ".")
                Return str
            End Function

            Friend Shared Function ApLike(ByVal testo)
                Dim str As String
                str = testo.ToString
                str = str.Replace("'", "''")
                str = "like '%" & str & "%'"
                Return str
            End Function

            Friend Shared Function ApLikeRight(ByVal testo)
                Dim str As String
                str = testo.ToString
                str = str.Replace("'", "''")
                str = "like '" & str & "%'"
                Return str
            End Function

            Friend Shared Function ApIn(ByVal Valore) As String
                Dim str As String = String.Empty
                str = Valore.ToString
                str = str.Replace("'", "''")
                Return str
            End Function
        End Class

    End Class

    Partial Public Class LunaContext

        Private Shared DbConnection As Data.IDbConnection

        Private Shared Property _ConnectionString As String = String.Empty
        Public Shared Property ConnectionString As String
            Get
                If _ConnectionString = String.Empty Then
                    If Not ConfigurationManager.ConnectionStrings(ProjectId & ".ConnectionString") Is Nothing Then
                        _ConnectionString = ConfigurationManager.ConnectionStrings(ProjectId & ".ConnectionString").ConnectionString
                    ElseIf Not ConfigurationManager.ConnectionStrings("ConnectionString") Is Nothing Then
                        _ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
                    Else
                        If System.ComponentModel.LicenseManager.UsageMode <> ComponentModel.LicenseUsageMode.Designtime Then
                            Throw New Exception("Luna Engine Exception: Connection String not configured!")
                        End If
                    End If
                End If
                Return _ConnectionString
            End Get
            Set(value As String)
                _ConnectionString = value
            End Set
        End Property

        Shared Sub New()

            Dim ParamValue As String = ConfigurationManager.AppSettings(ProjectId & ".LUNA.ShareConnection")
            If Not ParamValue Is Nothing Then
                _ShareConnection = Convert.ToBoolean(ParamValue)
            End If

            ParamValue = ConfigurationManager.AppSettings(ProjectId & ".LUNA.DisableLazyLoading")
            If Not ParamValue Is Nothing Then
                _DisableLazyLoading = Convert.ToBoolean(ParamValue)
            End If

            ParamValue = ConfigurationManager.AppSettings(ProjectId & ".LUNA.WriteAllFieldEveryTime")
            If Not ParamValue Is Nothing Then
                _WriteAllFieldEveryTime = Convert.ToBoolean(ParamValue)
            End If

        End Sub

        Public Shared Function IsOkDbConnection() As Boolean
            Dim ris As Boolean = False

            Try
                Using c As IDbConnection = GetDbConnection()
                    'c.Open()
                    CloseConn(c)
                End Using
                ris = True
            Catch ex As Exception

            End Try

            Return ris
        End Function

        Public Shared Function GetServerDate() As Date
            Dim Ris As Date = Date.MinValue

            Try
                Using cn As IDbConnection = GetDbConnection()
                    Using myCommand As DbCommand = cn.CreateCommand
                        myCommand.CommandText = "SELECT GetDate()"
                        If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
                        Using myReader As DbDataReader = myCommand.ExecuteReader
                            myReader.Read()
                            If myReader.HasRows Then
                                Ris = myReader(0)
                            End If
                            myReader.Close()
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw New ApplicationException("Luna Engine Exception: ", ex)
            End Try

            Return Ris

        End Function

        Private Shared _WriteAllFieldEveryTime As Boolean = True
        Public Shared ReadOnly Property WriteAllFieldEveryTime As Boolean
            Get
                Return _WriteAllFieldEveryTime
            End Get
        End Property

        Public Shared ReadOnly Property ProjectId As String
            Get
                Dim ris As String = Assembly.GetExecutingAssembly().GetName.Name
                Return ris
            End Get
        End Property

        Private Shared _TransactionBoxes As New List(Of LUNA.LunaTransactionBox)

        Private Shared Function GetTransactionBox() As LUNA.LunaTransactionBox

            Dim ris As LUNA.LunaTransactionBox = Nothing
            Dim stackTrace As New Diagnostics.StackTrace

            Dim l As List(Of LunaTransactionBox) = _TransactionBoxes.FindAll(Function(x) Not x Is Nothing AndAlso x.ThreadId = CurrentThreadID AndAlso x.State = enTransactionBoxState.Active)

            l.Sort(Function(x, y) y.CreationTime.CompareTo(x.CreationTime))

            For Each T As LUNA.LunaTransactionBox In l
                For Each f As StackFrame In stackTrace.GetFrames
                    Dim m As System.Reflection.MethodBase = f.GetMethod
                    If m.Name = T.CallerFunction Then
                        ris = T
                        Exit For
                    End If
                Next
                If Not ris Is Nothing Then Exit For
            Next

            Return ris

        End Function

        Public Shared ReadOnly Property TransactionBox As LUNA.LunaTransactionBox
            Get
                Return GetTransactionBox()
            End Get
        End Property

        Public Shared Sub DestroyTransactionBox(ByRef T As LUNA.LunaTransactionBox)
            Try
                _TransactionBoxes.Remove(T)
            Catch ex As Exception

            End Try
            Try
                T = Nothing
            Catch ex As Exception

            End Try

        End Sub

        Private Shared Function GetCallerFunction() As String

            Dim stackTrace As New Diagnostics.StackFrame(2)
            Dim m As System.Reflection.MethodBase = stackTrace.GetMethod
            Return m.Name

        End Function

        Public Shared Function CreateTransactionBox(Optional ForceStandAloneTransaction As Boolean = False) As LUNA.LunaTransactionBox
            Dim _TransactionBox As LUNA.LunaTransactionBox = Nothing
            If ForceStandAloneTransaction = False Then _TransactionBox = TransactionBox
            If _TransactionBox Is Nothing Then
                _TransactionBox = New LunaTransactionBox(GetCallerFunction, CurrentThreadID)
                _TransactionBoxes.Add(_TransactionBox)
            End If

            Return _TransactionBox
        End Function

        Public Shared ReadOnly Property Connection As Data.IDbConnection
            Get
                If Not LUNA.LunaContext.TransactionBox Is Nothing Then
                    DbConnection = LUNA.LunaContext.TransactionBox.DbConnection
                Else
                    DbConnection = LUNA.LunaContext.GetDbConnection
                End If
                Return DbConnection
            End Get
        End Property

        Public Shared ReadOnly Property CurrentThreadID As Integer
            Get
                Return Threading.Thread.CurrentThread.ManagedThreadId
            End Get
        End Property

        Private Shared Sub CloseConn(ByRef Conn As IDbConnection)
            If Not Conn Is Nothing Then
                _TotConnAttive.Remove(Conn.GetHashCode)
                If Conn.State <> ConnectionState.Closed Then Conn.Close()
                Conn.Dispose()
                Conn = Nothing
            End If
        End Sub

        Public Shared Sub CloseDbConnection(Optional ByRef Conn As IDbConnection = Nothing)
            Try
                If Not Conn Is Nothing Then
                    If ShareConnection = False Then
                        CloseConn(Conn)
                    End If
                Else
                    CloseConn(DbConnection)
                End If

            Catch ex As Exception
                'Throw New ApplicationException("Luna Engine Exception: Error Closing DB", ex)
            End Try
        End Sub

        Friend Shared Function GetDbConnection(Optional ConnString As String = "") As IDbConnection
            Dim ris As IDbConnection = Nothing
            Try
                Dim CS As String = ConnectionString
                If ConnString.Length Then
                    CS = ConnString
                End If
                ris = OpenConn(CS)
            Catch ex As Exception
                If System.ComponentModel.LicenseManager.UsageMode <> System.ComponentModel.LicenseUsageMode.Designtime Then
                    Throw New ApplicationException("Luna Engine Exception: Error Opening DB", ex)
                End If
            End Try
            Return ris
        End Function

        Private Shared Function CreateNewConnection(ConnString As String) As IDbConnection

            Dim Ris As IDbConnection
            Dim LunaFactory As DbProviderFactory
            LunaFactory = DbProviderFactories.GetFactory(GetProviderFactory)
            Ris = LunaFactory.CreateConnection
            Ris.ConnectionString = ConnString
            Ris.Open()
            Dim HashConn As Integer = Ris.GetHashCode
            If _TotConnAttive.FindAll(Function(x) x = HashConn).Count = 0 Then _TotConnAttive.Add(HashConn)
            Return Ris

        End Function

        Private Shared Function OpenConn(ConnString As String) As IDbConnection
            Dim Ris As IDbConnection
            Try
                If ShareConnection = False Then
                    Ris = CreateNewConnection(ConnString)
                Else
                    If DbConnection Is Nothing Then
                        DbConnection = CreateNewConnection(ConnString)
                    ElseIf DbConnection.State <> Data.ConnectionState.Open Then
                        DbConnection.Open()
                    End If
                    Ris = DbConnection
                End If
            Catch ex As Exception
                Throw New ApplicationException("Luna Engine Exception: Error Opening DB", ex)
            End Try
            Return Ris
        End Function

        Private Shared _ShareConnection As Boolean = False
        Public Shared ReadOnly Property ShareConnection As Boolean
            Get
                Return _ShareConnection
            End Get
        End Property

        Private Shared _DisableLazyLoading As Boolean = False
        Public Shared ReadOnly Property DisableLazyLoading As Boolean
            Get
                Return _DisableLazyLoading
            End Get
        End Property

        Private Shared _ProviderFactory As String = String.Empty
        Friend Shared Function GetProviderFactory() As String
            If _ProviderFactory = String.Empty Then
                Dim ParamName As String = ProjectId & ".LUNA.Ioc.ProviderFactory"
                Dim ParamValue As String = ConfigurationManager.AppSettings(ParamName)
                If Not ParamValue Is Nothing Then
                    _ProviderFactory = ParamValue
                Else
                    _ProviderFactory = "System.Data.SqlClient"
                End If
            End If
            Return _ProviderFactory
        End Function

        Private Shared _MgrTypeForEntity As System.Type = Nothing
        Friend Shared Function GetMgrTypeForEntity(EntityName As System.Type) As System.Type
            If _MgrTypeForEntity Is Nothing Then
                Dim ParamName As String = ProjectId & ".LUNA.Ioc." & EntityName.Name
                Dim ParamValue As String = ConfigurationManager.AppSettings(ParamName)
                If Not ParamValue Is Nothing Then
                    _MgrTypeForEntity = Type.GetType(ParamValue, False, True)
                End If
            End If
            Return _MgrTypeForEntity
        End Function

        Private Shared _TotConnAttive As New List(Of Integer)
        Public Shared ReadOnly Property TotConnAttive As Integer
            Get
                Return _TotConnAttive.Count
            End Get
        End Property

        Public Shared ReadOnly Property TotTransactionAttive As Integer
            Get
                Return _TransactionBoxes.FindAll(Function(x) x.State = enTransactionBoxState.Active).Count
            End Get
        End Property

    End Class

    Public MustInherit Class LunaBaseClass
        Protected Overridable Sub ManageError(ByVal ex As Exception)
            Throw New ApplicationException("Luna Engine Exception: " & ex.Message, ex)
        End Sub

    End Class

    Public MustInherit Class LunaBaseClassEntity
        Inherits LunaBaseClass
        Implements ILunaBaseClassEntity

        Private _IsChanged As Boolean = False
        Public Property IsChanged As Boolean
            Get
                Return _IsChanged
            End Get
            Set(value As Boolean)
                _IsChanged = value
            End Set
        End Property

        Public Overridable Function IsValid() As Boolean
            Return True
        End Function

        Public Sub New()

        End Sub

        Protected _Mgr As IDisposable

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: eliminare stato gestito (oggetti gestiti).
                    If Not _Mgr Is Nothing Then
                        _Mgr.Dispose()
                        _Mgr = Nothing
                    End If
                End If

                ' TODO: liberare risorse non gestite (oggetti non gestiti) ed eseguire l'override del seguente Finalize().
                ' TODO: impostare campi di grandi dimensioni su null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: eseguire l'override di Finalize() solo se Dispose(ByVal disposing As Boolean) dispone del codice per liberare risorse non gestite.
        'Protected Overrides Sub Finalize()
        '    ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(ByVal disposing As Boolean).
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Public Interface ILunaBaseClassEntity
        Inherits IDisposable

    End Interface

    Public Interface ILunaBaseClassDAO(Of T)
        Inherits IDisposable
        Function Read(ByVal Id As Integer) As T
        Function Save(ByRef obj As T) As Integer
        Sub Delete(ByVal Id As Integer)
        Sub Delete(ByRef obj As T, Optional ByRef ListaObj As List(Of T) = Nothing)
        Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As T
        Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of T)
        Function GetAll(Optional ByVal OrderByField As String = "", Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of T)
    End Interface

    Public MustInherit Class LunaBaseClassDAO(Of T)
        Inherits LunaBaseClass
        Implements IDisposable
        Implements ILunaBaseClassDAO(Of T)

        Private _DbConnection As IDbConnection = Nothing

        Private Sub InitializeDBConnection()
            If _DbConnection Is Nothing OrElse _DbConnection.State <> ConnectionState.Open Then
                If Not LunaContext.TransactionBox Is Nothing Then
                    _DbConnection = LunaContext.TransactionBox.DbConnection
                Else
                    _DbConnection = LUNA.LunaContext.GetDbConnection
                End If
            End If
        End Sub

        Protected Property _Cn As IDbConnection
            Get
                InitializeDBConnection()
                Return _DbConnection
            End Get
            Set(value As IDbConnection)
                _DbConnection = value
            End Set
        End Property

        Protected _ConnectionString As String = String.Empty
        Private _ConnAdHoc As Boolean = False

        Public Sub New()

        End Sub

        Public Sub New(ByVal Connection As IDbConnection)
            'Require a valid and OPEN DBconnection
            _Cn = Connection
        End Sub

        Public MustOverride Function Read(ByVal Id As Integer) As T Implements ILunaBaseClassDAO(Of T).Read
        Public MustOverride Function Save(ByRef obj As T) As Integer Implements ILunaBaseClassDAO(Of T).Save
        Public MustOverride Sub Delete(ByVal Id As Integer) Implements ILunaBaseClassDAO(Of T).Delete
        Public MustOverride Sub Delete(ByRef obj As T, Optional ByRef ListaObj As List(Of T) = Nothing) Implements ILunaBaseClassDAO(Of T).Delete
        Public MustOverride Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As T Implements ILunaBaseClassDAO(Of T).Find
        Public MustOverride Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of T) Implements ILunaBaseClassDAO(Of T).FindAll
        Public MustOverride Function GetAll(Optional ByVal OrderByField As String = "", Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of T) Implements ILunaBaseClassDAO(Of T).GetAll


        Protected Function Ap(ByVal Valore) As String
            Return LunaTools.StringTools.Ap(Valore)
        End Function

        Protected Function ApN(ByVal Testo) As String
            Return LunaTools.StringTools.ApN(Testo)
        End Function

        Protected Function ApLike(ByVal testo)
            Return LunaTools.StringTools.ApLike(testo)
        End Function

        Protected Function ApLikeRight(ByVal testo)
            Return LunaTools.StringTools.ApLikeRight(testo)
        End Function

        Protected Function ApIn(ByVal Valore) As String
            Return LunaTools.StringTools.ApIn(Valore)
        End Function

#Region "Serialization Method"
        Public Function ReadSerialize(ByVal PathXMLSerial As String) As T

            Dim cls As T
            Try
                Dim serialize As XmlSerializer = New XmlSerializer(GetType(T))
                Dim deSerialize As IO.FileStream = New IO.FileStream(PathXMLSerial, IO.FileMode.Open)
                cls = serialize.Deserialize(deSerialize)
            Catch ex As Exception
                ManageError(ex)
            End Try

            Return cls
        End Function

        Public Sub SaveSerialize(Obj As T, ByVal PathXML As String)

            Try
                Dim serialize As XmlSerializer = New XmlSerializer(GetType(T))
                Dim Writer As New System.IO.StreamWriter(PathXML)
                serialize.Serialize(Writer, Obj)
                Writer.Close()
            Catch ex As Exception
                ManageError(ex)
            End Try

        End Sub
#End Region

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls
        Protected Overridable Sub Dispose(disposing As Boolean)
            If LunaContext.TransactionBox Is Nothing Then LUNA.LunaContext.CloseDbConnection(_Cn)
            Me.disposedValue = True
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
        Protected Overrides Sub Finalize()
            Dispose(False)
        End Sub
#End Region

    End Class

    Public Class LunaSearchOption
        Public Property Top As Integer = 0
        Public Property OrderBy As String = ""
        Public Property AddEmptyItem As Boolean = False
        Public Property Distinct As Boolean = False
    End Class

    Public Class LunaFieldName
        Public Sub New(FieldName As String)
            _Name = FieldName
        End Sub
        Private _Name As String = String.Empty
        Public ReadOnly Property Name As String
            Get
                Return _Name
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return _Name
        End Function
    End Class

    ''' <summary>
    '''This Class is an alias for LunaSearchOption. You could use both without difference
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    Public Class LSO
        Inherits LunaSearchOption

    End Class

    ''' <summary>
    '''This Class is an alias for LunaSearchParameter. You could use both without difference
    ''' </summary>
    ''' <remarks>
    '''
    ''' </remarks>
    Public Class LSP
        Inherits LunaSearchParameter

        Public Sub New()
            MyBase.New
        End Sub

        Public Sub New(ByVal FieldName As LunaFieldName,
                       ByVal Value As Object,
                       Optional ByVal SqlOperator As String = "",
                       Optional ByVal LogicOperator As enLogicOperator = enLogicOperator.enAND)
            MyBase.New(FieldName, Value, SqlOperator, LogicOperator)
        End Sub

        <Obsolete("Use Instead Constructor with LFM field definition")>
        Public Sub New(ByVal FieldName As String,
                       ByVal Value As Object,
                       Optional ByVal SqlOperator As String = "",
                       Optional ByVal LogicOperator As enLogicOperator = enLogicOperator.enAND)
            MyBase.New(FieldName, Value, SqlOperator, LogicOperator)
        End Sub

    End Class

    Public Class LunaSearchParameter

        Public Sub New()

        End Sub

        Public Sub New(ByVal FieldName As LunaFieldName,
                       ByVal Value As Object,
                       Optional ByVal SqlOperator As String = "",
                       Optional ByVal LogicOperator As enLogicOperator = enLogicOperator.enAND)
            InternalNew(FieldName.Name, Value, SqlOperator, LogicOperator)
        End Sub

        <Obsolete("Use Instead Constructor with LFM field definition")>
        Public Sub New(ByVal FieldName As String,
                       ByVal Value As Object,
                       Optional ByVal SqlOperator As String = "",
                       Optional ByVal LogicOperator As enLogicOperator = enLogicOperator.enAND)
            InternalNew(FieldName, Value, SqlOperator, LogicOperator)
        End Sub

        Protected Sub InternalNew(ByVal FieldName As String,
                                  ByVal Value As Object,
                                  Optional ByVal SqlOperator As String = "",
                                  Optional ByVal LogicOperator As enLogicOperator = enLogicOperator.enAND)
            _FieldName = FieldName
            If TypeOf (Value) Is Boolean Then
                If Value = True Then
                    _Value = 1
                Else
                    _Value = 0
                End If
            Else
                _Value = Value
            End If
            If SqlOperator.Length Then _SqlOperator = SqlOperator
            _LogicOperator = LogicOperator

        End Sub

        Private _SqlOperator As String = " = "
        Public Property SqlOperator As String
            Get
                Return _SqlOperator
            End Get
            Set(ByVal value As String)
                _SqlOperator = value
            End Set
        End Property

        Private _LogicOperator As enLogicOperator = enLogicOperator.enAND
        Public Property LogicOperator As enLogicOperator
            Get
                Return _LogicOperator
            End Get
            Set(ByVal value As enLogicOperator)
                _LogicOperator = value
            End Set
        End Property

        Public ReadOnly Property LogicOperatorStr As String
            Get
                If _LogicOperator = enLogicOperator.enAND Then
                    Return " AND "
                Else
                    Return " OR "
                End If
            End Get
        End Property

        Private _FieldName As String
        Public Property FieldName As String
            Get
                Return _FieldName
            End Get
            Set(ByVal value As String)
                _FieldName = value
            End Set
        End Property

        Private _Value
        Public Property Value
            Get
                Return _Value
            End Get
            Set(ByVal value)
                _Value = value
            End Set
        End Property

    End Class

End Namespace

