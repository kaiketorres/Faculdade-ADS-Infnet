using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace AgenciaTurismo.Pages
{
    public class DescontoModel : PageModel
    {
        public delegate decimal CalculateDiscountDelegate(decimal originalPrice);

        [BindProperty]
        public decimal InputPrice { get; set; }

        public decimal DiscountedPrice { get; set; }

        public void OnGet()
        {
            InputPrice = 100.0m;
            DiscountedPrice = 0.0m;
        }

        public void OnPost()
        {
           
            CalculateDiscountDelegate applyTenPercentDiscount = (originalPrice) => originalPrice * 0.90m;

           
            DiscountedPrice = applyTenPercentDiscount(InputPrice);

          
        }
    }
}
