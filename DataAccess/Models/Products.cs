using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
	public class Products
	{
		public int id { get; set; }
		public int food_id { get; set; }
		public string name { get; set; }
		public int price { get; set; }
		public string description { get; set; }
		public string img_url { get; set; }
		public int count { get; set; }
		public string country { get; set; }
		public decimal rating { get; set; }


		public Products() { }

		public Products(int id, int food_id, string name, int price, string description, string url, int count, string country, decimal rating)
		{
			this.id = id;
			this.food_id = food_id;
			this.name = name;
			this.price = price;
			this.description = description;
			this.img_url = url;
			this.count = count;
			this.country = country;
			this.rating = rating;
		}
	}
}
