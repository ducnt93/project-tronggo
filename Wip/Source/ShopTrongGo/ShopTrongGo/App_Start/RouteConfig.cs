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
              "RouteIndexNon",
              "",
              new
              {
                  controller = "Home",
                  action = "Index",
              }
          );
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
                "RouteAdminLogin",
                "AdminLogin/Login",
                new
                {
                    controller = "AdminLogin",
                    action = "Login",
                    id = UrlParameter.Optional
                }
            );
            routes.MapRoute(
                "RouteAdminLogout",
                "AdminLogin/Logout",
                new
                {
                    controller = "AdminLogin",
                    action = "Logout",
                    id = UrlParameter.Optional
                }
            );
            routes.MapRoute(
               "RouteListProduct",
               "AdProduct/ListProduct",
               new
               {
                   controller = "AdProduct",
                   action = "ListProduct",
                   id = UrlParameter.Optional
               }
           );
            //Trang quan tri admin
            #region ==Admin==
            routes.MapRoute(
             "RouteAdProvider",
             "AdProvider/Index",
             new
             {
                 controller = "AdProvider",
                 action = "ListProvider",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
            "RouteAddProvider",
            "AdProvider/AddProvider",
            new
            {
                controller = "AdProvider",
                action = "AddProvider",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
              "RouteAdNews",
              "AdNews/Index",
              new
              {
                  controller = "AdNews",
                  action = "Index",
                  id = UrlParameter.Optional
              }
          );
            routes.MapRoute(
              "RouteAddNews",
              "AdNews/Create",
              new
              {
                  controller = "AdNews",
                  action = "Create",
                  id = UrlParameter.Optional
              }
          );
            routes.MapRoute(
             "RouteAdCategoryNews",
             "AdCategoryNews/Index",
             new
             {
                 controller = "AdCategoryNews",
                 action = "Index",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
            "RouteAddCategoryNews",
            "AdCategoryNews/Create",
            new
            {
                controller = "AdCategoryNews",
                action = "Create",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
             "RouteAdAccount",
             "AdAccount/Index",
             new
             {
                 controller = "AdAccount",
                 action = "Index",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
             "RouteAddAccount",
             "AdAccount/Create",
             new
             {
                 controller = "AdAccount",
                 action = "Create",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
             "RouteAdInforCompany",
             "AdInforCompany/Index",
             new
             {
                 controller = "AdInforCompany",
                 action = "Index",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
             "RouteAddCompany",
             "AdInforCompany/Create",
             new
             {
                 controller = "AdInforCompany",
                 action = "Create",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
             "RouteAdPartner",
             "AdPartners/Index",
             new
             {
                 controller = "AdPartners",
                 action = "Index",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
             "RouteAddPartners",
             "AdPartners/Create",
             new
             {
                 controller = "AdPartners",
                 action = "Create",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
                "RouteAdServices",
                "AdServices/Index",
                new
                {
                    controller = "AdServices",
                    action = "Index",
                    id = UrlParameter.Optional
                }
                );
            routes.MapRoute(
                "RouteAddServices",
                "AdServices/Create",
                new
                {
                    controller = "AdServices",
                    action = "Create",
                    id = UrlParameter.Optional
                }
                );

            routes.MapRoute(
                "RouteAdTypeOfAcc",
                "AdTypeOfAcc/Index",
                new
                {
                    controller = "AdTypeOfAcc",
                    action = "Index",
                    id = UrlParameter.Optional
                }
                );
            routes.MapRoute(
           "RouteAddTypeOfAcc",
           "AdTypeOfAcc/Create",
           new
           {
               controller = "AdTypeOfAcc",
               action = "Create",
               id = UrlParameter.Optional
           }
           );


            routes.MapRoute(
               "RouteListProductCatalogies",
               "ProductCatagories/ListProductCatagories",
               new
               {
                   controller = "ProductCatagories",
                   action = "ListProductCatagories",
                   id = UrlParameter.Optional
               }
           );
            routes.MapRoute(
              "RouteAddProductCatalogies",
              "ProductCatagories/Create",
              new
              {
                  controller = "ProductCatagories",
                  action = "Create",
                  id = UrlParameter.Optional
              }
          );
            routes.MapRoute(
               "RouteListProvider",
               "Provider/ListProvider",
               new
               {
                   controller = "Provider",
                   action = "ListProvider",
                   id = UrlParameter.Optional
               }
            );
            routes.MapRoute(
              "RouteAddProduct",
              "AdProduct/AddProduct",
              new
              {
                  controller = "AdProduct",
                  action = "AddProduct",
                  id = UrlParameter.Optional
              }
          );
            #endregion
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
                "ket-qua-tim-kiem",
                new
                {
                    controller = "Product",
                    action = "SearchProducts"
                }
            );
            routes.MapRoute(
              "RouteShoppingCart",
              "gio-hang",
              new
              {
                  controller = "ShoppingCart",
                  action = "Cart"
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
          "RouteContact",
          "lien-he",
          new
          {
              controller = "Home",
              action = "Contact"
          }
      );
            routes.MapRoute(
          "RouteInformation",
          "gioi-thieu",
          new
          {
              controller = "Home",
              action = "Information"
          }
      );
            routes.MapRoute(
               name: "Admin",
               url: "quan-ly-loai-tai-khoan/danh-sach",
               defaults:
               new
               {
                   controller = "AdTypeOfAcc",
                   action = "Index"
               }
           );
            routes.MapRoute(
             name: "AdminService",
             url: "admin-danh-sach-dich-vu",
             defaults:
             new
             {
                 controller = "AdServices",
                 action = "Create"
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
                    action = "DetailNews",
                    id = UrlParameter.Optional
                }
            );
            routes.MapRoute(
                "RouteAllServices",
                "danh-sach-dich-vu",
                new
                {
                    controller = "News",
                    action = "AllServices"
                }
            );
            routes.MapRoute(
                "RouteDetailServices",
                "danh-vu/{id}/{TenKhongDau}",
                new
                {
                    controller = "News",
                    action = "DetailServices",
                    id = UrlParameter.Optional
                }
            );
            routes.MapRoute(
    name: "Default1",
    url: "{controller}/{action}",
    defaults: new { controller = "Home", action = "Index" }
);
        }
    }
}