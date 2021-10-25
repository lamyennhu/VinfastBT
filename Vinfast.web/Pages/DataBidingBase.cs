using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vinfast.web.Pages
{
    public class DataBidingBase : ComponentBase
    {
        protected string Name { get; set; } = "Tom";

        protected string Gender { get; set; } = "Male";
        protected string Color { get; set; } = "background-color:white";
        public string Description { get; set; } = string.Empty;
    }
}
