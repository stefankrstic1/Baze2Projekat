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
    public class PaketViewModel : BindableBase
    {
        public PaketFunctions paketFunction;
        public MagacinFunctions magacinFunction;
        public MasinaFunctions masinaFunction;
        public RadnikFunctions radnikFunction;

        public MyICommand DodajCommand { get; set; }
        public MyICommand IzbrisiCommand { get; set; }
        public MyICommand AzurirajCommand { get; set; }
        public MyICommand DobaviSveCommand { get; set; }

        public ObservableCollection<Paket> paketi { get; set; } 

        public ObservableCollection<int> sviMagacini { get; set; }

        public ObservableCollection<int> svePakerMasine { get; set; }
        public ObservableCollection<int> sviDostavljaci { get; set; }

        private string addId;

        public string AddId
        {
            get { return addId; }
            set { addId = value; }
        }

        private string addTezina;

        public string AddTezina
        {
            get { return addTezina; }
            set { addTezina = value; }
        }

        private string addMBR;

        public string AddMBR
        {
            get { return addMBR; }
            set { addMBR = value; }
        }

        private string addIdMasine;

        public string AddIdMasine
        {
            get { return addIdMasine; }
            set { addIdMasine = value; }
        }

        private string addIdMagacina;

        public string AddIdMagacina
        {
            get { return addIdMagacina; }
            set { addIdMagacina = value; }
        }

        private string updateId;

        public string UpdateId
        {
            get { return updateId; }
            set { updateId = value; }
        }

        private string updateTezina;

        public string UpdateTezina
        {
            get { return updateTezina; }
            set { updateTezina = value; }
        }

        private string updateIdDostavljaca;

        public string UpdateIdDostavljaca
        {
            get { return updateIdDostavljaca; }
            set { updateIdDostavljaca = value; }
        }

        private string updateIdMasine;

        public string UpdateIdMasine
        {
            get { return updateIdMasine; }
            set { updateIdMasine = value; }
        }

        private string updateIdMagacina;

        public string UpdateIdMagacina
        {
            get { return updateIdMagacina; }
            set { updateIdMagacina = value; }
        }

        private string deleteId;

        public string DeleteId
        {
            get { return deleteId; }
            set { deleteId = value; }
        }


        public PaketViewModel()
        {
            DodajCommand = new MyICommand(Dodaj);
            IzbrisiCommand = new MyICommand(Izbrisi);
            AzurirajCommand = new MyICommand(Azuriraj);
            DobaviSveCommand = new MyICommand(DobaviSve);

            magacinFunction = new MagacinFunctions();
            masinaFunction = new MasinaFunctions();
            radnikFunction = new RadnikFunctions();
            paketFunction = new PaketFunctions();

            DobaviSve();
            DobaviSveMagacine();
            DobaviSvePakere();
            DobaviSveDostavljace();

            addId = "";
            addTezina = "";
            addMBR = "";
            addIdMasine = "";
            addIdMagacina = "";

            updateId = "";
            updateTezina = "";
            updateIdDostavljaca = "";
            updateIdMasine = "";
            updateIdMagacina = "";

            deleteId = "";
        }

        private void DobaviSveDostavljace()
        {
            try
            {
                List<Radnik> listaRadnika = radnikFunction.DobaviSve();
                sviDostavljaci = new ObservableCollection<int>();

                foreach (Radnik radnik in listaRadnika)
                {
                   if(radnik.Tip == "Dostavljac")
                    {
                        sviDostavljaci.Add(radnik.MBR);
                    }
                }
                OnPropertyChanged("sviDostavljaci");
            }
            catch
            {
                MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih dostavljaca", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DobaviSvePakere()
        {
            try
            {
                List<Masina> listaMasina = masinaFunction.DobaviSve();
                svePakerMasine = new ObservableCollection<int>();

                foreach (Masina masina in listaMasina)
                {
                    if(masina.Tip == "Paker")
                    {
                        svePakerMasine.Add(masina.IDMasina);
                    }
                }
                OnPropertyChanged("svePakerMasine");
            }
            catch
            {
                MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih paker masina", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DobaviSveMagacine()
        {
            try
            {
                List<Magacin> listaMagacina = magacinFunction.DobaviSve();
                sviMagacini = new ObservableCollection<int>();

                foreach (Magacin magacin in listaMagacina)
                {
                    sviMagacini.Add(magacin.ID);
                }
                OnPropertyChanged("sviMagacini");
            }
            catch
            {
                MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih magacina", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DobaviSve()
        {
            try
            {
                List<Paket> listaPaketa = paketFunction.DobaviSve();
                paketi = new ObservableCollection<Paket>();

                foreach (Paket paket in listaPaketa)
                {
                    paketi.Add(paket);
                }
                OnPropertyChanged("paketi");
            }
            catch
            {
                MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih paketa", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Azuriraj()
        {
            if (updateId != "" && updateTezina != "" && updateIdDostavljaca != "" && updateIdMagacina != "" && updateIdMasine != "")
            {
                try
                {
                    int id = Int32.Parse(updateId);
                    if (id > 0)
                    {

                        if (!paketFunction.Azuriraj(id, updateTezina, updateIdMasine, updateIdDostavljaca, updateIdMagacina))
                        {
                            MessageBox.Show("Greska pri azuriranju!", "Dodavanje novog paketa", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            DobaviSve();
                            UpdateId = "";
                            UpdateTezina = "";
                            UpdateIdDostavljaca = "";
                            UpdateIdMagacina = "";
                            UpdateIdMasine = "";
                            OnPropertyChanged("UpdateId");
                            OnPropertyChanged("UpdateTezina");
                            OnPropertyChanged("UpdateIdDostavljaca");
                            OnPropertyChanged("UpdateIdMagacina");
                            OnPropertyChanged("UpdateIdMasine");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Polje id paketa mora da bude pozitivan broj", "Dodavanje novog paketa", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id paketa mora da bude broj!", "Dodavanje novog paketa", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polja ne smeju biti prazna!", "Dodavanje novog paketa", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    

        private void Izbrisi()
        {
            if (deleteId != "")
            {
                try
                {
                    int mbr = Int32.Parse(deleteId);
                    if (mbr > 0)
                    {
                        if (!paketFunction.Izbrisi(mbr))
                        {
                            MessageBox.Show("Unet je nepostojeci id paketa!", "Brisanje paketa", MessageBoxButton.OK, MessageBoxImage.Error);

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
                        MessageBox.Show("Polje id paketa mora biti pozitivan broj!", "Brisanje paketa", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id paketa mora biti broj!", "Brisanje paketa", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polje id paketa ne sme biti prazno!", "Brisanje paketa", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Dodaj()
        {
            if (addId != "" && addTezina != "" && addMBR != "" && addIdMagacina != "" && addIdMasine != "")
            {
                try
                {
                    int id = Int32.Parse(addId);
                    if (id > 0)
                    {
                        
                        if (!paketFunction.Dodaj(id, addTezina, addIdMasine, addMBR, addIdMagacina))
                        {
                            MessageBox.Show("Greska pri dodavanju!", "Dodavanje novog paketa", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            DobaviSve();
                            AddId = "";
                            AddTezina = "";
                            AddMBR = "";
                            AddIdMagacina = "";
                            AddIdMasine = "";
                            OnPropertyChanged("AddId");
                            OnPropertyChanged("AddTezina");
                            OnPropertyChanged("AddMBR");
                            OnPropertyChanged("AddIdMagacina");
                            OnPropertyChanged("AddIdMasine");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Polje id mora da bude pozitivan broj", "Dodavanje novog paketa", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id mora da bude broj!", "Dodavanje novog paketa", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polja ne smeju biti prazna!", "Dodavanje novog paketa", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

