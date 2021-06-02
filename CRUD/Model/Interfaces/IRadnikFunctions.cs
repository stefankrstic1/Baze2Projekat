using B2Projekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model.Interfaces
{
    public interface IRadnikFunctions
    {
        bool Dodaj(int mbr, string ime, string prezime, string adresaStanovanja, string datumZaposlenja, string DatumRodjenja, RadnikTip radnikTip, string radniSati, string magacinID, string masinaId);
        List<Radnik> DobaviSve();
        bool Izbrisi(int mbr);
        bool Azuriraj(int mbr, string ime, string prezime, string adresaStanovanja, string datumZaposlenja, string DatumRodjenja, RadnikTip radnikTip, string radniSati, string magacinID, string masinaId);
    }
}
