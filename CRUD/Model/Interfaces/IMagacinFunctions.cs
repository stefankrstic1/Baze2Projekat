using B2Projekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.Interfaces
{
    public interface IMagacinFunctions
    {
        bool Dodaj(int id, string stanje, int kapacitet);
        List<Magacin> DobaviSve();
        bool Izbrisi(int id);
        bool Azuriraj(int id, string stanje, int kapacitet);
    }
}
