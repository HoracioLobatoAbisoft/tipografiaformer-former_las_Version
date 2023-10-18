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
'''This class manage persistency on db of Corriere object
''' </summary>
''' <remarks>
'''
''' </remarks>

Public MustInherit Class _CorrieriDAO
	Inherits LUNA.LunaBaseClassDAO(Of Corriere)

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
	'''Read from DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return a Corriere object
	''' </returns>
	Public Overrides Function Read(Id as integer) as Corriere
		Dim cls as new Corriere

		Try
			Using myCommand As DbCommand = _cn.CreateCommand
				myCommand.CommandText = "SELECT * FROM T_corriere WHERE IdCorriere = " & Id
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
	'''Save on DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return ID insert in DB
	''' </returns>
	Public Overrides Function Save(byRef cls as Corriere) as Integer

		Dim Ris as integer=0 'in Ris return Insert Id

		If cls.IsValid Then
			If cls.IsChanged Then
				Using myCommand As DbCommand = _Cn.CreateCommand()
					Try
						Dim sql As String = String.Empty
						If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
						If cls.IdCorriere = 0 Then
							sql = "INSERT INTO T_corriere ("
							sql &= " Costo,"
							sql &= " Descrizione,"
							sql &= " Disattivo,"
							sql &= " DisponibileOnline,"
							sql &= " GGConsegna,"
							sql &= " KgLimite1,"
							sql &= " KgLimite2,"
							sql &= " KgLimite3,"
							sql &= " KgLimite4,"
							sql &= " KgLimite5,"
							sql &= " KgLimite6,"
							sql &= " KgLimite7,"
							sql &= " Label,"
							sql &= " NomeBreve,"
							sql &= " PathTrack,"
							sql &= " PercPortoAssegnato,"
							sql &= " PrevedeAccorpamento,"
							sql &= " TariffaLimite1,"
							sql &= " TariffaLimite2,"
							sql &= " TariffaLimite3,"
							sql &= " TariffaLimite4,"
							sql &= " TariffaLimite5,"
							sql &= " TariffaLimite6,"
							sql &= " TariffaLimite7,"
							sql &= " TestoMail,"
							sql &= " TipoCorriere"
							sql &= ") VALUES ("
							sql &= " @Costo,"
							sql &= " @Descrizione,"
							sql &= " @Disattivo,"
							sql &= " @DisponibileOnline,"
							sql &= " @GGConsegna,"
							sql &= " @KgLimite1,"
							sql &= " @KgLimite2,"
							sql &= " @KgLimite3,"
							sql &= " @KgLimite4,"
							sql &= " @KgLimite5,"
							sql &= " @KgLimite6,"
							sql &= " @KgLimite7,"
							sql &= " @Label,"
							sql &= " @NomeBreve,"
							sql &= " @PathTrack,"
							sql &= " @PercPortoAssegnato,"
							sql &= " @PrevedeAccorpamento,"
							sql &= " @TariffaLimite1,"
							sql &= " @TariffaLimite2,"
							sql &= " @TariffaLimite3,"
							sql &= " @TariffaLimite4,"
							sql &= " @TariffaLimite5,"
							sql &= " @TariffaLimite6,"
							sql &= " @TariffaLimite7,"
							sql &= " @TestoMail,"
							sql &= " @TipoCorriere"
							sql &= ")"
						Else
							sql = "UPDATE T_corriere SET "
							If cls.WhatIsChanged.Costo Then sql &= "Costo = @Costo,"
							If cls.WhatIsChanged.Descrizione Then sql &= "Descrizione = @Descrizione,"
							If cls.WhatIsChanged.Disattivo Then sql &= "Disattivo = @Disattivo,"
							If cls.WhatIsChanged.DisponibileOnline Then sql &= "DisponibileOnline = @DisponibileOnline,"
							If cls.WhatIsChanged.GGConsegna Then sql &= "GGConsegna = @GGConsegna,"
							If cls.WhatIsChanged.KgLimite1 Then sql &= "KgLimite1 = @KgLimite1,"
							If cls.WhatIsChanged.KgLimite2 Then sql &= "KgLimite2 = @KgLimite2,"
							If cls.WhatIsChanged.KgLimite3 Then sql &= "KgLimite3 = @KgLimite3,"
							If cls.WhatIsChanged.KgLimite4 Then sql &= "KgLimite4 = @KgLimite4,"
							If cls.WhatIsChanged.KgLimite5 Then sql &= "KgLimite5 = @KgLimite5,"
							If cls.WhatIsChanged.KgLimite6 Then sql &= "KgLimite6 = @KgLimite6,"
							If cls.WhatIsChanged.KgLimite7 Then sql &= "KgLimite7 = @KgLimite7,"
							If cls.WhatIsChanged.Label Then sql &= "Label = @Label,"
							If cls.WhatIsChanged.NomeBreve Then sql &= "NomeBreve = @NomeBreve,"
							If cls.WhatIsChanged.PathTrack Then sql &= "PathTrack = @PathTrack,"
							If cls.WhatIsChanged.PercPortoAssegnato Then sql &= "PercPortoAssegnato = @PercPortoAssegnato,"
							If cls.WhatIsChanged.PrevedeAccorpamento Then sql &= "PrevedeAccorpamento = @PrevedeAccorpamento,"
							If cls.WhatIsChanged.TariffaLimite1 Then sql &= "TariffaLimite1 = @TariffaLimite1,"
							If cls.WhatIsChanged.TariffaLimite2 Then sql &= "TariffaLimite2 = @TariffaLimite2,"
							If cls.WhatIsChanged.TariffaLimite3 Then sql &= "TariffaLimite3 = @TariffaLimite3,"
							If cls.WhatIsChanged.TariffaLimite4 Then sql &= "TariffaLimite4 = @TariffaLimite4,"
							If cls.WhatIsChanged.TariffaLimite5 Then sql &= "TariffaLimite5 = @TariffaLimite5,"
							If cls.WhatIsChanged.TariffaLimite6 Then sql &= "TariffaLimite6 = @TariffaLimite6,"
							If cls.WhatIsChanged.TariffaLimite7 Then sql &= "TariffaLimite7 = @TariffaLimite7,"
							If cls.WhatIsChanged.TestoMail Then sql &= "TestoMail = @TestoMail,"
							If cls.WhatIsChanged.TipoCorriere Then sql &= "TipoCorriere = @TipoCorriere"
							sql = sql.TrimEnd(",")
							sql &= " WHERE IdCorriere= " & cls.IdCorriere
						End If
					
						Dim p As DbParameter = Nothing 
						p = myCommand.CreateParameter
						p.ParameterName = "@Costo"
						p.Value = cls.Costo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Descrizione"
						p.Value = cls.Descrizione
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Disattivo"
						p.Value = cls.Disattivo
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@DisponibileOnline"
						p.Value = cls.DisponibileOnline
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@GGConsegna"
						p.Value = cls.GGConsegna
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@KgLimite1"
						p.Value = cls.KgLimite1
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@KgLimite2"
						p.Value = cls.KgLimite2
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@KgLimite3"
						p.Value = cls.KgLimite3
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@KgLimite4"
						p.Value = cls.KgLimite4
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@KgLimite5"
						p.Value = cls.KgLimite5
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@KgLimite6"
						p.Value = cls.KgLimite6
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@KgLimite7"
						p.Value = cls.KgLimite7
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@Label"
						p.Value = cls.Label
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@NomeBreve"
						p.Value = cls.NomeBreve
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PathTrack"
						p.Value = cls.PathTrack
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PercPortoAssegnato"
						p.Value = cls.PercPortoAssegnato
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@PrevedeAccorpamento"
						p.Value = cls.PrevedeAccorpamento
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TariffaLimite1"
						p.Value = cls.TariffaLimite1
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TariffaLimite2"
						p.Value = cls.TariffaLimite2
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TariffaLimite3"
						p.Value = cls.TariffaLimite3
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TariffaLimite4"
						p.Value = cls.TariffaLimite4
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TariffaLimite5"
						p.Value = cls.TariffaLimite5
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TariffaLimite6"
						p.Value = cls.TariffaLimite6
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TariffaLimite7"
						p.Value = cls.TariffaLimite7
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TestoMail"
						p.Value = cls.TestoMail
						myCommand.Parameters.Add(p)
						p = myCommand.CreateParameter
						p.ParameterName = "@TipoCorriere"
						p.Value = cls.TipoCorriere
						myCommand.Parameters.Add(p)
						myCommand.CommandType = CommandType.Text
						myCommand.CommandText = sql
						myCommand.ExecuteNonQuery()

		            
						If cls.IdCorriere=0 Then
							Dim IdInserito as integer = 0
							Sql = "select @@identity"
							myCommand.CommandText = Sql
							IdInserito = myCommand.ExecuteScalar()
							cls.IdCorriere = IdInserito
							Ris = IdInserito
						Else
							Ris  =  cls.IdCorriere
						End If
					Catch ex As Exception
						ManageError(ex)
					End Try
				End Using
			else
				Ris  =  cls.IdCorriere
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
				'Dim Sql As String = "UPDATE T_corriere SET DELETED=True "
				Dim Sql As String = "DELETE FROM T_corriere"
				Sql &= " WHERE IdCorriere = " & Id 
				myCommand.CommandText = Sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				myCommand.ExecuteNonQuery()
    		End Using
		Catch ex As Exception
			ManageError(ex)
		End Try
	End Sub

	''' <summary>
	'''Delete from DB table T_corriere. Accept id of object to delete.
	''' </summary>
	Public Overrides Sub Delete(Id as integer) 
		DestroyPermanently (Id)
	End Sub

	''' <summary>
	'''Delete from DB table T_corriere. Accept object to delete and optional a List to remove the object from.
	''' </summary>
	Public Overrides Sub Delete(byref obj as Corriere, Optional ByRef ListaObj as List (of Corriere) = Nothing)
		DestroyPermanently (obj.IdCorriere)
		If Not ListaObj Is Nothing Then ListaObj.Remove(obj)
 
	End Sub

	Private Function InternalFind(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Corriere
		Dim ris As Corriere = Nothing
		Dim So As New LUNA.LunaSearchOption With {.Top = 1, .OrderBy = OrderBy}
		Dim l As IEnumerable(Of Corriere) = FindReal(So, Parameter)
		If l.Count Then
			ris = l(0)
		End If
		Return ris
	End Function

	''' <summary>
	'''Find one on DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return first of Corriere
	''' </returns>
	Public Overrides Function Find(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Corriere
		Return InternalFind(String.Empty, Parameter)
	End Function

	''' <summary>
	'''Find one on DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return first of Corriere
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function Find(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Corriere
		Return InternalFind(OrderBy, Parameter)
	End Function
		
	''' <summary>
	'''Find one on DB table Corriere
	''' </summary>
	''' <returns>
	'''Return first of Corriere
	''' </returns>
	Public Overloads Function Find(ByVal OrderBy As LUNA.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As Corriere
		Return InternalFind(OrderBy.Name, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return a list of Corriere
	''' </returns>
	Public Overrides Function FindAll(ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Corriere)
		Dim So As New Luna.LunaSearchOption
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return a list of Corriere
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Corriere)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return a list of Corriere
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As String, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Corriere)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy}
		Return FindReal(So, Parameter)
	End Function
	
	''' <summary>
	'''Find on DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return a list of Corriere
	''' </returns>
	Public Overloads Function FindAll(ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Corriere)
		Dim So As New Luna.LunaSearchOption With {.OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return a list of Corriere
	''' </returns>
	Public Overloads Function FindAll(byVal Top as integer, ByVal OrderBy As Luna.LunaFieldName, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as IEnumerable(Of Corriere)
		Dim So As New Luna.LunaSearchOption With {.Top = Top, .OrderBy = OrderBy.Name}
		Return FindReal(So, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return a list of Corriere
	''' </returns>
	Public Overloads Function FindAll(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) As IEnumerable(Of Corriere)
		Return FindReal(SearchOption, Parameter)
	End Function

	''' <summary>
	'''Find on DB table T_corriere by custom query 
	''' </summary>
	''' <returns>
	'''Return a list of Corriere by custom query
	''' </returns>
	Public Function GetBySQL(SQlQuery As String, Optional AddEmptyItem As Boolean = False) As IEnumerable(Of Corriere)
		Dim Ls As New List(Of Corriere)
		Try
			Ls = GetData(SQlQuery, AddEmptyItem)
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ls
	End Function
		
	Private Function FindReal(ByVal SearchOption As LUNA.LunaSearchOption, ByVal ParamArray Parameter() As LUNA.LunaSearchParameter) as iEnumerable(Of Corriere)
		Dim Ls As New List(Of Corriere)
		Try
			Dim sql As String = ""
			sql ="SELECT "   
			If SearchOption.Top Then sql &= " TOP " & SearchOption.Top
			If SearchOption.Distinct Then sql &= " DISTINCT "
			sql &=" * FROM T_corriere" 
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
	'''Return all record on DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return all record in list of Corriere
	''' </returns>
	Public Overloads Function GetAll() As IEnumerable(Of Corriere)
		Return InternalGetAll()
	End Function

	''' <summary>
	'''Return all record on DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return all record in list of Corriere
	''' </returns>
	Public Overloads Function GetAll(Optional OrderByField As LUNA.LunaFieldName = Nothing, Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Corriere)
		Return InternalGetAll(IIf(Not OrderByField Is Nothing, OrderByField.Name, String.Empty), AddEmptyItem)
	End Function

	''' <summary>
	'''Return all record on DB table T_corriere
	''' </summary>
	''' <returns>
	'''Return all record in list of Corriere
	''' </returns>
	<Obsolete("Use Instead Constructor with LFM field definition")>
	Public Overrides Function GetAll(Optional OrderByField As String = "",Optional ByVal AddEmptyItem As Boolean = False) As IEnumerable(Of Corriere)
		Return InternalGetAll(OrderByField, AddEmptyItem)
	End Function

	Private Function InternalGetAll(Optional OrderByField as string = "", Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Corriere)
		Dim Ls As List(Of Corriere)
		Try
			Dim sql As String = ""
			sql ="SELECT * FROM T_corriere" 
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

	Protected Function GetData(sql as string, Optional ByVal AddEmptyItem As Boolean = False) as iEnumerable(Of Corriere)
		Dim Ls As New List(Of Corriere)
		Try
			Using myCommand As DbCommand = _Cn.CreateCommand
				myCommand.CommandText = sql
				If Not LUNA.LunaContext.TransactionBox Is Nothing Then myCommand.Transaction = LUNA.LunaContext.TransactionBox.Transaction
				Using myReader As DbDataReader = myCommand.ExecuteReader()
					If AddEmptyItem Then Ls.Add(New  Corriere() With {.IdCorriere = 0 ,.Costo = 0 ,.Descrizione = EmptyItemDescription,.Disattivo = 0 ,.DisponibileOnline = False ,.GGConsegna = 0 ,.KgLimite1 = 0 ,.KgLimite2 = 0 ,.KgLimite3 = 0 ,.KgLimite4 = 0 ,.KgLimite5 = 0 ,.KgLimite6 = 0 ,.KgLimite7 = 0 ,.Label = "" ,.NomeBreve = "" ,.PathTrack = "" ,.PercPortoAssegnato = 0 ,.PrevedeAccorpamento = False ,.TariffaLimite1 = 0 ,.TariffaLimite2 = 0 ,.TariffaLimite3 = 0 ,.TariffaLimite4 = 0 ,.TariffaLimite5 = 0 ,.TariffaLimite6 = 0 ,.TariffaLimite7 = 0 ,.TestoMail = "" ,.TipoCorriere = 0  })
					While myReader.Read
						Dim classe as new Corriere(CType(myReader, IDataRecord))
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