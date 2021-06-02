using B2Projekat;
using CRUD.Functions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD.ViewModel
{
    public class ProizvodiViewModel : BindableBase
    {
        public ProizvodiFunctions proizvodiFunctions;
        public ProizvodFunctions proizvodFunctions;
        public MasinaFunctions masinaFunctions;

        public MyICommand DodajCommand { get; set; }
        public MyICommand IzbrisiCommand { get; set; }
        public MyICommand DobaviSveCommand { get; set; }

        public ObservableCollection<Proizvodi> proizvodnje { get; set; }
        public ObservableCollection<int> sveMasineProizvodjaci { get; set; }
        public ObservableCollection<int> sviProizvodi { get; set; }

        private string addIdMasine;

        public string AddIdMasine
        {
            get { return addIdMasine; }
            set { addIdMasine = value; }
        }

        private string addIdProizvoda;

        public string AddIdProizvoda
        {
            get { return addIdProizvoda; }
            set { addIdProizvoda = value; }
        }

        private string deleteIdProizvoda;

        public string DeleteIdProizvoda
        {
            get { return deleteIdProizvoda; }
            set { deleteIdProizvoda = value; }
        }

        private string deleteIdMasine;

        public string DeleteIdMasine
        {
            get { return deleteIdMasine; }
            set { deleteIdMasine = value; }
        }


        public ProizvodiViewModel()
        {
            DodajCommand = new MyICommand(Dodaj);
            IzbrisiCommand = new MyICommand(Izbrisi);
            DobaviSveCommand = new MyICommand(DobaviSve);

            proizvodiFunctions = new ProizvodiFunctions();
            proizvodFunctions = new ProizvodFunctions();
            masinaFunctions = new MasinaFunctions();

            DobaviSve();
            DobaviProizvode();
            DobaviMasineProizvodjace();

            addIdMasine = "";
            addIdProizvoda = "";

            deleteIdProizvoda = "";
            deleteIdMasine = "";

        }

        private void DobaviMasineProizvodjace()
        {
            try
            {
                List<Masina> listaMasina = masinaFunctions.DobaviSve();
                sveMasineProizvodjaci = new ObservableCollection<int>();

                foreach (Masina masina in listaMasina)
                {
                    if(masina.Tip == "Proizvodjac")
                    {
                        sveMasineProizvodjaci.Add(masina.IDMasina);
                    }
                }
                OnPropertyChanged("sveMasineProizvodjaci");
            }
            catch
            {
                MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih masina proizvodjaca", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DobaviProizvode()
        {
            try
            {
                List<Proizvod> listaProizvoda = proizvodFunctions.DobaviSve();
                sviProizvodi = new ObservableCollection<int>();

                foreach (Proizvod proizvod in listaProizvoda)
                {
                    sviProizvodi.Add(proizvod.IdProizvoda);
                }
                OnPropertyChanged("sviProizvodi");
            }
            catch
            {
                MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DobaviSve()
        {
            try
            {
                List<Proizvodi> listaProizvodnje = proizvodiFunctions.DobaviSve();
                proizvodnje = new ObservableCollection<Proizvodi>();

                foreach (Proizvodi proizvodi in listaProizvodnje)
                {
                    proizvodnje.Add(proizvodi);
                }
                OnPropertyChanged("proizvodnje");
            }
            catch
            {
                MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih proizvodnja", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Izbrisi()
        {
            if (deleteIdMasine != "" && deleteIdProizvoda != "")
            {
                try
                {                   
                    if (!proizvodiFunctions.Izbrisi(Int32.Parse(deleteIdMasine), Int32.Parse(deleteIdProizvoda)))
                    {
                        MessageBox.Show("Unet je nepostojeci id proizvodnje!", "Brisanje proizvodnje", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else
                    {
                        DobaviSve();
                        DeleteIdMasine = "";
                        DeleteIdProizvoda = "";
                        OnPropertyChanged("DeleteIdMasine");
                        OnPropertyChanged("DeleteIdProizvoda");
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id-eva mora biti broj!", "Brisanje proizvodnje", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polje id-eva ne sme biti prazno!", "Brisanje proizvodnje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Dodaj()
        {
			if (addIdMasine != "" && addIdProizvoda != "")
			{
				int idMasine = Int32.Parse(addIdMasine);
				int idProizvoda = Int32.Parse(addIdProizvoda);
					
                if(!proizvodiFunctions.Dodaj(idMasine, idProizvoda))
                {
                    MessageBox.Show("Greska pri dodavanju nove proizvodnje!", "Dodavanje nove proizvodnje", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    DobaviSve();
                    AddIdMasine = "";
                    AddIdProizvoda = "";
                    OnPropertyChanged("AddIdMasine");
                    OnPropertyChanged("AddIdProizvoda");
                    
                }
			}
			else
			{
				MessageBox.Show("Polja ne smeju biti prazna!", "Dodavanje nove proizvodnje", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
    }
}
