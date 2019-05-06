using System;
namespace RestaurantMIS.Model
{
	/// <summary>
	/// 实体类PaySum 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PaySum
	{
		public PaySum()
		{}
		#region Model

		private string _saler;
		private decimal _yesterdaysum;
		private decimal _todaymoney;
		private decimal _todaysum;
		private DateTime _logdate;

		/// <summary>
		/// 
		/// </summary>
		public string 供货商
		{
			set{ _saler=value;}
			get{return _saler;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 承上天金额
		{
			set{ _yesterdaysum=value;}
			get{return _yesterdaysum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 当日金额
		{
			set{ _todaymoney=value;}
			get{return _todaymoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 累计金额
		{
			set{ _todaysum=value;}
			get{return _todaysum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime 日期
		{
			set{ _logdate=value;}
			get{return _logdate;}
		}

        public string 备注 { get; set; }
		#endregion Model

	}
}

