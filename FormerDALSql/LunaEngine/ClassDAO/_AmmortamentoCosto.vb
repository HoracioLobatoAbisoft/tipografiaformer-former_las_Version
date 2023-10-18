#Region "Author"
'*********************************
'LUNA ORM -	http://www.lunaorm.org
'*********************************
'Code created with Luna 5.19.11.8 
'Author: Diego Lunadei
'Date: 19/12/2019 
#End Region


Imports System.Xml.Serialization

''' <summary>
'''DAO Class for table Ammortamentocosti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public MustInherit Class _AmmortamentoCosto
	Inherits LUNA.LunaBaseClassEntity
	Implements _IAmmortamentoCosto
	'******IMPORTANT: Don't write your code here. Write your code in the Class object that inherits from this Class.
	'******So you can replace this file without lost your code

	Public Sub New()

	End Sub

	Public Sub New(myRecord As IDataRecord)
		FillFromDataRecord(myRecord)
	End Sub

	Friend Overridable Sub FillFromDataRecord(myRecord As IDataRecord) Implements _IAmmortamentoCosto.FillFromDataRecord
		IdAmmCosto = myRecord("IdAmmCosto")
		Anni = myRecord("Anni")
		AnnoEnd = myRecord("AnnoEnd")
		AnnoStart = myRecord("AnnoStart")
		if not myRecord("IdAzienda") is DBNull.Value then IdAzienda = myRecord("IdAzienda")
		IdCosto = myRecord("IdCosto")
		ImportoAnnuo = myRecord("ImportoAnnuo")
		ImportoTotale = myRecord("ImportoTotale")
		PercTotale = myRecord("PercTotale")
   
		ResetIsChanged()
	End Sub

	Private Property Manager As LUNA.ILunaBaseClassDAO(Of AmmortamentoCosto)
		Get
			If _Mgr Is Nothing Then
				Dim _MgrType As System.Type = LUNA.LunaContext.GetMgrTypeForEntity(Me.GetType)
				If _MgrType Is Nothing Then _MgrType = GetType(AmmortamentoCostiDAO)
				_Mgr = Activator.CreateInstance(_MgrType)
			End If
			Return _Mgr
		End Get
		Set(value As LUNA.ILunaBaseClassDAO(Of AmmortamentoCosto))
			_Mgr = value
		End Set
	End Property

#Region "Database Field Map"

	Public Class WhatIsChanged

		Public Shared Property IdAmmCosto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property Anni As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AnnoEnd As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property AnnoStart As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdAzienda As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property IdCosto As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImportoAnnuo As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property ImportoTotale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 
		Public Shared Property PercTotale As Boolean = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Class

	Private Sub ResetIsChanged()

		IsChanged = False
		WhatIsChanged.IdAmmCosto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.Anni = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AnnoEnd = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.AnnoStart = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdAzienda = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.IdCosto = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImportoAnnuo = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.ImportoTotale = LUNA.LunaContext.WriteAllFieldEveryTime 
		WhatIsChanged.PercTotale = LUNA.LunaContext.WriteAllFieldEveryTime 

	End Sub

	Protected _IdAmmCosto as integer  = 0 
	Public Overridable Property IdAmmCosto() as integer  Implements _IAmmortamentoCosto.IdAmmCosto
		Get
			Return _IdAmmCosto
		End Get
		Set (byval value as integer)
			If _IdAmmCosto <> value Then
				IsChanged = True
				WhatIsChanged.IdAmmCosto = True
				_IdAmmCosto = value
			End If
		End Set
	End property 

	Protected _Anni as integer  = 0 
	Public Overridable Property Anni() as integer  Implements _IAmmortamentoCosto.Anni
		Get
			Return _Anni
		End Get
		Set (byval value as integer)
			If _Anni <> value Then
				IsChanged = True
				WhatIsChanged.Anni = True
				_Anni = value
			End If
		End Set
	End property 

	Protected _AnnoEnd as integer  = 0 
	Public Overridable Property AnnoEnd() as integer  Implements _IAmmortamentoCosto.AnnoEnd
		Get
			Return _AnnoEnd
		End Get
		Set (byval value as integer)
			If _AnnoEnd <> value Then
				IsChanged = True
				WhatIsChanged.AnnoEnd = True
				_AnnoEnd = value
			End If
		End Set
	End property 

	Protected _AnnoStart as integer  = 0 
	Public Overridable Property AnnoStart() as integer  Implements _IAmmortamentoCosto.AnnoStart
		Get
			Return _AnnoStart
		End Get
		Set (byval value as integer)
			If _AnnoStart <> value Then
				IsChanged = True
				WhatIsChanged.AnnoStart = True
				_AnnoStart = value
			End If
		End Set
	End property 

	Protected _IdAzienda as integer  = 0 
	Public Overridable Property IdAzienda() as integer  Implements _IAmmortamentoCosto.IdAzienda
		Get
			Return _IdAzienda
		End Get
		Set (byval value as integer)
			If _IdAzienda <> value Then
				IsChanged = True
				WhatIsChanged.IdAzienda = True
				_IdAzienda = value
			End If
		End Set
	End property 

	Protected _IdCosto as integer  = 0 
	Public Overridable Property IdCosto() as integer  Implements _IAmmortamentoCosto.IdCosto
		Get
			Return _IdCosto
		End Get
		Set (byval value as integer)
			If _IdCosto <> value Then
				IsChanged = True
				WhatIsChanged.IdCosto = True
				_IdCosto = value
			End If
		End Set
	End property 

	Protected _ImportoAnnuo as decimal  = 0 
	Public Overridable Property ImportoAnnuo() as decimal  Implements _IAmmortamentoCosto.ImportoAnnuo
		Get
			Return _ImportoAnnuo
		End Get
		Set (byval value as decimal)
			If _ImportoAnnuo <> value Then
				IsChanged = True
				WhatIsChanged.ImportoAnnuo = True
				_ImportoAnnuo = value
			End If
		End Set
	End property 

	Protected _ImportoTotale as decimal  = 0 
	Public Overridable Property ImportoTotale() as decimal  Implements _IAmmortamentoCosto.ImportoTotale
		Get
			Return _ImportoTotale
		End Get
		Set (byval value as decimal)
			If _ImportoTotale <> value Then
				IsChanged = True
				WhatIsChanged.ImportoTotale = True
				_ImportoTotale = value
			End If
		End Set
	End property 

	Protected _PercTotale as integer  = 0 
	Public Overridable Property PercTotale() as integer  Implements _IAmmortamentoCosto.PercTotale
		Get
			Return _PercTotale
		End Get
		Set (byval value as integer)
			If _PercTotale <> value Then
				IsChanged = True
				WhatIsChanged.PercTotale = True
				_PercTotale = value
			End If
		End Set
	End property 


