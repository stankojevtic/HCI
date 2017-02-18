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
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[1]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                if (str == "er")
                {
                    if (TagComboBox.SelectedItem != null)
                    {
                        HelpProvider.ShowHelp("s", this.mainWindow);
                    }
                    else
                    {
                        HelpProvider.ShowHelp("man", this.mainWindow);
                    }
                        
                }
                else
                {
                   HelpProvider.ShowHelp(str, this.mainWindow);
                }
            }
           
        }
        public static readonly RoutedCommand Escape = new RoutedUICommand("Options", "OptionsCommand", typeof(Window1), new InputGestureCollection(new InputGesture[]
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
        public void doThings(string param)
        {
            // btnOK.Background = new SolidColorBrush(Color.FromRgb(32, 64, 128));
            Title = param;
        }
      
        private Etiketa _pomocnaEtiketa;
        private String _greskaID;
        public String GreskaID
        {
            get
            {
                return _greskaID;
            }
            set
            {
                if (_greskaID != value)
                {
                    _greskaID = value;
                    OnPropertyChanged("GreskaID");
                }
            }
        }
        public ObservableCollection<string> Names { get; set; }
        private String _greskaIkonica;
        public String GreskaIkonica
        {
            get
            {
                return _greskaIkonica;
            }
            set
            {
                if (_greskaIkonica != value)
                {
                    _greskaIkonica = value;
                    OnPropertyChanged("GreskaIkonica");
                }
            }
        }
        private String _greskaNaziv;
        public String GreskaNaziv
        {
            get
            {
                return _greskaNaziv;
            }
            set
            {
                if (_greskaNaziv != value)
                {
                    _greskaNaziv = value;
                    OnPropertyChanged("GreskaNaziv");
                }
            }
        }
        private String _greskaDatum;
        public String GreskaDatum
        {
            get
            {
                return _greskaDatum;
            }
            set
            {
                if (_greskaDatum != value)
                {
                    _greskaDatum = value;
                    OnPropertyChanged("GreskaDatum");
                }
            }
        }
        public TextCompositionAutoComplete autoComplete { get; set; }
        private Etiketa _selektovanaEtiketa;
        public Etiketa SelektovanaEtiketa
        {
            get
            {
                return _selektovanaEtiketa;
            }
            set
            {
                if (_selektovanaEtiketa != value)
                {
                    _selektovanaEtiketa = value;
                    OnPropertyChanged("SelektovanaEtiketa");
                }
            }
        }
        private Etiketa _selektovanaEtiketa1;
        public Etiketa SelektovanaEtiketa1
        {
            get
            {
                return _selektovanaEtiketa1;
            }
            set
            {
                if (_selektovanaEtiketa1 != value)
                {
                    _selektovanaEtiketa1 = value;
                    OnPropertyChanged("SelektovanaEtiketa1");
                }
            }
        }
        private Tip _selektovaniTip;
        public Tip SelektovaniTip
        {
            get
            {
                return _selektovaniTip;
            }
            set
            {
                if (_selektovaniTip != value)
                {
                    _selektovaniTip = value;
                    OnPropertyChanged("SelektovaniTip");
                }
            }
        }
        public string SelectedName { get; set; }
        
        //List<string> lista = new List<string>();
        public ObservableCollection<Tip> listaTipova
        {
            get;
            set;
        }
        public ObservableCollection<Etiketa> listaEtiketa
        {
            get;
            set;
        }
        public ObservableCollection<Etiketa> listaEtiketaPom
        {
            get;
            set;
        }
        public ObservableCollection<Etiketa> listaEtiketaPom1
        {
            get;
            set;
        }
        public ObservableCollection<Manifestacija> listaManifestacija
        {
            get;
            set;
        }
        public ObservableCollection<Etiketa> listBoxTagovi
        {
            get;
            set;
        }


        private List<string> Test4
        {
            get;
            set;
        }
        private string _test2;
        public string Test2
        {
            get
            {
                return _test2;
            }
            set
            {
                if (value != _test2)
                {
                    _test2 = value;
                    OnPropertyChanged("Test2");
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
        public bool neDajIstiId = true;
        public string url = "";
        public int p = 0;
        public int Q = 1;
        public int Exit = 0;
        public int Exit1 = 0;
        public int neDajX = 0;
        public string url2;
        public string url1;
        public Uri uri;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool ikonica = false;
        public bool ikonica1 = false;
        public List<string> show = new List<string>();
        public MainWindow mainWindow;
        public Manifestacija manifestZaDodavanje;

        public Window1(MainWindow mw)
        {
            this.mainWindow = mw;
            InitializeComponent();
            listaEtiketa = mainWindow.etikete;
            listBoxTagovi = new ObservableCollection<Etiketa>();
            listaEtiketaPom1 = new ObservableCollection<Etiketa>();
            listaTipova = mainWindow.tipovi;
            listaManifestacija=mainWindow.manifestacije;
            this.DataContext = this;
            idMan.Focus();
            Names = new ObservableCollection<string>();
            for (int i = 0; i < listaEtiketa.Count; i++)
            {
                Names.Add(listaEtiketa.ElementAt(i).id);

                    
            }

            for (int i = 0; i < listaEtiketa.Count; i++)
            {
                listaEtiketaPom1.Add(listaEtiketa.ElementAt(i));
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Images|*.png";

            if (opf.ShowDialog() == true)
            {
                try
                {
                    url = opf.FileName;
                    string startupPath = System.IO.Directory.GetCurrentDirectory();
                    startupPath = startupPath.Substring(0, startupPath.Length - 9);
                    startupPath += "Images\\";
                    string[] filesInImage = Directory.GetFiles(startupPath);
                    bool mozeDaSekopira = true;
                    string myFile = System.IO.Path.GetFileName(url);
                    foreach (string s in filesInImage)
                    {
                        string temp = System.IO.Path.GetFileName(s);
                        if (temp.Equals(myFile))
                        {
                            mozeDaSekopira = false;
                            break;
                        }

                    }

                    if (mozeDaSekopira)
                    {
                        startupPath += System.IO.Path.GetFileName(url);
                        File.Copy(url, startupPath, true);
                    }


                }
                catch
                {
                    
                }
              //  url = opf.FileName;
              ////  string appPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
              //  //File.Copy(url, System.IO.Path.Combine(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmployeePics"), System.IO.Path.GetFileName(url)));
              //  //Console.WriteLine("url " + url);
                
              //  //string[] url1 = url.Split('\\');
                
              //  //for(int i=0;i<url1.Length;i++)
              //  //{
              //  //    url2=url1[i];
              //  //    //Console.WriteLine("na poziciji i: " + url1[i]);
              //  //}
              ////  url2 = url.Substring(
              //  //url D:\IIIgod\VI semestar\InterakcijaCovekRacunar\Ikonice\ikonica2.png
              ////  String name = url.Substring(url.LastIndexOf("/") + 1);
                
               int i = url.LastIndexOf("\\");
               url1 = url.Substring(i + 1);

              //  //url = D:\IIIgod\VI semestar\InterakcijaCovekRacunar\Ikonice\ikonica2.png
              //  //url1 = ikonica2.png
              //  File.Copy(url,);
                
               ikonicaMan.Source = new BitmapImage(new Uri(url));
                
                ikonica = true;
                ikonica1 = true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            p = 0;
            Manifestacija man = new Manifestacija();
            man.etiketa = new ObservableCollection<Etiketa>();
            for (int k = 0; k < listaManifestacija.Count; k++)
            {
                if (idMan.Text == listaManifestacija.ElementAt(k).ID)
                {
                    p = 1;
                }
            }

            if (idMan.Text == "")
            {
                GreskaID = "Morate uneti ID!";
                GreskaDatum = "";
                GreskaNaziv = "";
            }
            else if (p == 1 && Q == 1)
            {
                GreskaID = "Postojeci ID!";
                GreskaDatum = "";
                GreskaNaziv = "";
            }
            else if (nazivMan.Text == "")
            {
                GreskaID = "";
                GreskaDatum = "";
                GreskaNaziv = "Morate uneti naziv!";
            }
            else if (datumMan.SelectedDate == null)
            {
                GreskaNaziv = "";
                GreskaID = "";
                GreskaDatum = "Morate uneti datum!";
            }
            else if (ikonica == false)
            {
                GreskaIkonica = "Morate uneti ikonicu!";
            }
            else
            {

                man.ID = idMan.Text;

                man.Naziv = nazivMan.Text;
                man.opis = opisMan.Text;
                if (tipMan.SelectedIndex == -1)
                {
                    
                }
                else
                {
                    man.tip = SelektovaniTip;
                    man.tipovId = SelektovaniTip.ime;
                    man.ikonicaTi = SelektovaniTip.ikonica;
                    man.pathT = SelektovaniTip.path;
                }
                if ((bool)dozvoljeno.IsChecked)
                {
                    man.alkohol = "Dozvoljeno";

                }
                else
                    man.alkohol = "Nedozvoljeno";
                man.Cene = (String)cenaMan.Text;
                if (man.Cene.Equals("Odaberite"))
                {
                    man.Cene = "";
                }
                man.hendikep = (bool)hendikepiraniMan.IsChecked;
                man.pusenje = (bool)pusenjeMan.IsChecked;
                if ((bool)napolje.IsChecked)
                {
                    man.napoljuUnutra = "Napolju";
                }
                else
                    man.napoljuUnutra = "Unutra";
                man.Datum = (DateTime)datumMan.SelectedDate;
                man.ocekivanePublike = (String)publikeMan.Text;

                for (int i = 0; i < listBoxTagovi.Count; i++)
                {
                    man.etiketa.Add(listBoxTagovi.ElementAt(i));
                }
                man.dragovan = false;
                man.ikonicaMa = ikonicaMan.Source;
                man.pathM = url1;
                //manifestZaDodavanje = new Manifestacija();
                //manifestZaDodavanje = man;
                mainWindow.manifestacije.Add(man);


                mainWindow.manifestacijeZaDrag.Add(man);
                Exit1 = 2;
                mainWindow.MemorisiManifestacije();

                // pravim novu listu etiketa i dodajem u nju sve iz leve i desne liste tagova
                mainWindow.etikete = null;
                mainWindow.etikete = new ObservableCollection<Etiketa>();

                for (int i = 0; i < listaEtiketa.Count; i++)
                {
                    _pomocnaEtiketa = listaEtiketa.ElementAt(i);
                    mainWindow.etikete.Add(_pomocnaEtiketa);
                }
                for (int i = 0; i < listBoxTagovi.Count; i++)
                {
                    _pomocnaEtiketa = listBoxTagovi.ElementAt(i);
                    mainWindow.etikete.Add(_pomocnaEtiketa);
                }

                
               
                this.Close();
            }
        }

        //private void etiketaSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    listBoxTagovi.Add(SelektovanaEtiketa);
        //}

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int y = 0;
            if (SelektovanaEtiketa == null)
            {
                //for (int u=0; u < listaEtiketa.Count; u++)
                //{
                //    if (SearchEtikete.Text == listaEtiketa.ElementAt(u).id)
                //    {
                //        listBoxTagovi.Add(listaEtiketa.ElementAt(u));

                //        listaEtiketa.Remove(listaEtiketa.ElementAt(u));
                //        y = 1;
                //        break;
                //    }
                //    break;
                //}
                //if (y == 0)
                //{
                //    var s = new UnosEtikete(mainWindow);
                    
           
                //    s.idEtikete.Text = SearchEtikete.Text;
                //    s.idEtikete.IsEnabled = false;
                //    s.ShowDialog();
                //}

            }
            else
            {
                listBoxTagovi.Add(SelektovanaEtiketa);
                listaEtiketa.Remove(SelektovanaEtiketa);
            }
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (SelektovanaEtiketa1 == null)
            {
            }
            else
            {
                listaEtiketa.Add(SelektovanaEtiketa1);
                listBoxTagovi.Remove(SelektovanaEtiketa1);
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            int b=0;
            for (int i = 0; i < listaEtiketa.Count(); i++)
            {
                b++;
            }
            for (int i = b-1; i >=0; i--)
            {
                listBoxTagovi.Add(listaEtiketa.ElementAt(i));
                listaEtiketa.Remove(listaEtiketa.ElementAt(i));
            }
           
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            int b = 0;
            for (int i = 0; i < listBoxTagovi.Count(); i++)
            {
                b++;
            }
            for (int i = b - 1; i >= 0; i--)
            {
                listaEtiketa.Add(listBoxTagovi.ElementAt(i));
                listBoxTagovi.Remove(listBoxTagovi.ElementAt(i));
                
            }
        }

        private void SearchEtikete_TextChanged(object sender, TextChangedEventArgs e)
        {
            //for (int i = 0; i < listaEtiketa.Count; i++)
            //{
            //    if (listaEtiketa.ElementAt(i).id.StartsWith(SearchEtikete.Text))
            //    {
            //        listaEtiketaPom.Add(listaEtiketa.ElementAt(i));
            //        listaEtiketa.Remove(listaEtiketa.ElementAt(i));
            //    }
            //}
            //for (int i = 0; i < listaEtiketa.Count; i++)
            //{
            //    _pomocnaEtiketa = listaEtiketa.ElementAt(i);
            //    listaEtiketa.Add(_pomocnaEtiketa);
            //}
            //for (int i = 0; i < listaEtiketaPom.Count; i++)
            //{
            //    _pomocnaEtiketa = listaEtiketaPom.ElementAt(i);
            //    listaEtiketa.Add(_pomocnaEtiketa);
            //}
           
        }

        public void Window_Closing(object sender, CancelEventArgs e)
        {
            Exit = 0;
            string msg = "Are you sure?";
            MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "Manifestacija",
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

        private void tipMan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ikonica1 == false)
            {
                ikonicaMan.Source = null;
            }
            if (ikonicaMan.Source == null)
            {
                for (int i = 0; i < listaTipova.Count(); i++)
                {
                    if (listaTipova.ElementAt(i).ime.Equals(SelektovaniTip.ime))
                    {
                        ikonicaMan.Source = listaTipova.ElementAt(i).ikonica;
                        
                        ikonica = true;
                        int j = listaTipova.ElementAt(i).path.LastIndexOf("\\");
                        url1 = listaTipova.ElementAt(i).path.Substring(j + 1);
                    }
                }
            }
            
            //foreach (Tip tip in listaTipova)
            //    if (tipMan.SelectedItem.Equals(tip.ime))
            //        ikonicaMan.Source = tip.ikonica;
            //ikonica = true;
        }

       

        private void autocom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            var s = new DodajTip(mainWindow);
            s.ShowDialog();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            var s = new UnosEtikete(mainWindow);
            s.ShowDialog();
        }

        private void Window_Closing_1(object sender, CancelEventArgs e)
        {

            mainWindow.etikete = null;
            mainWindow.etikete = new ObservableCollection<Etiketa>();

            for (int i = 0; i < listaEtiketa.Count; i++)
            {
                _pomocnaEtiketa = listaEtiketa.ElementAt(i);
                mainWindow.etikete.Add(_pomocnaEtiketa);
            }
            for (int i = 0; i < listBoxTagovi.Count; i++)
            {
                _pomocnaEtiketa = listBoxTagovi.ElementAt(i);
                mainWindow.etikete.Add(_pomocnaEtiketa);
            }

        }

        

       

        
    }
}
