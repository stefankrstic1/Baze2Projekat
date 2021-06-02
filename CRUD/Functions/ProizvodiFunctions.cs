using B2Projekat;
using CRUD.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Functions
{
    public class ProizvodiFunctions : IProizvodiFunctions
    {
        public List<Proizvodi> DobaviSve()
        {
            List<Proizvodi> ret = new List<Proizvodi>();

            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    ret = db.Proizvodis.ToList();
                }
                catch
                {

                }
            }
            return ret;
        }

        public bool Dodaj(int idMasina, int idProizvod)
        {
            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Proizvodi proizvodi = new Proizvodi();
                    proizvodi.ProizvodjacIDMasina = idMasina;
                    proizvodi.ProizvodIdProizvoda1 = idProizvod;

                    db.Proizvodis.Add(proizvodi);
                    db.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public bool Izbrisi(int idMasina, int idProizvod)
        {
            using(var db = new ProizvodnaOrganizacijaContainer())
            {
                try
                {
                    Proizvodi obrisati = db.Proizvodis.Find(idMasina, idProizvod);

                    if(obrisati == null)
                    {
                        return false;
                    }


                    db.Proizvodis.Remove(obrisati);
                    db.SaveChanges();
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
