using AioiTestWebApplication.Helper.Common;
using AioiTestWebApplication.Helper.ViewModel;
using AioiTestWebApplication.Models.Contexts;
using System.Globalization;
using AioiTestWebApplication.Interface;

namespace WebApis.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context = new();

        public async Task<ResponseMessage> CreateMockData()
        {
            ResponseMessage result = new() { Is_Success = true };
            #region Customer

            List<Customer> lstModel = new() {
                new Customer {
                    Customer_Id = "0001",
                    Name = "Sara",
                    Gender = "Female",
                    Email = "Sara@gmail.com",
                    Id_Card = "1233333333333",
                    Date_Of_Birth = DateTime.ParseExact("07/05/1994", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                },
                 new Customer
                 {
                     Customer_Id = "0002",
                     Name = "Eric",
                     Gender = "Male",
                     Email = "Eric@gmail.com",
                     Id_Card = "1234444444444",
                     Date_Of_Birth = DateTime.ParseExact("08/05/1995", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                 },
                  new Customer
                  {
                      Customer_Id = "0003",
                      Name = "Robert",
                      Gender = "Male",
                      Email = "Robert@gmail.com",
                      Id_Card = "1235555555555",
                      Date_Of_Birth = DateTime.ParseExact("09/05/1996", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                  }
                };
            #endregion

            _context.Customers.RemoveRange(_context.Customers);
            await _context.Customers.AddRangeAsync(lstModel);
            await _context.SaveChangesAsync();
            return result;
        }

        public IEnumerable<CustomerVM> GetListCustomer(string id_card)
        {
            var data = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(id_card)) 
            {
                data = data.Where(i => i.Id_Card.Contains(id_card));
            }

            return data.Select(u => new CustomerVM
            {
                Customer_Id = u.Customer_Id,
                Name = u.Name,
                Email = u.Email,
                Gender = u.Gender,
                Date_Of_Birth = u.Date_Of_Birth,
                Str_Date_Of_Birth = u.Date_Of_Birth.ToString("yyyy-MM-dd"),
                Id_Card = u.Id_Card,
            }).AsEnumerable();
        }

        public async Task<ResponseMessage> CreateCustomer(Customer model)
        {
            ResponseMessage result = new() { Is_Success = true };
            try
            {
                model.Customer_Id = (int.Parse(_context.Customers.Max(i => i.Customer_Id) ?? "0") + 1).ToString().PadLeft(4, '0');

                _context.Customers.Add(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Is_Success = false;
                result.Message = ex.Message;

            }
            return result;
        }

        public async Task<ResponseMessage> UpdateCustomer(Customer model)
        {
            ResponseMessage result = new() { Is_Success = true };
            try
            {
                var data = _context.Customers.First(i => i.Customer_Id.Equals(model.Customer_Id));
                data.Name = model.Name;
                data.Id_Card = model.Id_Card;
                data.Gender = model.Gender;
                data.Email = model.Email;
                data.Date_Of_Birth = model.Date_Of_Birth;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Is_Success = false;
                result.Message = ex.Message;

            }
            return result;
        }

        public async Task<ResponseMessage> DeleteCustomer(string user_id)
        {
            ResponseMessage result = new() { Is_Success = true };
            try
            {
                var data = _context.Customers.First(i => i.Customer_Id.Equals(user_id));
                _context.Customers.Remove(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Is_Success = false;
                result.Message = ex.Message;

            }
            return result;
        }

    }
}
