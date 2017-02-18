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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for UnosEtikete.xaml
    /// </summary>
    public partial class UnosEtikete : Window, INotifyPropertyChanged
    {
        public List<Brush> ColorsList { get; set; }
        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[1]);
            if (focusedControl is DependencyObject)
            {
                
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                Console.WriteLine("--> " + str);
                if (str == "er")
                {
                    
                    
                        HelpProvider.ShowHelp("etiketa", this.mainWindow);
                    

                }
                else
                {
                    HelpProvider.ShowHelp(str, this.mainWindow);
                }
            }

        }
        public static readonly RoutedCommand Escape = new RoutedUICommand("Options", "OptionsCommand", typeof(UnosEtikete), new InputGestureCollection(new InputGesture[]
        {
            new KeyGesture(Key.Escape)
        }));

        private void CommandBinding_CanExecute_10(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_10(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
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
        public UnosEtikete(MainWindow mw)
        {
            InitializeComponent();
            this.mainWindow = mw;
            listaEtiketa = mainWindow.etikete;
            this.DataContext = this;
            idEtikete.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            p = 0;
            for (int k = 0; k < listaEtiketa.Count; k++)
            {
                if (idEtikete.Text == listaEtiketa.ElementAt(k).id)
                {
                    p = 1;
                }
            }
            if (idEtikete.Text == "")
            {
                GreskaID = "Morate uneti ID!";
                GreskaBoja = "";
            }
            else if (p == 1 && Q == 1)
            {
                GreskaID = "Postojeci ID!";
                GreskaBoja = "";
            }
            else if (bojaEtikete.SelectedColor == null)
            {
                GreskaID = "";
                GreskaBoja = "Morate uneti boju!";
            }
            else
            {
                Color c = (Color)ColorConverter.ConvertFromString(bojaEtikete.SelectedColorText);
                //SolidColorBrush cb = new SolidColorBrush(c);
                Etiketa etiketa = new Etiketa();
                etiketa.id = idEtikete.Text;
                etiketa.opis = opisEtikete.Text;
                etiketa.color = (Color)bojaEtikete.SelectedColor;
                //etiketa.imeBoje = new ColorConverter().ConvertToString(c);
                etiketa.imeBoje = c.ToString();

                Console.WriteLine(etiketa.imeBoje);

                //etiketaZaDodavanje = new Etiketa();
                //etiketaZaDodavanje = etiketa;
                mainWindow.etikete.Add(etiketa);
                mainWindow.MemorisiEtikete();
                Exit1 = 2;
                this.Close();
            }
            
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Exit = 0;
            string msg = "Are you sure?";
            MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "Etiketa",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                // If user doesn't want to close, cancel closure
                e.Cancel = true;
            }
            if (result == MessageBoxResult.Yes)
            {
               
                Exit = 1;
            }
        }

     

        
        }

        
        
        
        






        
    }

