using DevExpress.Xpf.Layout.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WpfDemoForMultiSelectorTemplete.ViewModels;

namespace WpfDemoForMultiSelectorTemplete.Views
{
    /// <summary>
    /// Interaction logic for View1.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void TableView_ValidateCell(object sender, DevExpress.Xpf.Grid.GridCellValidationEventArgs e)
        {
            if (e.Column.FieldName.ToLower() == "identitycard")
            {

                //if(int.TryParse(e.Value?.ToString(),out int num) && ((PersonInfo)e.Row).VerifyLabwareNum == num)
                //{
                //    e.IsValid = true;
                //}
                //else
                //{
                //    e.IsValid = false;
                //    e.ErrorContent = $"The number of sample plates should be :{((PersonInfo)e.Row).VerifyLabwareNum}";

                //}
            }
        }
        public IEnumerable<T> FindChildren<T>(DependencyObject parent) where T : class
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);
            if (count > 0)
            {
                for (var i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);
                    var t = child as T;
                    if (t != null)
                        yield return t;

                    var children = FindChildren<T>(child);
                    foreach (var item in children)
                        yield return item;
                }
            }
        }
        private void PART_Editor_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            var t = (e.Source as DevExpress.Xpf.Editors.ComboBoxEdit).ItemsSource as System.Collections.ObjectModel.ObservableCollection<IdentityCardInfo>;
            var tx = (e.Source as DevExpress.Xpf.Editors.ComboBoxEdit).Parent;
            DependencyObject xx = sender as DevExpress.Xpf.Editors.ComboBoxEdit;
            var cx = VisualTreeHelper.GetParent(this);
            var k = FindChildren<DevExpress.Xpf.Grid.GridControl>(this);
            var tse = k?.FirstOrDefault().DataContext as MainViewModel;
            //switch (t[0].Addr)
            //{     case   "云南":tse.YN
            //    default:
            //}
            var SelectedIndex = (e.Source as DevExpress.Xpf.Editors.ComboBoxEdit).SelectedIndex;
            //t.RemoveAt(SelectedIndex);
            for (int i = 0; i < t.Count; i++)
            {
                if (i== SelectedIndex)
                {
                    t[SelectedIndex].IsEnable = false;
                }
                else
                {
                    t[SelectedIndex].IsEnable = true;
                }
            }
        }

        private void PART_Editor_CustomDisplayText(object sender, DevExpress.Xpf.Editors.CustomDisplayTextEventArgs e)
        {
            var t = (e.Source as DevExpress.Xpf.Editors.ComboBoxEdit).ItemsSource as System.Collections.ObjectModel.ObservableCollection<IdentityCardInfo>;
            var SelectedIndex = (e.Source as DevExpress.Xpf.Editors.ComboBoxEdit);
        }

        private void ComboBoxEditItem_MouseEnter(object sender, MouseEventArgs e)
        {

        }
    }
}
