using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GieAndVince.Models.Db;

namespace GieAndVince.Models.ViewModel
{
    public class CombinedModels
    {
        public List<RawItem> RawItemModel { get; set; }
        public MenuRecipe MenuRecipeModel { get; set; }
        public List<MenuRecipe> MenuRecipeList { get; set; }
    }
}