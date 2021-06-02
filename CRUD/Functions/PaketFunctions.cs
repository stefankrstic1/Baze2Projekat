using B2Projekat;
using CRUD.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Functions
{
    public class PaketFunctions : IPaketFunctions
    {
        public bool Azuriraj(int id, string tezina, string pakerId, string dostavljacid, string magacionid)
        {
            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Paket kojiAzuriram = db.Pakets.Find(id);

                    if (kojiAzuriram == null)
                        return false;                           

                    if(tezina != "")
                    {
                        kojiAzuriram.Tezina = tezina;
                    }

                    if(pakerId != "")
                    {
                        kojiAzuriram.PakerIDMasina = Int32.Parse(pakerId);
                    }

                    if(dostavljacid != "")
                    {
                        kojiAzuriram.DostavljacMBR = Int32.Parse(dostavljacid);
                    }

                    if(magacionid != "")
                    {
                        kojiAzuriram.MagacinID = Int32.Parse(magacionid);
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

        public List<Paket> DobaviSve()
        {
            List<Paket> ret = new List<Paket>();

            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    ret = db.Pakets.ToList();
                }
                catch
                {

                }
            }
            return ret;
        }

        public bool Dodaj(int id, string tezina, string pakerId, string dostavljacid, string magacionid)
        {
            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Paket paket = new Paket();

                    paket.IdPaketa = id;
                    paket.Tezina = tezina;
                    paket.PakerIDMasina = Int32.Parse(pakerId);
                    paket.DostavljacMBR = Int32.Parse(dostavljacid);
                    paket.MagacinID = Int32.Parse(magacionid);

                    db.Pakets.Add(paket);
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
                    Paket obrisati = db.Pakets.Find(id);

                    if(obrisati == null)
                    {
                        return false;
                    }
                    else
                    {
                        List<Proizvod> proizvodi = db.Proizvods.ToList();

                        foreach (Proizvod proizvod in proizvodi)
                        {
                            if(proizvod.PaketIdPaketa == id)
                            {
                                proizvod.PaketIdPaketa = null;
                                db.Entry(proizvod).State = System.Data.Entity.EntityState.Modified;
                            }
                        }

                        db.Pakets.Remove(obrisati);
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
