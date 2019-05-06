using System;
using System.Data;
using System.Collections.Generic;

using RestaurantMIS.Model;
namespace RestaurantMIS.BLL
{
    /// <summary>
    /// 业务逻辑类PayOrderItem 的摘要说明。
    /// </summary>
    public class PayOrderItem
    {
        private readonly RestaurantMIS.DAL.PayOrderItem dal = new RestaurantMIS.DAL.PayOrderItem();
        public PayOrderItem()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(RestaurantMIS.Model.PayOrderItem model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RestaurantMIS.Model.PayOrderItem model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RestaurantMIS.Model.PayOrderItem GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RestaurantMIS.Model.PayOrderItem> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RestaurantMIS.Model.PayOrderItem> DataTableToList(DataTable dt)
        {
            List<RestaurantMIS.Model.PayOrderItem> modelList = new List<RestaurantMIS.Model.PayOrderItem>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                RestaurantMIS.Model.PayOrderItem model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new RestaurantMIS.Model.PayOrderItem();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["PayOrderID"].ToString() != "")
                    {
                        model.PayOrderID = int.Parse(dt.Rows[n]["PayOrderID"].ToString());
                    }
                    model.Category = dt.Rows[n]["Category"].ToString();
                    model.ItemName = dt.Rows[n]["ItemName"].ToString();
                    if (dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = int.Parse(dt.Rows[n]["Amount"].ToString());
                    }
                    if (dt.Rows[n]["Sum"].ToString() != "")
                    {
                        model.Sum = decimal.Parse(dt.Rows[n]["Sum"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
    }
}

