using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OraiMunkaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedMovie = (ComboBoxItem)filmChoose.SelectedItem;
            string jegy = "";
            if (diak.IsChecked == true)
            {
                jegy = "Diák";
            } 
            else if (normal.IsChecked == true)
            {
                jegy = "Normál";
            }
                else {
                jegy = "Nyugdíjas";
            }
                if (Nev_Validate() && Eletkor_Validate() && Film_Validate() && Jegytipus_Validate() && Jegyek_Validate() && Feltetelek_Valid())
            {
                int fizetendo = 0;
                if (happyfinish.IsChecked == true) { fizetendo += 30000; }
                if (popcorn.IsChecked == true) { fizetendo += 1500; }
                if (nachos.IsChecked == true) { fizetendo += 2000; }
                if (diak.IsChecked == true)
                {
                    fizetendo += Convert.ToInt32(jegyek.Text) * 2100;
                }
                else if(normal.IsChecked == true)
                {
                    fizetendo += Convert.ToInt32(jegyek.Text) * 3000;
                }
                else
                {
                    fizetendo += Convert.ToInt32(jegyek.Text) * 1500;
                }

                string kiiratas = "";
                if (happyfinish.IsChecked == true)
                {
                    kiiratas += "Happy Finish ";
                }
                if (popcorn.IsChecked == true)
                {
                    kiiratas += "Popcorn";
                }
                if (nachos.IsChecked == true)
                {
                    kiiratas += "Nachos ";
                }

                MessageBox.Show($"Sikeres foglalás!\n\n\nNév: {nev.Text}\nÉletkor: {eletkor.Text}\nFilm: {selectedMovie.Content}\nJegytípus: {jegy}\nJegyek száma: {jegyek.Text}\nExtrák: {kiiratas}\n\n\nFizetendő: {fizetendo} Ft", "Foglalás", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            ;
        }
        private bool Nev_Validate()
        {
            if (nev.Text.Trim() == "")
            {
                MessageBox.Show("A név nem lehet üres!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
                
            }
            else if (nev.Text.Trim().Length < 3)
            {
                MessageBox.Show("A névnek legalább 3 karakterből kell állnia!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool Eletkor_Validate()
        {
            try { int age = Convert.ToInt32(eletkor.Text);
                if (age <= 0 || age >= 120)
                {
                    MessageBox.Show("Az életkornak 0 és 120 között kell lennie!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    return true;
                }
                ;
            }
            catch (FormatException)
            {
                MessageBox.Show("Az életkorhoz számot adj meg!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private bool Jegyek_Validate()
        {
            try
            {
                int jegy = Convert.ToInt32(jegyek.Text);
                if (jegy < 1)
                {
                    MessageBox.Show("Legalább 1 jegyet venned kell!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (jegy > 10)
                {
                    MessageBox.Show("Maximum 10 jegyet vehetsz egyszerre!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("A jegyekhez számot adj meg!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private bool Feltetelek_Valid()
        {
            if (feltetel.IsChecked == false)
            {
                MessageBox.Show("Kérlek fogadd el a felhasználási feltételeket!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                feltetel.Focus();
                return false;
            }
            return true;
        }
        private bool Film_Validate()
        {
            ComboBoxItem selectedMovie = (ComboBoxItem)filmChoose.SelectedItem;
            if (selectedMovie == null || selectedMovie.Content.ToString() == "") {
                MessageBox.Show("Kérlek válassz ki egy filmet!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool Jegytipus_Validate()
        {
            if (diak.IsChecked == false && normal.IsChecked == false && nyugdijas.IsChecked == false)
            {
                MessageBox.Show("Kérlek válassz ki egy jegy típust!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        
    }
}