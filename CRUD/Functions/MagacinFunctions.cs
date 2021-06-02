using B2Projekat;
using CRUD.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Functions
{
    public class MagacinFunctions : IMagacinFunctions
    {
        public bool Azuriraj(int id, string stanje, int kapacitet)
        {
            using (var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Magacin kojiAzuriram = db.Magacins.Find(id);


                    if (kojiAzuriram == null)
                        return false;
                    

                    if(kapacitet != -1)
                    {
                        kojiAzuriram.Kapacitet = kapacitet;
                    }

                    if(stanje != "")
                    {
                        kojiAzuriram.Stanje = stanje;
                    }

                    db.Entry(kojiAzuriram).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public List<Magacin> DobaviSve()
        {
            List<Magacin> ret = new List<Magacin>();

            using (var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    ret = db.Magacins.ToList();
                }
                catch
                {

                }
            }
            return ret;

        }

        public bool Dodaj(int id, string stanje, int kapacitet)
        {
            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Magacin magacin = new Magacin();

                    magacin.ID = id;
                    magacin.Stanje = stanje;
                    magacin.Kapacitet = kapacitet;

                    db.Magacins.Add(magacin);
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
            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Magacin obrisati = db.Magacins.Find(id);

                    if(obrisati == null)
                    {
                        return false;
                    }
                    else
                    {
                        List<Radnik> radnici = db.Radniks.ToList();
                        List<Paket> paketi = db.Pakets.ToList();
                        List<Proizvod> proizvodi = db.Proizvods.ToList();

                        foreach (Radnik radnik in radnici)
                        {
                            if(radnik.Tip == "Magacioner")
                            {
                                (radnik as Magacioner).MagacinID = null;

                                db.Entry(radnik).State = System.Data.Entity.EntityState.Modified;
                            }
                        }

                        foreach (Paket paket in paketi)
                        {
                            if(paket.MagacinID == id)
                            {
                                db.Pakets.Remove(paket);

                                foreach (Proizvod proizvod in proizvodi)
                                {
                                    if(paket.IdPaketa == proizvod.PaketIdPaketa)
                                    {
                                        proizvod.PaketIdPaketa = null;

                                        db.Entry(proizvod).State = System.Data.Entity.EntityState.Modified;
                                    }
                                }
                            }
                        }


                        db.Magacins.Remove(obrisati);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
