using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace WpfApplication1
{
    [Serializable]
    public class Tip
    {
        public string id { get; set; }
        public string ime { get; set; }
        public string opis { get; set; }
        public string path { get; set; }
       

      

        public ImageSource ikonica { get { return ik; } set { ik = value; } }
        [NonSerialized]
        private ImageSource ik;

        public Tip()
        {

        }
    }
}
