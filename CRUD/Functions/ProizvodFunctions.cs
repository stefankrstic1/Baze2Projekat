using B2Projekat;
using CRUD.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Functions
{
    public class ProizvodFunctions : IProizvodFunctions
    {
        public bool Azuriraj(int id, string naziv, string vrsta, string paketid)
        {
            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Proizvod kojuAzuriram = db.Proizvods.Find(id);

                    if (kojuAzuriram == null)
                        return false;


                    if(naziv != "")
                    {
                        kojuAzuriram.Naziv = naziv;
                    }

                    if(vrsta != "")
                    {
                        kojuAzuriram.Vrsta = vrsta;
                    }

                    if(paketid != "")
                    {
                        kojuAzuriram.PaketIdPaketa = Int32.Parse(paketid);
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

        public List<Proizvod> DobaviSve()
        {
            List<Proizvod> ret = new List<Proizvod>();

            using (var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    ret = db.Proizvods.ToList();
                }
                catch
                {

                }
            }
            return ret;
        }

        public bool Dodaj(int id, string naziv, string vrsta, string paketid)
        {
            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Proizvod proizvod = new Proizvod();

                    proizvod.IdProizvoda = id;
                    proizvod.Naziv = naziv;
                    proizvod.Vrsta = vrsta;
                    proizvod.PaketIdPaketa = Int32.Parse(paketid);

                    db.Proizvods.Add(proizvod);
                    db.SaveChanges();
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
                    Proizvod obrisati = db.Proizvods.Find(id);

                    if (obrisati == null)
                    {
                        return false;
                    }
                    else
                    {

                        List<Proizvodi> proizvodis = db.Proizvodis.ToList();

                        foreach (Proizvodi item in proizvodis)
                        {
                            if (item.ProizvodIdProizvoda1 == id)
                            {
                                db.Proizvodis.Remove(item);
                            }
                        }

                        db.Proizvods.Remove(obrisati);
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
