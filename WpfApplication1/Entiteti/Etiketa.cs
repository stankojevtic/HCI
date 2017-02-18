using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Runtime.Serialization;
using System.ComponentModel;


namespace WpfApplication1
{
    [Serializable]
    public class Etiketa
    {   
       

        public string id { get; set; }
        public string opis { get; set; }
        public string imeBoje { get; set; }
        [NonSerialized]
        public Color color;

        
        
        //public SolidColorBrush BojaBrush {get {return bojaBrush;} set {bojaBrush = value;}}
        //public Color boja { get { return ik; } set { ik = value; } }
        //[NonSerialized]
        //private Color ik;
        //[NonSerialized]
        //private SolidColorBrush bojaBrush;
        //[NonSerialized]
        //public Color boja;
        //[NonSerialized]
        //public SolidColorBrush BojaBrush;
        //[NonSerialized]
        //private SolidColorBrush ik;
   
       
        public Etiketa()
        {

        }
    }
}
