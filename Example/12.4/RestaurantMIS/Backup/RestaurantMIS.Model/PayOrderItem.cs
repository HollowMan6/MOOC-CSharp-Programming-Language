using System;
namespace RestaurantMIS.Model
{
    /// <summary>
    /// 实体类PayOrderItem 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PayOrderItem
    {
        public PayOrderItem()
        { }
        #region Model
        private int? _id;
        private int? _payorderid;
        private string _category;
        private string _itemname;
        private decimal _price;
        private int _amount;
        private decimal _sum;
        /// <summary>
        /// 
        /// </summary>
        public int? ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PayOrderID
        {
            set { _payorderid = value; }
            get { return _payorderid; }
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
        public string ItemName
        {
            set { _itemname = value; }
            get { return _itemname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Sum
        {
            set { _sum = value; }
            get { return _sum; }
        }
        #endregion Model

    }
}

