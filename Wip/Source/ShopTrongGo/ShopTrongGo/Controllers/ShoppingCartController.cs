using System;
using System.Linq;
using System.Web.Mvc;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers
{
    public class ShoppingCartController : Controller
    {
        //
        // GET: /ShoppingCart/

        public ActionResult Cart()
        {
            var model = new ShoppingCartModels { Cart = (ShoppingCart)Session["Cart"] };
            return View(model);
        }

        /// <summary>
        /// Them san pham vao gio hang
        /// </summary>
        /// <param name="id">ID san pham can them</param>
        /// <returns>Tra ve json theo dinh dang {Code: ReturnCode, Msg: "Return message"}</returns>
        [HttpPost]
        public JsonResult AddToCart(string id)
        {
            var response = new { Code = 1, Msg = "Fail" };
            SanPham objProduct = GetProductById(id);
            if (objProduct != null)
            {
                var objCart = (ShoppingCart)Session["Cart"] ?? new ShoppingCart();

                var item = new ShoppingCartItem()
                {
                    ProductId = objProduct.SanPhamID,
                    ProductName = objProduct.TenSp,
                    ProductImage = objProduct.AnhDaiDien,
                    Price = Convert.ToDecimal(objProduct.Gia),
                    Quantity = 1,
                    Total = Convert.ToDecimal(objProduct.Gia),
                };
                
                objCart.AddToCart(item);
                Session["Cart"] = objCart;
                response = new { Code = 0, Msg = "Success" };
            }
            return Json(response);
        }

        /// <summary>
        /// Xoa san pham khoi gio hang
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult RemoveFromCart(string id)
        {
            var response = new { Code = 1, Msg = "Fail" };

            var objCart = (ShoppingCart)Session["Cart"];
            if (objCart != null)
            {
                objCart.RemoveFromCart(id);
                Session["Cart"] = objCart;
                response = new { Code = 0, Msg = "Success" };
            }
            return Json(response);
        }

        /// <summary>
        /// Cap nhat so luong san pham can mua trong gio hang
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateQuantity(string id, int quantity)
        {
            var response = new { Code = 1, Msg = "Fail" };

            var objCart = (ShoppingCart)Session["Cart"];
            if (objCart != null)
            {
                objCart.UpdateQuantity(id, quantity);
                Session["Cart"] = objCart;
                response = new { Code = 0, Msg = "Success" };
            }
            return Json(response);
        }

        /// <summary>
        /// Gia lap method lay thong tin san pham tu DB dua vao ID san pham
        /// </summary>
        /// <param name="id">ID san pham can lay thong tin</param>
        /// <returns></returns>
        public SanPham GetProductById(string id)
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            var product = dbTapHoa.SanPhams.SingleOrDefault(p => p.SanPhamID == id & !p.TrangThaiXoa);
            if (product != null)
            {
                return new SanPham()
                {
                    SanPhamID = product.SanPhamID,
                    TenSp = product.TenSp,
                    AnhDaiDien = product.AnhDaiDien,
                    Gia = product.Gia
                };
            }
            else
            {
                return null;
            }
        }

    }
}
