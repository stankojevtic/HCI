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
using Microsoft.Win32;
using System.IO;

namespace WpfApplication1.Izmena
{
    /// <summary>
    /// Interaction logic for IzmenaManifestacije.xaml
    /// </summary>
    public partial class IzmenaManifestacije : Window, INotifyPropertyChanged
    {
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
        public Manifestacija MANIFESTACIJA;
        public IzmenaManifestacije(MainWindow mw,Manifestacija man)
        {
            this.mainWindow = mw;
            InitializeComponent();
            this.MANIFESTACIJA = man;
            listaEtiketa = mainWindow.etikete;
            listBoxTagovi = new ObservableCollection<Etiketa>();
            listaEtiketaPom1 = new ObservableCollection<Etiketa>();
            listaTipova = mainWindow.tipovi;
            listaManifestacija=mainWindow.manifestacije;
            this.DataContext = this;
            Names = new ObservableCollection<string>();
            for (int i = 0; i < listaEtiketa.Count; i++)
            {
                Names.Add(listaEtiketa.ElementAt(i).id);
            }
            for (int i = 0; i < listaEtiketa.Count; i++)
            {
                listaEtiketaPom1.Add(listaEtiketa.ElementAt(i));
            }
            idMan.Text = man.ID;
            idMan.IsEnabled = false;
            nazivMan.Text = man.Naziv;
            opisMan.Text = man.opis;
            ikonica = true;
            url1 = man.pathM;
            ikonicaMan1.Source = man.ikonicaMa;
            listBoxTagovi = man.etiketa;
            for (int i = 0; i < listBoxTagovi.Count; i++)
            {
                for (int j = 0; j < listaEtiketa.Count; j++)
                {
                    if (listBoxTagovi.ElementAt(i).id == listaEtiketa.ElementAt(j).id)
                    {
                        listaEtiketa.Remove(listaEtiketa.ElementAt(j));
                    }
                }
            }
            foreach (Tip tip in listaTipova)
            {
                if (tip.ime == man.tipovId)
                {
                    SelektovaniTip = tip;
                }
            }


            if (man.alkohol == "Dozvoljeno")
            {
                dozvoljeno.IsChecked = true;
            }
            else
            {
                nedozvoljeno.IsChecked = true;
            }
            if (man.Cene == "Odaberite")
            {
                cenaMan.SelectedIndex = 0;
            }
            else if (man.Cene == "Niske cene")
            {
                cenaMan.SelectedIndex = 1;
            }
            else if (man.Cene == "Srednje cene")
            {
                cenaMan.SelectedIndex = 2;
            }
            else if (man.Cene == "Visoke cene")
            {
                cenaMan.SelectedIndex = 3;
            }
            datumMan.SelectedDate = man.Datum;
            if (man.hendikep == true)
            {
                hendikepiraniMan.IsChecked = true;
            }
            else
                hendikepiraniMan.IsChecked = false;
            if (man.pusenje == true)
            {
                pusenjeMan.IsChecked = true;
            }

            else
                pusenjeMan.IsChecked = false;
            if (man.napoljuUnutra == "Napolju")
            {
                napolje.IsChecked = true;
            }
            else
            {
                unutra.IsChecked = true;
            }
            
           if (man.ocekivanePublike == "0-10")
            {
                publikeMan.SelectedIndex = 0;
            }
            else if (man.ocekivanePublike == "10-50")
            {
                publikeMan.SelectedIndex = 1;
            }
            else if (man.ocekivanePublike == "50-100")
            {
                publikeMan.SelectedIndex = 2;
            }
            else if (man.ocekivanePublike == "100-200")
            {
                publikeMan.SelectedIndex = 3;
            }
            else if (man.ocekivanePublike == "200 i vise")
            {
                publikeMan.SelectedIndex = 5;
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



                    Console.WriteLine("source : " + url);
                    Console.WriteLine("dest : " + startupPath);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Ikonica lokala nije dobro ucitana!");
                }

               int i = url.LastIndexOf("\\");
               url1 = url.Substring(i + 1);
               ikonicaMan1.Source = new BitmapImage(new Uri(url));
                
                ikonica = true;
                ikonica1 = true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (nazivMan.Text == "")
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
           
            else
            {

                

                MANIFESTACIJA.ID = idMan.Text;

                MANIFESTACIJA.Naziv = nazivMan.Text;
                MANIFESTACIJA.opis = opisMan.Text;
                if (tipMan.SelectedIndex == -1)
                {

                }
                else
                {
                    MANIFESTACIJA.tip = SelektovaniTip;
                    MANIFESTACIJA.tipovId = SelektovaniTip.ime;
                    MANIFESTACIJA.ikonicaTi = SelektovaniTip.ikonica;
                }
                if ((bool)dozvoljeno.IsChecked)
                {
                    MANIFESTACIJA.alkohol = "Dozvoljeno";

                }
                else
                    MANIFESTACIJA.alkohol = "Nedozvoljeno";
                MANIFESTACIJA.Cene = (String)cenaMan.Text;
                if (MANIFESTACIJA.Cene.Equals("Odaberite"))
                {
                    MANIFESTACIJA.Cene = "";
                }
                MANIFESTACIJA.hendikep = (bool)hendikepiraniMan.IsChecked;
                MANIFESTACIJA.pusenje = (bool)pusenjeMan.IsChecked;
                if ((bool)napolje.IsChecked)
                {
                    MANIFESTACIJA.napoljuUnutra = "Napolju";
                }
                else
                    MANIFESTACIJA.napoljuUnutra = "Unutra";
                MANIFESTACIJA.Datum = (DateTime)datumMan.SelectedDate;
                MANIFESTACIJA.ocekivanePublike = (String)publikeMan.Text;
                //MANIFESTACIJA.etiketa = null;
                //for (int i = 0; i < listBoxTagovi.Count; i++)
                //{
                //    MANIFESTACIJA.etiketa.Add(listBoxTagovi.ElementAt(i));
                    
                //}

                MANIFESTACIJA.ikonicaMa = ikonicaMan1.Source;
                MANIFESTACIJA.pathM = url1;
               

            
                mainWindow.MemorisiManifestacije();

                //// pravim novu listu etiketa i dodajem u nju sve iz leve i desne liste tagova
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
            
           
        }

       

        private void autocom_Populating(object sender, PopulatingEventArgs e)
        {
            string text = autocom.Text;
            autocom.ItemsSource = Names;
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

       

        
    }
}
