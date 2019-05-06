using System;
using System.Data;
using System.Collections.Generic;

using RestaurantMIS.Model;
namespace RestaurantMIS.BLL
{
	/// <summary>
	/// 业务逻辑类Income 的摘要说明。
	/// </summary>
	public class Income
	{
		private readonly RestaurantMIS.DAL.Income dal=new RestaurantMIS.DAL.Income();
		public Income()
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
		public void Add(RestaurantMIS.Model.Income model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(RestaurantMIS.Model.Income model)
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
		public RestaurantMIS.Model.Income GetModel(int ID)
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
		public List<RestaurantMIS.Model.Income> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<RestaurantMIS.Model.Income> DataTableToList(DataTable dt)
		{
			List<RestaurantMIS.Model.Income> modelList = new List<RestaurantMIS.Model.Income>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RestaurantMIS.Model.Income model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new RestaurantMIS.Model.Income();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["IncomeSum"].ToString()!="")
					{
						model.IncomeSum=decimal.Parse(dt.Rows[n]["IncomeSum"].ToString());
					}
					if(dt.Rows[n]["IncomeMoneySum"].ToString()!="")
					{
						model.IncomeMoneySum=decimal.Parse(dt.Rows[n]["IncomeMoneySum"].ToString());
					}
					if(dt.Rows[n]["DishMoney"].ToString()!="")
					{
						model.DishMoney=decimal.Parse(dt.Rows[n]["DishMoney"].ToString());
					}
					if(dt.Rows[n]["WineMoney"].ToString()!="")
					{
						model.WineMoney=decimal.Parse(dt.Rows[n]["WineMoney"].ToString());
					}
					if(dt.Rows[n]["OtherMoney"].ToString()!="")
					{
						model.OtherMoney=decimal.Parse(dt.Rows[n]["OtherMoney"].ToString());
					}
					if(dt.Rows[n]["IncomeLendSum"].ToString()!="")
					{
						model.IncomeLendSum=decimal.Parse(dt.Rows[n]["IncomeLendSum"].ToString());
					}
					if(dt.Rows[n]["ReturnSum"].ToString()!="")
					{
						model.ReturnSum=decimal.Parse(dt.Rows[n]["ReturnSum"].ToString());
					}
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

		#endregion  成员方法
	}
}

