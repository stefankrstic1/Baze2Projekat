using B2Projekat;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace CRUD.View
{
    /// <summary>
    /// Interaction logic for RadnikView.xaml
    /// </summary>
    public partial class RadnikView : UserControl
    {
        public RadnikView()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string temp = comboBoxTip.SelectedItem.ToString().Split(' ')[1];
            switch (temp)
            {
                case "Proizvodnja":
                    labelIdMagacin.Visibility = Visibility.Hidden;
                    txtBrojRadnihSati.Visibility = Visibility.Visible;
                    labelBrojRadnihSati.Visibility = Visibility.Visible;
                    cmbIdMagacin.Visibility = Visibility.Hidden;
                    labelIdMasina.Visibility = Visibility.Visible;
                    cmbIdMasina.Visibility = Visibility.Visible;
                    break;
                case "Dostavljac":
                    labelIdMagacin.Visibility = Visibility.Hidden;
                    txtBrojRadnihSati.Visibility = Visibility.Hidden;
                    labelBrojRadnihSati.Visibility = Visibility.Hidden;
                    cmbIdMagacin.Visibility = Visibility.Hidden;
                    labelIdMasina.Visibility = Visibility.Hidden;
                    cmbIdMasina.Visibility = Visibility.Hidden;
                    break;
                case "Magacioner":
                    labelIdMagacin.Visibility = Visibility.Visible;
                    txtBrojRadnihSati.Visibility = Visibility.Hidden;
                    labelBrojRadnihSati.Visibility = Visibility.Hidden;
                    cmbIdMagacin.Visibility = Visibility.Visible;
                    labelIdMasina.Visibility = Visibility.Hidden;
                    cmbIdMasina.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string temp = cmbTip.SelectedItem.ToString().Split(' ')[1];
            switch (temp)
            {
                case "Proizvodnja":
                    labelIdMagacinUpdate.Visibility = Visibility.Hidden;
                    txtBrojRadnihSatiUpdate.Visibility = Visibility.Visible;
                    labelBrojRadnihSatiUpdate.Visibility = Visibility.Visible;
                    cmbIdMagacinUpdate.Visibility = Visibility.Hidden;
                    labelIdMasinaUpdate.Visibility = Visibility.Visible;
                    cmbIdMasinaUpdate.Visibility = Visibility.Visible;
                    break;
                case "Dostavljac":
                    labelIdMagacinUpdate.Visibility = Visibility.Hidden;
                    txtBrojRadnihSatiUpdate.Visibility = Visibility.Hidden;
                    labelBrojRadnihSatiUpdate.Visibility = Visibility.Hidden;
                    cmbIdMagacinUpdate.Visibility = Visibility.Hidden;
                    labelIdMasinaUpdate.Visibility = Visibility.Hidden;
                    cmbIdMasinaUpdate.Visibility = Visibility.Hidden;
                    break;
                case "Magacioner":
                    labelIdMagacinUpdate.Visibility = Visibility.Visible;
                    txtBrojRadnihSatiUpdate.Visibility = Visibility.Hidden;
                    labelBrojRadnihSatiUpdate.Visibility = Visibility.Hidden;
                    cmbIdMagacinUpdate.Visibility = Visibility.Visible;
                    labelIdMasinaUpdate.Visibility = Visibility.Hidden;
                    cmbIdMasinaUpdate.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}
