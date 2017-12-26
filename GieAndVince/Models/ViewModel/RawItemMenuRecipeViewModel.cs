using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GieAndVince.Models.Db;

namespace GieAndVince.Models.ViewModel
{
    public class RawItemMenuRecipeViewModel
    {
        public List<RawItem> RawItemModel { get; set; }
        public List<MenuRecipe> MenuRecipeModel { get; set; }
    }
}