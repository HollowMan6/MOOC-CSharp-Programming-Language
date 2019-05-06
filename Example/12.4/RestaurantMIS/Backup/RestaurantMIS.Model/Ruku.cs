using System;

namespace RestaurantMIS.Model
{
    public class Ruku
    {
        public DateTime 日期 { get; set; }
        public decimal 厨房入库 { get; set; }
        public decimal 酒水入库 { get; set; }
        public decimal 香烟入库 { get; set; }
        public decimal 干货入库 { get; set; }
        public decimal 食油入库 { get; set; }
        public decimal 合计金额 { get; set; }
        public string 备注 { get; set; }
    }
}
