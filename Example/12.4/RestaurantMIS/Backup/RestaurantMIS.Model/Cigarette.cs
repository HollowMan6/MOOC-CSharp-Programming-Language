using System;
namespace RestaurantMIS.Model
{
	/// <summary>
	/// 实体类Cigarette 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Cigarette
	{
		public Cigarette()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _type;
		private string _unit;
		private int _yesterdaystorknum;
		private int _todayinnum;
		private int _todayoutnum;
		private int _todaystorknum;
		private decimal _price;
		private decimal _incomesum;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int YesterdayStorkNum
		{
			set{ _yesterdaystorknum=value;}
			get{return _yesterdaystorknum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TodayInNum
		{
			set{ _todayinnum=value;}
			get{return _todayinnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TodayOutNum
		{
			set{ _todayoutnum=value;}
			get{return _todayoutnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TodayStorkNum
		{
			set{ _todaystorknum=value;}
			get{return _todaystorknum;}
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
		public decimal IncomeSum
		{
			set{ _incomesum=value;}
			get{return _incomesum;}
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

