using DevExpress.Mvvm;
using DevExpress.Xpf.Grid;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfDemoForMultiSelectorTemplete.ViewModels
{
    public class IsCollectionNotEmptyToBoolConverter :IValueConverter
    {
        public object Convert(object value,Type targetType,object parameter,CultureInfo culture)
        {
            return true;
        }

        public object ConvertBack(object value,Type targetType,object parameter,CultureInfo culture)
        {
            return null;
        }
    }
    public class TemplateList :List<DataTemplate>
    {
    }
    public class ProcessNameValueDataTemplateSelector :DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item,DependencyObject container)
        {

            var k = (item as DevExpress.Xpf.Grid.EditGridCellData)?.Row as PersonInfo;
            var num = k?.Addr.ToString();

            var tem = Templates.FirstOrDefault(t => t.DataType.ToString() == num);
            //var kx = tem.Template as DevExpress.Xpf.Editors.ComboBoxEdit;
            return tem;
        }
        public TemplateList Templates { get; set; }
    }
    public class MainViewModel :ViewModelBase
    {
        private ObservableCollection<PersonInfo> personInfo;

        public ObservableCollection<PersonInfo> PersonInfo
        {
            get { return personInfo; }
            set => SetProperty(ref personInfo,value,"PersonInfo");
        }
        private ObservableCollection<IdentityCardInfo> yn;

        public ObservableCollection<IdentityCardInfo> YN
        {
            get { return yn; }
            set => SetProperty(ref yn,value,"YN");
        }
        private ObservableCollection<IdentityCardInfo> bj;

        public ObservableCollection<IdentityCardInfo> BJ
        {
            get { return bj; }
            set => SetProperty(ref bj,value,"BJ");
        }
        private ObservableCollection<IdentityCardInfo> hn;

        public ObservableCollection<IdentityCardInfo> HN
        {
            get { return hn; }
            set => SetProperty(ref hn,value,"HN");
        }
        public DelegateCommand<CellValueChangedEventArgs> LmisProcesValueChangedCommand { set; get; }
        public MainViewModel()
        {
            LmisProcesValueChangedCommand = new DelegateCommand<CellValueChangedEventArgs>(OnLmValueChanged);
            PersonInfo = new ObservableCollection<PersonInfo>();
            PersonInfo.Add(new ViewModels.PersonInfo()
            {
                Addr = "北京",
                Age = 12,
                Name = "王松"
            });
            PersonInfo.Add(new ViewModels.PersonInfo()
            {
                Addr = "北京",
                Age = 12,
                Name = "王松"
            });
            PersonInfo.Add(new ViewModels.PersonInfo()
            {
                Addr = "云南",
                Age = 22,
                IdentityCard = "002001",
                Name = "刘强"
            });
            PersonInfo.Add(new ViewModels.PersonInfo()
            {
                Addr = "湖南",
                Age = 42,
                IdentityCard = "003001",
                Name = "王陶"
            });
            YN = new ObservableCollection<IdentityCardInfo>
            {
                new IdentityCardInfo
                {
                     Addr="云南",
                    IdentityCard = "002001",
                } ,
                  new IdentityCardInfo
                {
                     Addr="云南",
                    IdentityCard = "002002",
                } ,
                   new IdentityCardInfo
                {
                     Addr="云南",
                    IdentityCard = "002003",
                } ,
            };
            BJ = new ObservableCollection<IdentityCardInfo>
            {
                new IdentityCardInfo
                {
                     Addr="北京",
                    IdentityCard = "001001",
                } ,
                  new IdentityCardInfo
                {
                     Addr="北京",
                    IdentityCard = "001002",
                } ,
                   new IdentityCardInfo
                {
                     Addr="北京",
                    IdentityCard = "001003",
                } ,
            };
            HN = new ObservableCollection<IdentityCardInfo>
            {
                new IdentityCardInfo
                {
                     Addr="湖南",
                    IdentityCard = "003001",
                } ,
                  new IdentityCardInfo
                {
                     Addr="湖南",
                    IdentityCard = "003002",
                } ,
                   new IdentityCardInfo
                {
                     Addr="湖南",
                    IdentityCard = "003003",
                } ,
            };

        }

        private void OnLmValueChanged(CellValueChangedEventArgs obj)
        {

        }
    }
    public class PersonInfo :BindableBase
    {
        private string name;

        public string Name
        {
            get { return name; }
            set => SetProperty(ref name,value,"Name");
        }

        private int age;

        public int Age
        {
            get { return age; }
            set => SetProperty(ref age,value,"Age");
        }
        private string addr;

        public string Addr
        {
            get { return addr; }
            set => SetProperty(ref addr,value,"Addr");
        }
        private string identityCard;

        public string IdentityCard
        {
            get { return identityCard; }
            set => SetProperty(ref identityCard,value,"IdentityCard");
        }


    }
    public class IdentityCardInfo
    {
        public string Addr { get; set; }
        public string IdentityCard { get; set; }
    }
}