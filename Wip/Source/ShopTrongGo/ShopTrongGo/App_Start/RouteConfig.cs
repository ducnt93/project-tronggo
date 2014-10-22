﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopTrongGo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               "RouteIndex",
               "trang-chu",
               new
               {
                   controller = "Home",
                   action = "Index",
               }
           );
            routes.MapRoute(
                "RouteDetail",
                "{id}/san-pham-{TenKhongDau}",
                new
                {
                    controller = "Product",
                    action = "Details",
                    id = UrlParameter.Optional
                }
            );
            routes.MapRoute(
               "RouteRegisterAccount",
               "tai-khoan/dang-ky",
               new
               {
                   controller = "Account",
                   action = "Register"
               }
           );
            routes.MapRoute(
               "RouteLoginAccount",
               "tai-khoan/dang-nhap",
               new
               {
                   controller = "Account",
                   action = "Login"
               }
           );
            routes.MapRoute(
               "RouteLogoutAccount",
               "tai-khoan/dang-xuat",
               new
               {
                   controller = "Account",
                   action = "Logout"
               }
           );
            routes.MapRoute(
               "RouteRegisterSuccess",
               "tai-khoan/dang-thanh-cong",
               new
               {
                   controller = "Account",
                   action = "RegisterSuccess"
               }
           );
            routes.MapRoute(
               "RouteForgotPass",
               "tai-khoan/quen-mat-khau",
               new
               {
                   controller = "Account",
                   action = "ForgotPass"
               }
           );
            routes.MapRoute(
              "RouteRePassSuccess",
              "tai-khoan/doi-mat-khau-thanh-cong",
              new
              {
                  controller = "Account",
                  action = "RePassSuccess"
              }
          );
            routes.MapRoute(
                "RouteAllProduct",
                "{idDm}/danh-sach-san-pham-{TenKhongDau}",
                new
                {
                    controller = "Product",
                    action = "All",
                    id = "idDm"
                }
            );
            routes.MapRoute(
                "RouteAllNews",
                "danh-sach-tin-tuc",
                new
                {
                    controller = "News",
                    action = "AllNews"
                }
            );
            routes.MapRoute(
                "RoutDetailNews",
                "{id}/{TenKhongDau}",
                new
                {
                    controller = "News",
                    action = "DetailNews"
                }
            );
            routes.MapRoute(
                "RouteAllService",
                "danh-sach-dich-vu",
                new
                {
                    controller = "News",
                    action = "AllServices"
                }
            );
            routes.MapRoute(
                "RoutDetailServices",
                "{id}/{TenKhongDau}",
                new
                {
                    controller = "News",
                    action = "DetailServices"
                }
            );

            routes.MapRoute(
            "RouteProductFeatured",
            "danh-sach-san-pham-noi-bat",
            new
            {
                controller = "Product",
                action = "ProductFeatured"
            }
        );
            routes.MapRoute(
                "RoutSearchProducts",
                "ket-qua-tim-kien-san-pham-{TenKhongDau}",
                new
                {
                    controller = "Product",
                    action = "SearchProducts"
                }
            );
            routes.MapRoute(
              "RouteShoppingCart",
              "gio-hang/{id}",
              new
              {
                  controller = "ShoppingCart",
                  action = "Cart",
                  id = UrlParameter.Optional
              }
          );
            routes.MapRoute(
              "RouteAddCart",
              "them-san-pham",
              new
              {
                  controller = "ShoppingCart",
                  action = "AddToCart"
              }
          );
            routes.MapRoute(
             "RouteRemoveFromCart",
             "xoa-san-pham",
             new
             {
                 controller = "ShoppingCart",
                 action = "RemoveFromCart",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
             "RouteUpdateQuantity",
             "sua-san-pham",
             new
             {
                 controller = "ShoppingCart",
                 action = "UpdateQuantity",
                 id = UrlParameter.Optional,
                 quantity = UrlParameter.Optional
             }
         );
            routes.MapRoute(
            "RouteSendMail",
            "gui-thong-tin",
            new
            {
                controller = "Payment",
                action = "SendMail"
            }
        );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}