using AioiTestWebApplication.Helper.Common;
using AioiTestWebApplication.Helper.ViewModel;
using AioiTestWebApplication.Models.Contexts;

namespace AioiTestWebApplication.Interface
{
    public interface ICustomerRepository
    {
        Task<ResponseMessage> CreateMockData();
        IEnumerable<CustomerVM> GetListCustomer(string id_card);
        Task<ResponseMessage> CreateCustomer(Customer model);
        Task<ResponseMessage> UpdateCustomer(Customer model);
        Task<ResponseMessage> DeleteCustomer(string id_card);
    }
}
