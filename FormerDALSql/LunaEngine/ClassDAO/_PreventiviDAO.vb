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
'''This class manage persistency on db of Preventivo object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _PreventiviDAO
	Inherits LUNA.LunaBaseClassDAO(Of Preventivo)

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
	'''Read from DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return a Preventivo object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Preventivo
		Dim cls as new Preventivo

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_preventivi WHERE IdPrev = " & Id
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
	'''Save on DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Preventivo) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdPrev = 0 Then
							sql = "INSERT INTO T_preventivi ("
							sql &= " Anteprima,"
							sql &= " Carta,"
							sql &= " Codice,"
							sql &= " DataIns,"
							sql &= " EmailRif,"
							sql &= " FormatoAperto,"
							sql &= " FormatoChiuso,"
							sql &= " IdCorr,"
							sql &= " IdListinoBase,"
							sql &= " IdRub,"
							sql &= " Iva,"
							sql &= " Lavorazioni,"
							sql &= " Numero,"
							sql &= " Pagine,"
							sql &= " PrezzoNetto,"
							sql &= " Qta,"
							sql &= " Risposto,"
							sql &= " Sconto,"
							sql &= " Stampa,"
							sql &= " TestoRisp,"
							sql &= " TipoLavoro"
							sql &= ") VALUES ("
							sql &= " @Anteprima,"
							sql &= " @Carta,"
							sql &= " @Codice,"
							sql &= " @DataIns,"
							sql &= " @EmailRif,"
							sql &= " @FormatoAperto,"
							sql &= " @FormatoChiuso,"
							sql &= " @IdCorr,"
							sql &= " @IdListinoBase,"
							sql &= " @IdRub,"
							sql &= " @Iva,"
							sql &= " @Lavorazioni,"
							sql &= " @Numero,"
							sql &= " @Pagine,"
							sql &= " @PrezzoNetto,"
							sql &= " @Qta,"
							sql &= " @Risposto,"
							sql &= " @Sconto,"
							sql &= " @Stampa,"
							sql &= " @TestoRisp,"
							sql &= " @TipoLavoro"
							sql &= ")"
						Else
							sql = "UPDATE T_preventivi SET "
							If cls.WhatIsChanged.Anteprima Then sql &= "Anteprima = @Anteprima,"
							If cls.WhatIsChanged.Carta Then sql &= "Carta = @Carta,"
							If cls.WhatIsChanged.Codice Then sql &= "Codice = @Codice,"
							If cls.WhatIsChanged.DataIns Then sql &= "DataIns = @DataIns,"
							If cls.WhatIsChanged.EmailRif Then sql &= "EmailRif = @EmailRif,"
							If cls.WhatIsChanged.FormatoAperto Then sql &= "FormatoAperto = @FormatoAperto,"
							If cls.WhatIsChanged.FormatoChiuso Then sql &= "FormatoChiuso = @FormatoChiuso,"
							If cls.WhatIsChanged.IdCorr Then sql &= "IdCorr = @IdCorr,"
							If cls.WhatIsChanged.IdListinoBase Then sql &= "IdListinoBase = @IdListinoBase,"
							If cls.WhatIsChanged.IdRub Then sql &= "IdRub = @IdRub,"
							If cls.WhatIsChanged.Iva Then sql &= "Iva = @Iva,"
							If cls.WhatIsChanged.Lavorazioni Then sql &= "Lavorazioni = @Lavorazioni,"
							If cls.WhatIsChanged.Numero Then sql &= "Numero = @Numero,"
							If cls.WhatIsChanged.Pagine Then sql &= "Pagine = @Pagine,"
							If cls.WhatIsChanged.PrezzoNetto Then sql &= "PrezzoNetto = @PrezzoNetto,"
							If cls.WhatIsChanged.Qta Then sql &= "Qta = @Qta,"
							If cls.WhatIsChanged.Risposto Then sql &= "Risposto = @Risposto,"
							If cls.WhatIsChanged.Sconto Then sql &= "Sconto = @Sconto,"
							If cls.WhatIsChanged.Stampa Then sql &= "Stampa = @Stampa,"
							If cls.WhatIsChanged.TestoRisp Then sql &= "TestoRisp = @TestoRisp,"
							If cls.WhatIsChanged.TipoLavoro Then sql &= "TipoLavoro = @TipoLavoro"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdPrev= " & cls.IdPrev
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@Anteprima"
						p.Value = cls.Anteprima
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Carta"
						p.Value = cls.Carta
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Codice"
						p.Value = cls.Codice
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@DataIns"
						p.DbType = DbType.DateTime
						If cls.DataIns <> Date.MinValue Then
							p.Value = cls.DataIns
						Else
							p.Value = DBNull.Value
						End If  
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@EmailRif"
						p.Value = cls.EmailRif
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@FormatoAperto"
						p.Value = cls.FormatoAperto
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@FormatoChiuso"
						p.Value = cls.FormatoChiuso
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdCorr"
						p.Value = cls.IdCorr
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdListinoBase"
						p.Value = cls.IdListinoBase
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdRub"
						p.Value = cls.IdRub
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Iva"
						p.Value = cls.Iva
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Lavorazioni"
						p.Value = cls.Lavorazioni
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Numero"
						p.Value = cls.Numero
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Pagine"
						p.Value = cls.Pagine
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PrezzoNetto"
						p.Value = cls.PrezzoNetto
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Qta"
						p.Value = cls.Qta
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Risposto"
						p.Value = cls.Risposto
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Sconto"
						p.Value = cls.Sconto
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Stampa"
						p.Value = cls.Stampa
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TestoRisp"
						p.Value = cls.TestoRisp
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TipoLavoro"
						p.Value = cls.TipoLavoro
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdPrev=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdPrev = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdPrev
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdPrev
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
				'Dim Sql As String = "UPDATE T_preventivi SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_preventivi"
				Sql &= " WHERE IdPrev = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_preventivi. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_preventivi. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Preventivo, Optional ByRef ListaObj as List (of Preventivo) = Nothing)
		DestroyPermanently (obj.IdPrev)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Preventivo
		Dim ris As Preventivo = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Preventivo) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return first of Preventivo
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Preventivo
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return first of Preventivo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Preventivo
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Preventivo
	''' </summary>
	''' <returns>
	'''Return first of Preventivo
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Preventivo
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return a list of Preventivo
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Preventivo)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return a list of Preventivo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Preventivo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return a list of Preventivo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Preventivo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return a list of Preventivo
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Preventivo)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return a list of Preventivo
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Preventivo)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return a list of Preventivo
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Preventivo)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_preventivi by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Preventivo by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Preventivo)
		Dim Ls As New List(Of Preventivo)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Preventivo)
		Dim Ls As New List(Of Preventivo)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_preventivi" 
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
	'''Return all record on DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return all record in list of Preventivo
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Preventivo)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return all record in list of Preventivo
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Preventivo)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_preventivi
	''' </summary>
	''' <returns>
	'''Return all record in list of Preventivo
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Preventivo)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Preventivo)
		Dim Ls As List(Of Preventivo)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_preventivi" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Preventivo)
		Dim Ls As New List(Of Preventivo)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Preventivo() With {.IdPrev = 0 ,.Anteprima = "" ,.Carta = "" ,.Codice = "" ,.DataIns = Nothing ,.EmailRif = "" ,.FormatoAperto = "" ,.FormatoChiuso = "" ,.IdCorr = 0 ,.IdListinoBase = 0 ,.IdRub = 0 ,.Iva = 0 ,.Lavorazioni = "" ,.Numero = "" ,.Pagine = "" ,.PrezzoNetto = 0 ,.Qta = "" ,.Risposto = 0 ,.Sconto = 0 ,.Stampa = "" ,.TestoRisp = "" ,.TipoLavoro = ""  })
					While myReader.Read
						Dim classe as new Preventivo(CType(myReader, IDataRecord))
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