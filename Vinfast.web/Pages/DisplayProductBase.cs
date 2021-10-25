using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinfast.models;

namespace Vinfast.web.Pages
{
    public class DisplayProductBase : ComponentBase
    {
        [Parameter]
        public Product Product { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }
        protected bool IsSelected { get; set; }

        [Parameter]
        public EventCallback<bool> OnProductSelection { get; set; }

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            IsSelected = (bool)e.Value;
            await OnProductSelection.InvokeAsync(IsSelected);
        }
    }
}
