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
using Microsoft.Win32;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DodajTip1.xaml
    /// </summary>
    public partial class DodajTip1 : Window, INotifyPropertyChanged
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
        public int poo = 0;

        public DodajTip1(MainWindow mw)
        {
            InitializeComponent();

            this.mainWindow = mw;
            listaTipova = mainWindow.tipovi;
            this.DataContext = this;
            idTipa.Focus();
        }


        public ImageSource Image;



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog opf = new OpenFileDialog();
            //opf.Filter = "Images|*.png";

            //if (opf.ShowDialog() == true)
            //{
            //    url = opf.FileName;
            //    ikonicaTipa.Source = new BitmapImage(new Uri(url, UriKind.Absolute));
            //    ikonica = true;
            //}
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

                ikonicaTipa.Source = new BitmapImage(new Uri(url));

                ikonica = true;
                opisTipa.IsEnabled = true;
                opisTipa.Focus();
                NovaIkonica.IsEnabled = false;
                popup1.PlacementTarget = opisTipa;
                textPopup.Text = "Unesite opis tipa i stisnite enter";

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            p = 0;
            for (int k = 0; k < listaTipova.Count; k++)
            {
                if (idTipa.Text == listaTipova.ElementAt(k).id)
                {
                    p = 1;
                }
            }
            if (idTipa.Text == "")
            {
                GreskaID = "Morate uneti ID!";
                GreskaIme = "";
                GreskaIkonica = "";
            }
            else if (p == 1 && Q == 1)
            {
                GreskaID = "Postojeci ID!";
                GreskaIme = "";
                GreskaIkonica = "";
                    
            }
            else if (imeTipa.Text == "")
            {
                GreskaIme = "Morate uneti ime!";
                GreskaID = "";
                GreskaIkonica = "";
            }
            else if (ikonica == false)
            {
                GreskaID = "";
                GreskaIme = "";
                GreskaIkonica = "Morate uneti ikonicu!";
            }
            else
            {
                Tip tip = new Tip();
                tip.id = idTipa.Text;
                tip.ime = imeTipa.Text;
                tip.ikonica = ikonicaTipa.Source;
                tip.opis = opisTipa.Text;
                tip.path = url1;


                mainWindow.tipovi.Add(tip);

                //BitmapSource myBitmapSource = tip.ikonica as BitmapImage;

                //mainWindow.ikonice64.Add(mainWindow.ImageToBase64(myBitmapSource));

                Exit1 = 2;
                mainWindow.MemorisiTipove();
              

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
                    "Tip",
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
                foreach (Window w in Application.Current.Windows)
                {
                    if (w.Name == "potvrdi")
                    {
                        w.Close();
                    }
                }
            }
        }

        private void idTipa_LostFocus(object sender, RoutedEventArgs e)
        {
            if (idTipa.Text != "")
            {
                popup1.PlacementTarget = imeTipa;
                textPopup.Text = "Unesite ime tipa i stisnite enter";
            }
        }

        private void imeTipa_LostFocus(object sender, RoutedEventArgs e)
        {
            if (imeTipa.Text != "")
            {
                popup1.PlacementTarget = NovaIkonica;
                textPopup.Text = "Unesite ikonicu tipa";
            }
        }
        private void opisTipa_LostFocus(object sender, RoutedEventArgs e)
        {
            popup1.PlacementTarget = Potvrdi;
            textPopup.Text = "Potvrdite unos";
        }

        private void idTipa_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (e.Key == Key.Return)
                {
                    if (e.Key == Key.Enter)
                    {
                        imeTipa.IsEnabled = true;
                        textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        idTipa.IsEnabled = false;
                        
                    }
                }
            }
        }

        private void opisTipa_KeyDown(object sender, KeyEventArgs e)
        {
            if (idTipa.Text != "" && imeTipa.Text != "")
            {
                TextBox textBox = sender as TextBox;
                if (textBox != null)
                {
                    if (e.Key == Key.Return)
                    {
                        if (e.Key == Key.Enter)
                        {
                            Potvrdi.IsEnabled = true;
                            textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                            opisTipa.IsEnabled = false;
                        }
                    }
                }
            }
        }

        private void imeTipa_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (e.Key == Key.Return)
                {
                    if (e.Key == Key.Enter)
                    {
                        NovaIkonica.IsEnabled = true;
                        textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        imeTipa.IsEnabled = false;
                    }
                }
            }
        }


    }
}
