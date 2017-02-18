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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for UpravljanjeIkonicama.xaml
    /// </summary>
    public partial class UpravljanjeIkonicama : Window, INotifyPropertyChanged
    {
        Image image;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private Manifestacija _manifestacija;
        public Manifestacija Manifestacija        
        {
            get
            {
                return _manifestacija;
            }
            set
            {
                if (_manifestacija != value)
                {
                    _manifestacija = value;
                    OnPropertyChanged("Manifestacija");
                }
            }
        }
        MainWindow mainWindow;
        public UpravljanjeIkonicama(MainWindow mw, Manifestacija manifest)
        {
            
            this.mainWindow = mw;
            this.Manifestacija = manifest;
            InitializeComponent();
            this.DataContext = this;

        }
    }
}
