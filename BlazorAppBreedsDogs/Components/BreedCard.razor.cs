using BlazorAppBreedsDogs.Models;
using BlazorAppBreedsDogs.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Color = MudBlazor.Color;


namespace BlazorAppBreedsDogs.Components
{
    public partial class BreedCard : ComponentBase
    {
        [Parameter]
        public int selectedBreedId { get; set; }
        [Parameter]
        public List<BreedDog> allBreedsDogs { get; set; } = new List<BreedDog>();
        

        [Inject]
        public BreedsDogsServices BreedsDogsServices { get; set; }

        private FavoriteBreedsService favoriteBreedsService = new FavoriteBreedsService();

        public bool isVisible { get; set; }
        public bool loading { get; set; }
        public Color favoriteColor { get; set; } = Color.Default;
        public List<int> favoritesIds { get; set; } = new List<int>();
        public int filterId { get; set; }
        public BreedDog? breedDogFiltered { get; set; } = null;

        List<BreedDog> displayedBreedsDogs { get; set; } = new List<BreedDog>();


        protected override async Task OnInitializedAsync()
        {
            loading = true;
            favoritesIds = favoriteBreedsService.GetFavorites();
     
            if (allBreedsDogs != null && allBreedsDogs.Count() != 0)
            {
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
            filterId = 0;
            breedDogFiltered = null;

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

    }
}
