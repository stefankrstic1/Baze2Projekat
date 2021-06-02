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
    public class MagacinViewModel : BindableBase
    {
        public MagacinFunctions Function;

        public ObservableCollection<Magacin> magacini { get; set; }

        public MyICommand DodajCommand { get; set; }
        public MyICommand IzbrisiCommand { get; set; }
        public MyICommand AzurirajCommand { get; set; }
        public MyICommand DobaviSveCommand { get; set; }

        private string addId;

        public string AddId
        {
            get { return addId; }
            set { addId = value; }
        }

        private string addStanje;

        public string AddStanje
        {
            get { return addStanje; }
            set { addStanje = value; }
        }

        private string addKapacitet;

        public string AddKapacitet
        {
            get { return addKapacitet; }
            set { addKapacitet = value; }
        }

        private string updateId;

        public string UpdateId
        {
            get { return updateId; }
            set { updateId = value; }
        }

        private string updateStanje;

        public string UpdateStanje
        {
            get { return updateStanje; }
            set { updateStanje = value; }
        }

        private string updateKapacitet;

        public string UpdateKapacitet
        {
            get { return updateKapacitet; }
            set { updateKapacitet = value; }
        }

        private string deleteId;

        public string DeleteId
        {
            get { return deleteId; }
            set { deleteId = value; }
        }


        public MagacinViewModel()
        {
            DodajCommand = new MyICommand(Dodaj);
            IzbrisiCommand = new MyICommand(Izbrisi);
            AzurirajCommand = new MyICommand(Azuriraj);
            DobaviSveCommand = new MyICommand(DobaviSve);

            Function = new MagacinFunctions();

            DobaviSve();

            addId = "";
            addStanje = "";
            addKapacitet = "";

            updateId = "";
            updateStanje = "";
            updateKapacitet = "";

            deleteId = "";
        }

        public void Dodaj()
        {
            if(addId != "" && addKapacitet != "" && addStanje != "")
            {
                try
                {
                    int id = Int32.Parse(addId);
                    if(id > 0)
                    {
                        if(Int32.TryParse(addKapacitet, out int n))
                        {
                            if (n <= 0)
                            {
                                MessageBox.Show("Kapacitet magacina ne moze da bude negativan ili nula", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            if (!Function.Dodaj(id, addStanje, n))
                            {
                                MessageBox.Show("Greska pri dodavanju!", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                DobaviSve();
                                AddId = "";
                                AddKapacitet = "";
                                AddStanje = "";
                                OnPropertyChanged("AddId");
                                OnPropertyChanged("AddKapacitet");
                                OnPropertyChanged("AddStanje");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kapacitet magacina mora biti broj", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        
                        
                    }
                    else
                    {
                        MessageBox.Show("Polje id magacina da bude pozitivan broj", "Dodavanje novog magacina", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id magacina mora da bude broj!", "Dodavanje novog magacina", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polja ne smeju biti prazna!", "Dodavanje novog magacina", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Izbrisi()
        {
            if (deleteId != "")
            {
                try
                {
                    int id = Int32.Parse(deleteId);
                    if (id > 0)
                    {
                        if (!Function.Izbrisi(id))
                        {
                            MessageBox.Show("Unet je nepostojeci id magacina!", "Brisanje magacina", MessageBoxButton.OK, MessageBoxImage.Error);

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
                        MessageBox.Show("Polje id magacina mora biti pozitivan broj!", "Brisanje magacina", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id magacina mora biti broj!", "Brisanje magacina", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polje id magacina ne sme biti prazno!", "Brisanje magacina", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Azuriraj()
        {
            if (updateId != "" && updateKapacitet != "" && updateStanje != "")
            {
                try
                {
                    int id = Int32.Parse(updateId);
                    if (id > 0)
                    {
                        if (Int32.TryParse(updateKapacitet, out int n))
                        {
                            if (n <= 0)
                            {
                                MessageBox.Show("Kapacitet magacina ne moze da bude negativan ili nula", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            
                            if(!Function.Azuriraj(id, updateStanje, n))
                            {
                                MessageBox.Show("Greska pri azuriranju!", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                DobaviSve();
                                UpdateId = "";
                                UpdateStanje = "";
                                UpdateKapacitet = "";
                                OnPropertyChanged("UpdateId");
                                OnPropertyChanged("UpdateStanje");
                                OnPropertyChanged("UpdateKapacitet");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Kapacitet magacina mora biti broj", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Polje id magacina da bude pozitivan broj", "Dodavanje novog magacina", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Polje id magacina mora da bude broj!", "Dodavanje novog magacina", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Polja ne smeju biti prazna!", "Dodavanje novog magacina", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DobaviSve()
        {
            try
            {
                List<Magacin> magacins = Function.DobaviSve();
                magacini = new ObservableCollection<Magacin>();

                foreach (Magacin magacin in magacins)
                {
                    magacini.Add(magacin);
                }
                OnPropertyChanged("magacini");
            }
            catch
            {
                MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih radnika", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
