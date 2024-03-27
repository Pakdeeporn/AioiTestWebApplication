using System.ComponentModel.DataAnnotations;

namespace AioiTestWebApplication.Models.Contexts
{
    public class Customer
    {
        [Key]
        public string Customer_Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string Id_Card { get; set; }

    }
}