#End Region

#Region "Method"
	''' <summary>
	'''This method read an AmmortamentoCosto from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
	Public Overridable Function Read(Id As Integer) As Integer
		'Return 0 if all ok
		Dim Ris As Integer = 0
		Try
			Using Manager
				Dim int As AmmortamentoCosto = Manager.Read(Id)
				_IdAmmCosto = int.IdAmmCosto
				_Anni = int.Anni
				_AnnoEnd = int.AnnoEnd
				_AnnoStart = int.AnnoStart
				_IdAzienda = int.IdAzienda
				_IdCosto = int.IdCosto
				_ImportoAnnuo = int.ImportoAnnuo
				_ImportoTotale = int.ImportoTotale
				_PercTotale = int.PercTotale
			End Using
			Manager = nothing
		Catch ex As Exception
			ManageError(ex)
			Ris = 1
		End Try
		Return Ris
	End Function

	''' <summary>
	'''This method Refresh all data in the entity from DB.
	''' </summary>
	''' <returns>
	'''Return 0 if all ok, 1 if error
	''' </returns>
    Public Function Refresh() As Integer
        Dim ris As Integer = 0
        If IdAmmCosto Then
            ris = Read(IdAmmCosto)
        End If
        Return ris
    End Function	
	
	''' <summary>
	'''This method save an AmmortamentoCosto on DB.
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
'''Interface for table Ammortamentocosti
''' </summary>
''' <remarks>
'''Don't write code here
''' </remarks>

Public Interface _IAmmortamentoCosto

	Sub FillFromDataRecord(myRecord As IDataRecord)

#Region "Database Field Map"

	Property IdAmmCosto() as integer
	Property Anni() as integer
	Property AnnoEnd() as integer
	Property AnnoStart() as integer
	Property IdAzienda() as integer
	Property IdCosto() as integer
	Property ImportoAnnuo() as decimal
	Property ImportoTotale() as decimal
	Property PercTotale() as integer

#End Region

End Interface

Partial Public Class LFM

	Public Class AmmortamentoCosto
		Public Shared ReadOnly Property IdAmmCosto As New LUNA.LunaFieldName("IdAmmCosto")
		Public Shared ReadOnly Property Anni As New LUNA.LunaFieldName("Anni")
		Public Shared ReadOnly Property AnnoEnd As New LUNA.LunaFieldName("AnnoEnd")
		Public Shared ReadOnly Property AnnoStart As New LUNA.LunaFieldName("AnnoStart")
		Public Shared ReadOnly Property IdAzienda As New LUNA.LunaFieldName("IdAzienda")
		Public Shared ReadOnly Property IdCosto As New LUNA.LunaFieldName("IdCosto")
		Public Shared ReadOnly Property ImportoAnnuo As New LUNA.LunaFieldName("ImportoAnnuo")
		Public Shared ReadOnly Property ImportoTotale As New LUNA.LunaFieldName("ImportoTotale")
		Public Shared ReadOnly Property PercTotale As New LUNA.LunaFieldName("PercTotale")
	End Class

End Class