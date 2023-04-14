Imports DevExpress.Data
Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace TreeList_DataBinding

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.treeListView1.ExpandAllNodes()
        End Sub
    End Class

    Public Class ViewModel
        Inherits ViewModelBase

        Public Property SummaryList As ObservableCollection(Of SummaryTask)
            Get
                Return GetProperty(Function() Me.SummaryList)
            End Get

            Set(ByVal value As ObservableCollection(Of SummaryTask))
                SetProperty(Function() SummaryList, value)
            End Set
        End Property

        Public Property SourceList As ObservableCollection(Of Employee)
            Get
                Return GetProperty(Function() Me.SourceList)
            End Get

            Set(ByVal value As ObservableCollection(Of Employee))
                SetProperty(Function() SourceList, value)
            End Set
        End Property

        Public Sub New()
            SourceList = GetStaff()
            SummaryList = New ObservableCollection(Of SummaryTask)()
            SummaryList.Add(New SummaryTask() With {.FieldName = "Statistics", .Type = SummaryItemType.Max})
            SummaryList.Add(New SummaryTask() With {.FieldName = "Statistics", .Type = SummaryItemType.Average})
            SummaryList.Add(New SummaryTask() With {.FieldName = "Department", .Type = SummaryItemType.Count})
        End Sub
    End Class

    Public Class SummaryTask

        Public Property FieldName As String

        Public Property Type As SummaryItemType
    End Class
End Namespace
