using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinfast.models;
using Vinfast.web.Services;

namespace Vinfast.web.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        public Product Product { get; set; } = new Product();
        [Inject]
        public  IProduceService ProduceService { get; set; }
        [Parameter]
        public string Id { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Product = await ProduceService.GetProduct(int.Parse(Id));
        }

        protected string Coordinates { get; set; }

        protected void Mouse_Move(MouseEventArgs e)
        {
            Coordinates = $"X = {e.ClientX } Y = {e.ClientY}";
        }

        //-----------------HIDE FOOTER--------------------------
        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;

        protected void Button_Click()
        {
            if (ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide Footer";
            }
        }

    }
}
