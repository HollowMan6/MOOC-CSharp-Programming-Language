using System;
namespace RestaurantMIS.Model
{
    /// <summary>
    /// 实体类CaiDan 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CaiDan
    {
        public CaiDan()
        { }
        #region Model
        private int _id;
        private string _category;
        private string _name;
        private decimal _price;
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
        public string Category
        {
            set { _category = value; }
            get { return _category; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
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
        public DateTime LogDate
        {
            set { _logdate = value; }
            get { return _logdate; }
        }
        #endregion Model

    }
}

