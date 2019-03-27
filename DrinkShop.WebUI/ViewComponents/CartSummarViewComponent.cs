using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkShop.WebUI.Models;
using DrinkShop.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace DrinkShop.WebUI.ViewComponents
{
    public class CartSummarViewComponent: ViewComponent
    {
        private ICartSessionService _cartSessionService;

        public CartSummarViewComponent(ICartSessionService cartSessionService)
        {
            _cartSessionService = cartSessionService;
        }

        public ViewViewComponentResult Invoke()
        {
           CartSummaryViewModel model=new CartSummaryViewModel()
           {
               Cart = _cartSessionService.GetCart(),
           };

           return View(model);
        }
    }
}
