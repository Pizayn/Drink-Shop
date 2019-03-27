using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace DrinkShop.WebUI.ViewComponents
{
    public class AccountLoginViewComponent:ViewComponent
    {

        public ViewViewComponentResult Invoke()
        {
            return View();
        }
    }

   
}
