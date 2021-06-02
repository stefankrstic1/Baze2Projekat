using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using B2Projekat;
using CRUD.Functions;
using CRUD.Model.Interfaces;

namespace CRUD.ViewModel
{
	public class RadnikViewModel : BindableBase
	{
		public RadnikFunctions Function;
		public MagacinFunctions magacinFunction;
		public MasinaFunctions masinaFunction;

        #region gluposti
        private string addTip;

        public string AddTip
        {
            get { return addTip; }
            set { addTip = value; }
        }


        public MyICommand DodajCommand { get; set; }
		public MyICommand IzbrisiCommand { get; set; }
		public MyICommand AzurirajCommand { get; set; }
		public MyICommand DobaviSveCommand { get; set; }
        private string addMBR;

        public string AddMBR
        {
            get { return addMBR; }
            set { addMBR = value; }
        }

        private string addIme;

        public string AddIme
        {
            get { return addIme; }
            set { addIme = value; }
        }

        private string addPrezime;

        public string AddPrezime
        {
            get { return addPrezime; }
            set { addPrezime = value; }
        }

        private string addAdresaStanovanja;

        public string AddAdresaStanovanja
        {
            get { return addAdresaStanovanja; }
            set { addAdresaStanovanja = value; }
        }

        private string addDatumZaposlenja;

        public string AddDatumZaposlenja
        {
            get { return addDatumZaposlenja; }
            set { addDatumZaposlenja = value; }
        }

        private string addDatumRodenja;

        public string AddDatumRodjenja
        {
            get { return addDatumRodenja; }
            set { addDatumRodenja = value; }
        }

        private string updateMBR;

        public string UpdateMBR
        {
            get { return updateMBR; }
            set { updateMBR = value; }
        }

        private string updateIme;

        public string UpdateIme
        {
            get { return updateIme; }
            set { updateIme = value; }
        }

        private string updatePrezime;

        public string UpdatePrezime
        {
            get { return updatePrezime; }
            set { updatePrezime = value; }
        }

        private string updateAdresaStanovanja;

        public string UpdateAdresaStanovanja
        {
            get { return updateAdresaStanovanja; }
            set { updateAdresaStanovanja = value; }
        }

        private string updateDatumZaposlenja;

        public string UpdateDatumZaposlenja
        {
            get { return updateDatumZaposlenja; }
            set { updateDatumZaposlenja = value; }
        }

        private string updateDatumRodenja;

        public string UpdateDatumRodjenja
        {
            get { return updateDatumRodenja; }
            set { updateDatumRodenja = value; }
        }

        private string updateTip;

        public string UpdateTip
        {
            get { return updateTip; }
            set { updateTip = value; }
        }

        private string deleteMBR;

        public string DeleteMBR
        {
            get { return deleteMBR; }
            set { deleteMBR = value; }
        }

        private string addBrojRadnihSati;

        public string AddBrojRadnihSati
		{
            get { return addBrojRadnihSati; }
            set { addBrojRadnihSati = value; }
        }

        private string addMagacinId;

        public string AddMagacinId
		{
            get { return addMagacinId; }
            set { addMagacinId = value; }
        }

        private string updateRadniSati;

        public string UpdateRadniSati
		{
            get { return updateRadniSati; }
            set { updateRadniSati = value; }
        }

        private string updateMagacinId;

        public string UpdateMagacinId
		{
            get { return updateMagacinId; }
            set { updateMagacinId = value; }
        }

        private string addMasinaId;

        public string AddMasinaId
		{
            get { return addMasinaId; }
            set { addMasinaId = value; }
        }

        private string updateMasinaId;

        public string UpdateMasinaId
		{
            get { return updateMasinaId; }
            set { updateMasinaId = value; }
        }


        #endregion
        public ObservableCollection<Radnik> radnici { get; set; }
		public ObservableCollection<UProizvodnji> proizvodjaci { get; set; }
		public ObservableCollection<Magacioner> magacioneri { get; set; }

		public ObservableCollection<int> magacini { get; set; }
		public ObservableCollection<int> masine { get; set; }



		public RadnikViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);
			AzurirajCommand = new MyICommand(Azuriraj);
			DobaviSveCommand = new MyICommand(DobaviSve);

			Function = new RadnikFunctions();
			magacinFunction = new MagacinFunctions();
			masinaFunction = new MasinaFunctions();

			DobaviSve();
			DobaviMagacine();
			DobaviMasine();

