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
    /// Interaction logic for Tutorial.xaml
    /// </summary>
    public partial class Tutorial : Window, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private ImageSource _slika;
        public ImageSource Slika
        {
            get
            {
                return _slika;
            }
            set
            {
                if (_slika != value)
                {
                    _slika = value;
                    OnPropertyChanged("Slika");
                }
            }
        }
        private String _tekst;
        public String Tekst
        {
            get
            {
                return _tekst;
            }
            set
            {
                if (_tekst != value)
                {
                    _tekst = value;
                    OnPropertyChanged("Tekst");
                }
            }
        }
        private String _naslov;
        public String Naslov
        {
            get
            {
                return _naslov;
            }
            set
            {
                if (_naslov != value)
                {
                    _naslov = value;
                    OnPropertyChanged("Naslov");
                }
            }
        }
        public Tutorial()
        {
            InitializeComponent();
            this.DataContext = this;
            textBox1.FontSize = 12;
            
            textBlock1.FontSize = 20;
            textBlock1.TextAlignment = TextAlignment.Center;
            textBlock1.Foreground = new SolidColorBrush(Colors.DodgerBlue);
            var uri = new Uri("pack://application:,,,/Images/help.jpg");
            var bitmap = new BitmapImage(uri);
            image1.Source = bitmap;
            Naslov = "Help";
            Tekst = "\n\n Dobrodosli u onlajn dokumentaciju evidencije o geografskoj \n distribuciji manifestacija. \n ";
        }

        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem item = (TreeViewItem) treeView1.SelectedItem;
            //Console.WriteLine(item.Name);
            if (item.Name == "Unos")
            {
                Naslov = "Unos";
                Tekst = " \n\n Evidencija o geografskoj distribuciji manifestacija \n omogućava unos tri tipa entiteta, moguće je uneti: \n\n  1. Novu manifestaciju \n  2. Novi tip manifestacije \n  3. Novu etiketu \n\n Da biste uneli manifestaciju, kliknite na 'Nova manifestacija'. \n\n Da biste uneli etiketu, kliknite na 'Nova etiketa'. \n\n Da biste uneli tip manifestacije, kliknite na 'Novi tip \n\n manifestacije'";
                var uri = new Uri("pack://application:,,,/Images/unos2.png");
                var bitmap = new BitmapImage(uri);
                image1.Source = bitmap;
                
            }
            else if (item.Name == "Manifestacija")
            {
                Naslov = "Manifestacija";
                Tekst = "Svaka manifestacija je opisana preko: svoje jedinstvene ljudski-čitljive oznake koju unosi korisnik, imena, opisa, tipa, statusa za služenje alkohola, ikonice, da li je dostupna za hendikepirane, da li je na njoj dozvoljeno pušenje, da li je napolju ili unutra, kategorije cena, očekivane publike, i datuma održavanja. Ikonica je sličica koja se učitava i koja se koristi da se manifestacija označi na mapi i može da se i ne postavi i, ako se ne postavi, onda se podrazumevano uzima ikonica tipa. Status služenja alkohola je jedna od sledećih vrednosti: nema alkohola, alkohol se može doneti, alkohol se može kupiti na licu mesta. Kategorija cena je jedna od sledećih vrednosti: besplatno, niske cene, srednje cene, visoke cene. Manifestacije takođe mogu biti i tagovane sa nijednom, jednom, ili više etiketa. Etikete specificira korisnik i one su opisane svojom jedinstvenom ljudski-čitljivom oznakom koju unosi korisnik, bojom i opisom. ";
                var uri = new Uri("pack://application:,,,/Images/unos1.png");
                var bitmap = new BitmapImage(uri);
                image1.Source = bitmap;
            }
            else if (item.Name == "Tip")
            {
                Naslov = "Tip";
                //Tekst = "Svaka manifestacija je opisana preko: svoje jedinstvene ljudski-čitljive oznake koju unosi korisnik, imena, opisa, tipa, statusa za služenje alkohola, ikonice, da li je dostupna za hendikepirane, da li je na njoj dozvoljeno pušenje, da li je napolju ili unutra, kategorije cena, očekivane publike, i datuma održavanja. Ikonica je sličica koja se učitava i koja se koristi da se manifestacija označi na mapi i može da se i ne postavi i, ako se ne postavi, onda se podrazumevano uzima ikonica tipa. Status služenja alkohola je jedna od sledećih vrednosti: nema alkohola, alkohol se može doneti, alkohol se može kupiti na licu mesta. Kategorija cena je jedna od sledećih vrednosti: besplatno, niske cene, srednje cene, visoke cene. Manifestacije takođe mogu biti i tagovane sa nijednom, jednom, ili više etiketa. Etikete specificira korisnik i one su opisane svojom jedinstvenom ljudski-čitljivom oznakom koju unosi korisnik, bojom i opisom. ";
                Tekst = "Tip manifestacije je opisan preko svoje jedinstvene ljudski-čitljive oznake koju unosi korisnik, imena, ikonice, i opisa. Ikonica je sličica koja se učitava i koja se koristi da se taj tip manifestacije označi na mapi.";
                var uri = new Uri("pack://application:,,,/Images/unos4.png");
                var bitmap = new BitmapImage(uri);
                image1.Source = bitmap;
            }
            else if (item.Name == "Etiketa")
            {
                Naslov = "Manifestacija";
                //Tekst = "Svaka manifestacija je opisana preko: svoje jedinstvene ljudski-čitljive oznake koju unosi korisnik, imena, opisa, tipa, statusa za služenje alkohola, ikonice, da li je dostupna za hendikepirane, da li je na njoj dozvoljeno pušenje, da li je napolju ili unutra, kategorije cena, očekivane publike, i datuma održavanja. Ikonica je sličica koja se učitava i koja se koristi da se manifestacija označi na mapi i može da se i ne postavi i, ako se ne postavi, onda se podrazumevano uzima ikonica tipa. Status služenja alkohola je jedna od sledećih vrednosti: nema alkohola, alkohol se može doneti, alkohol se može kupiti na licu mesta. Kategorija cena je jedna od sledećih vrednosti: besplatno, niske cene, srednje cene, visoke cene. Manifestacije takođe mogu biti i tagovane sa nijednom, jednom, ili više etiketa. Etikete specificira korisnik i one su opisane svojom jedinstvenom ljudski-čitljivom oznakom koju unosi korisnik, bojom i opisom. ";
                //Tekst = "Tip manifestacije je opisan preko svoje jedinstvene ljudski-čitljive oznake koju unosi korisnik, imena, ikonice, i opisa. Ikonica je sličica koja se učitava i koja se koristi da se taj tip manifestacije označi na mapi.";
                Tekst = "Etiketa ili nalepnica opisuje manifestaciju. Jedna manifestacija može imati nijednu jednu ili više etiketa u zavisnosti od same manifestacije. Etikete su opisane jedinstvenom oznakom, bojom i opisom.";
                var uri = new Uri("pack://application:,,,/Images/unos3.png");
                var bitmap = new BitmapImage(uri);
                image1.Source = bitmap;
            }
            else if (item.Name == "UnosM")
            {
                Naslov = "Unos manifestacije";
                Tekst = " \n\n Klikom na 'Nova manifestacija' otvara se \n novi prozor (slika desno). \n\n Da biste uneli novu manifestaciju \n neophodno je uneti sledece stavke: \n\n  1. ID manifestacije (jedinstvena ljudski-čitljiva oznaka \n  manifestacije). \n  2. Naziv manifestacije. \n  3. Datum manifestacije. \n  4. Ikonicu manifestacije. \n\n Takodje pozeljno je uneti i ostale stavke: \n\n  1. Opis manifestacije. \n  2. Sluzenje alkohola. \n  3. Kategorije cena. \n  4. Dostupno za hendikepirane. \n  5. Dozvoljeno pusenje. \n  6. Napolju ili unutra. \n  7. Ocekivano publike. \n  8. Etikete manifestacije. \n  9. Tip manifestacije.  \n\n\n  Kada ste uneli informacije o manifestaciji, \n  kliknite dugme potvrdi.";
                var uri = new Uri("pack://application:,,,/Images/unos1.png");
                var bitmap = new BitmapImage(uri);
                image1.Source = bitmap;
            }
            else if (item.Name == "UnosE")
            {
                Naslov = "Unos etikete";
                Tekst = " \n\n Klikom na 'Nova etiketa' otvara se novi prozor (slika desno). \n\n Da biste uneli novu etiketu \n neophodno je uneti sledece stavke: \n\n  1. ID etikete (jedinstvena ljudski-čitljiva oznaka etikete). \n  2. Boju etikete. \n\n  Takodje pozeljno je uneti i opis etikete. \n\n\n  Kada ste uneli informacije o etiketi, \n  kliknite dugme potvrdi. ";
                var uri = new Uri("pack://application:,,,/Images/unos3.png");
                var bitmap = new BitmapImage(uri);
                image1.Source = bitmap;
            }
            else if (item.Name == "UnosT")
            {
                Naslov = "Unos tipa manifestacije";
                Tekst = " \n\n Klikom na 'Novi tip manifestacije' otvara se \n novi prozor (slika desno). \n\n Da biste uneli novu tip manifestacije\n neophodno je uneti sledece stavke: \n\n  1. ID tipa manifestacije (jedinstvena ljudski-čitljiva oznaka \n  tipa manifestacije). \n  2. Naziv tipa manifestacije. \n  4. Ikonicu tipa manifestacije. \n\n Takodje pozeljno je uneti i opis tipa manifestacije.  \n\n\n  Kada ste uneli informacije o tipu manifestacije, \n  kliknite dugme potvrdi.";
                var uri = new Uri("pack://application:,,,/Images/unos4.png");
                var bitmap = new BitmapImage(uri);
                image1.Source = bitmap;
            }
            else if (item.Name == "Brisanje")
            {
                Naslov = "Brisanje entiteta";
                Tekst = " \n\n Evidencija o geografskoj distribuciji manifestacija \n omogućava brisanje sva tri tipa entiteta, moguće je obrisati: \n  1. Manifestaciju \n  2. Tip manifestacije \n  3. Etiketu \n\n Da biste obrisali odredjeni entitet: \n\n  1. Kliknite na 'Pregled' na pocetnoj stranici. \n\n  1a. Otvorice vam se padajuci meni.  \n\n  2. Zatim odaberite grupu entiteta iz koje zelite da \n   obrisete odredjeni entitet. \n\n  2a. Potom ce vam se otvoriti pregled svih \n   entiteta (slika desno uokvireno zelenim pravougaonikom) \n   iz grupe entiteta koje ste odabrali. \n\n  3. Selektujte entitet koji zelite da obrisete. \n\n  4. Kliknite 'Obrisi'.";
                var uri = new Uri("pack://application:,,,/Images/brisanje1.png");
                var bitmap = new BitmapImage(uri);
                image1.Source = bitmap;
            }
            else if (item.Name == "Izmena")
            {
                Naslov = "Izmena entiteta";
                Tekst = " \n\n Evidencija o geografskoj distribuciji manifestacija \n omogućava izmenu sva tri tipa entiteta, moguće je izmeniti: \n  1. Manifestaciju \n  2. Tip manifestacije \n  3. Etiketu \n\n Da biste izmenili odredjeni entitet: \n\n  1. Kliknite na 'Pregled' na pocetnoj stranici. \n\n  1a. Otvorice vam se padajuci meni.  \n\n  2. Zatim odaberite grupu entiteta iz koje zelite da \n   izmenite odredjeni entitet. \n\n  2a. Potom ce vam se otvoriti pregled svih \n   entiteta (slika desno uokvireno zelenim pravougaonikom) \n   iz grupe entiteta koje ste odabrali. \n\n  3. Selektujte entitet koji zelite da izmenite. \n\n  4. Kliknite 'Izmeni'. \n\n  5. Izmenite zeljena polja i kliknite dugme potvrdi";
                var uri = new Uri("pack://application:,,,/Images/izmeni1.png");
                var bitmap = new BitmapImage(uri);
                image1.Source = bitmap;
            }
            else if (item.Name == "Drag")
            {
                Naslov = "Postavljanje manifestacije na mapu";
                Tekst = "\n\n Evidencija o geografskoj distribuciji manifestacija \n omogucava postavljanje manifestacija na mapu \n direktnom manipulacijom. \n\n\n Postavljanje manifestacija na mapu se \n vrsi na sledeci nacin: \n\n  1. Selektujete manifestaciju koju zelite da \n  postavite na mapu (iz liste manifestacija \n  u plavom pravougaoniku sa slike). \n\n  2. Pritisnete levi klik misa i zadrzite \n  sve dok ne pozicionirate manifestaciju na zeljenu \n  poziciju. \n\n  3. Kad ste postavili manifestaciju na zeljenu \n  poziciju, otpustite levi taster misa. ";
                var uri = new Uri("pack://application:,,,/Images/drag1.png");
                var bitmap = new BitmapImage(uri);
                image1.Source = bitmap;
            }
            else if (item.Name == "Info")
            {
                Naslov = "Informacije o manifestaciji";
                Tekst = "\n\n Evidencija o geografskoj distribuciji manifestacija \n omogucava pregled informacija svake \n manifestacije. \n\n\n Pregled informacija manifestacije se \n moze izvrsiti na 2 nacina: \n\n  Prvi nacin: \n\n  Klikom na pregled otvara se tabela \n  svih manifestacija gde klikom na pojedinacnu \n  mozete videti sve informacije. \n\n  Drugi nacin: \n\n  Desnim klikom na ikonicu manifestacije \n  na mapi otvara se prozor sa informacijama.";
                var uri = new Uri("pack://application:,,,/Images/info1.png");
                var bitmap = new BitmapImage(uri);
                image1.Source = bitmap;
            }
      

        }
       
    }
}

