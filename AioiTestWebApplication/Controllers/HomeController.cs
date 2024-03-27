using AioiTestWebApplication.Helper.ViewModel;
using Microsoft.AspNetCore.Mvc;
using AioiTestWebApplication.Interface;
using AioiTestWebApplication.Models.Contexts;
using AioiTestWebApplication.Helper.Common;

namespace AioiTestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _icust;
        public HomeController(ICustomerRepository icust)
        {
            _icust = icust;
        }

        public IActionResult Index()
        {
            //Initial date
            _icust.CreateMockData();
            return View();
        }

        [HttpPost]
        public JsonResult GetListData(string id_card)
        {
            IEnumerable<CustomerVM> lstData = _icust.GetListCustomer(id_card);
            return Json(lstData);
        }

        [HttpPost]
        public async Task<ResponseMessage> DoAdd(Customer model)
        {
            ResponseMessage response = await _icust.CreateCustomer(model);
            return response;
        }

        [HttpPost]
        public async Task<ResponseMessage> DoEdit(Customer model)
        {
            ResponseMessage response = await _icust.UpdateCustomer(model);
            return response;
        }

        [HttpPost]
        public async Task<ResponseMessage> DoDelete(string customer_id)
        {
            ResponseMessage response = await _icust.DeleteCustomer(customer_id);
            return response;
        }


    }
}