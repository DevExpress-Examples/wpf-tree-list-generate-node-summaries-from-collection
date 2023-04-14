using DevExpress.Data;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;

namespace TreeList_DataBinding {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            treeListView1.ExpandAllNodes();
        }
    }

    public class ViewModel : ViewModelBase {
        public ObservableCollection<SummaryTask> SummaryList {
            get { return GetProperty(() => SummaryList); }
            set { SetProperty(() => SummaryList, value); }
        }

        public ObservableCollection<Employee> SourceList {
            get { return GetProperty(() => SourceList); }
            set { SetProperty(() => SourceList, value); }
        }

        public ViewModel() {
            SourceList = Staff.GetStaff();
            SummaryList = new ObservableCollection<SummaryTask>();

            SummaryList.Add(new SummaryTask() { FieldName = "Statistics", Type = SummaryItemType.Max });
            SummaryList.Add(new SummaryTask() { FieldName = "Statistics", Type = SummaryItemType.Average });
            SummaryList.Add(new SummaryTask() { FieldName = "Department", Type = SummaryItemType.Count });
        }
    }

    public class SummaryTask {
        public string FieldName { get; set; }
        public SummaryItemType Type { get; set; }
    }
}
