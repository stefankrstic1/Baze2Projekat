using B2Projekat;
using CRUD.Functions;
using CRUD.Model.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CRUD.ViewModel
{
    public class MasinaViewModel : BindableBase
    {
        public MasinaFunctions Function;

        public MyICommand DodajCommand { get; set; }
        public MyICommand IzbrisiCommand { get; set; }
        public MyICommand AzurirajCommand { get; set; }
        public MyICommand DobaviSveCommand { get; set; }

        public ObservableCollection<Masina> masine { get; set; }

        private string addIdMasina;

        public string AddIdMasina
        {
            get { return addIdMasina; }
            set { addIdMasina = value; }
        }

        private string addModel;

        public string AddModel
        {
            get { return addModel; }
            set { addModel = value; }
        }

        private string addProizvodjac;

        public string AddProizvodjac
        {
            get { return addProizvodjac; }
            set { addProizvodjac = value; }
        }

        private string addBrzinaRada;

        public string AddBrzinaRada
        {
            get { return addBrzinaRada; }
            set { addBrzinaRada = value; }
        }

        private string updateIdMasina;

        public string UpdateIdMasina
        {
            get { return updateIdMasina; }
            set { updateIdMasina = value; }
        }

        private string updateModel;

        public string UpdateModel
        {
            get { return updateModel; }
            set { updateModel = value; }
        }

        private string updateProizvodjac;

        public string UpdateProizvodjac
        {
            get { return updateProizvodjac; }
            set { updateProizvodjac = value; }
        }

        private string updateBrzinaRada;

        public string UpdateBrzinaRada
        {
            get { return updateBrzinaRada; }
            set { updateBrzinaRada = value; }
        }

        private string deleteIdMasina;

        public string DeleteIdMasina
        {
            get { return deleteIdMasina; }
            set { deleteIdMasina = value; }
        }

        private string addTip;

        public string AddTip
        {
            get { return addTip; }
            set { addTip = value; }
        }

        private string updateTip;

        public string UpdateTip
        {
            get { return updateTip; }
            set { updateTip = value; }
        }


        public MasinaViewModel()
        {
            DodajCommand = new MyICommand(Dodaj);
            IzbrisiCommand = new MyICommand(Izbrisi);
            AzurirajCommand = new MyICommand(Azuriraj);
            DobaviSveCommand = new MyICommand(DobaviSve);

            Function = new MasinaFunctions();

            DobaviSve();

            addIdMasina = "";
            addModel = "";
            addProizvodjac = "";
            addBrzinaRada = "";
            addTip = "";

            updateIdMasina = "";
            updateModel = "";
            updateProizvodjac = "";
            updateBrzinaRada = "";
            updateTip = "";

            deleteIdMasina = "";
        }

        public void Dodaj()
        {
            if (addIdMasina != "" && addModel != "" && addProizvodjac != "" && addBrzinaRada != "")
            {
                try
                {
                    int id = Int32.Parse(addIdMasina);
                    if (id > 0)
                    {                     
                        MasinaTip masinaTip = MasinaTip.NONE;

                        string tip = addTip.Split(' ')[1];

                        switch (tip)
                        {
                            case "Paker":
                                masinaTip = MasinaTip.PAKER;
                                break;
                            case "Proizvodjac":
                                masinaTip = MasinaTip.PROIZVODJAC;
                                break;
                        }

                        if (Int32.TryParse(addBrzinaRada, out int n))
                        {
                            if (n <= 0)
                            {
                                MessageBox.Show("Brzina Rada ne moze da bude negativan ili nula", "Dodavanje nove masine", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Brzina Rada mora biti broj", "Dodavanje nove masine", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        if (!Function.Dodaj(id, addProizvodjac, addModel, addBrzinaRada, masinaTip))
                        {
                            MessageBox.Show("Greska pri dodavanju!", "Dodavanje nove masine", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            DobaviSve();
                            AddIdMasina = "";
                            AddBrzinaRada = "";
                            AddModel = "";
                            AddProizvodjac = "";
                            AddTip = "";
                            OnPropertyChanged("AddIdMasina");
                            OnPropertyChanged("AddBrzinaRada");
                            OnPropertyChanged("AddModel");
                            OnPropertyChanged("AddProizvodjac");
                            OnPropertyChanged("AddTip");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Polje id da bude pozitivan broj", "Dodavanje nove masine", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id mora da bude broj!", "Dodavanje nove masine", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polja ne smeju biti prazna!", "Dodavanje nove masine", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Izbrisi()
        {
            if (deleteIdMasina != "")
            {
                try
                {
                    int id = Int32.Parse(deleteIdMasina);
                    if (id > 0)
                    {
                        if (!Function.Izbrisi(id))
                        {
                            MessageBox.Show("Unet je nepostojeci id!", "Brisanje masine", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                        else
                        {
                            DobaviSve();
                            DeleteIdMasina = "";
                            OnPropertyChanged("DeleteIdMasina");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Polje id mora biti pozitivan broj!", "Brisanje masine", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id mora biti broj!", "Brisanje masine", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polje id ne sme biti prazno!", "Brisanje masine", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Azuriraj()
        {
            if (updateIdMasina != "" && updateModel != "" && updateBrzinaRada != "" && updateProizvodjac != "")
            {
                try
                {
                    int id = Int32.Parse(updateIdMasina);
                    if (id > 0)
                    {

                        if (Int32.TryParse(updateBrzinaRada, out int n))
                        {
                            if (n <= 0)
                            {
                                MessageBox.Show("Brzina Rada ne moze da bude negativan ili nula", "Dodavanje nove masine", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Brzina Rada mora biti broj", "Dodavanje nove masine", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        if (!Function.Azuriraj(id, updateProizvodjac, updateModel, updateBrzinaRada))
                        {
                            MessageBox.Show("Greska pri azuriranju!", "Dodavanje nove masine", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            DobaviSve();
                            UpdateIdMasina = "";
                            UpdateBrzinaRada = "";
                            UpdateModel = "";
                            UpdateProizvodjac = "";
                            UpdateTip = "";
                            OnPropertyChanged("UpdateIdMasina");
                            OnPropertyChanged("UpdateBrzinaRada");
                            OnPropertyChanged("UpdateModel");
                            OnPropertyChanged("UpdateProizvodjac");
                            OnPropertyChanged("UpdateTip");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Polje id da bude pozitivan broj", "Dodavanje nove masine", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id mora da bude broj!", "Dodavanje nove masine", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polja ne smeju biti prazna!", "Dodavanje nove masine", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DobaviSve()
        {
            try
            {
                List<Masina> listaMasina = Function.DobaviSve();
                masine = new ObservableCollection<Masina>();

                foreach (Masina masina in listaMasina)
                {
                    masine.Add(masina);
                }
                OnPropertyChanged("masine");
            }
            catch
            {
                MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih masina", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
