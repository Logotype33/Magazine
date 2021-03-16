using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DbModels
{
    public class Order
    {
        [Key]
        public Guid ID { get; set; }

        public Guid UserId { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public IEnumerable<OrderProduct> Products { get; set; }

        

    }
   
    public class OrderProduct
    {
        [Key]
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }     
        public int ProductQuantity { get; set; }
        public Product Product { get; set; }
    }
	


}
