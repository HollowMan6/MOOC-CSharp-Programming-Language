using System;
using System.Data;
using System.Collections.Generic;

using RestaurantMIS.Model;
namespace RestaurantMIS.BLL
{
	/// <summary>
	/// 业务逻辑类Buy 的摘要说明。
	/// </summary>
	public class Buy
	{
		private readonly RestaurantMIS.DAL.Buy dal=new RestaurantMIS.DAL.Buy();
		public Buy()
		{}
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
		public void Add(RestaurantMIS.Model.Buy model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(RestaurantMIS.Model.Buy model)
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
		public RestaurantMIS.Model.Buy GetModel(int ID)
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
		public List<RestaurantMIS.Model.Buy> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<RestaurantMIS.Model.Buy> DataTableToList(DataTable dt)
		{
			List<RestaurantMIS.Model.Buy> modelList = new List<RestaurantMIS.Model.Buy>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RestaurantMIS.Model.Buy model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new RestaurantMIS.Model.Buy();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.Saler=dt.Rows[n]["Saler"].ToString();
					model.Product=dt.Rows[n]["Product"].ToString();
					model.Type=dt.Rows[n]["Type"].ToString();
					if(dt.Rows[n]["Price"].ToString()!="")
					{
						model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
					}
					model.Unit=dt.Rows[n]["Unit"].ToString();
					if(dt.Rows[n]["Num"].ToString()!="")
					{
						model.Num=decimal.Parse(dt.Rows[n]["Num"].ToString());
					}
					if(dt.Rows[n]["Money"].ToString()!="")
					{
						model.Money=decimal.Parse(dt.Rows[n]["Money"].ToString());
					}
					model.Category=dt.Rows[n]["Category"].ToString();
					if(dt.Rows[n]["LogDate"].ToString()!="")
					{
						model.LogDate=DateTime.Parse(dt.Rows[n]["LogDate"].ToString());
					}
					model.Memo=dt.Rows[n]["Memo"].ToString();
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

        public List<string> GetDistinctCol(string colName)
        {
            return dal.GetDistinctCol(colName,null);
        }

        public List<string> GetDistinctCol(string colName, string category)
        {
            return dal.GetDistinctCol(colName, category);
        }

        public void Pay(string saler, string date)
        {
            dal.Pay(saler, date);
        }
		#endregion  成员方法
	}
}

