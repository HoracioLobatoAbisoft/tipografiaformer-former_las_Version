#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 07/04/2020 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of GruppoVarianteRifW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _GruppiVariantiRifWDAO
	Inherits LUNA.LunaBaseClassDAO(Of GruppoVarianteRifW)

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
	'''Read from DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return a GruppoVarianteRifW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as GruppoVarianteRifW
		Dim cls as new GruppoVarianteRifW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM Tr_gruppovarianterif WHERE IdGruppoVarianteDett = " & Id
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
	'''Save on DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as GruppoVarianteRifW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdGruppoVarianteDett = 0 Then
							sql = "INSERT INTO Tr_gruppovarianterif ("
							sql &= " IdGruppoVariante,"
							sql &= " IdListinoBase,"
							sql &= " IdRiferimento,"
							sql &= " PercDiminuzione,"
							sql &= " TipoRiferimento"
							sql &= ") VALUES ("
							sql &= " @IdGruppoVariante,"
							sql &= " @IdListinoBase,"
							sql &= " @IdRiferimento,"
							sql &= " @PercDiminuzione,"
							sql &= " @TipoRiferimento"
							sql &= ")"
						Else
							sql = "UPDATE Tr_gruppovarianterif SET "
							If cls.WhatIsChanged.IdGruppoVariante Then sql &= "IdGruppoVariante = @IdGruppoVariante,"
							If cls.WhatIsChanged.IdListinoBase Then sql &= "IdListinoBase = @IdListinoBase,"
							If cls.WhatIsChanged.IdRiferimento Then sql &= "IdRiferimento = @IdRiferimento,"
							If cls.WhatIsChanged.PercDiminuzione Then sql &= "PercDiminuzione = @PercDiminuzione,"
							If cls.WhatIsChanged.TipoRiferimento Then sql &= "TipoRiferimento = @TipoRiferimento"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdGruppoVarianteDett= " & cls.IdGruppoVarianteDett
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.IdGruppoVariante Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdGruppoVariante"
							p.Value = cls.IdGruppoVariante
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdListinoBase Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdListinoBase"
							p.Value = cls.IdListinoBase
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRiferimento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRiferimento"
							p.Value = cls.IdRiferimento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.PercDiminuzione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@PercDiminuzione"
							p.Value = cls.PercDiminuzione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.TipoRiferimento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@TipoRiferimento"
							p.Value = cls.TipoRiferimento
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdGruppoVarianteDett=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdGruppoVarianteDett = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdGruppoVarianteDett
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdGruppoVarianteDett
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
				'Dim Sql As String = "UPDATE Tr_gruppovarianterif SET DELETED=True "
				Dim Sql As String = "DELETE FROM Tr_gruppovarianterif"
				Sql &= " WHERE IdGruppoVarianteDett = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table Tr_gruppovarianterif. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table Tr_gruppovarianterif. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as GruppoVarianteRifW, Optional ByRef ListaObj as List (of GruppoVarianteRifW) = Nothing)
		DestroyPermanently (obj.IdGruppoVarianteDett)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As GruppoVarianteRifW
		Dim ris As GruppoVarianteRifW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of GruppoVarianteRifW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return first of GruppoVarianteRifW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As GruppoVarianteRifW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return first of GruppoVarianteRifW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As GruppoVarianteRifW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table GruppoVarianteRifW
	''' </summary>
	''' <returns>
	'''Return first of GruppoVarianteRifW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As GruppoVarianteRifW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return a list of GruppoVarianteRifW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of GruppoVarianteRifW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return a list of GruppoVarianteRifW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of GruppoVarianteRifW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return a list of GruppoVarianteRifW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of GruppoVarianteRifW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return a list of GruppoVarianteRifW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of GruppoVarianteRifW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return a list of GruppoVarianteRifW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of GruppoVarianteRifW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return a list of GruppoVarianteRifW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of GruppoVarianteRifW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table Tr_gruppovarianterif by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of GruppoVarianteRifW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of GruppoVarianteRifW)
		Dim Ls As New List(Of GruppoVarianteRifW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of GruppoVarianteRifW)
		Dim Ls As New List(Of GruppoVarianteRifW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM Tr_gruppovarianterif" 
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
	'''Return all record on DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return all record in list of GruppoVarianteRifW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of GruppoVarianteRifW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return all record in list of GruppoVarianteRifW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of GruppoVarianteRifW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table Tr_gruppovarianterif
	''' </summary>
	''' <returns>
	'''Return all record in list of GruppoVarianteRifW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of GruppoVarianteRifW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of GruppoVarianteRifW)
		Dim Ls As List(Of GruppoVarianteRifW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM Tr_gruppovarianterif" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of GruppoVarianteRifW)
		Dim Ls As New List(Of GruppoVarianteRifW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  GruppoVarianteRifW() With {.IdGruppoVarianteDett = 0 ,.IdGruppoVariante = 0 ,.IdListinoBase = 0 ,.IdRiferimento = 0 ,.PercDiminuzione = 0 ,.TipoRiferimento = 0  })
					While myReader.Read
						Dim classe as new GruppoVarianteRifW(CType(myReader, IDataRecord))
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