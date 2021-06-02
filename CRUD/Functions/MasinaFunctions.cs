using B2Projekat;
using CRUD.Model.Enums;
using CRUD.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Functions
{
    public class MasinaFunctions : IMasinaFunction
    {
        public bool Azuriraj(int id, string proizvodjac, string model, string brzinaRada)
        {
            using (var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Masina kojuAzuriram = db.Masinas.Find(id);

                    if (kojuAzuriram == null)
                        return false;

                    if(proizvodjac != "")
                    {
                        kojuAzuriram.Proizvodjac = proizvodjac;
                    }

                    if(model != "")
                    {
                        kojuAzuriram.Model = model;
                    }

                    if(brzinaRada != "")
                    {
                        kojuAzuriram.BrzinaRada = Int32.Parse(brzinaRada);
                    }

                    db.Entry(kojuAzuriram).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public List<Masina> DobaviSve()
        {
            List<Masina> ret = new List<Masina>();

            using (var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    ret = db.Masinas.ToList();
                }
                catch
                {

                }
            }
            return ret;
        }

        public bool Dodaj(int id, string proizvodjac, string model, string brzinaRada, MasinaTip masinaTip)
        {
            using (var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Masina masina = new Masina();

                    switch (masinaTip)
                    {
                        case MasinaTip.PAKER:
                            Paker paker = new Paker();
                            paker.IDMasina = id;
                            paker.Proizvodjac = proizvodjac;
                            paker.BrzinaRada = Int32.Parse(brzinaRada);
                            paker.Model = model;
                            paker.Tip = "Paker";


                            db.Masinas.Add(paker);
                            db.SaveChanges();
                            break;
                        case MasinaTip.PROIZVODJAC:
                            Proizvodjac proizv = new Proizvodjac();
                            proizv.IDMasina = id;
                            proizv.Proizvodjac = proizvodjac;
                            proizv.BrzinaRada = Int32.Parse(brzinaRada);
                            proizv.Model = model;
                            proizv.Tip = "Proizvodjac";

                            db.Masinas.Add(proizv);
                            db.SaveChanges();
                            break;
                        default:
                            masina.IDMasina = id;
                            masina.Proizvodjac = proizvodjac;
                            masina.BrzinaRada = Int32.Parse(brzinaRada);
                            masina.Model = model;
                            masina.Tip = "None";

                            db.Masinas.Add(masina);
                            db.SaveChanges();
                            break;
                    }

                    
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public bool Izbrisi(int id)
        {
            using (var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Masina obrisati = db.Masinas.Find(id);

                    if (obrisati == null)
                    {
                        return false;
                    }
                    else
                    {
                        List<Radnik> radnici = db.Radniks.ToList();
                        List<Proizvodi> proizvodis = db.Proizvodis.ToList();
                        List<Paket> paketi = db.Pakets.ToList();
                        List<Proizvod> proizvods = db.Proizvods.ToList();

                        foreach (Radnik radnik in radnici)
                        {
                            if(radnik.Tip == "U proizvodnji")
                            {
                                if((radnik as UProizvodnji).MasinaIDMasina == id)
                                {
                                    db.Radniks.Remove(radnik);
                                }
                            }
                        }

                        foreach (Proizvodi proizvodi in proizvodis)
                        {
                            if(proizvodi.ProizvodjacIDMasina == id)
                            {
                                db.Proizvodis.Remove(proizvodi);
                            }
                        }

                        foreach (Paket paket in paketi)
                        {
                            if(paket.PakerIDMasina == id)
                            {
                                db.Pakets.Remove(paket);
                                foreach (Proizvod proizvod in proizvods)
                                {
                                    if(proizvod.PaketIdPaketa == paket.IdPaketa)
                                    {
                                        proizvod.PaketIdPaketa = null;

                                        db.Entry(proizvod).State = System.Data.Entity.EntityState.Modified;
                                    }
                                }

                            }    
                        }

                        db.Masinas.Remove(obrisati);
                        db.SaveChanges();
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
}
