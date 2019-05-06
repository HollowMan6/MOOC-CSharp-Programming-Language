using System;
using System.Data;
using System.Collections.Generic;

using RestaurantMIS.Model;
namespace RestaurantMIS.BLL
{
    /// <summary>
    /// 业务逻辑类PayOrder 的摘要说明。
    /// </summary>
    public class PayOrder
    {
        private readonly RestaurantMIS.DAL.PayOrder dal = new RestaurantMIS.DAL.PayOrder();
        public PayOrder()
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
        public void Add(RestaurantMIS.Model.PayOrder model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RestaurantMIS.Model.PayOrder model)
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
        public RestaurantMIS.Model.PayOrder GetModel(int ID)
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
        public List<RestaurantMIS.Model.PayOrder> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RestaurantMIS.Model.PayOrder> DataTableToList(DataTable dt)
        {
            List<RestaurantMIS.Model.PayOrder> modelList = new List<RestaurantMIS.Model.PayOrder>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                RestaurantMIS.Model.PayOrder model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new RestaurantMIS.Model.PayOrder();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["RoomID"].ToString() != "")
                    {
                        model.RoomID = int.Parse(dt.Rows[n]["RoomID"].ToString());
                    }
                    model.Category = dt.Rows[n]["Category"].ToString();
                    if (dt.Rows[n]["FoodSum"].ToString() != "")
                    {
                        model.FoodSum = decimal.Parse(dt.Rows[n]["FoodSum"].ToString());
                    }
                    if (dt.Rows[n]["WineSum"].ToString() != "")
                    {
                        model.WineSum = decimal.Parse(dt.Rows[n]["WineSum"].ToString());
                    }
                    if (dt.Rows[n]["CigaretteSum"].ToString() != "")
                    {
                        model.CigaretteSum = decimal.Parse(dt.Rows[n]["CigaretteSum"].ToString());
                    }
                    if (dt.Rows[n]["OtherSum"].ToString() != "")
                    {
                        model.OtherSum = decimal.Parse(dt.Rows[n]["OtherSum"].ToString());
                    }
                    if (dt.Rows[n]["TotalSum"].ToString() != "")
                    {
                        model.TotalSum = decimal.Parse(dt.Rows[n]["TotalSum"].ToString());
                    }
                    if (dt.Rows[n]["RealSum"].ToString() != "")
                    {
                        model.RealSum = decimal.Parse(dt.Rows[n]["RealSum"].ToString());
                    }
                    if (dt.Rows[n]["LogDate"].ToString() != "")
                    {
                        model.LogDate = DateTime.Parse(dt.Rows[n]["LogDate"].ToString());
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

