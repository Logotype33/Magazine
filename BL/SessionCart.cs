using DataLayer.Models;
using DataLayer.Models.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SessionCart
	{
		private readonly List<CartLine> _lineCollection;
		public SessionCart()
		{
			_lineCollection = new List<CartLine>();
		}
		[JsonIgnore]
		public ISession Session { get; set; }
		public void AddItem(Product product, int quantity)
		{
			CartLine line = _lineCollection
				.Where(p => p.Product.Id == product.Id)
				.FirstOrDefault();

			if (line == null)
			{
				_lineCollection.Add(new CartLine
				{
					Product = product,
					Quantity = quantity
				});
			}
			else
			{
				line.Quantity += quantity;
			}

			SetCart(this);
		}

		public void RemoveLine(Product product)
		{
			_lineCollection.RemoveAll(l => l.Product.Id == product.Id);
			SetCart(this);
		}

		public decimal ComputeTotalValue() =>
			_lineCollection.Sum(e => e.Product.Price * e.Quantity);

		public void Clear()
		{
			_lineCollection.Clear();
			Session?.Remove("Cart");
		}
		public IEnumerable<CartLine> Lines => _lineCollection;
		public static SessionCart GetCart(IServiceProvider serviceProvider)
		{
			IHttpContextAccessor httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
			ISession session = httpContextAccessor?.HttpContext.Session;
			var stringCart = session.GetString("Cart");
			SessionCart cart = stringCart == null ? new SessionCart() :
				JsonConvert.DeserializeObject<SessionCart>(stringCart);
			cart.Session = session;
			return cart;
		}

		public void Decrease(Product product)
		{
			CartLine line = _lineCollection
				   .Where(p => p.Product.Id == product.Id)
				   .FirstOrDefault();
			if (line.Quantity > 1)
				line.Quantity--;
			else
				RemoveLine(product);
			SetCart(this);
		}

		public void Increase(Product product)
		{
			CartLine line = _lineCollection
				   .Where(p => p.Product.Id == product.Id)
				   .FirstOrDefault();
			line.Quantity++;
			SetCart(this);
		}

		public static void SetCart(SessionCart cart) =>
			cart.Session?.SetString("Cart", JsonConvert.SerializeObject(cart));
	}
}
