using B2Projekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.Interfaces
{
    public interface IProizvodFunctions
    {
        bool Dodaj(int id, string naziv, string vrsta, string paketid);
        List<Proizvod> DobaviSve();
        bool Izbrisi(int id);
        bool Azuriraj(int id, string naziv, string vrsta, string paketid);
    }
}
