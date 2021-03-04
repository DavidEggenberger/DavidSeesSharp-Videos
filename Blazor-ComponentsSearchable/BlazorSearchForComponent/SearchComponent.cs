using BlazorSearchForComponent.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSearchForComponent
{
    public class SearchComponent : ComponentBase
    {
        public string[] Tags { get; set; }
        [CascadingParameter]
        public MainLayout MainLayout { get; set; }
        public bool IsSearchAfter
        {
            get
            {
                if(MainLayout.searchWord.Length > 3)
                {
                    return Tags.Any(t => t.ToUpper().Contains(MainLayout.searchWord.ToUpper()));
                }
                return false;
            }
        }
    }
}
