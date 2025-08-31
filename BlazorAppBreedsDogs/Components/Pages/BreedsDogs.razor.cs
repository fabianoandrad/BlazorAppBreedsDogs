using BlazorAppBreedsDogs.Models;
using BlazorAppBreedsDogs.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Color = MudBlazor.Color;



namespace BlazorAppBreedsDogs.Components.Pages
{
    public partial class BreedsDogs : ComponentBase
    {
        [Inject]
        public BreedsDogsServices BreedsDogsServices { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private int selectedBreedId { get; set; }
        private FavoriteBreedsService favoriteBreedsService = new FavoriteBreedsService();

        public bool isVisible { get; set; }
        public bool loading { get; set; }
        public string selectedBreedName { get; set; }
        public Color favoriteColor { get; set; } = Color.Default;
        public List<int> favoritesIds { get; set; } = new List<int>();
        public int filterId { get; set; }
        public BreedDog? breedDogFiltered { get; set; } = null;

        public int SelectedBreedId
        {
            get => selectedBreedId;
            set
            {
                selectedBreedId = value;
                _ = GetBreedFiltered(selectedBreedId); // Chama o método ao alterar
            }
        }

        List<BreedDog> allBreedsDogs { get; set; } = new List<BreedDog>();
        List<BreedDog> displayedBreedsDogs { get; set; } = new List<BreedDog>();
        List<BreedsNames> breedsNames { get; set; } = new List<BreedsNames>();

      
        protected override async Task OnInitializedAsync()
        {
            loading = true;
            favoritesIds = favoriteBreedsService.GetFavorites();
            allBreedsDogs = await BreedsDogsServices.GetAllBreeedsDogs();
            if (allBreedsDogs != null && allBreedsDogs.Count() != 0)
            {
                breedsNames = allBreedsDogs.Select(b => new BreedsNames { Id = b.Id, BreedName = b.BreedName }).ToList();

                displayedBreedsDogs = new List<BreedDog>(allBreedsDogs);
                isVisible = true;
            }
            else
            {
                isVisible = false;
            }

            loading = false;
        }

        public async Task GetAllBreeds()
        {
            favoritesIds = favoriteBreedsService.GetFavorites();
            displayedBreedsDogs.Clear();
            displayedBreedsDogs = new List<BreedDog>(allBreedsDogs);
            StateHasChanged();
        }

        public async Task GetBreedFiltered(int value)
        {
            loading = true;
            filterId = value;
            displayedBreedsDogs.Clear();
            favoritesIds = favoriteBreedsService.GetFavorites();
            if (breedDogFiltered == null) breedDogFiltered = await BreedsDogsServices.GetFillterBreedDog(filterId);

            if (breedDogFiltered != null)
            {
                displayedBreedsDogs.Add(breedDogFiltered);
                isVisible = true;
            }
            else
            {
                isVisible = false;
            }

            loading = false;
            StateHasChanged();
        }

        public async Task onChangeBreedName(string breedName)
        {
            if (breedName == null)
            {
                breedDogFiltered = null;
                selectedBreedId = 0;
                selectedBreedName = "";
                filterId = 0;
                await GetAllBreeds();
                return;
            }

            BreedsNames selectedBreed = breedsNames.Where(n => n.BreedName == breedName).FirstOrDefault();

            selectedBreedId = selectedBreed.Id;
            selectedBreedName = selectedBreed.BreedName;
            await GetBreedFiltered(selectedBreedId);
        }

        public async Task onSaveFavorites(int breedsId)
        {
            if (favoriteBreedsService.IsFavorite(breedsId))
            {
                favoriteBreedsService.RemoveFavorite(breedsId);
                favoriteColor = Color.Default;
            }
            else
            {
                favoriteBreedsService.AddFavorite(breedsId);
                favoriteColor = Color.Error;
            }

            if (filterId != 0)
            {
                await GetBreedFiltered(filterId);
                return;
            }
            
            await GetAllBreeds();

        }

        private async Task<IEnumerable<string>> Search(string value, CancellationToken token)
        {
            if (string.IsNullOrEmpty(value)) return breedsNames.Select(v => v.BreedName);
            var selectedBreed = breedsNames.Where(v => v.BreedName.Contains(value, StringComparison.InvariantCultureIgnoreCase));
            return selectedBreed.Select(v => v.BreedName);
        }
    }
}
 