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
    public class ProizvodViewModel : BindableBase
    {
        public PaketFunctions paketFunctions;
        public ProizvodFunctions proizvodFunctions;

        public MyICommand DodajCommand { get; set; }
        public MyICommand IzbrisiCommand { get; set; }
        public MyICommand AzurirajCommand { get; set; }
        public MyICommand DobaviSveCommand { get; set; }

        public ObservableCollection<Proizvod> proizvodi { get; set; }

        public ObservableCollection<int> sviPaketi { get; set; }

        private string addId;

        public string AddId
        {
            get { return addId; }
            set { addId = value; }
        }

        private string addNaziv;

        public string AddNaziv
        {
            get { return addNaziv; }
            set { addNaziv = value; }
        }

        private string addVrsta;

        public string AddVrsta
        {
            get { return addVrsta; }
            set { addVrsta = value; }
        }

        private string addIdPaketa;

        public string AddIdPaketa
        {
            get { return addIdPaketa; }
            set { addIdPaketa = value; }
        }

        private string updateId;

        public string UpdateId
        {
            get { return updateId; }
            set { updateId = value; }
        }

        private string updateNaziv;

        public string UpdateNaziv
        {
            get { return updateNaziv; }
            set { updateNaziv = value; }
        }

        private string updateVrsta;

        public string UpdateVrsta
        {
            get { return updateVrsta; }
            set { updateVrsta = value; }
        }

        private string updateIdPaketa;

        public string UpdateIdPaketa
        {
            get { return updateIdPaketa; }
            set { updateIdPaketa = value; }
        }

        private string deleteId;

        public string DeleteId
        {
            get { return deleteId; }
            set { deleteId = value; }
        }


        public ProizvodViewModel()
        {
            DodajCommand = new MyICommand(Dodaj);
            IzbrisiCommand = new MyICommand(Izbrisi);
            AzurirajCommand = new MyICommand(Azuriraj);
            DobaviSveCommand = new MyICommand(DobaviSve);

            paketFunctions = new PaketFunctions();
            proizvodFunctions = new ProizvodFunctions();

            DobaviSve();
            DobaviPakete();

            addId = "";
            addNaziv = "";
            addVrsta = "";
            addIdPaketa = "";

            updateId = "";
            updateNaziv = "";
            updateVrsta = "";
            updateIdPaketa = "";

            deleteId = "";
        }

        private void DobaviPakete()
        {
            try
            {
                List<Paket> listaPaketa = paketFunctions.DobaviSve();
                sviPaketi = new ObservableCollection<int>();

                foreach (Paket paket in listaPaketa)
                {
                    sviPaketi.Add(paket.IdPaketa);
                }
                OnPropertyChanged("sviPaketi");
            }
            catch
            {
                MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih paketa", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DobaviSve()
        {
            try
            {
                List<Proizvod> listaProizvoda = proizvodFunctions.DobaviSve();
                proizvodi = new ObservableCollection<Proizvod>();

                foreach (Proizvod proizvod in listaProizvoda)
                {
                    proizvodi.Add(proizvod);
                }
                OnPropertyChanged("proizvodi");
            }
            catch
            {
                MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Azuriraj()
        {
            if (updateId != "" && updateIdPaketa != "" && updateNaziv != "" && updateVrsta != "")
            {
                try
                {
                    int id = Int32.Parse(updateId);
                    if (id > 0)
                    {

                        if (!proizvodFunctions.Azuriraj(id, updateNaziv, updateVrsta, updateIdPaketa))
                        {
                            MessageBox.Show("Greska pri azuriranju!", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            DobaviSve();
                            UpdateId = "";
                            UpdateIdPaketa = "";
                            UpdateNaziv = "";
                            UpdateVrsta = "";
                            OnPropertyChanged("UpdateId");
                            OnPropertyChanged("UpdateIdPaketa");
                            OnPropertyChanged("UpdateNaziv");
                            OnPropertyChanged("UpdateVrsta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Polje id proizvoda da bude pozitivan broj", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id proizvoda mora da bude broj!", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polja ne smeju biti prazna!", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Izbrisi()
        {
            if (deleteId != "")
            {
                try
                {
                    int id = Int32.Parse(deleteId);
                    if (id > 0)
                    {
                        if (!proizvodFunctions.Izbrisi(id))
                        {
                            MessageBox.Show("Unet je nepostojeci id!", "Brisanje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                        else
                        {
                            DobaviSve();
                            DeleteId = "";
                            OnPropertyChanged("DeleteId");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Polje id mora biti pozitivan broj!", "Brisanje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id mora biti broj!", "Brisanje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polje id ne sme biti prazno!", "Brisanje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Dodaj()
        {
            if (addId != "" && addIdPaketa != "" && addNaziv != "" && addVrsta != "")
            {
                try
                {
                    int id = Int32.Parse(addId);
                    if (id > 0)
                    {                    

                        if (!proizvodFunctions.Dodaj(id, addNaziv, addVrsta, addIdPaketa))
                        {
                            MessageBox.Show("Greska pri dodavanju!", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            DobaviSve();
                            AddId = "";
                            AddIdPaketa = "";
                            AddNaziv = "";
                            AddVrsta = "";
                            OnPropertyChanged("AddId");
                            OnPropertyChanged("AddIdPaketa");
                            OnPropertyChanged("AddNaziv");
                            OnPropertyChanged("AddVrsta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Polje id da bude pozitivan broj", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id mora da bude broj!", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polja ne smeju biti prazna!", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
