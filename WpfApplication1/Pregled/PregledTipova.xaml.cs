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
using WpfApplication1.Izmena;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for PregledTipova.xaml
    /// </summary>
    public partial class PregledTipova : Window, INotifyPropertyChanged
    {
        private String _greska;
        public String GreskaPostoji
        {
            get
            {
                return _greska;
            }
            set
            {
                if (_greska != value)
                {
                    _greska = value;
                    OnPropertyChanged("GreskaPostoji");
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

        public event PropertyChangedEventHandler PropertyChanged;
       
        private String _greskaID;
        public String GreskaPostojiID
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
                    OnPropertyChanged("GreskaPostojiID");
                }
            }
        }
        public ObservableCollection<Tip> listaTipova
        {
            get;
            set;
        }
        public ObservableCollection<Manifestacija> listaManifestova
        {
            get;
            set;
        }
         public MainWindow mainWindow;
        public String brisanjeID;
        public PregledTipova(MainWindow mw)
        {
            this.mainWindow = mw;
            InitializeComponent();
            this.DataContext = this;
            listaTipova = mainWindow.tipovi;
            listaManifestova = mainWindow.manifestacije;
            GreskaPostoji = "SHOW";
        }

       
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            String ime = "";
            brisanjeID = imeOdSelektovanog.Text;
            //for (int i = 0; i < listaTipova.Count; i++)
            //{
            //    listaTipova.Remove(listaTipova.ElementAt(i));
            //}
            if (listaManifestova.Count == 0)
            {
                for (int i = 0; i < listaTipova.Count; i++)
                {
                    if (listaTipova.ElementAt(i).id.Equals(brisanjeID))
                    {
                        
                        listaTipova.Remove(listaTipova.ElementAt(i));
                        mainWindow.MemorisiTipove();
                    }
                }
            }
            int p = 0;
            foreach (Manifestacija man in listaManifestova)
            {
                Console.WriteLine("tipovID: " + man.tipovId + "BrisanjeID: " + brisanjeID);
                if (man.tipovId == brisanjeID)
                {
                    Console.WriteLine("Usaoo");
                    //for (int i = 0; i < listaTipova.Count; i++)
                    //{
                    //    if (listaTipova.ElementAt(i).id.Equals(brisanjeID))
                    //    {
                    //        ime = listaTipova.ElementAt(i).id;
                    //        listaTipova.Remove(listaTipova.ElementAt(i));

                    //    }
                    //}
                    p = 1;
                }
            }
            if(p==0)
            {
                for (int i = 0; i < listaTipova.Count; i++)
                {
                    if (listaTipova.ElementAt(i).ime.Equals(brisanjeID))
                    {
                        ime = listaTipova.ElementAt(i).id;
                        listaTipova.Remove(listaTipova.ElementAt(i));

                    }
                }
                for (int j = 0; j < mainWindow.tipovi.Count; j++)
                {
                    if (ime == mainWindow.tipovi.ElementAt(j).id)
                    {
                        mainWindow.tipovi.Remove(mainWindow.tipovi.ElementAt(j));
                    }
                }
                mainWindow.MemorisiTipove();
            
               
            }
        }

        

        private void button1_Click1(object sender, RoutedEventArgs e)
        {

            
            Tip man = new Tip();
            for (int i = 0; i < listaTipova.Count; i++)
            {
                if (listaTipova.ElementAt(i).id.Equals(idOdSelektovanog.Text))
                {

                    man = listaTipova.ElementAt(i);

                }
            }

            var s = new IzmenaTip(mainWindow,man);
            s.ShowDialog();
            dgrMain.Items.Refresh();
            dgrMain.SelectedItem = null;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var s = new DodajTip(mainWindow);
            s.ShowDialog();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            mainWindow.Close();
            MainWindow w1 = new MainWindow();
            w1.Show();
        }
    }
}
