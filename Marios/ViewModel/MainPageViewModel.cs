using System;
using System.Collections.Generic;

using System.Text;

namespace Marios.ViewModel
{
    using Marios.Model;
    using Marios.Services;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Character> Characterslista { get; set; }

        private ObservableCollection<Amiibo> _AmmibosList;
        public ObservableCollection<Amiibo> AmmibosList
        {
            get { return _AmmibosList; }
            set { _AmmibosList = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; set; }
        public MainPageViewModel()
        {
          
            SearchCommand = new Command(async (loqueescribi) =>
            {
                IsBusy = true;
                var character = loqueescribi as Character;
                if (character != null)
                {
                    //esta es una cadena interpolada
                    string url = $"https://www.amiiboapi.com/api/amiibo/?character={character.name}";
                    var service = new HttpHelperServices<Amiibos>();
                    var amiibos = await service.GetRestServiceDataAsync(url);
                    AmmibosList = new ObservableCollection<Amiibo>(amiibos.amiibo);
                }
                IsBusy = false;
            });
        }
        public async Task LoadCharacter()
        {
            IsBusy = true;
            var url = "https://www.amiiboapi.com/api/character/";
            //uso de la clase que implementamos previamente en services
            //Le paso mi medoto de model
            var service = new HttpHelperServices<Characters>();
            var characters = await service.GetRestServiceDataAsync(url);
            Characterslista = new ObservableCollection<Character>(characters.amiibo);
            IsBusy = false;
        }
    }
}
