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
    public partial class MainView :UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void TableView_ValidateCell(object sender,DevExpress.Xpf.Grid.GridCellValidationEventArgs e)
        {
            if(e.Column.FieldName.ToLower() == "identitycard")
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

        private void PART_Editor_SelectedIndexChanged(object sender,RoutedEventArgs e)
        {
            var t = (e.Source as DevExpress.Xpf.Editors.ComboBoxEdit).ItemsSource as System.Collections.ObjectModel.ObservableCollection<IdentityCardInfo>;
            var SelectedIndex = (e.Source as DevExpress.Xpf.Editors.ComboBoxEdit).SelectedIndex;
            //t.RemoveAt(SelectedIndex);
        }
    }
}
