Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Core
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace GroupFootersWPF
	Partial Public Class MainWindow
		Inherits DXWindow
		Public Sub New()
			InitializeComponent()
			Dim list As New List(Of TestData)()
			For i As Integer = 0 To 199
				list.Add(New TestData() With {.Text = "Text0 Row" & i, .Number0 = i, .Number1 = 100 - i, .Number2 = i Mod 10, .Group = i Mod 10})
			Next i
			DataContext = list
		End Sub
	End Class

	Public Class TestData
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
		Private privateNumber0 As Integer
		Public Property Number0() As Integer
			Get
				Return privateNumber0
			End Get
			Set(ByVal value As Integer)
				privateNumber0 = value
			End Set
		End Property
		Private privateNumber1 As Integer
		Public Property Number1() As Integer
			Get
				Return privateNumber1
			End Get
			Set(ByVal value As Integer)
				privateNumber1 = value
			End Set
		End Property
		Private privateNumber2 As Integer
		Public Property Number2() As Integer
			Get
				Return privateNumber2
			End Get
			Set(ByVal value As Integer)
				privateNumber2 = value
			End Set
		End Property
		Private privateGroup As Integer
		Public Property Group() As Integer
			Get
				Return privateGroup
			End Get
			Set(ByVal value As Integer)
				privateGroup = value
			End Set
		End Property
	End Class
End Namespace