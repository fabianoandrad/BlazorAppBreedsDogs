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
        private int selectedBreedId { get; set; }
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

        /*
         * TODO
         * criar uma classe com nome e id pra usar no campo de pesquisa
         */
        protected override async Task OnInitializedAsync()
        {
            loading = true;
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
            displayedBreedsDogs.Clear();
            displayedBreedsDogs = new List<BreedDog>(allBreedsDogs);
            StateHasChanged();
        }

        public async Task GetBreedFiltered(int value)
        {
            if (value == null) return;

            if (value == 0)
            {
                GetAllBreeds();
                return;
            }

            loading = true;
            displayedBreedsDogs.Clear();
            BreedDog breedDogFiltered = await BreedsDogsServices.GetFillterBreedDog(value);

            displayedBreedsDogs.Add(breedDogFiltered);

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
 