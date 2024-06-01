using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Domain.Helpers
{
    public static class ImageHelper
    {
        public static string GetRamenImage(string ramenImage)
        {
            return ramenImage switch
            {
                "Chasu" => "https://tech.redventures.com.br/icons/ramen/ramenChasu.png",
                "Yasai Vegetarian" => "https://tech.redventures.com.br/icons/ramen/ramenKaraague.png", //TODO: Salva no s3
                "Karaague" => "https://tech.redventures.com.br/icons/ramen/ramenKaraague.png",
                _ => throw new Exception("Invalid ramen.")
            };
        }
    }
}
