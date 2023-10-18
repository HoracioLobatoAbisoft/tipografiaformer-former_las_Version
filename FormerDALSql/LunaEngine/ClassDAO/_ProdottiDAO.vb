#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.51 
'Author: Diego Lunadei
'Date: 29/12/2017 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of Prodotto object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _ProdottiDAO
	Inherits LUNA.LunaBaseClassDAO(Of Prodotto)

	''' <summary>
	'''New() create an istance of this class. Use default DB Connection
	''' </summary>
	Public Sub New()
		MyBase.New()
	End Sub

	''' <summary>
	'''New() create an istance of this class and specify an OPENED DB connection
	''' </summary>
	Public Sub New(ByVal Connection As DbConnection)
		MyBase.New(Connection)
	End Sub

	''' <summary>
	'''Read from DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return a Prodotto object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Prodotto
		Dim cls as new Prodotto

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_prodotti WHERE IdProd = " & Id
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader
					myReader.Read()
					If myReader.HasRows Then
						cls.FillFromDataRecord(CType(myReader, IDataRecord))	
					End If
					myReader.Close()
				End Using
			End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return cls
	End Function

	''' <summary>
	'''Save on DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Prodotto) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdProd = 0 Then
							sql = "INSERT INTO T_prodotti ("
							sql &= " Codice,"
							sql &= " Descrizione,"
							sql &= " DescrizioneEstesa,"
							sql &= " FronteRetro,"
							sql &= " GGFast,"
							sql &= " GGLow,"
							sql &= " GGNormale,"
							sql &= " IdCatProd,"
							sql &= " IdFormato,"
							sql &= " IdListinoBase,"
							sql &= " IdTipoCarta,"
							sql &= " NoImpiantiSuFacciate,"
							sql &= " NumColli,"
							sql &= " NumDuplic,"
							sql &= " NumFacciate,"
							sql &= " NumOreMax,"
							sql &= " NumPezzi,"
							sql &= " NumSpazi,"
							sql &= " PercFast,"
							sql &= " PercLow,"
							sql &= " PercNormale,"
							sql &= " PesoComplessivo,"
							sql &= " Prezzo,"
							sql &= " PrezzoPubbl,"
							sql &= " Scarto,"
							sql &= " Status,"
							sql &= " TipoProd"
							sql &= ") VALUES ("
							sql &= " @Codice,"
							sql &= " @Descrizione,"
							sql &= " @DescrizioneEstesa,"
							sql &= " @FronteRetro,"
							sql &= " @GGFast,"
							sql &= " @GGLow,"
							sql &= " @GGNormale,"
							sql &= " @IdCatProd,"
							sql &= " @IdFormato,"
							sql &= " @IdListinoBase,"
							sql &= " @IdTipoCarta,"
							sql &= " @NoImpiantiSuFacciate,"
							sql &= " @NumColli,"
							sql &= " @NumDuplic,"
							sql &= " @NumFacciate,"
							sql &= " @NumOreMax,"
							sql &= " @NumPezzi,"
							sql &= " @NumSpazi,"
							sql &= " @PercFast,"
							sql &= " @PercLow,"
							sql &= " @PercNormale,"
							sql &= " @PesoComplessivo,"
							sql &= " @Prezzo,"
							sql &= " @PrezzoPubbl,"
							sql &= " @Scarto,"
							sql &= " @Status,"
							sql &= " @TipoProd"
							sql &= ")"
						Else
							sql = "UPDATE T_prodotti SET "
							If cls.WhatIsChanged.Codice Then sql &= "Codice = @Codice,"
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.DescrizioneEstesa Then sql &= "DescrizioneEstesa = @DescrizioneEstesa,"
							If cls.WhatIsChanged.FronteRetro Then sql &= "FronteRetro = @FronteRetro,"
							If cls.WhatIsChanged.GGFast Then sql &= "GGFast = @GGFast,"
							If cls.WhatIsChanged.GGLow Then sql &= "GGLow = @GGLow,"
							If cls.WhatIsChanged.GGNormale Then sql &= "GGNormale = @GGNormale,"
							If cls.WhatIsChanged.IdCatProd Then sql &= "IdCatProd = @IdCatProd,"
							If cls.WhatIsChanged.IdFormato Then sql &= "IdFormato = @IdFormato,"
							If cls.WhatIsChanged.IdListinoBase Then sql &= "IdListinoBase = @IdListinoBase,"
							If cls.WhatIsChanged.IdTipoCarta Then sql &= "IdTipoCarta = @IdTipoCarta,"
							If cls.WhatIsChanged.NoImpiantiSuFacciate Then sql &= "NoImpiantiSuFacciate = @NoImpiantiSuFacciate,"
							If cls.WhatIsChanged.NumColli Then sql &= "NumColli = @NumColli,"
							If cls.WhatIsChanged.NumDuplic Then sql &= "NumDuplic = @NumDuplic,"
							If cls.WhatIsChanged.NumFacciate Then sql &= "NumFacciate = @NumFacciate,"
							If cls.WhatIsChanged.NumOreMax Then sql &= "NumOreMax = @NumOreMax,"
							If cls.WhatIsChanged.NumPezzi Then sql &= "NumPezzi = @NumPezzi,"
							If cls.WhatIsChanged.NumSpazi Then sql &= "NumSpazi = @NumSpazi,"
							If cls.WhatIsChanged.PercFast Then sql &= "PercFast = @PercFast,"
							If cls.WhatIsChanged.PercLow Then sql &= "PercLow = @PercLow,"
							If cls.WhatIsChanged.PercNormale Then sql &= "PercNormale = @PercNormale,"
							If cls.WhatIsChanged.PesoComplessivo Then sql &= "PesoComplessivo = @PesoComplessivo,"
							If cls.WhatIsChanged.Prezzo Then sql &= "Prezzo = @Prezzo,"
							If cls.WhatIsChanged.PrezzoPubbl Then sql &= "PrezzoPubbl = @PrezzoPubbl,"
							If cls.WhatIsChanged.Scarto Then sql &= "Scarto = @Scarto,"
							If cls.WhatIsChanged.Status Then sql &= "Status = @Status,"
							If cls.WhatIsChanged.TipoProd Then sql &= "TipoProd = @TipoProd"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdProd= " & cls.IdProd
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@Codice"
						p.Value = cls.Codice
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Descrizione"
						p.Value = cls.Descrizione
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@DescrizioneEstesa"
						p.Value = cls.DescrizioneEstesa
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@FronteRetro"
						p.Value = cls.FronteRetro
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@GGFast"
						p.Value = cls.GGFast
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@GGLow"
						p.Value = cls.GGLow
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@GGNormale"
						p.Value = cls.GGNormale
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdCatProd"
						p.Value = cls.IdCatProd
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdFormato"
						p.Value = cls.IdFormato
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdListinoBase"
						p.Value = cls.IdListinoBase
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdTipoCarta"
						p.Value = cls.IdTipoCarta
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NoImpiantiSuFacciate"
						p.Value = cls.NoImpiantiSuFacciate
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NumColli"
						p.Value = cls.NumColli
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NumDuplic"
						p.Value = cls.NumDuplic
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NumFacciate"
						p.Value = cls.NumFacciate
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NumOreMax"
						p.Value = cls.NumOreMax
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NumPezzi"
						p.Value = cls.NumPezzi
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NumSpazi"
						p.Value = cls.NumSpazi
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PercFast"
						p.Value = cls.PercFast
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PercLow"
						p.Value = cls.PercLow
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PercNormale"
						p.Value = cls.PercNormale
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PesoComplessivo"
						p.Value = cls.PesoComplessivo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Prezzo"
						p.Value = cls.Prezzo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PrezzoPubbl"
						p.Value = cls.PrezzoPubbl
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Scarto"
						p.Value = cls.Scarto
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Status"
						p.Value = cls.Status
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TipoProd"
						p.Value = cls.TipoProd
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdProd=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdProd = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdProd
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdProd
			End If
		Else
			throw new ApplicationException("Object data is not valid")
		End If
		Return Ris
	End Function

	Private Sub DestroyPermanently(Id as integer) 
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.Connection = _cn

				'******IMPORTANT: You can use this commented instruction to make a logical delete .
				'******Replace DELETED Field with your logic deleted field name.
				'Dim Sql As String = "UPDATE T_prodotti SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_prodotti"
				Sql &= " WHERE IdProd = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_prodotti. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_prodotti. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Prodotto, Optional ByRef ListaObj as List (of Prodotto) = Nothing)
		DestroyPermanently (obj.IdProd)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Prodotto
		Dim ris As Prodotto = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Prodotto) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return first of Prodotto
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Prodotto
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return first of Prodotto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Prodotto
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Prodotto
	''' </summary>
	''' <returns>
	'''Return first of Prodotto
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Prodotto
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return a list of Prodotto
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Prodotto)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return a list of Prodotto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Prodotto)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return a list of Prodotto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Prodotto)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return a list of Prodotto
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Prodotto)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return a list of Prodotto
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Prodotto)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return a list of Prodotto
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Prodotto)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_prodotti by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Prodotto by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Prodotto)
		Dim Ls As New List(Of Prodotto)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Prodotto)
		Dim Ls As New List(Of Prodotto)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_prodotti" 
			For Each Par As LUNA.LunaSearchParameter In Parameter
				If Not Par Is Nothing Then
					If Sql.IndexOf("WHERE") = -1 Then Sql &= " WHERE " Else Sql &=  " " & Par.LogicOperatorStr & " "
					sql &= Par.FieldName & " " & Par.SqlOperator
					If Par.SqlOperator.ToUpper.IndexOf("IN") <> -1 Then
						sql &= " " & ApIn(Par.Value)
					Else
						sql &= " " & Ap(Par.Value)
					End If
				End if
			Next

			If SearchOption.OrderBy.Length Then Sql &= " ORDER BY " & SearchOption.OrderBy

			Ls = GetData(sql, SearchOption.AddEmptyItem)

		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function

	''' <summary>
	'''Return all record on DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return all record in list of Prodotto
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Prodotto)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return all record in list of Prodotto
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Prodotto)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_prodotti
	''' </summary>
	''' <returns>
	'''Return all record in list of Prodotto
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Prodotto)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Prodotto)
		Dim Ls As List(Of Prodotto)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_prodotti" 
			If OrderByField.Length Then
				Sql &= " ORDER BY " & OrderByField
			End If
			Ls = GetData(Sql,AddEmptyItem)

		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function

	Protected Overridable Property EmptyItemDescription As String = "Selezionare una voce"

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Prodotto)
		Dim Ls As New List(Of Prodotto)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Prodotto() With {.IdProd = 0 ,.Codice = "" ,.Descrizione = EmptyItemDescription,.DescrizioneEstesa = "" ,.FronteRetro = False ,.GGFast = 0 ,.GGLow = 0 ,.GGNormale = 0 ,.IdCatProd = 0 ,.IdFormato = 0 ,.IdListinoBase = 0 ,.IdTipoCarta = 0 ,.NoImpiantiSuFacciate = 0 ,.NumColli = 0 ,.NumDuplic = 0 ,.NumFacciate = 0 ,.NumOreMax = 0 ,.NumPezzi = 0 ,.NumSpazi = 0 ,.PercFast = 0 ,.PercLow = 0 ,.PercNormale = 0 ,.PesoComplessivo = 0 ,.Prezzo = 0 ,.PrezzoPubbl = 0 ,.Scarto = 0 ,.Status = 0 ,.TipoProd = 0  })
					While myReader.Read
						Dim classe as new Prodotto(CType(myReader, IDataRecord))
						Ls.Add(classe)
					End While
					myReader.Close()
				End Using
			End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
End Class