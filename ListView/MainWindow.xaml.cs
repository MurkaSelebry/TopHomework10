using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyListView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        GridView gv = new GridView();
        GridView gv1 = new GridView();
        DataTemplate dtBig;
        DataTemplate dtSmall;
        ItemsPanelTemplate IPTTable;
        ItemsPanelTemplate IPTList;
        ItemsPanelTemplate IPTBig;
        ItemsPanelTemplate IPTSmall;

        public MainWindow()
        {
            InitializeComponent();
            AutoList.Items.Add(new AutoItem("Mazda", "CX5", @"images\mazda.jpg"));
            AutoList.Items.Add(new AutoItem("Mitsubishi", "Outlander", @"images\mit2.jpg"));
            AutoList.Items.Add(new AutoItem("Ferrari", "895", @"images\ferrari.jpg"));
            AutoList.Items.Add(new AutoItem("Mitsubishi", "Evolution IX", @"images\mit1.jpg"));
            
            CreateBig();
            CreateSmall();
            CreateList();
            CreateTableView();
            
            Height = 600;
            Width = 1000;
            
        }

        private void CreateTableView()
        {

            GridViewColumn columnBrand = new GridViewColumn();
            GridViewColumnHeader headerBrand = new GridViewColumnHeader();
            headerBrand.Content = "Марка";
            columnBrand.Header = headerBrand;
            columnBrand.DisplayMemberBinding = new Binding("Brand");

            GridViewColumn columnModel = new GridViewColumn();
            GridViewColumnHeader headerModel = new GridViewColumnHeader();
            headerModel.Content = "Модель";
            columnModel.Header = headerModel;
            columnModel.DisplayMemberBinding = new Binding("Model");

            GridViewColumn columnImage = new GridViewColumn();
            columnImage.Header = "Фото";

            DataTemplate dtCell = new DataTemplate();
            FrameworkElementFactory imageF = new FrameworkElementFactory(typeof(Image));
            imageF.SetValue(Image.SourceProperty, new Binding("Path"));
            imageF.SetValue(Image.WidthProperty, Width = 60);
            //imageF.SetValue(Image.HeightProperty, Height = 60);
            dtCell.VisualTree = imageF;
            columnImage.CellTemplate = dtCell;

            gv.Columns.Add(columnBrand);
            gv.Columns.Add(columnModel);
            gv.Columns.Add(columnImage);

            AutoList.View = gv;
            IPTTable = new ItemsPanelTemplate();
            FrameworkElementFactory WPFTable = new FrameworkElementFactory(typeof(StackPanel));
            WPFTable.SetValue(WrapPanel.OrientationProperty, Orientation.Vertical);
            IPTTable.VisualTree = WPFTable;
        }
        private void CreateList()
        {
            GridViewColumn columnBrand = new GridViewColumn();
            GridViewColumnHeader headerBrand = new GridViewColumnHeader();
            headerBrand.Content = "Марка";
            columnBrand.Header = headerBrand;
            columnBrand.DisplayMemberBinding = new Binding("Brand");

            GridViewColumn columnModel = new GridViewColumn();
            GridViewColumnHeader headerModel = new GridViewColumnHeader();
            headerModel.Content = "Модель";
            columnModel.Header = headerModel;
            columnModel.DisplayMemberBinding = new Binding("Model");

            

            DataTemplate dtCell = new DataTemplate();
      
            //imageF.SetValue(Image.HeightProperty, Height = 60);

            gv1.Columns.Add(columnBrand);
            gv1.Columns.Add(columnModel);

            AutoList.View = gv1;
            IPTList = new ItemsPanelTemplate();
            FrameworkElementFactory WPFList = new FrameworkElementFactory(typeof(StackPanel));
            WPFList.SetValue(WrapPanel.OrientationProperty, Orientation.Vertical);
            IPTList.VisualTree = WPFList;
        }
        private void CreateBig()
        {
            FrameworkElementFactory StackPanelF_Big = new FrameworkElementFactory(typeof(StackPanel));
            StackPanelF_Big.SetValue(StackPanel.BackgroundProperty, Background = new SolidColorBrush(Colors.Beige));

            FrameworkElementFactory ImageFB = new FrameworkElementFactory(typeof(Image));
            ImageFB.SetValue(Image.SourceProperty, new Binding("Path"));
            ImageFB.SetValue(Image.WidthProperty, Width = 200);
            StackPanelF_Big.AppendChild(ImageFB);

            FrameworkElementFactory LableF = new FrameworkElementFactory(typeof(Label));
            LableF.SetValue(Label.ContentProperty, new Binding("Model"));
            LableF.SetValue(Label.WidthProperty, Width = 100);
            StackPanelF_Big.AppendChild(LableF);

            FrameworkElementFactory LableC = new FrameworkElementFactory(typeof(Label));
            LableC.SetValue(Label.ContentProperty, new Binding("Brand"));
            LableC.SetValue(Label.WidthProperty, Width = 100);
            StackPanelF_Big.AppendChild(LableC);

            dtBig = new DataTemplate();

            dtBig.VisualTree = StackPanelF_Big;

            IPTBig = new ItemsPanelTemplate();


            FrameworkElementFactory WPF_Big = new FrameworkElementFactory(typeof(WrapPanel));
            WPF_Big.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);

            Binding B_W = new Binding("ActualWidth");
            B_W.Source = this.AutoList;
            WPF_Big.SetValue(WrapPanel.WidthProperty, B_W);

            Binding B_H = new Binding("ActualHeight");
            B_H.Source = this.AutoList;
            WPF_Big.SetValue(WrapPanel.HeightProperty, B_H);


            IPTBig.VisualTree = WPF_Big;
            

        }
        private void CreateSmall()
        {
            FrameworkElementFactory StackPanelF_Small = new FrameworkElementFactory(typeof(StackPanel));
            StackPanelF_Small.SetValue(StackPanel.BackgroundProperty, Background = new SolidColorBrush(Colors.Beige));

            FrameworkElementFactory ImageFB = new FrameworkElementFactory(typeof(Image));
            ImageFB.SetValue(Image.SourceProperty, new Binding("Path"));
            ImageFB.SetValue(Image.WidthProperty, Width = 100);
            StackPanelF_Small.AppendChild(ImageFB);

            FrameworkElementFactory LableF = new FrameworkElementFactory(typeof(Label));
            LableF.SetValue(Label.ContentProperty, new Binding("Model"));
            LableF.SetValue(Label.WidthProperty, Width = 100);
            StackPanelF_Small.AppendChild(LableF);

            FrameworkElementFactory LableC = new FrameworkElementFactory(typeof(Label));
            LableC.SetValue(Label.ContentProperty, new Binding("Brand"));
            LableC.SetValue(Label.WidthProperty, Width = 100);
            StackPanelF_Small.AppendChild(LableC);

            dtSmall = new DataTemplate();

            dtSmall.VisualTree = StackPanelF_Small;

            IPTSmall = new ItemsPanelTemplate();


            FrameworkElementFactory WPF_Small = new FrameworkElementFactory(typeof(WrapPanel));
            WPF_Small.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);

            Binding B_W = new Binding("ActualWidth");
            B_W.Source = this.AutoList;
            WPF_Small.SetValue(WrapPanel.WidthProperty, B_W);

            Binding B_H = new Binding("ActualHeight");
            B_H.Source = this.AutoList;
            WPF_Small.SetValue(WrapPanel.HeightProperty, B_H);


            IPTSmall.VisualTree = WPF_Small;

        }
        private void ViewType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (AutoList == null) throw new Exception();
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    AutoList.ItemsPanel = IPTTable;
                    AutoList.View = gv;
                    break;
                case 1:
                    AutoList.ItemTemplate = dtBig;
                    AutoList.ItemsPanel = IPTBig;
                    AutoList.View = null;
                    break;
                case 2:
                    AutoList.ItemTemplate = dtSmall;
                    AutoList.ItemsPanel = IPTSmall;
                    AutoList.View = null;
                    break;
                case 3:
                    AutoList.ItemsPanel = IPTList;
                    AutoList.View = gv1;
                    break;
                default:
                    break;
            }

        }
    }
}

