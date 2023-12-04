using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


	public class GetResponse
	{
		public int count { get; set; }
		public List<NamedApiResource> results { get; set; }
		public string activity { get; set; }
		public double accessibility { get; set; }
		public string type { get; set; }
		public int participants { get; set; }
		public double price { get; set; }
		


}