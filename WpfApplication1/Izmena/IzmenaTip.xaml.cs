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
using System.IO;
using Microsoft.Win32;

namespace WpfApplication1.Izmena
{
    /// <summary>
    /// Interaction logic for IzmenaTip.xaml
    /// </summary>
    public partial class IzmenaTip : Window, INotifyPropertyChanged
    {
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

        private string _greskaIkonica;
        public string GreskaIkonica
        {
            get
            {
                return _greskaIkonica;
            }
            set
            {
                if (value != _greskaIkonica)
                {
                    _greskaIkonica = value;
                    OnPropertyChanged("GreskaIkonica");
                }
            }
        }
        private string _greskaIme;
        public string GreskaIme
        {
            get
            {
                return _greskaIme;
            }
            set
            {
                if (value != _greskaIme)
                {
                    _greskaIme = value;
                    OnPropertyChanged("GreskaIme");
                }
            }
        }
        private ObservableCollection<Tip> listaTipova
        {
            get;
            set;
        }
        public bool ikonica = false;
        public MainWindow mainWindow;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public int Exit = 0;
        public int Exit1 = 0;
        public int p = 0;
        public string url1;
        public int Q = 1;
        public string url = "";
        public Tip tipZaDodavanje;
        public Tip TIP;
        public IzmenaTip(MainWindow mw, Tip tip)
        {
            InitializeComponent();
            this.TIP = tip;
            this.mainWindow = mw;
            listaTipova = mainWindow.tipovi;
            this.DataContext = this;
            idTipa.Text = tip.id;
            idTipa.IsEnabled = false;
            imeTipa.Text = tip.ime;
            opisTipa.Text = tip.opis;
            ikonica = true;
            ikonicaTipa.Source = tip.ikonica;
            url1 = tip.path;
            
        }
        public ImageSource Image;
        private void Button_Click(object sender, RoutedEventArgs e)
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
                   
                }
                int i = url.LastIndexOf("\\");
                url1 = url.Substring(i + 1);

                ikonicaTipa.Source = new BitmapImage(new Uri(url));

                ikonica = true;

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            if (imeTipa.Text == "")
            {
                GreskaIme = "Morate uneti ime!";
                GreskaID = "";
                GreskaIkonica = "";
            }
            else
            {
               
                TIP.ime = imeTipa.Text;
                TIP.ikonica = ikonicaTipa.Source;
                TIP.opis = opisTipa.Text;
                TIP.path = url1;
             
                
               

                mainWindow.MemorisiTipove();
                this.Close();
            }


        }

    }
}

