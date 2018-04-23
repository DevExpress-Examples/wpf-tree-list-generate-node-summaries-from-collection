Imports DevExpress.Data
Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Grid
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace TreeList_DataBinding
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()

			InitializeComponent()
			treeListView1.ExpandAllNodes()
		End Sub
	End Class

	Public Class ViewModel
		Inherits ViewModelBase

		Public Property SummaryList() As ObservableCollection(Of SummaryTask)
			Get
				Return GetProperty(Function() SummaryList)
			End Get
			Set(ByVal value As ObservableCollection(Of SummaryTask))
				SetProperty(Function() SummaryList, value)
			End Set
		End Property

		Public Property SourceList() As ObservableCollection(Of Employee)
			Get
				Return GetProperty(Function() SourceList)
			End Get
			Set(ByVal value As ObservableCollection(Of Employee))
				SetProperty(Function() SourceList, value)
			End Set
		End Property



		Public Sub New()
			SourceList = Stuff.GetStuff()
			SummaryList = New ObservableCollection(Of SummaryTask)()

			SummaryList.Add(New SummaryTask() With {.FieldName = "Statistics", .Type = SummaryItemType.Max})
			SummaryList.Add(New SummaryTask() With {.FieldName = "Statistics", .Type = SummaryItemType.Average})
			SummaryList.Add(New SummaryTask() With {.FieldName = "Department", .Type = SummaryItemType.Count})
		End Sub
	End Class

	Public Class SummaryTask
		Public Property FieldName() As String
		Public Property Type() As SummaryItemType
	End Class
End Namespace
