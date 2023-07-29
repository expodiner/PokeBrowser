using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using PokeBrowser.Http;


namespace PokeBrowser
{
    internal class ShellViewModel : BindableBase
    {
        private readonly PokeClient client;


        public ShellViewModel(PokeClient client)
        {
            this.client = client;
        }


        public ObservableCollection<PokeCatalogItem> CatalogItems
        {
            get => this._catalogItems;
            private set => this.SetProperty(ref this._catalogItems, value);
        }
        private ObservableCollection<PokeCatalogItem> _catalogItems;


        public PokeCatalogItem SelectedCatalogItem
        {
            get => this._selectedCatalogItem;
            set 
            {
                if (this.SetProperty(ref this._selectedCatalogItem, value))
                {
                    var response = this.client.GetPokemon(value.Url);

                    if (response.IsSuccessStatusCode)
                    {
                        this.Pokemon = response.GetBody();
                    }
                }
            }
        }
        private PokeCatalogItem _selectedCatalogItem;


        public Uri NextUrl
        {
            get => this._nextUrl;
            private set => this.SetProperty(ref this._nextUrl, value);
        }
        private Uri _nextUrl;


        public Pokemon Pokemon
        {
            get => this._pokemon;
            private set
            {
                if (this.SetProperty(ref this._pokemon, value))
                {
                    this.RaisePropertyChanged(nameof(this.Id));
                    this.RaisePropertyChanged(nameof(this.Name));
                    this.RaisePropertyChanged(nameof(this.Height));
                    this.RaisePropertyChanged(nameof(this.Weight));
                    this.RaisePropertyChanged(nameof(this.FrontImageSource));
                    this.RaisePropertyChanged(nameof(this.BackImageSource));

                }
            }
        }
        private Pokemon _pokemon;


        public int Id => this._pokemon?.Id ?? 0;


        public string Name => this._pokemon?.Name;


        public int Height => this._pokemon?.Height ?? 0;


        public int Weight => this._pokemon?.Weight ?? 0;


        public Uri FrontImageSource => this._pokemon?.Sprites.Front;


        public Uri BackImageSource => this._pokemon?.Sprites.Back;



        public DelegateCommand ExtendCatalogItems => new DelegateCommand(
            () =>
            {
                var response = this.client.GetCatalog(this.NextUrl);

                if (response.IsSuccessStatusCode)
                {
                    var catalog = response.GetBody();

                    this.CatalogItems.AddRange(catalog.Results);

                    this.NextUrl = catalog.Next;
                }
            },
            () => this.NextUrl != null
        ).ObservesProperty(() => this.NextUrl);


        public DelegateCommand LoadedCommand => new DelegateCommand(() =>
        {
            var response = this.client.GetCatalog();

            if (response.IsSuccessStatusCode)
            {
                var catalog = response.GetBody();

                this.CatalogItems = new ObservableCollection<PokeCatalogItem>(catalog.Results);

                this.NextUrl = catalog.Next;
            }
        });

    }

}
