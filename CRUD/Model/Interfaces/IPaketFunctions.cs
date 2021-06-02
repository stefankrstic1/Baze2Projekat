using B2Projekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.Interfaces
{
    public interface IPaketFunctions
    {
        bool Dodaj(int id, string tezina, string pakerId, string dostavljacid, string magacionid);
        List<Paket> DobaviSve();
        bool Izbrisi(int id);
        bool Azuriraj(int id, string tezina, string pakerId, string dostavljacid, string magacionid);
    }
}
