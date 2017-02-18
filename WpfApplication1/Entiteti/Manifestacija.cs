using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace WpfApplication1
{
    [Serializable]
    public class Manifestacija
    {
        public bool dragovan { get; set; }
        public double pozicijaX { get; set; }
        public double pozicijaY { get; set; }
        public string pathM { get; set; }
        public string pathT { get; set; }
        public string ID { get; set; }
        public string Naziv { get; set; }
        public string opis { get; set; }
        public Tip tip { get; set; }
        public string tipovId { get; set; }
        public string alkohol { get; set; }
        public string Cene { get; set; }
        public bool hendikep { get; set; }
        
        public bool pusenje { get; set; }
        public string napoljuUnutra { get; set; }
        public DateTime Datum { get; set; }
        public String ocekivanePublike { get; set; }
        public ObservableCollection<Etiketa> etiketa
        {
            get;
            set;
        }

        public ImageSource ikonicaMa { get { return ikM; } set { ikM = value; } }
        public ImageSource ikonicaTi { get { return ikT; } set { ikT = value; } }
        [NonSerialized]
        private ImageSource ikM;
        [NonSerialized]
        private ImageSource ikT;

        public Manifestacija()
        {

        }
        
    }
}
