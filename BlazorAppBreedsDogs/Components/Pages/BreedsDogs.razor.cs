using BlazorAppBreedsDogs.Models;
using BlazorAppBreedsDogs.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace BlazorAppBreedsDogs.Components.Pages
{
    public partial class BreedsDogs : ComponentBase
    {
        [Inject]
        public BreedsDogsServices BreedsDogsServices { get; set; }
        public bool isVisible { get; set; }
        public bool loading { get; set; }
        public string breedName { get; set; }
        public string selectedBreedId { get; set; }

        List<BreedDog> breedsDogs = new List<BreedDog>();

        /*
         * TODO
         * criar uma classe com nome e id pra usar no campo de pesquisa
         */
        protected override async Task OnInitializedAsync()
        {
            GetAllBreeds();
        }

        public async void GetAllBreeds()
        {
            loading = true;
            breedsDogs = await BreedsDogsServices.GetAllBreeedsDogs();
            if (breedsDogs != null && breedsDogs.Count() != 0)
            {
                isVisible = true;
            }
            else
            {
                isVisible = false;
            }

            loading = false;
            StateHasChanged();
        }

        public async void GetBreedDog()
        {
            if (selectedBreedId == null) return;

            if (int.Parse(selectedBreedId) == 0)
            {
                GetAllBreeds();
                return;
            }

            loading = true;
            breedsDogs.Clear();
            BreedDog breedDogFiltered = await BreedsDogsServices.GetFillterBreedDog(int.Parse(selectedBreedId));

            breedsDogs.Add(breedDogFiltered);

            if (breedDogFiltered != null)
            {
                isVisible = true;
            }
            else
            {
                isVisible = false;
            }

            loading = false;
            StateHasChanged();
        }
    }
}
 