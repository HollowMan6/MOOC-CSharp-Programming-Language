using System;
namespace RestaurantMIS.Model
{
	/// <summary>
	/// 实体类Buy 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Buy
	{
		public Buy()
		{}
		#region Model
		private int _id;
		private string _saler;
		private string _product;
		private string _type;
		private decimal _price;
		private string _unit;
        private decimal _num;
		private decimal _money;
		private string _category;
		private DateTime _logdate;
		private string _memo;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Saler
		{
			set{ _saler=value;}
			get{return _saler;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Product
		{
			set{ _product=value;}
			get{return _product;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Category
		{
			set{ _category=value;}
			get{return _category;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LogDate
		{
			set{ _logdate=value;}
			get{return _logdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Memo
		{
			set{ _memo=value;}
			get{return _memo;}
		}
		#endregion Model

	}
}

