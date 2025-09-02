using BlazorAppBreedsDogs.Models;
using BlazorAppBreedsDogs.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Color = MudBlazor.Color;


namespace BlazorAppBreedsDogs.Components.Pages
{
    public partial class Favorites
    {

        [Inject]
        public BreedsDogsServices BreedsDogsServices { get; set; }

        private int selectedBreedId { get; set; }
        private BreedCard? BreedCardRef { get; set; }
        private FavoriteBreedsService favoriteBreedsService { get; set; } = new FavoriteBreedsService();

        public bool isVisible { get; set; } = true;
        public bool loading { get; set; }
        public string? selectedBreedName { get; set; }
        public List<int> favoritesIds { get; set; } = new List<int>();

        List<BreedDog> allBreedsDogs { get; set; } = new List<BreedDog>();
        List<BreedsNames> breedsNames { get; set; } = new List<BreedsNames>();


        protected override async Task OnInitializedAsync()
        {
            loading = true;

            var allBreedsDogsFavorites = await BreedsDogsServices.GetAllBreeedsDogs();
            favoritesIds = favoriteBreedsService.GetFavorites();

            allBreedsDogs = allBreedsDogsFavorites.Where(f => favoritesIds.Contains(f.Id)).ToList();

            if (allBreedsDogs != null && allBreedsDogs.Count() != 0)
            {
                

                breedsNames = allBreedsDogs.Select(b => new BreedsNames { Id = b.Id, BreedName = b.BreedName }).ToList();

                isVisible = true;
            }
            else
            {
                isVisible = false;
            }

            loading = false;
        }

        public async Task onChangeBreedName(string breedName)
        {
            if (breedName == null)
            {
                selectedBreedId = 0;
                selectedBreedName = "";
                await BreedCardRef.GetAllBreeds();
                return;
            }

            BreedsNames selectedBreed = breedsNames.Where(n => n.BreedName == breedName).FirstOrDefault();

            selectedBreedId = selectedBreed.Id;
            selectedBreedName = selectedBreed.BreedName;
            await BreedCardRef.GetBreedFiltered(selectedBreedId);
        }

        private async Task<IEnumerable<string>> Search(string value, CancellationToken token)
        {
            if (string.IsNullOrEmpty(value)) return breedsNames.Select(v => v.BreedName);
            var selectedBreed = breedsNames.Where(v => v.BreedName.Contains(value, StringComparison.InvariantCultureIgnoreCase));
            return selectedBreed.Select(v => v.BreedName);
        }
    }
}
