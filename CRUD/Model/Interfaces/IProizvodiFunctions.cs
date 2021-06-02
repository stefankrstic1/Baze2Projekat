using B2Projekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.Interfaces
{
    public interface IProizvodiFunctions
    {
        bool Dodaj(int idMasina, int idProizvod);
        List<Proizvodi> DobaviSve();
        bool Izbrisi(int idMasina, int idProizvod);
    }
}
