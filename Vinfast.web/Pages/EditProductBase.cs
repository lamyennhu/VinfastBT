using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinfast.models;
using Vinfast.web.Services;

namespace Vinfast.web.Pages
{
    public class EditProductBase :ComponentBase
    {
        public Product Product { get; set; } = new Product();
        [Inject]
        public  IProduceService ProduceService { get; set; }
        [Parameter]
        public string Id { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Product = await ProduceService.GetProduct(int.Parse(Id));
        }
    }
}
