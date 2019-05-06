using System;
namespace RestaurantMIS.Model
{
	/// <summary>
	/// 实体类Income 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Income
	{
		public Income()
		{}
		#region Model
		private int _id;
		private decimal _incomesum;
		private decimal _incomemoneysum;
		private decimal _dishmoney;
		private decimal _winemoney;
		private decimal _othermoney;
		private decimal _incomelendsum;
		private decimal _returnsum;
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
		public decimal IncomeSum
		{
			set{ _incomesum=value;}
			get{return _incomesum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal IncomeMoneySum
		{
			set{ _incomemoneysum=value;}
			get{return _incomemoneysum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal DishMoney
		{
			set{ _dishmoney=value;}
			get{return _dishmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal WineMoney
		{
			set{ _winemoney=value;}
			get{return _winemoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal OtherMoney
		{
			set{ _othermoney=value;}
			get{return _othermoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal IncomeLendSum
		{
			set{ _incomelendsum=value;}
			get{return _incomelendsum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ReturnSum
		{
			set{ _returnsum=value;}
			get{return _returnsum;}
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

