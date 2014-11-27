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

            //Trang quan tri admin
            #region ==Admin==
            #region ==Provider==
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
            "RouteDeleteProvider",
            "AdProvider/DeleteProvider",
            new
            {
                controller = "AdProvider",
                action = "DeleteProvider",
                id = UrlParameter.Optional
            }
        );
            #endregion
            #region ==News==
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
              "RouteEditNew",
              "AdNews/Edit",
              new
              {
                  controller = "AdNews",
                  action = "Edit",
                  id = UrlParameter.Optional
              }
          );
            routes.MapRoute(
             "RouteDetailsNew",
             "AdNews/Details",
             new
             {
                 controller = "AdNews",
                 action = "Details",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
             "RouteDeleteNew",
             "AdNews/Delete",
             new
             {
                 controller = "AdNews",
                 action = "Delete",
                 id = UrlParameter.Optional
             }
         );
            #endregion
            #region ==CatagoryNews==
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
            "RouteEditCategoryNews",
            "AdCategoryNews/Edit",
            new
            {
                controller = "AdCategoryNews",
                action = "Edit",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
            "RouteDeleteCategoryNews",
            "AdCategoryNews/Delete",
            new
            {
                controller = "AdCategoryNews",
                action = "Delete",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
            "RouteDetailsCategoryNews",
            "AdCategoryNews/Details",
            new
            {
                controller = "AdCategoryNews",
                action = "Details",
                id = UrlParameter.Optional
            }
        );
            #endregion
            #region ==Account==
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
            #endregion
            #region ==Company==
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
            "RouteEditCompany",
            "AdInforCompany/Edit",
            new
            {
                controller = "AdInforCompany",
                action = "Edit",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
            "RouteDeleteCompany",
            "AdInforCompany/Delete",
            new
            {
                controller = "AdInforCompany",
                action = "Delete",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
            "RouteDetailsCompany",
            "AdInforCompany/Details",
            new
            {
                controller = "AdInforCompany",
                action = "Details",
                id = UrlParameter.Optional
            }
        );
            #endregion
            #region ==Partner==
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
             "RouteEditPartners",
             "AdPartners/Edit",
             new
             {
                 controller = "AdPartners",
                 action = "Edit",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
             "RouteDeletePartners",
             "AdPartners/Delete",
             new
             {
                 controller = "AdPartners",
                 action = "Delete",
                 id = UrlParameter.Optional
             }
         );
            routes.MapRoute(
             "RouteDetailsPartners",
             "AdPartners/Details",
             new
             {
                 controller = "AdPartners",
                 action = "Details",
                 id = UrlParameter.Optional
             }
         );
            #endregion
            #region ==Services==
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
              "RouteEditServices",
              "AdServices/Edit",
              new
              {
                  controller = "AdServices",
                  action = "Edit",
                  id = UrlParameter.Optional
              }
              );
            routes.MapRoute(
                "RouteDeleteServices",
                "AdServices/Delete",
                new
                {
                    controller = "AdServices",
                    action = "Delete",
                    id = UrlParameter.Optional
                }
                );
            routes.MapRoute(
                "RouteDetailsServices",
                "AdServices/Details",
                new
                {
                    controller = "AdServices",
                    action = "Details",
                    id = UrlParameter.Optional
                }
                );
            #endregion
            #region ==CatagoryAccounts==
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
           "RouteDeleteTypeOfAcc",
           "AdTypeOfAcc/Delete",
           new
           {
               controller = "AdTypeOfAcc",
               action = "Delete",
               id = UrlParameter.Optional
           }
           );
            routes.MapRoute(
           "RouteDetailsTypeOfAcc",
           "AdTypeOfAcc/Details",
           new
           {
               controller = "AdTypeOfAcc",
               action = "Details",
               id = UrlParameter.Optional
           }
           );
            routes.MapRoute(
           "RouteEditTypeOfAcc",
           "AdTypeOfAcc/Edit",
           new
           {
               controller = "AdTypeOfAcc",
               action = "Edit",
               id = UrlParameter.Optional
           }
           );
            #endregion
            #region ==CatagoryListProduct==
            routes.MapRoute(
               "RouteListProductCatalogies",
               "AdProductCatagories/ListProductCatagories",
               new
               {
                   controller = "AdProductCatagories",
                   action = "ListProductCatagories",
                   id = UrlParameter.Optional
               }
           );
            routes.MapRoute(
              "RouteAddProductCatalogies",
              "AdProductCatagories/Create",
              new
              {
                  controller = "AdProductCatagories",
                  action = "Create",
                  id = UrlParameter.Optional
              }
          );
            routes.MapRoute(
              "RouteEditProductCatalogies",
              "AdProductCatagories/Edit",
              new
              {
                  controller = "AdProductCatagories",
                  action = "Edit",
                  id = UrlParameter.Optional
              }
          );
            routes.MapRoute(
              "RouteDeleteProductCatalogies",
              "AdProductCatagories/Delete",
              new
              {
                  controller = "AdProductCatagories",
                  action = "Delete",
                  id = UrlParameter.Optional
              }
          );
            routes.MapRoute(
              "RouteDetailsProductCatalogies",
              "AdProductCatagories/Details",
              new
              {
                  controller = "AdProductCatagories",
                  action = "Details",
                  id = UrlParameter.Optional
              }
          );
            #endregion
            #region ==Product==
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
            routes.MapRoute(
                "RouteEditProduct",
                "AdProduct/EditProduct",
                new
                {
                    controller = "AdProduct",
                    action = "EditProduct",
                    id = UrlParameter.Optional
                }
                );
            routes.MapRoute(
                "RouteDetailsProduct",
                "AdProduct/DetailsProduct",
                new
                {
                    controller = "AdProduct",
                    action = "DetailsProduct",
                    id = UrlParameter.Optional
                }
                );
            routes.MapRoute(
                "RouteDeleteProduct",
                "AdProduct/DeleteProduct",
                new
                {
                    controller = "AdProduct",
                    action = "DeleteProduct",
                    id = UrlParameter.Optional
                }
                );
            #endregion
            #region ==Order==
            routes.MapRoute(
            "RouteAdOrder",
            "AdOrder/Index",
            new
            {
                controller = "AdOrderDetails",
                action = "Index",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
            "RouteCreateOrder",
            "AdOrder/Create",
            new
            {
                controller = "AdOrderDetails",
                action = "Create",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
            "RouteEditOrder",
            "AdOrder/Edit",
            new
            {
                controller = "AdOrderDetails",
                action = "Edit",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
            "RouteDeleteOrder",
            "AdOrder/Delete",
            new
            {
                controller = "AdOrderDetails",
                action = "Delete",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
            "RouteDetailsOrder",
            "AdOrder/Details",
            new
            {
                controller = "AdOrderDetails",
                action = "Details",
                id = UrlParameter.Optional
            }
        );
            #endregion
            #region ==CatagoryImages==
            routes.MapRoute(
            "RouteAdCatagoryImage",
            "AdCatagoryImage/Index",
            new
            {
                controller = "AdCatagoryImage",
                action = "Index",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
            "RouteAddCatagoryImage",
            "AdCatagoryImage/Create",
            new
            {
                controller = "AdCatagoryImage",
                action = "Create",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
            "RouteEditCatagoryImage",
            "AdCatagoryImage/Edit",
            new
            {
                controller = "AdCatagoryImage",
                action = "Edit",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
            "RouteDeleteCatagoryImage",
            "AdCatagoryImage/Delete",
            new
            {
                controller = "AdCatagoryImage",
                action = "Delete",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
            "RouteDetailsCatagoryImage",
            "AdCatagoryImage/Details",
            new
            {
                controller = "AdCatagoryImage",
                action = "Details",
                id = UrlParameter.Optional
            }
        );

            #endregion
            #region ==Catagory==
            routes.MapRoute(
            "RouteAddCatagory",
            "AdCatagory/Create",
            new
            {
                controller = "AdCatagory",
                action = "Create",
                id = UrlParameter.Optional
            }
        );
            routes.MapRoute(
           "RouteAdCatagory",
           "AdCatagory/Index",
           new
           {
               controller = "AdCatagory",
               action = "Index",
               id = UrlParameter.Optional
           }
       );
                               routes.MapRoute(
           "RouteDeleteCatagory",
           "AdCatagory/Delete",
           new
           {
               controller = "AdCatagory",
               action = "Delete",
               id = UrlParameter.Optional
           }
       );
                routes.MapRoute(
           "RouteEditCatagory",
           "AdCatagory/Edit",
           new
           {
               controller = "AdCatagory",
               action = "Edit",
               id = UrlParameter.Optional
           }
       );

                routes.MapRoute(
           "RouteDetailsCatagory",
           "AdCatagory/Details",
           new
           {
               controller = "AdCatagory",
               action = "Details",
               id = UrlParameter.Optional
           }
       );

            #endregion
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
                "dich-vu/{id}/{TenKhongDau}",
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