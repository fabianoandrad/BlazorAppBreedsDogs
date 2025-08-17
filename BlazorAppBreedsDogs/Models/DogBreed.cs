using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppBreedsDogs.Models
{
    public class DogBreed
    {
        public int Id { get; set; }
        [JsonProperty("name")]
        public string BreedName { get; set; }
        public string Temperament { get; set; }
        public string Origin { get; set; }
        [JsonProperty("bred_for")]
        public string BredFor { get; set; }
        [JsonProperty("life_span")]
        public string LifeSpan { get; set; }
        public Weight Weight { get; set; }
        public Height Height { get; set; }
        //public string ReferenceImageId { get; set; }
        public DogImage Image { get; set; }
    }
}
