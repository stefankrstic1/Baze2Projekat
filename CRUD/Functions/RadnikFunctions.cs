using B2Projekat;
using CRUD.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Functions
{
    public class RadnikFunctions : IRadnikFunctions
    {
        public bool Azuriraj(int mbr, string ime, string prezime, string adresaStanovanja, string datumZaposlenja, string DatumRodjenja, RadnikTip radnikTip, string radniSati, string magacinID, string masinaId)
        {
            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Radnik kojiAzuriram = db.Radniks.Find(mbr);

                    if (kojiAzuriram == null)
                        return false;

                    if (radnikTip != RadnikTip.NONE || radnikTip.ToString() == kojiAzuriram.Tip)
                    {
                        if(kojiAzuriram.Tip == "Dostavljac")
                        {
                            List<Paket> paketi = db.Pakets.ToList();
                            List<Proizvod> proizvodi = db.Proizvods.ToList();

                            foreach (Paket paket in paketi)
                            {
                                if (paket.DostavljacMBR == mbr)
                                {
                                    paket.DostavljacMBR = null;

                                    db.Entry(paket).State = System.Data.Entity.EntityState.Modified;
                                }
                            }
                        }

                        db.Radniks.Remove(kojiAzuriram);
                        db.SaveChanges();                      

                        switch (radnikTip)
                        {
                            case RadnikTip.UPROIZVODNJI:
                                UProizvodnji proizvodnji = new UProizvodnji();
                                proizvodnji.MBR = kojiAzuriram.MBR;
                                proizvodnji.Tip = "U proizvodnji";                               
                                if (ime != "")
                                {
                                    proizvodnji.Ime = ime;
                                }

                                if (prezime != "")
                                {
                                    proizvodnji.Prezime = prezime;
                                }

                                if (adresaStanovanja != "")
                                {
                                    proizvodnji.AdresaStanovanja = adresaStanovanja;
                                }

                                if (datumZaposlenja != "")
                                {
                                    proizvodnji.DatumZaposlenja = DateTime.Parse(datumZaposlenja);
                                }

                                if (DatumRodjenja != "")
                                {
                                    proizvodnji.DatumRodjenja = DateTime.Parse(DatumRodjenja);
                                }

                                if(masinaId != "")
                                {
                                    proizvodnji.MasinaIDMasina = Int32.Parse(masinaId);
                                }

                                if(radniSati != "")
                                {
                                    proizvodnji.BrojRadnihSati = radniSati;
                                }

                                db.Radniks.Add(proizvodnji);
                                db.SaveChanges();

                                break;
                            case RadnikTip.DOSTAVLJAC:
                                Dostavljac dostavljac = new Dostavljac();
                                dostavljac.Tip = "Dostavljac";
                                if (ime != "")
                                {
                                    dostavljac.Ime = ime;
                                }

                                if (prezime != "")
                                {
                                    dostavljac.Prezime = prezime;
                                }

                                if (adresaStanovanja != "")
                                {
                                    dostavljac.AdresaStanovanja = adresaStanovanja;
                                }

                                if (datumZaposlenja != "")
                                {
                                    dostavljac.DatumZaposlenja = DateTime.Parse(datumZaposlenja);
                                }

                                if (DatumRodjenja != "")
                                {
                                    dostavljac.DatumRodjenja = DateTime.Parse(DatumRodjenja);
                                }

                                db.Radniks.Add(dostavljac);
                                db.SaveChanges();
                                break;
                            case RadnikTip.MAGACIONER:
                                Magacioner magacioner = new Magacioner();
                                magacioner.Tip = "Magacioner";
                                if(ime != "")
                                {
                                    magacioner.Ime = ime;
                                }

                                if (prezime != "")
                                {
                                    magacioner.Prezime = prezime;
                                }

                                if (adresaStanovanja != "")
                                {
                                    magacioner.AdresaStanovanja = adresaStanovanja;
                                }

                                if (datumZaposlenja != "")
                                {
                                    magacioner.DatumZaposlenja = DateTime.Parse(datumZaposlenja);
                                }

                                if (DatumRodjenja != "")
                                {
                                    magacioner.DatumRodjenja = DateTime.Parse(DatumRodjenja);
                                }

                                db.Radniks.Add(magacioner);
                                db.SaveChanges();
                                break;
                        }


                    }
                    else
                    {


                        if (ime != "")
                        {
                            kojiAzuriram.Ime = ime;
                        }

                        if (prezime != "")
                        {
                            kojiAzuriram.Prezime = prezime;
                        }

                        if (adresaStanovanja != "")
                        {
                            kojiAzuriram.AdresaStanovanja = adresaStanovanja;
                        }

                        if (datumZaposlenja != "")
                        {
                            kojiAzuriram.DatumZaposlenja = DateTime.Parse(datumZaposlenja);
                        }

                        if (DatumRodjenja != "")
                        {
                            kojiAzuriram.DatumRodjenja = DateTime.Parse(DatumRodjenja);
                        }

                        db.Entry(kojiAzuriram).State = System.Data.Entity.EntityState.Modified;
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

        public List<Radnik> DobaviSve()
        {
            List<Radnik> ret = new List<Radnik>();

            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    ret = db.Radniks.ToList();
                }
                catch
                {

                }
            }
            return ret;
        }

        public bool Dodaj(int mbr, string ime, string prezime, string adresaStanovanja, string datumZaposlenja, string DatumRodjenja, RadnikTip radnikTip, string radniSati, string magacinID, string masinaId)
        {
            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Radnik radnik = new Radnik();

                    switch (radnikTip)
                    {
                        case RadnikTip.DOSTAVLJAC:
                            radnik = new Dostavljac();
                            radnik.MBR = mbr;
                            radnik.Ime = ime;
                            radnik.Prezime = prezime;
                            radnik.AdresaStanovanja = adresaStanovanja;
                            radnik.DatumRodjenja = DateTime.Parse(DatumRodjenja);
                            radnik.DatumZaposlenja = DateTime.Parse(datumZaposlenja);
                            radnik.Tip = "Dostavljac";

                            db.Radniks.Add(radnik);
                            db.SaveChanges();
                            break;
                        case RadnikTip.MAGACIONER:
                            radnik = new Magacioner();                           
                            Magacioner magacioner = new Magacioner();
                            magacioner.MBR = mbr;
                            magacioner.Ime = ime;
                            magacioner.Prezime = prezime;
                            magacioner.AdresaStanovanja = adresaStanovanja;
                            magacioner.DatumRodjenja = DateTime.Parse(DatumRodjenja);
                            magacioner.DatumZaposlenja = DateTime.Parse(datumZaposlenja);
                            magacioner.Tip = "Magacioner";
                            magacioner.MagacinID = Int32.Parse(magacinID);

                            db.Radniks.Add(magacioner);
                            db.SaveChanges();
                            break;
                        default:
                            UProizvodnji uProizvodnji = new UProizvodnji();
                            uProizvodnji.MBR = mbr;
                            uProizvodnji.Ime = ime;
                            uProizvodnji.Prezime = prezime;
                            uProizvodnji.AdresaStanovanja = adresaStanovanja;
                            uProizvodnji.DatumRodjenja = DateTime.Parse(DatumRodjenja);
                            uProizvodnji.DatumZaposlenja = DateTime.Parse(datumZaposlenja);
                            uProizvodnji.BrojRadnihSati = radniSati;
                            uProizvodnji.Tip = "U proizvodnji";
                            uProizvodnji.MasinaIDMasina = Int32.Parse(masinaId);

                            db.Radniks.Add(uProizvodnji);
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

        public bool Izbrisi(int mbr)
        {
            using (var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Radnik obrisati = db.Radniks.Find(mbr);

                    if(obrisati == null)
                    {
                        return false;
                    }
                    else
                    {
                        List<Paket> paketi = db.Pakets.ToList();
                        List<Proizvod> proizvodi = db.Proizvods.ToList();

                        foreach (Paket paket in paketi)
                        {
                            if(paket.DostavljacMBR == mbr)
                            {
                                paket.DostavljacMBR = null;

                                db.Entry(paket).State = System.Data.Entity.EntityState.Modified;
                            }
                        }

                        db.Radniks.Remove(obrisati);
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
