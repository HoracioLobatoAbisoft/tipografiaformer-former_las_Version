#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.20.1.8 
'Author: Diego Lunadei
'Date: 28/01/2020 
#End Region


Imports System.Data.Common
''' <summary>
'''This class manage persistency on db of MacchinarioW object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _MacchinariWDAO
	Inherits LUNA.LunaBaseClassDAO(Of MacchinarioW)

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
	'''Read from DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return a MacchinarioW object
	''' </returns>
	Public Overrides Function Read(Id as integer) as MacchinarioW
		Dim cls as new MacchinarioW

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_macchinari WHERE IdMacchinario = " & Id
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
	'''Save on DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as MacchinarioW) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdMacchinario = 0 Then
							sql = "INSERT INTO T_macchinari ("
							sql &= " AlertCommesse,"
							sql &= " AltezzaCaricoCm,"
							sql &= " CaricoPrevistoMensile,"
							sql &= " CopieOra,"
							sql &= " CostoMensile,"
							sql &= " CostoMinAvv,"
							sql &= " CostoSingCopia,"
							sql &= " Descrizione,"
							sql &= " DescrizioneEstesa,"
							sql &= " DescrizioneOnline,"
							sql &= " HotFolderFlusso,"
							sql &= " IdRepartoDefault,"
							sql &= " ImgBig,"
							sql &= " ImgRif,"
							sql &= " MinutiAvv,"
							sql &= " Ordinamento,"
							sql &= " Tipo,"
							sql &= " VisibileOnline"
							sql &= ") VALUES ("
							sql &= " @AlertCommesse,"
							sql &= " @AltezzaCaricoCm,"
							sql &= " @CaricoPrevistoMensile,"
							sql &= " @CopieOra,"
							sql &= " @CostoMensile,"
							sql &= " @CostoMinAvv,"
							sql &= " @CostoSingCopia,"
							sql &= " @Descrizione,"
							sql &= " @DescrizioneEstesa,"
							sql &= " @DescrizioneOnline,"
							sql &= " @HotFolderFlusso,"
							sql &= " @IdRepartoDefault,"
							sql &= " @ImgBig,"
							sql &= " @ImgRif,"
							sql &= " @MinutiAvv,"
							sql &= " @Ordinamento,"
							sql &= " @Tipo,"
							sql &= " @VisibileOnline"
							sql &= ")"
						Else
							sql = "UPDATE T_macchinari SET "
							If cls.WhatIsChanged.AlertCommesse Then sql &= "AlertCommesse = @AlertCommesse,"
							If cls.WhatIsChanged.AltezzaCaricoCm Then sql &= "AltezzaCaricoCm = @AltezzaCaricoCm,"
							If cls.WhatIsChanged.CaricoPrevistoMensile Then sql &= "CaricoPrevistoMensile = @CaricoPrevistoMensile,"
							If cls.WhatIsChanged.CopieOra Then sql &= "CopieOra = @CopieOra,"
							If cls.WhatIsChanged.CostoMensile Then sql &= "CostoMensile = @CostoMensile,"
							If cls.WhatIsChanged.CostoMinAvv Then sql &= "CostoMinAvv = @CostoMinAvv,"
							If cls.WhatIsChanged.CostoSingCopia Then sql &= "CostoSingCopia = @CostoSingCopia,"
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.DescrizioneEstesa Then sql &= "DescrizioneEstesa = @DescrizioneEstesa,"
							If cls.WhatIsChanged.DescrizioneOnline Then sql &= "DescrizioneOnline = @DescrizioneOnline,"
							If cls.WhatIsChanged.HotFolderFlusso Then sql &= "HotFolderFlusso = @HotFolderFlusso,"
							If cls.WhatIsChanged.IdRepartoDefault Then sql &= "IdRepartoDefault = @IdRepartoDefault,"
							If cls.WhatIsChanged.ImgBig Then sql &= "ImgBig = @ImgBig,"
							If cls.WhatIsChanged.ImgRif Then sql &= "ImgRif = @ImgRif,"
							If cls.WhatIsChanged.MinutiAvv Then sql &= "MinutiAvv = @MinutiAvv,"
							If cls.WhatIsChanged.Ordinamento Then sql &= "Ordinamento = @Ordinamento,"
							If cls.WhatIsChanged.Tipo Then sql &= "Tipo = @Tipo,"
							If cls.WhatIsChanged.VisibileOnline Then sql &= "VisibileOnline = @VisibileOnline"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdMacchinario= " & cls.IdMacchinario
						End If
					
						Dim p As DbParameter = Nothing 
						If cls.WhatIsChanged.AlertCommesse Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AlertCommesse"
							p.Value = cls.AlertCommesse
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.AltezzaCaricoCm Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@AltezzaCaricoCm"
							p.Value = cls.AltezzaCaricoCm
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CaricoPrevistoMensile Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CaricoPrevistoMensile"
							p.Value = cls.CaricoPrevistoMensile
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CopieOra Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CopieOra"
							p.Value = cls.CopieOra
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoMensile Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoMensile"
							p.Value = cls.CostoMensile
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoMinAvv Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoMinAvv"
							p.Value = cls.CostoMinAvv
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.CostoSingCopia Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@CostoSingCopia"
							p.Value = cls.CostoSingCopia
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Descrizione Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Descrizione"
							p.Value = cls.Descrizione
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DescrizioneEstesa Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DescrizioneEstesa"
							p.Value = cls.DescrizioneEstesa
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.DescrizioneOnline Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@DescrizioneOnline"
							p.Value = cls.DescrizioneOnline
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.HotFolderFlusso Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@HotFolderFlusso"
							p.Value = cls.HotFolderFlusso
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.IdRepartoDefault Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@IdRepartoDefault"
							p.Value = cls.IdRepartoDefault
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgBig Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgBig"
							p.Value = cls.ImgBig
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.ImgRif Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@ImgRif"
							p.Value = cls.ImgRif
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.MinutiAvv Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@MinutiAvv"
							p.Value = cls.MinutiAvv
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Ordinamento Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Ordinamento"
							p.Value = cls.Ordinamento
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.Tipo Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@Tipo"
							p.Value = cls.Tipo
							myCommand.Parameters.Add(p)
						End If

						If cls.WhatIsChanged.VisibileOnline Then 
							p = myCommand.CreateParameter
							p.ParameterName = "@VisibileOnline"
							p.Value = cls.VisibileOnline
							myCommand.Parameters.Add(p)
						End If

						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdMacchinario=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdMacchinario = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdMacchinario
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdMacchinario
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
				'Dim Sql As String = "UPDATE T_macchinari SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_macchinari"
				Sql &= " WHERE IdMacchinario = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_macchinari. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_macchinari. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as MacchinarioW, Optional ByRef ListaObj as List (of MacchinarioW) = Nothing)
		DestroyPermanently (obj.IdMacchinario)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As MacchinarioW
		Dim ris As MacchinarioW = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of MacchinarioW) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return first of MacchinarioW
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As MacchinarioW
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return first of MacchinarioW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As MacchinarioW
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table MacchinarioW
	''' </summary>
	''' <returns>
	'''Return first of MacchinarioW
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As MacchinarioW
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return a list of MacchinarioW
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of MacchinarioW)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return a list of MacchinarioW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of MacchinarioW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return a list of MacchinarioW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of MacchinarioW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return a list of MacchinarioW
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of MacchinarioW)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return a list of MacchinarioW
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of MacchinarioW)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return a list of MacchinarioW
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of MacchinarioW)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_macchinari by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of MacchinarioW by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of MacchinarioW)
		Dim Ls As New List(Of MacchinarioW)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of MacchinarioW)
		Dim Ls As New List(Of MacchinarioW)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_macchinari" 
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
	'''Return all record on DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return all record in list of MacchinarioW
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of MacchinarioW)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return all record in list of MacchinarioW
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of MacchinarioW)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_macchinari
	''' </summary>
	''' <returns>
	'''Return all record in list of MacchinarioW
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of MacchinarioW)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of MacchinarioW)
		Dim Ls As List(Of MacchinarioW)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_macchinari" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of MacchinarioW)
		Dim Ls As New List(Of MacchinarioW)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  MacchinarioW() With {.IdMacchinario = 0 ,.AlertCommesse = 0 ,.AltezzaCaricoCm = 0 ,.CaricoPrevistoMensile = 0 ,.CopieOra = 0 ,.CostoMensile = 0 ,.CostoMinAvv = 0 ,.CostoSingCopia = 0 ,.Descrizione = EmptyItemDescription,.DescrizioneEstesa = "" ,.DescrizioneOnline = "" ,.HotFolderFlusso = "" ,.IdRepartoDefault = 0 ,.ImgBig = "" ,.ImgRif = "" ,.MinutiAvv = 0 ,.Ordinamento = 0 ,.Tipo = 0 ,.VisibileOnline = 0  })
					While myReader.Read
						Dim classe as new MacchinarioW(CType(myReader, IDataRecord))
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