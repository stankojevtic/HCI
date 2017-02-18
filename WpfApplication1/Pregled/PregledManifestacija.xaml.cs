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
    /// Interaction logic for PregledManifestacijaT.xaml
    /// </summary>
    public partial class PregledManifestacija : Window, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Etiketa> _eti;
        private String _tipIme;
        public String TipIme
        {
            get
            {
                return _tipIme;
            }
            set
            {
                if (value != _tipIme)
                {
                    _tipIme = value;
                    OnPropertyChanged("TipIme");
                }
            }
        }
        public ObservableCollection<Etiketa> ListBoxTagovi
        {
            get
            {
                return _eti;
            }
            set
            {
                if (value != _eti)
                {
                    _eti = value;
                    OnPropertyChanged("ListBoxTagovi");
                }
            }
        }
        public ObservableCollection<Manifestacija> listaManifest
        {
            get;
            set;
        }
        public ObservableCollection<Etiketa> listaTagova
        {
            get;
            set;
        }
        public ObservableCollection<Tip> listaTipova
        {
            get;
            set;
        }
        public MainWindow mainWindow;
        public String brisanjeID;
        public PregledManifestacija(MainWindow mw)
        {
            this.mainWindow = mw;
            InitializeComponent();
            this.DataContext = this;
            listaManifest = mainWindow.manifestacije;

            textBox1.Focus();

            Names = new ObservableCollection<string>();
            for (int i = 0; i < listaManifest.Count; i++)
            {
                Names.Add(listaManifest.ElementAt(i).ID);


            }
            comboBox2.Visibility = System.Windows.Visibility.Hidden;
            image5.Visibility = System.Windows.Visibility.Hidden;
            listaTagova = mainWindow.etikete;
            listaTipova = mainWindow.tipovi;
            for (int i = 0; i < mainWindow.manifestacije.Count; i++)
            {
                if (idOdSelektovanog.Text == mainWindow.manifestacije.ElementAt(i).ID)
                {
                    TipIme = mainWindow.manifestacije.ElementAt(i).tip.ime;
                }
            }
            
        }
        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            comboBox2.Visibility = System.Windows.Visibility.Visible;
            image5.Visibility = System.Windows.Visibility.Visible;

        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            comboBox2.Visibility = System.Windows.Visibility.Hidden;
            image5.Visibility = System.Windows.Visibility.Hidden;
        }
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        private ICollectionView _listItemCollection;
        private string _filterString;
        private string _filterString2 = "Filtriraj po:";
        public string FilterString2
        {
            get { return _filterString2; }
            set
            {
                _filterString2 = value;
                NotifyPropertyChanged("FilterString2");
                if (_listItemCollection != null)
                {
                    _listItemCollection.Refresh();
                }
            }
        }

        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                NotifyPropertyChanged("FilterString");
                if (_listItemCollection != null)
                {
                    _listItemCollection.Refresh();
                }
            }
        }
        public ICollectionView ListItemCollection
        {
            get { return _listItemCollection; }
            set { _listItemCollection = value; NotifyPropertyChanged("ListItemCollection"); }
        }

        public bool FilterTask(object value)
        {
            var entry = value as Manifestacija;
            if (entry != null)
            {
                if (_filterString2 != "Filtriraj po:" && !(string.IsNullOrEmpty(_filterString)))
                {

                    if (comboBox1.SelectedIndex == 0)
                    {
                        return true;
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        return (entry.pusenje && entry.ID.Contains(_filterString));
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        return (!(entry.pusenje) && entry.ID.Contains(_filterString));
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        return (entry.hendikep && entry.ID.Contains(_filterString));
                    }
                    if (comboBox1.SelectedIndex == 4)
                    {
                        return (!(entry.hendikep) && entry.ID.Contains(_filterString));
                    }
                    if (comboBox1.SelectedIndex == 5)
                    {
                        return (entry.alkohol.Contains("Dozvoljeno") &&  entry.ID.Contains(_filterString));
                    }
                    if (comboBox1.SelectedIndex == 6)
                    {
                        return (entry.alkohol.Contains("Nedozvoljeno") && entry.ID.Contains(_filterString));
                    }
                    if (comboBox1.SelectedIndex == 7)
                    {
                        return (entry.Cene.Contains("Besplatno") && entry.ID.Contains(_filterString));
                    }
                    if (comboBox1.SelectedIndex == 8)
                    {
                        return (entry.Cene.Contains("Niske cene") && entry.ID.Contains(_filterString));
                    }
                    if (comboBox1.SelectedIndex == 9)
                    {
                        return (entry.Cene.Contains("Srednje cene") && entry.ID.Contains(_filterString));
                    }
                    if (comboBox1.SelectedIndex == 10)
                    {
                        return (entry.Cene.Contains("Visoke cene") && entry.ID.Contains(_filterString));
                    }

                }
                else if (!string.IsNullOrEmpty(_filterString) && _filterString2=="Filtriraj po:")
                {
                    return entry.ID.Contains(_filterString);
                }
                else if ( _filterString2 != "Filtriraj po:" && string.IsNullOrEmpty(_filterString))
                {

                    if (comboBox1.SelectedIndex == 0)
                    {
                        return true;
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        return (entry.pusenje);
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        return (!(entry.pusenje));
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        return (entry.hendikep);
                    }
                    if (comboBox1.SelectedIndex == 4)
                    {
                        return (!(entry.hendikep));
                    }
                    if (comboBox1.SelectedIndex == 5)
                    {
                        return (entry.alkohol.Contains("Dozvoljeno"));
                    }
                    if (comboBox1.SelectedIndex == 6)
                    {
                        return (entry.alkohol.Contains("Nedozvoljeno"));
                    }
                    if (comboBox1.SelectedIndex == 7)
                    {
                        return (entry.Cene.Contains("Besplatno"));
                    }
                    if (comboBox1.SelectedIndex == 8)
                    {
                        return entry.Cene.Contains("Niske cene");
                    }
                    if (comboBox1.SelectedIndex == 9)
                    {
                        return entry.Cene.Contains("Srednje cene");
                    }
                    if (comboBox1.SelectedIndex == 10)
                    {
                        return entry.Cene.Contains("Visoke cene");
                    }

                }
                else if (comboBox2.SelectedItem != null && comboBox2.Visibility==System.Windows.Visibility.Visible)
                {
                    Tip tip = new Tip();
                    tip = (Tip)comboBox2.SelectedItem;
                    return entry.tipovId.Contains(tip.ime);
                }
                
               
                return true;
            }
            return false;
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            _filterString = textBox1.Text;
            ListItemCollection = CollectionViewSource.GetDefaultView(listaManifest);
            ListItemCollection.Filter = FilterTask;
            ListItemCollection = null;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String ime = "";
            brisanjeID = idOdSelektovanog.Text;

            for (int i = 0; i < listaManifest.Count; i++)
            {
                if (listaManifest.ElementAt(i).ID.Equals(brisanjeID))
                {
                    ime = listaManifest.ElementAt(i).ID;
                    listaManifest.Remove(listaManifest.ElementAt(i));
                   
                }
            }
            for (int j = 0; j < mainWindow.manifestacije.Count; j++)
            {
                if (ime == mainWindow.manifestacije.ElementAt(j).ID)
                {
                    mainWindow.manifestacije.Remove(mainWindow.manifestacije.ElementAt(j));
                    
                }
            }
            mainWindow.MemorisiManifestacije();
            Names = new ObservableCollection<string>();
            for (int i = 0; i < listaManifest.Count; i++)
            {
                Names.Add(listaManifest.ElementAt(i).ID);


            }
           
          
        }
        public void Window_Closing(object sender, CancelEventArgs e)
        {
        
            string msg = "Are you sure?";
            MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "Pregled manifestacija",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                // If user doesn't want to close, cancel closure
                e.Cancel = true;
            }
            if (result == MessageBoxResult.Yes)
            {
                mainWindow.Close();
                MainWindow w1 = new MainWindow();
                w1.Show();
            }


        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {

            if (idOdSelektovanog.Text != "")
            {

                Manifestacija man = new Manifestacija();
                for (int i = 0; i < listaManifest.Count; i++)
                {
                    if (listaManifest.ElementAt(i).ID.Equals(idOdSelektovanog.Text))
                    {

                        man = listaManifest.ElementAt(i);

                    }
                }
                var s = new IzmenaManifestacije(mainWindow, man);
                s.ShowDialog();
                dgrMain.Items.Refresh();
                dgrMain.SelectedItem = null;
                

                mainWindow.MemorisiManifestacije();
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var s = new Window1(mainWindow);
            s.ShowDialog();
        }
        private ICollectionView _View;
        public ICollectionView View
        {
            get
            {
                return _View;
            }
            set
            {
                _View = value;
                OnPropertyChanged("View");
            }
        }

        private bool _GroupView;
        public bool GroupView
        {
            get
            {
                return _GroupView;
            }
            set
            {
                if (value != _GroupView && View != null)
                {
                    View.GroupDescriptions.Clear();
                    if (value)
                    {
                        View.GroupDescriptions.Add(new PropertyGroupDescription("pusenje"));
                    }
                    _GroupView = value;
                    OnPropertyChanged("GroupView");

                    OnPropertyChanged("View");
                }
            }
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgrMain.SelectedItem = null;
        }

        private void winTable_Closing(object sender, CancelEventArgs e)
        {
            mainWindow.Close();
            var s = new MainWindow();
            s.Show();
        }
        public static readonly RoutedCommand Delete = new RoutedUICommand("Delete", "Delete", typeof(PregledManifestacija), new InputGestureCollection(new InputGesture[]
        {
            new KeyGesture(Key.H, ModifierKeys.Control)
        }));

        private void CommandBinding_CanExecute_11(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        public static readonly RoutedCommand Escape = new RoutedUICommand("Escape", "Escape", typeof(PregledManifestacija), new InputGestureCollection(new InputGesture[]
        {
            new KeyGesture(Key.Escape)
        }));

        private void CommandBinding_CanExecute_12(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_11(object sender, ExecutedRoutedEventArgs e)
        {
            String ime = "";
            brisanjeID = idOdSelektovanog.Text;

            for (int i = 0; i < listaManifest.Count; i++)
            {
                if (listaManifest.ElementAt(i).ID.Equals(brisanjeID))
                {
                    ime = listaManifest.ElementAt(i).ID;
                    listaManifest.Remove(listaManifest.ElementAt(i));

                }
            }
            for (int j = 0; j < mainWindow.manifestacije.Count; j++)
            {
                if (ime == mainWindow.manifestacije.ElementAt(j).ID)
                {
                    mainWindow.manifestacije.Remove(mainWindow.manifestacije.ElementAt(j));

                }
            }
            mainWindow.MemorisiManifestacije();
        }

        private void dgrMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Delete))
            {
                String ime = "";
                brisanjeID = idOdSelektovanog.Text;

                for (int i = 0; i < listaManifest.Count; i++)
                {
                    if (listaManifest.ElementAt(i).ID.Equals(brisanjeID))
                    {
                        ime = listaManifest.ElementAt(i).ID;
                        listaManifest.Remove(listaManifest.ElementAt(i));

                    }
                }
                for (int j = 0; j < mainWindow.manifestacije.Count; j++)
                {
                    if (ime == mainWindow.manifestacije.ElementAt(j).ID)
                    {
                        mainWindow.manifestacije.Remove(mainWindow.manifestacije.ElementAt(j));

                    }
                }
                mainWindow.MemorisiManifestacije();
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            _filterString = "";
            _filterString2 = "Filtriraj po:";
           
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            checkBox1.IsChecked = false;
            comboBox2.Visibility = System.Windows.Visibility.Hidden;
            ListItemCollection = CollectionViewSource.GetDefaultView(listaManifest);
            ListItemCollection.Filter = FilterTask;
            ListItemCollection = null;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            _filterString = textBox1.Text;
            button4_Click(sender, e);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            button4_Click(sender, e);

        }
        public ObservableCollection<string> Names { get; set; }
        private void autocom_Populating(object sender, PopulatingEventArgs e)
        {
            string text = textBox1.Text;
            textBox1.ItemsSource = Names;
            _filterString = text;
        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tip tip = new Tip();
            tip = (Tip) comboBox2.SelectedItem;
            Console.WriteLine(tip.ime);
            Console.WriteLine(comboBox2.SelectedItem.ToString());
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

       

      

        
    }
}
