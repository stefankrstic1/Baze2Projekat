using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private RadnikViewModel radnikViewModel = new RadnikViewModel();
        private MagacinViewModel magacinViewModel = new MagacinViewModel();
        private MasinaViewModel masinaViewModel = new MasinaViewModel();
        private PaketViewModel paketViewModel = new PaketViewModel();
        private ProizvodiViewModel proizvodiViewModel = new ProizvodiViewModel();
        private ProizvodViewModel proizvodViewModel = new ProizvodViewModel();

        private BindableBase currentViewModel;

        public MyICommand<string> KarteCommand { get; private set; }

        public BindableBase CurrentViewModel
        {
            get
            {
                return currentViewModel;
            }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        public MainWindowViewModel()
        {
            currentViewModel = radnikViewModel;
            KarteCommand = new MyICommand<string>(Karte);
        }

        public void Karte(string name)
        {
            switch (name)
            {
                case "Radnici":
                    if(CurrentViewModel == radnikViewModel)
                    {
                        break;
                    }
                    CurrentViewModel = radnikViewModel;
                    break;
                case "Magacini":
                    if(CurrentViewModel == magacinViewModel)
                    {
                        break;
                    }
                    CurrentViewModel = magacinViewModel;
                    break;
                case "Masine":
                    if(CurrentViewModel == masinaViewModel)
                    {
                        break;
                    }
                    CurrentViewModel = masinaViewModel;
                    break;
                case "Paketi":
                    if(CurrentViewModel == paketViewModel)
                    {
                        break;
                    }
                    CurrentViewModel = paketViewModel;
                    break;
                case "Proizvodnja masine":
                    if(CurrentViewModel == proizvodiViewModel)
                    {
                        break;
                    }
                    CurrentViewModel = proizvodiViewModel;
                    break;
                case "Proizvodi":
                    if(CurrentViewModel == proizvodViewModel)
                    {
                        break;
                    }
                    CurrentViewModel = proizvodViewModel;
                    break;
            }
        }
    }
}
