using System;
namespace RestaurantMIS.Model
{
    /// <summary>
    /// 实体类PayOrder 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PayOrder
    {
        public PayOrder()
        { }
        #region Model
        private int _id;
        private int _roomid;
        private string _category;
        private decimal _foodsum;
        private decimal _winesum;
        private decimal _cigarettesum;
        private decimal _othersum;
        private decimal _totalsum;
        private decimal _realsum;
        private DateTime _logdate;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RoomID
        {
            set { _roomid = value; }
            get { return _roomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Category
        {
            set { _category = value; }
            get { return _category; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal FoodSum
        {
            set { _foodsum = value; }
            get { return _foodsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal WineSum
        {
            set { _winesum = value; }
            get { return _winesum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CigaretteSum
        {
            set { _cigarettesum = value; }
            get { return _cigarettesum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OtherSum
        {
            set { _othersum = value; }
            get { return _othersum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalSum
        {
            set { _totalsum = value; }
            get { return _totalsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RealSum
        {
            set { _realsum = value; }
            get { return _realsum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LogDate
        {
            set { _logdate = value; }
            get { return _logdate; }
        }
        #endregion Model
    }
}

