using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank_Applikation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Kunde> kundeListe;
        List<Konto> kontoListe;
        public MainWindow()
        {
            InitializeComponent();
            kundeListe = new List<Kunde>();

            Kunde k1 = new Kunde("Frederik Pedersen", "Cirkelvej 20");
            Kunde k2 = new Kunde("Thomas Larsen", "brovej 4");
            Kunde k3 = new Kunde("Morten Jensen", "Solsortevej 52");
            Kunde k4 = new Kunde("Ida Thomsen", "Lærkevej 12");

            kundeListe.Add(k1);
            kundeListe.Add(k2);
            kundeListe.Add(k3);
            kundeListe.Add(k4);

            Konto konto1 = new Konto(k1, 20000.0, "Børne Konto");
            Konto konto2 = new Konto(k2, 170.0, "");
            Konto konto3 = new Konto(k3, 1500.0, "Personlig");
            Konto konto4 = new Konto(k4, 4000.0, "Budget");
            Konto konto5 = new Konto(k3, 5000.0, "Fælles konto");
            konto5.AddKunde(k4);


            kontoListe = new List<Konto>();
            kontoListe.Add(konto1);
            kontoListe.Add(konto2);
            kontoListe.Add(konto3);
            kontoListe.Add(konto4);
            kontoListe.Add(konto5);

            foreach (Kunde fillKunde in kundeListe)
            {
                CBKunde.Items.Add(fillKunde);
            }

            lblTransferTo.Visibility = Visibility.Hidden;
            CBTransfer.Visibility = Visibility.Hidden;

        }

        private void CBKundeTest_SelectionChanged(Object sender, SelectionChangedEventArgs e)
        {
            CBKonto.Items.Clear();

            foreach (Konto k in kundeListe.Find(x => x == CBKunde.SelectedItem).kontoliste)
            {
                CBKonto.Items.Add(k);
            }

            CBKonto.SelectedIndex = 0;

        }

        private void CBKontoTest_SelectionChanged(Object sender, SelectionChangedEventArgs e)
        {
            CBTransfer.Items.Clear();

            foreach (Kunde kun in kundeListe)
            {
                foreach (Konto kon in kun.kontoliste)
                {
                    if (kon != CBKonto.SelectedItem)
                    {
                        CBTransfer.Items.Add(kon);
                    }
                    else lblKontoAmountDisplay.Content = ((Konto)CBKonto.SelectedItem).belob.ToString("N2") + " kr.";
                }
            }

        }

        private void RBTransaktionsType_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Name.Equals("RBtrans") && rb.IsChecked == true)
            {
                lblTransferTo.Visibility = Visibility.Visible;
                CBTransfer.Visibility = Visibility.Visible;
            }
            else
            {
                lblTransferTo.Visibility = Visibility.Hidden;
                CBTransfer.Visibility = Visibility.Hidden;
            }
        }

        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (CBKunde.SelectedItem != null)
            {
                // Sikre at det er en int eller double der bliver indtastet i beløb feltet
                try
                {
                    int kundeIndex = CBKunde.SelectedIndex;
                    if (RBIndsaet.IsChecked == true)
                        kontoListe.Find(x => x.navn == ((Konto)CBKonto.SelectedValue).navn).belob += double.Parse(txtAmount.Text);
                    else if (RBHaeve.IsChecked == true)
                        kontoListe.Find(x => x.navn == ((Konto)CBKonto.SelectedValue).navn).belob -= double.Parse(txtAmount.Text);
                    else if (RBtrans.IsChecked == true)
                    {
                        kontoListe.Find(x => x.navn == ((Konto)CBTransfer.SelectedValue).navn).belob += double.Parse(txtAmount.Text);
                        kontoListe.Find(x => x.navn == ((Konto)CBKonto.SelectedValue).navn).belob -= double.Parse(txtAmount.Text);
                    }
                    else MessageBox.Show("vælg venligst én transaktions metode");
                }
                catch
                {
                    MessageBox.Show("indtast venligst et tal i beløb feltet");
                }
                lblKontoAmountDisplay.Content = ((Konto)CBKonto.SelectedItem).belob.ToString("N") + " kr.";
            }
            else MessageBox.Show("Vælg en konto");
        }
    }
}
