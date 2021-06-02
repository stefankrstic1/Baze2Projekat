using B2Projekat;
using CRUD.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.Interfaces
{
    public interface IMasinaFunction
    {
        bool Dodaj(int id, string proizvodjac, string model, string brzinaRada,  MasinaTip masinaTip);
        List<Masina> DobaviSve();
        bool Izbrisi(int id);
        bool Azuriraj(int id, string proizvodjac, string model, string brzinaRada);
    }
}
