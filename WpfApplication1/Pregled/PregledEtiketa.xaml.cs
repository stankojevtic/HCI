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
    /// Interaction logic for PregledEtiketa.xaml
    /// </summary>
    public partial class PregledEtiketa : Window, INotifyPropertyChanged
    {
        public Brush Convert(string boja)
        {
            Color color = (Color)ColorConverter.ConvertFromString(boja);
            SolidColorBrush brush = new SolidColorBrush(color);
            return brush;
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Etiketa> listaEtiketa
        {
            get;
            set;
        }
         public MainWindow mainWindow;
        public String brisanjeID;
        public PregledEtiketa(MainWindow mw)
        {
            this.mainWindow = mw;
            InitializeComponent();
            this.DataContext = this;
            listaEtiketa = mainWindow.etikete;
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            {
                String ime = "";
                brisanjeID = idOdSelektovanog.Text;

                for (int i = 0; i < listaEtiketa.Count; i++)
                {
                    if (listaEtiketa.ElementAt(i).id.Equals(brisanjeID))
                    {
                        ime = listaEtiketa.ElementAt(i).id;
                        listaEtiketa.Remove(listaEtiketa.ElementAt(i));

                    }
                }
                for (int j = 0; j < mainWindow.etikete.Count; j++)
                {
                    if (ime == mainWindow.etikete.ElementAt(j).id)
                    {
                        mainWindow.etikete.Remove(mainWindow.etikete.ElementAt(j));
                    }
                }
                mainWindow.MemorisiEtikete();
            }
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            
            Etiketa man = new Etiketa();
            for (int i = 0; i < listaEtiketa.Count; i++)
            {
                if (listaEtiketa.ElementAt(i).id.Equals(idOdSelektovanog.Text))
                {

                    man = listaEtiketa.ElementAt(i);

                }
            }
            var s = new IzmenaEtiketa(mainWindow, man);
            s.ShowDialog();
            dgrMain.Items.Refresh();
            dgrMain.SelectedItem = null;
            mainWindow.MemorisiEtikete();

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var s = new UnosEtikete(mainWindow);
            s.ShowDialog();
        }
    }
}
