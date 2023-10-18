#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 4.17.12.51 
'Author: Diego Lunadei
'Date: 29/12/2017 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table T_templmarkoff
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _TemplateMarketingOfferte
	Inherits LUNA.LunaBaseClassEntity
	Implements _ITemplateMarketingOfferte
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Public Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _ITemplateMarketingOfferte.FillFromDataRecord
		IdTmOff = myRecord("IdTmOff")
		IdFM = myRecord("IdFM")
		Mese = myRecord("Mese")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of TemplateMarketingOfferte)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(TemplateMarketingOfferteDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of TemplateMarketingOfferte))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdTmOff As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdFM As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Mese As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Public Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdTmOff = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdFM = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Mese = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdTmOff as integer  = 0 
	Public Overridable Property IdTmOff() as integer  Implements _ITemplateMarketingOfferte.IdTmOff
		Get
			Return _IdTmOff
		End Get
		Set (byval value as integer)
			If _IdTmOff <> value Then
				IsChanged = True
				WhatIsChanged.IdTmOff = True
				_IdTmOff = value
			End If
		End Set
	End property 

	Protected _IdFM as integer  = 0 
	Public Overridable Property IdFM() as integer  Implements _ITemplateMarketingOfferte.IdFM
		Get
			Return _IdFM
		End Get
		Set (byval value as integer)
			If _IdFM <> value Then
				IsChanged = True
				WhatIsChanged.IdFM = True
				_IdFM = value
			End If
		End Set
	End property 

	Protected _Mese as integer  = 0 
	Public Overridable Property Mese() as integer  Implements _ITemplateMarketingOfferte.Mese
		Get
			Return _Mese
		End Get
		Set (byval value as integer)
			If _Mese <> value Then
				IsChanged = True
				WhatIsChanged.Mese = True
				_Mese = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an TemplateMarketingOfferte from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As TemplateMarketingOfferte = Manager.Read(Id)
				_IdTmOff = int.IdTmOff
				_IdFM = int.IdFM
				_Mese = int.Mese
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method save an TemplateMarketingOfferte on DB.
	''' </summary>
	''' <returns>
	'''Return Id insert in DB if all ok, 0 if error
	''' </returns>
	Public Overridable Function Save() As Integer
		'Return the id Inserted
		Dim Ris As Integer = 0
		Try
			Using Manager
				Ris = Manager.Save(Me)
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
		End Try
		Return Ris
	End Function

	Protected Function InternalIsValid() As Boolean
		Dim Ris As Boolean = True

		Return Ris
	End Function

#End Region

#Region "Embedded Class"


#End Region

End Class 

''' <summary>
'''Interface for table T_templmarkoff
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _ITemplateMarketingOfferte

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdTmOff() as integer
	Property IdFM() as integer
	Property Mese() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class TemplateMarketingOfferte
		Public Shared ReadOnly Property IdTmOff As New LUNA.LunaFieldName("IdTmOff")
		Public Shared ReadOnly Property IdFM As New LUNA.LunaFieldName("IdFM")
		Public Shared ReadOnly Property Mese As New LUNA.LunaFieldName("Mese")
	End Class

End Class