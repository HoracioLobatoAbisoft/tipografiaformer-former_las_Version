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
'''This class manage persistency on db of AzioneSottoscorta object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _AzioniSottoscortaDAO
	Inherits LUNA.LunaBaseClassDAO(Of AzioneSottoscorta)

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
	'''Read from DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return a AzioneSottoscorta object
	''' </returns>
	Public Overrides Function Read(Id as integer) as AzioneSottoscorta
		Dim cls as new AzioneSottoscorta

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_azionisottoscorta WHERE IdRegola = " & Id
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
	'''Save on DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as AzioneSottoscorta) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdRegola = 0 Then
							sql = "INSERT INTO T_azionisottoscorta ("
							sql &= " Azione,"
							sql &= " IdDestMessaggio,"
							sql &= " IdListinoBase,"
							sql &= " IdRisorsa,"
							sql &= " PathFile,"
							sql &= " QtaOrdine,"
							sql &= " StampareReminder"
							sql &= ") VALUES ("
							sql &= " @Azione,"
							sql &= " @IdDestMessaggio,"
							sql &= " @IdListinoBase,"
							sql &= " @IdRisorsa,"
							sql &= " @PathFile,"
							sql &= " @QtaOrdine,"
							sql &= " @StampareReminder"
							sql &= ")"
						Else
							sql = "UPDATE T_azionisottoscorta SET "
							If cls.WhatIsChanged.Azione Then sql &= "Azione = @Azione,"
							If cls.WhatIsChanged.IdDestMessaggio Then sql &= "IdDestMessaggio = @IdDestMessaggio,"
							If cls.WhatIsChanged.IdListinoBase Then sql &= "IdListinoBase = @IdListinoBase,"
							If cls.WhatIsChanged.IdRisorsa Then sql &= "IdRisorsa = @IdRisorsa,"
							If cls.WhatIsChanged.PathFile Then sql &= "PathFile = @PathFile,"
							If cls.WhatIsChanged.QtaOrdine Then sql &= "QtaOrdine = @QtaOrdine,"
							If cls.WhatIsChanged.StampareReminder Then sql &= "StampareReminder = @StampareReminder"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdRegola= " & cls.IdRegola
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@Azione"
						p.Value = cls.Azione
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdDestMessaggio"
						p.Value = cls.IdDestMessaggio
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdListinoBase"
						p.Value = cls.IdListinoBase
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@IdRisorsa"
						p.Value = cls.IdRisorsa
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PathFile"
						p.Value = cls.PathFile
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@QtaOrdine"
						p.Value = cls.QtaOrdine
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@StampareReminder"
						p.Value = cls.StampareReminder
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdRegola=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdRegola = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdRegola
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdRegola
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
				'Dim Sql As String = "UPDATE T_azionisottoscorta SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_azionisottoscorta"
				Sql &= " WHERE IdRegola = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_azionisottoscorta. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_azionisottoscorta. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as AzioneSottoscorta, Optional ByRef ListaObj as List (of AzioneSottoscorta) = Nothing)
		DestroyPermanently (obj.IdRegola)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As AzioneSottoscorta
		Dim ris As AzioneSottoscorta = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of AzioneSottoscorta) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return first of AzioneSottoscorta
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As AzioneSottoscorta
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return first of AzioneSottoscorta
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As AzioneSottoscorta
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table AzioneSottoscorta
	''' </summary>
	''' <returns>
	'''Return first of AzioneSottoscorta
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As AzioneSottoscorta
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return a list of AzioneSottoscorta
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AzioneSottoscorta)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return a list of AzioneSottoscorta
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AzioneSottoscorta)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return a list of AzioneSottoscorta
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AzioneSottoscorta)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return a list of AzioneSottoscorta
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AzioneSottoscorta)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return a list of AzioneSottoscorta
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of AzioneSottoscorta)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return a list of AzioneSottoscorta
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of AzioneSottoscorta)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_azionisottoscorta by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of AzioneSottoscorta by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of AzioneSottoscorta)
		Dim Ls As New List(Of AzioneSottoscorta)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of AzioneSottoscorta)
		Dim Ls As New List(Of AzioneSottoscorta)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_azionisottoscorta" 
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
	'''Return all record on DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return all record in list of AzioneSottoscorta
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of AzioneSottoscorta)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return all record in list of AzioneSottoscorta
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of AzioneSottoscorta)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_azionisottoscorta
	''' </summary>
	''' <returns>
	'''Return all record in list of AzioneSottoscorta
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of AzioneSottoscorta)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of AzioneSottoscorta)
		Dim Ls As List(Of AzioneSottoscorta)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_azionisottoscorta" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of AzioneSottoscorta)
		Dim Ls As New List(Of AzioneSottoscorta)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  AzioneSottoscorta() With {.IdRegola = 0 ,.Azione = 0 ,.IdDestMessaggio = 0 ,.IdListinoBase = 0 ,.IdRisorsa = 0 ,.PathFile = "" ,.QtaOrdine = 0 ,.StampareReminder = 0  })
					While myReader.Read
						Dim classe as new AzioneSottoscorta(CType(myReader, IDataRecord))
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