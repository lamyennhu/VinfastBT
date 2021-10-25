using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinfast.models;
using Vinfast.web.Services;


namespace Vinfast.web.Pages
{
    public class ProductListBase : ComponentBase
    {
        [Inject]
        public IProduceService ProduceService { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public bool ShowFooter { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
            Products = (await ProduceService.GetProducts()).ToList();
        }
        protected int SelectedProductCount { get; set; } = 0;

        protected void ProductSelectionChange(bool isSelected)
        {
            if (isSelected)
            {
                SelectedProductCount++;
            }
            else
            {
                SelectedProductCount--;
            }
        }
    }
 }

