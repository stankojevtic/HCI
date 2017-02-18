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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WpfApplication1.Izmena
{
    /// <summary>
    /// Interaction logic for IzmenaEtiketa.xaml
    /// </summary>
    public partial class IzmenaEtiketa : Window, INotifyPropertyChanged
    {
        public List<Brush> ColorsList { get; set; }

        public Brush SelectedColor { get; set; }
        public MainWindow mainWindow;
        private ObservableCollection<Colors> listaBoja
        {
            get;
            set;
        }
        private ObservableCollection<Etiketa> listaEtiketa
        {
            get;
            set;
        }
        private string _test1;
        private List<string> Test4
        {
            get;
            set;
        }
        public string Test1
        {
            get
            {
                return _test1;
            }
            set
            {
                if (value != _test1)
                {
                    _test1 = value;
                    OnPropertyChanged("Test1");
                }
            }
        }
        private string _greskaID;
        public string GreskaID
        {
            get
            {
                return _greskaID;
            }
            set
            {
                if (value != _greskaID)
                {
                    _greskaID = value;
                    OnPropertyChanged("GreskaID");
                }
            }
        }
        private string _greskaBoja;
        public string GreskaBoja
        {
            get
            {
                return _greskaBoja;
            }
            set
            {
                if (value != _greskaBoja)
                {
                    _greskaBoja = value;
                    OnPropertyChanged("GreskaBoja");
                }
            }
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public Etiketa etiketaZaDodavanje;
        public int Exit = 0;
        public int Exit1 = 0;
        public int p = 0;
        public int Q = 1;
        public event PropertyChangedEventHandler PropertyChanged;
        public Etiketa ETIKETA;
        public IzmenaEtiketa(MainWindow mw,Etiketa etiketa)
        {
            InitializeComponent();
            this.mainWindow = mw;
            this.ETIKETA = etiketa;
            listaEtiketa = mainWindow.etikete;
            this.DataContext = this;
            listaEtiketa = mainWindow.etikete;
            idEtikete.Text = etiketa.id;
            idEtikete.IsEnabled = false;
            opisEtikete.Text = etiketa.opis;
            Color c = (Color)ColorConverter.ConvertFromString(etiketa.imeBoje);
            bojaEtikete.SelectedColor = c;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (bojaEtikete.SelectedColor == null)
            {
                GreskaID = "";
                GreskaBoja = "Morate uneti boju!";
            }
            else
            {
                Color c = (Color)ColorConverter.ConvertFromString(bojaEtikete.SelectedColorText);
                ETIKETA.id = idEtikete.Text;
                ETIKETA.opis = opisEtikete.Text;
                ETIKETA.color = (Color)bojaEtikete.SelectedColor;              
                ETIKETA.imeBoje = c.ToString();
                mainWindow.MemorisiEtikete();
                this.Close();
            }
            
        }
    }
}