			addMBR = "";
			addIme = "";
			addPrezime = "";
			addAdresaStanovanja = "";
			addDatumZaposlenja = "";
			addDatumRodenja = "";
			addTip = "";
			addBrojRadnihSati = "";
			addMagacinId = "";
			addMasinaId = "";

			updateMBR = "";
			updateIme = "";
			updatePrezime = "";
			updateAdresaStanovanja = "";
			updateDatumZaposlenja = "";
			updateDatumRodenja = "";
			updateTip = "";
			updateRadniSati = "";
			updateMagacinId = "";
			updateMasinaId = "";

			deleteMBR = "";
		}

        private void DobaviMasine()
        {
            try
            {
				List<Masina> listaMasin = masinaFunction.DobaviSve();
				masine = new ObservableCollection<int>();

                foreach (Masina masina in listaMasin)
                {
					masine.Add(masina.IDMasina);
                }
				OnPropertyChanged("masine");
            }
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih masina", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

        private void DobaviMagacine()
        {
            try
            {
				List<Magacin> listaMagacina = magacinFunction.DobaviSve();
				magacini = new ObservableCollection<int>();

                foreach (Magacin magacin in listaMagacina)
                {
					magacini.Add(magacin.ID);
                }
				OnPropertyChanged("magacini");
            }
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih magacina", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

        public void Dodaj()
		{
			if (addMBR != "" && addIme != "" && addPrezime != "" && addAdresaStanovanja != "" && addDatumZaposlenja != "" && addDatumRodenja != "")
			{
				try
				{
					int mbr = Int32.Parse(addMBR);
					if (mbr > 0)
					{
						DateTime dtZap, dtRodj;
						string[] formats = { "d/M/yyyy" };
						if (!DateTime.TryParseExact(addDatumZaposlenja, formats, CultureInfo.InvariantCulture,
												  DateTimeStyles.None, out dtZap))
						{
							MessageBox.Show("Format za datum je 1/1/2001", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
							return;
						}

						if (!DateTime.TryParseExact(addDatumRodenja, formats, CultureInfo.InvariantCulture,
												  DateTimeStyles.None, out dtRodj))
						{
							MessageBox.Show("Format za datum je 1/1/2001", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
							return;
						}

						RadnikTip radnikTip = RadnikTip.DOSTAVLJAC;

						string tip = addTip.Split(' ')[1];

                        switch (tip)
                        {
							case "Proizvodnja":
								if (addBrojRadnihSati == "")
								{			
									MessageBox.Show("Radni sati nisu napisani", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
									return;
								}

								if(Int32.TryParse(addBrojRadnihSati, out int n))
                                {
									if (n <= 0)
									{
										MessageBox.Show("Broj radnih sati ne moze da bude negativan ili nula", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
										return;
									}
									radnikTip = RadnikTip.UPROIZVODNJI;
                                }
                                else
                                {
									MessageBox.Show("Broj radnih sati mora biti broj", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
									return;
                                }			
								break;
							case "Magacioner":
								radnikTip = RadnikTip.MAGACIONER;
								break;
							default:
								radnikTip = RadnikTip.DOSTAVLJAC;
								break;
                        }
					

						if (!Function.Dodaj(mbr, addIme, addPrezime, addAdresaStanovanja, addDatumZaposlenja, addDatumRodenja, radnikTip, addBrojRadnihSati, addMagacinId, addMasinaId))
						{
							MessageBox.Show("Greska pri dodavanju!", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							DobaviMagacine();
							DobaviMasine();

							AddMBR = "";
							AddIme = "";
							AddPrezime = "";
							AddAdresaStanovanja = "";
							AddDatumZaposlenja = "";
							AddDatumRodjenja = "";
							AddTip = "";
							OnPropertyChanged("AddMBR");
							OnPropertyChanged("AddIme");
							OnPropertyChanged("AddPrezime");
							OnPropertyChanged("AddAdresaStanovanja");
							OnPropertyChanged("AddDatumZaposlenja");
							OnPropertyChanged("AddDatumRodjenja");
							OnPropertyChanged("AddTip");
						}
					}
					else
					{
						MessageBox.Show("Polje MBR da bude pozitivan broj", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje MBR mora da bude broj!", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja ne smeju biti prazna!", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSve()
		{
			try
			{
				List<Radnik> listaRadnika = Function.DobaviSve();
				radnici = new ObservableCollection<Radnik>();
				proizvodjaci = new ObservableCollection<UProizvodnji>();
				magacioneri = new ObservableCollection<Magacioner>();

				foreach (Radnik radnik in listaRadnika)
				{
					if(radnik.Tip == "U proizvodnji")
                    {
						UProizvodnji proizv = radnik as UProizvodnji;
						proizvodjaci.Add(proizv);
                    }

					if (radnik.Tip == "Magacioner")
					{
						Magacioner magacioner = radnik as Magacioner;
						magacioneri.Add(magacioner);
					}

					radnici.Add(radnik);
				}
				OnPropertyChanged("radnici");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih radnika", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public void Izbrisi()
		{
			if (deleteMBR != "")
			{
				try
				{
					int mbr = Int32.Parse(deleteMBR);
					if (mbr > 0)
					{
						if (!Function.Izbrisi(mbr))
						{
							MessageBox.Show("Unet je nepostojeci MBR!", "Brisanje radnika", MessageBoxButton.OK, MessageBoxImage.Error);
							
						}
						else
						{
							DobaviSve();
							DeleteMBR = "";
							OnPropertyChanged("DeleteMBR");
						}
					}
					else
					{
						MessageBox.Show("Polje MBR mora biti pozitivan broj!", "Brisanje radnika", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje MBR mora biti broj!", "Brisanje radnika", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polje MBR ne sme biti prazno!", "Brisanje radnika", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Azuriraj()
		{
			if (updateMBR != "" && updateIme != "" && updatePrezime != "" && updateAdresaStanovanja != "" && updateDatumZaposlenja != "" && updateDatumRodenja != "")
			{
				try
				{
					int mbr = Int32.Parse(updateMBR);
					if (mbr > 0)
					{
						DateTime dtZap, dtRodj;
						string[] formats = { "d/M/yyyy" };
						if (!DateTime.TryParseExact(updateDatumZaposlenja, formats, CultureInfo.InvariantCulture,
												  DateTimeStyles.None, out dtZap))
						{
							MessageBox.Show("Format za datum je 1/1/2001", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
							return;
						}

						if (!DateTime.TryParseExact(updateDatumRodenja, formats, CultureInfo.InvariantCulture,
												  DateTimeStyles.None, out dtRodj))
						{
							MessageBox.Show("Format za datum je 1/1/2001", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
							return;
						}

						RadnikTip radnikTip = RadnikTip.DOSTAVLJAC;
						if (updateTip != "")
						{
							updateTip = updateTip.Split(' ')[1];
						}

						switch (updateTip)
						{
							case "Proizvodnja":
								if(updateRadniSati == "" && Int32.TryParse(updateRadniSati,out int n))
                                {
									if(n <= 0)
                                    {
										MessageBox.Show("Broj radnih sati ne moze da bude negativan ili nula", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
										return;
									}
									MessageBox.Show("Radni sati nisu napisani", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
									return;
                                }
								radnikTip = RadnikTip.UPROIZVODNJI;
								break;
							case "Magacioner":
								radnikTip = RadnikTip.MAGACIONER;
								break;
							case "Dostavljac":
								radnikTip = RadnikTip.DOSTAVLJAC;
								break;
							default:
								radnikTip = RadnikTip.NONE;
								break;
						}

						if(updateMagacinId != "")
                        {
							if(!Int32.TryParse(updateMagacinId, out int n))
                            {
								MessageBox.Show("Magacin id je pogresan!", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
								return;
                            }
                        }


						if (!Function.Azuriraj(mbr, updateIme, updatePrezime, updateAdresaStanovanja, updateDatumZaposlenja, updateDatumRodenja, radnikTip, updateRadniSati, updateMagacinId, updateMasinaId))
						{
							MessageBox.Show("Greska pri azuriranju!", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							DobaviMagacine();
							DobaviMasine();
							UpdateMBR = "";
							UpdateIme = "";
							UpdatePrezime = "";
							UpdateAdresaStanovanja = "";
							UpdateDatumZaposlenja = "";
							UpdateDatumRodjenja = "";
							UpdateTip = "";
							OnPropertyChanged("UpdateMBR");
							OnPropertyChanged("UpdateIme");
							OnPropertyChanged("UpdatePrezime");
							OnPropertyChanged("UpdateAdresaStanovanja");
							OnPropertyChanged("UpdateDatumZaposlenja");
							OnPropertyChanged("UpdateDatumRodjenja");
							OnPropertyChanged("UpdateTip");
						}
					}
					else
					{
						MessageBox.Show("Polje MBR da bude pozitivan broj", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje MBR mora da bude broj!", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja ne smeju biti prazna!", "Dodavanje novog radnika", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
