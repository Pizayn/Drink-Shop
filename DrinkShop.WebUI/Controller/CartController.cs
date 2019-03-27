using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drink.Business.Abstract;
using Drink.Entities.Concrete;
using DrinkShop.Business.Abstract;
using DrinkShop.WebUI.Entities;
using DrinkShop.WebUI.Models;
using DrinkShop.WebUI.Services;
using DrinkShopCore.Entities;
using DrinkShopCore.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DrinkShop.WebUI.Controller
{
    [Authorize]
    public class CartController : Microsoft.AspNetCore.Mvc.Controller
    {
        Random r=new Random();
        DrinkShopContext context = new DrinkShopContext();
        private readonly UserManager<CustomIdentityUser> _userManager;

        private ICartService _cartService;
        private ICartSessionService _sessionService;
        private IProductService _productService;
        private IOrderLineService _orderLineService;
        private IOrderService _orderService;
      

        public CartController(ICartService cartService, ICartSessionService sessionService, IProductService productService, UserManager<CustomIdentityUser> userManager, IOrderLineService orderLineService, IOrderService orderService)
        {
            _cartService = cartService;
            _sessionService = sessionService;
            _productService = productService;
            _userManager = userManager;
            _orderLineService = orderLineService;
            _orderService = orderService;
        }

        public IActionResult AddToCart(int productId)
        {
           

            var addedProduct = _productService.GetByProductId(productId);
            var cart = _sessionService.GetCart();
            _cartService.AddToCart(cart,addedProduct);
          
            _sessionService.SetCart(cart);
            TempData.Add("message",String.Format("Your product {0},was succes added to cart! ", addedProduct.ProductName));
            return RedirectToAction("Index", "Home");

        }

        public IActionResult RemoveCart(int productId)
        {
            
            var cart = _sessionService.GetCart();
            _cartService.RemoveCart(cart,productId);
            _sessionService.SetCart(cart);
            TempData.Add("message",String.Format("Your product was succes remove your cart"));
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            var cart = _sessionService.GetCart();
            CartListViewModel model=new CartListViewModel()
            {
               Cart = cart,
            };
            return View(model);
        }

       

        

        public IActionResult Complete()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public IActionResult Complete(ShippingDetails shippingDetails)
        {
            if (ModelState.IsValid)
            {
                var cart = _sessionService.GetCart();
               
                foreach (var item in cart.CartLines)
                {
                    if (item.Product.UnitInStock>item.Quantity)
                    {
                        _productService.Update(new Product()
                        {
                            ProductName = item.Product.ProductName,
                            Id = item.Product.Id,
                            UnitPrice = item.Product.UnitPrice,
                            UnitInStock = (item.Product.UnitInStock - item.Quantity),
                            Image = item.Product.Image,
                            CategoryId = item.Product.CategoryId
                        });
                    }
                    else
                    {
                        TempData.Add("message", String.Format("insufficient product units(Available product Units={0})",item.Product.UnitInStock));
                        return View(shippingDetails);
                    }
                   
                }
                var order=new Order()
                {
                    Id = r.Next(10000,100000),
                    Total = cart.Total,
                    AccountId = _userManager.GetUserId(HttpContext.User),
                    Mahalle = shippingDetails.Neighborhood,
                    Name = shippingDetails.Name,
                    Sehir = shippingDetails.Province,
                    Semt = shippingDetails.District
                };
                _orderService.Add(order);

                foreach (var pr in cart.CartLines)
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.Quantity = pr.Quantity;
                    orderLine.Price = pr.Quantity * pr.Product.UnitPrice;
                    orderLine.ProductId = pr.Product.Id;
                    orderLine.AccountId = _userManager.GetUserId(HttpContext.User);
                    orderLine.OrderId = order.Id;
                   

                    _orderLineService.Add(orderLine);


                }
                cart.CartLines.Clear();
               
                



            }

            return RedirectToAction("Details");
        }

        public IActionResult Details(int orderId=0)

        {
            var details = from o in context.Orders
                join ol in context.OrderLines on o.Id equals ol.OrderId
                join p in context.Products on ol.ProductId equals p.Id
                where o.Id==orderId
                    
                select new OrderDetailsModel()
                {
                    ProductName = p.ProductName,
                    Image = p.Image, 
                    Price = ol.Price,
                    Quantity = ol.Quantity,
                    Mahalle = o.Mahalle,
                    Name = o.Name,
                    Sehir = o.Sehir,
                    Semt = o.Semt,
                    Total = o.Total,
                    Id = o.Id,
                    ProductId = p.Id
                    
                    
                };
            OrderDetailsListViewModel viewModel=new OrderDetailsListViewModel()
            {
                OrderDetailsModels = details.ToList(),

                Orders = _orderService.GetOrder(_userManager.GetUserId(HttpContext.User))
            };
            if (orderId != 0)
            {
                viewModel.Orders = _orderService.GetOrderById(orderId);
            }
            
            return View(viewModel);
        }


       
    }
}