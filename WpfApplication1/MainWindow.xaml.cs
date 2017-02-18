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
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Windows.Shapes;
using WpfApplication1.Izmena;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    [Serializable]
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
     
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                if(str== "er")
                {
                    str = "Dragg";
                HelpProvider.ShowHelp(str, this);
            
                }
            }
            else
                HelpProvider.ShowHelp("Dragg", this);
            
        }

        public void doThings(string param)
        {
           // btnOK.Background = new SolidColorBrush(Color.FromRgb(32, 64, 128));
            Title = param;
        }
        Point startPoint = new Point();
        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
           
        }
        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                try
                {
                    // Get the dragged ListViewItem
                    ListView listView = sender as ListView;
                    ListViewItem listViewItem =
                        FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
                    // Find the data behind the ListViewItem
                    Manifestacija manifest = (Manifestacija)listView.ItemContainerGenerator.
                        ItemFromContainer(listViewItem);
                    // Initialize the drag & drop operation
                    DataObject dragData = new DataObject(manifest);
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                }
                catch
                {
                }
            }
        }
        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }
        private void ListView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (SelektovanaManifestacija == null)
            {
            }
            else
            {
                var s = new UpravljanjeIkonicama(this, SelektovanaManifestacija);
                s.ShowDialog();
                
            }
        }
        //ovo je glavni deo za drag and drop i dodavanje dece na kanvas
        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Manifestacija)) != null)
            {
                Manifestacija manu = e.Data.GetData(typeof(Manifestacija)) as Manifestacija;
                ImageSource image = manu.ikonicaMa;
                //manu.dragovan = true;

                //Image imageControl = new Image() { Name = manu.ID, Source = image };
                rect = new Rectangle
                {
                    Stroke = Brushes.LightBlue,
                    StrokeThickness = 2

                };
                rect.Name = manu.ID;
                rect.Height = image.Height;
                rect.Width = image.Width;
                rect.Fill = new ImageBrush(image);
                Canvas.SetLeft(rect, e.GetPosition(c).X-11);
                Canvas.SetTop(rect, e.GetPosition(c).Y - 11);
                if(manu.dragovan==false)
                {

                    if (DaLiSeSeku(e.GetPosition(c).X-11, e.GetPosition(c).Y-11, rect))
                    {
                        c.Children.Add(rect);
                        manu.dragovan = true;
                        manu.pozicijaX = e.GetPosition(c).X - 11;
                        manu.pozicijaY = e.GetPosition(c).Y - 11;
                    }
                    
                }
                
               
              // manifestacijeZaDrag.Remove(manu);
              //  MemorisiManifestacije();
                //Canvas.SetLeft(imageControl, e.GetPosition(c).X-11);
                //Canvas.SetTop(imageControl, e.GetPosition(c).Y-11);
                //if (manu.dragovan == false)
                //{
                //    c.Children.Add(imageControl);
                //    manu.dragovan = true;
                 
                //}
                
                MemorisiManifestacije();
             
                
                
                
            }
            else if (e.Data.GetData(typeof(Rectangle)) != null)
            {
                Rectangle image = e.Data.GetData(typeof(Rectangle)) as Rectangle;
                if (c.Children.Contains(image))
                {
                  //  c.Children.Remove(image);
                    
                    foreach (Manifestacija m in manifestacije)
                    {
                        if (m.ID.Equals(image.Name))
                        {
                            if (!DaLiSeSeku(e.GetPosition(c).X - 11, e.GetPosition(c).Y - 11, image))
                            {
                                break;
                            }
                            else if(DaLiSeSeku(e.GetPosition(c).X - 11, e.GetPosition(c).Y - 11, image))
                            {
                                Canvas.SetLeft(image, e.GetPosition(c).X - 11);
                                Canvas.SetTop(image, e.GetPosition(c).Y - 11);
                                m.pozicijaX = e.GetPosition(c).X - 11;
                                m.pozicijaY = e.GetPosition(c).Y - 11;
                                MemorisiManifestacije();
                            }
                        }
                    }
                    //c.Children.Add(image);
                }
            }
        }

        private bool DaLiSeSeku(double mojaX, double mojaY, Rectangle rect)
        {
            double xLoc = 0;
            double yLoc = 0;
            foreach (Manifestacija manifest in manifestacije)
            {
                if (rect.Name == manifest.ID)
                {
                    
                }
                else if (manifest.dragovan == true)
                {
                    xLoc = manifest.pozicijaX;
                    yLoc = manifest.pozicijaY;

                    if (mojaX <= xLoc + 25 && xLoc <= mojaX + 25 && mojaY <= yLoc + 28 && yLoc <= mojaY + 28)
                        return false;
                }
            }
            return true;
        }

        //ovo je za pomeranje
        void imageControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                
                        Rectangle image = e.Source as Rectangle;
                        image.Opacity = 0.5;
                        DataObject data = new DataObject(typeof(Rectangle), image);
                        DragDrop.DoDragDrop(image, data, DragDropEffects.All);
                        image.Opacity = 1;
                    
               }
            
            catch
            {

            }
        }
        public string show1 = "";

        public Rectangle rect1;
        //na desni klik da otvara info o manifestaciji ( na mapi )
        private void c_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            try
            {


                Rectangle image = e.Source as Rectangle;

                Console.WriteLine("ime: " + image.Name);
                foreach (Manifestacija m in manifestacije)
                {
                    if (m.ID.Equals(image.Name))
                    {
                        //m.dragovan = false;
                        //MemorisiManifestacije();
                        // manifestacijeZaDrag.Add(m);
                        ContextMenu pMenu = new ContextMenu();
                        MenuItem item1 = new MenuItem();
                        MenuItem item2 = new MenuItem();
                        MenuItem item3 = new MenuItem();
                        //I have about 10 items
                        //...
                        

                        
                        item1.Header = "Informacije";

                        show1 = image.Name;
                        rect1 = image;
                        item1.Click += new RoutedEventHandler(MenuItem_Click_15);
                        pMenu.Items.Add(item1);

                        item2.Header = "Ukloni sa mape";
                        item2.Click += new RoutedEventHandler(MenuItem_Click_16);

                        pMenu.Items.Add(item2);

                        item3.Header = "Izmeni";
                        item3.Click += new RoutedEventHandler(MenuItem_Click_17);


                        pMenu.Items.Add(item3);
                        pMenu.IsOpen = true;
                       // var s = new UpravljanjeIkonicama(this, m);
                       // s.ShowDialog();
                        // c.Children.Remove(image);
                        //break;
                        //var s = new Window1(this);

                        //s.idMan.Text = m.ID;
                        //s.idMan.IsEnabled = false;
                        //s.nazivMan.Text = m.Naziv;
                        //s.opisMan.Text = m.opis;
                        //s.ShowDialog();
                    }
                }

            }
            catch
            {

            }
        }
        private Rectangle rect;
        private string _datotekaManifestacija;
        private string _datotekaEtiketa;
        private string _datotekaTipova;
        public bool Checked;
        public List<String> ikonice64
        {
            get;
            set;
        }
        
        public ObservableCollection<Etiketa> etikete
        {
            get;
            set;
        }
        public ObservableCollection<Tip> tipovi
        {
            get;
            set;
        }
        public ObservableCollection<Manifestacija> manifestacije
        {
            get;
            set;
        }
        public ObservableCollection<Manifestacija> manifestacijeZaDrag
        {
            get;
            set;
        }
      
        public ObservableCollection<string> Test3
        {
            get;
            set;
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public List<int> listaKojeTrebaBrisati = new List<int>();
        public event PropertyChangedEventHandler PropertyChanged;
        private Manifestacija _manifest;
        public Manifestacija SelektovanaManifestacija
        {
            get
            {
                return _manifest;
            }
            set
            {
                if (_manifest != value)
                {
                    _manifest = value;
                    OnPropertyChanged("SelektovanaManifestacija");
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
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            //Test3 = new ObservableCollection<string>();
            etikete = new ObservableCollection<Etiketa>();
            tipovi = new ObservableCollection<Tip>();
            manifestacije = new ObservableCollection<Manifestacija>();
            manifestacijeZaDrag = new ObservableCollection<Manifestacija>();
            _datotekaManifestacija = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "p.manifestacije");
            UcitajManifestacije();

            Console.WriteLine(manifestacijeZaDrag.Count);

            _datotekaEtiketa = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "p.etikete");
            UcitajEtikete();

           
            _datotekaTipova = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "p.tipovi");
            UcitajTipove();

            

            for (int i = 0; i < tipovi.Count; i++)
            {
                if (tipovi.ElementAt(i).path == null)
                {
                }
                else
                {
                    string startupPath = System.IO.Directory.GetCurrentDirectory();
                    startupPath = startupPath.Substring(0, startupPath.Length - 9);
                    startupPath += "Images\\";
                    startupPath += tipovi.ElementAt(i).path;
                    tipovi.ElementAt(i).ikonica= new BitmapImage(new Uri(startupPath));
                }
            }

            for (int k = 0; k < manifestacije.Count; k++)
            {
                if (manifestacije.ElementAt(k).pathM == null)
                {

                }
                else
                {
                    string startupPath = System.IO.Directory.GetCurrentDirectory();
                    startupPath = startupPath.Substring(0, startupPath.Length - 9);
                    startupPath += "Images\\";
                    startupPath += manifestacije.ElementAt(k).pathM;
                    manifestacije.ElementAt(k).ikonicaMa = new BitmapImage(new Uri(startupPath));
                    string startupPath1 = System.IO.Directory.GetCurrentDirectory();
                    startupPath1 = startupPath1.Substring(0, startupPath1.Length - 9);
                    startupPath1 += "Images\\";
                    startupPath1 += manifestacije.ElementAt(k).pathT;
                    manifestacije.ElementAt(k).ikonicaTi = new BitmapImage(new Uri(startupPath1));
                }
                    //manifestacije.ElementAt(k).ikonicaMa = new BitmapImage(new Uri("pack://application:,,/Images/" + manifestacije.ElementAt(k).pathM));
            }

            for (int y = 0; y < manifestacije.Count; y++)
            {
                manifestacijeZaDrag.Add(manifestacije.ElementAt(y));
               
            }
           // int wait = manifestacijeZaDrag.Count;
           
            
           
            
            
            
            for (int g = manifestacijeZaDrag.Count-1; g>=0; g--)
            {
                if (manifestacijeZaDrag.ElementAt(g).dragovan == true)
                {
                    ImageSource image = manifestacijeZaDrag.ElementAt(g).ikonicaMa;
                    rect = new Rectangle
                    {
                        Stroke = Brushes.LightBlue,
                        StrokeThickness = 2

                    };
                    rect.Height = image.Height;
                    rect.Width = image.Width;
                    rect.Fill = new ImageBrush(image);
                    rect.Name=manifestacijeZaDrag.ElementAt(g).ID;

                    Canvas.SetLeft(rect, manifestacijeZaDrag.ElementAt(g).pozicijaX);
                    Canvas.SetTop(rect, manifestacijeZaDrag.ElementAt(g).pozicijaY);
                    c.Children.Add(rect);
                   
                   // manifestacijeZaDrag.Remove(manifestacijeZaDrag.ElementAt(g));
                    
                }
            }
            
        }
        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int y = 0; y < manifestacije.Count; y++)
            {
                if (manifestacije.ElementAt(y).tip != SelektovaniTip)
                {

                    manifestacijeZaDrag.Remove(manifestacije.ElementAt(y));
                }
            }
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var s = new Window1(this);
            s.ShowDialog();
            s.idMan.Focus();
        }
        
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
           var s = new UnosEtikete(this);
           s.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var s =new DodajTip(this);
            s.ShowDialog();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            var s = new PregledManifestacija(this);
            s.ShowDialog();
           
        }
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            var s = new PregledEtiketa(this);
            s.ShowDialog();
        }
        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            var s = new PregledTipova(this);
            s.ShowDialog();
        }
        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {
            foreach (Manifestacija man in manifestacije)
            {
                if (man.ID == show1)
                {
                    var s = new UpravljanjeIkonicama(this, man);
                    s.ShowDialog();
                }
            }
        
        }
        private void MenuItem_Click_16(object sender, RoutedEventArgs e)
        {
            foreach (Manifestacija man in manifestacije)
            {
                
                if (man.ID == show1)
                {
                    
                        man.dragovan = false;
                        c.Children.Remove(rect1);
                        MemorisiManifestacije();
                }
            }
        }
        private void MenuItem_Click_17(object sender, RoutedEventArgs e)
        {
            foreach (Manifestacija man in manifestacije)
            {

                if (man.ID == show1)
                {

                    var s = new IzmenaManifestacije(this, man);
                    s.ShowDialog();
                    MemorisiManifestacije();
                    var ss = new MainWindow();
                    ss.Show();
                    foreach (Window window in Application.Current.Windows)
                    {
                        window.Close();
                        break;
                    }
                    
                    
                }
            }
        }
       
     


        private void UcitajManifestacije()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(_datotekaManifestacija))
            {
                try
                {
                    stream = File.Open(_datotekaManifestacija, FileMode.Open);
                   manifestacije =  (ObservableCollection<Manifestacija>)formatter.Deserialize(stream);
                }
                catch
                {
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
        }
        public void MemorisiManifestacije()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(_datotekaManifestacija, FileMode.OpenOrCreate);
                formatter.Serialize(stream, manifestacije);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        private void UcitajEtikete()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(_datotekaEtiketa))
            {
                try
                {
                    stream = File.Open(_datotekaEtiketa, FileMode.Open);
                    etikete = (ObservableCollection<Etiketa>)formatter.Deserialize(stream);
                }
                catch
                {
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
        }
        public void MemorisiEtikete()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(_datotekaEtiketa, FileMode.OpenOrCreate);
                formatter.Serialize(stream, etikete);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }
        private void UcitajTipove()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(_datotekaTipova))
            {
                try
                {
                    stream = File.Open(_datotekaTipova, FileMode.Open);
                    tipovi = (ObservableCollection<Tip>)formatter.Deserialize(stream);
                }
                catch
                {
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
        }
        public void MemorisiTipove()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(_datotekaTipova, FileMode.OpenOrCreate);
                formatter.Serialize(stream, tipovi);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }
     

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            var s = new Tutorial();
            s.ShowDialog();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
           
            var s = new DodajTip1(this);
            s.Show();
            s.popup1.IsOpen = true;
            s.imeTipa.IsEnabled = false;
            s.NovaIkonica.IsEnabled = false;
            s.opisTipa.IsEnabled = false;
            s.Potvrdi.IsEnabled = false;
            
           
           
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new Window1(this);
            s.ShowDialog();
        }
        public static readonly RoutedCommand OpenManifest = new RoutedUICommand("Options", "OptionsCommand", typeof(MainWindow), new InputGestureCollection(new InputGesture[]
        {
            new KeyGesture(Key.M, ModifierKeys.Control)
        }));
        public static readonly RoutedCommand OpenEtikete = new RoutedUICommand("Options", "OptionsCommand", typeof(MainWindow), new InputGestureCollection(new InputGesture[]
        {
            new KeyGesture(Key.E, ModifierKeys.Control)
        }));

        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new UnosEtikete(this);
            s.ShowDialog();
        }
        public static readonly RoutedCommand OpenTipa = new RoutedUICommand("Options", "OptionsCommand", typeof(MainWindow), new InputGestureCollection(new InputGesture[]
        {
            new KeyGesture(Key.T, ModifierKeys.Control)
        }));

        private void CommandBinding_CanExecute_3(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new DodajTip(this);
            s.ShowDialog();
        }
        public static readonly RoutedCommand OpenPregledM = new RoutedUICommand("Options", "OptionsCommand", typeof(MainWindow), new InputGestureCollection(new InputGesture[]
        {
            new KeyGesture(Key.M,ModifierKeys.Alt)
        }));

        private void CommandBinding_CanExecute_4(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_4(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new PregledManifestacija(this);
            s.ShowDialog();
        }
        public static readonly RoutedCommand OpenPregledE = new RoutedUICommand("Options", "OptionsCommand", typeof(MainWindow), new InputGestureCollection(new InputGesture[]
        {
            new KeyGesture(Key.E, ModifierKeys.Alt)
        }));

        private void CommandBinding_CanExecute_5(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_5(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new PregledEtiketa(this);
            s.ShowDialog();
        }
        public static readonly RoutedCommand OpenPregledT = new RoutedUICommand("Options", "OptionsCommand", typeof(MainWindow), new InputGestureCollection(new InputGesture[]
        {
            new KeyGesture(Key.T, ModifierKeys.Alt)
        }));

        private void CommandBinding_CanExecute_6(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_6(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new PregledTipova(this);
            s.ShowDialog();
        }
        public static readonly RoutedCommand Exit0 = new RoutedUICommand("Options", "OptionsCommand", typeof(MainWindow), new InputGestureCollection(new InputGesture[]
        {
            new KeyGesture(Key.W, ModifierKeys.Control)
        }));

        private void CommandBinding_CanExecute_7(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_7(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (Window w in Application.Current.Windows)
        {
            //Form f = Application.OpenForms[i];
            if (w.Name == "UnosMani")
            {
                w.Close();
            }
        }
        }













    }
}
