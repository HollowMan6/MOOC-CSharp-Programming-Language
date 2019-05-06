using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using RestaurantMIS.DBUtility;
using System.Collections.Generic;//请先添加引用
namespace RestaurantMIS.DAL
{
	/// <summary>
	/// 数据访问类Buy。
	/// </summary>
	public class Buy
	{
		public Buy()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Buy");
			strSql.Append(" where ID=@ID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(RestaurantMIS.Model.Buy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Buy(");
			strSql.Append("[Saler],[Product],[Type],[Price],[Unit],[Num],[Money],[Category],[LogDate],[Memo])");
			strSql.Append(" values (");
			strSql.Append("@Saler,@Product,@Type,@Price,@Unit,@Num,@Money,@Category,@LogDate,@Memo)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Saler", OleDbType.VarChar,255),
					new OleDbParameter("@Product", OleDbType.VarChar,255),
					new OleDbParameter("@Type", OleDbType.VarChar,255),
					new OleDbParameter("@Price", OleDbType.Decimal),
					new OleDbParameter("@Unit", OleDbType.VarChar,255),
					new OleDbParameter("@Num", OleDbType.Decimal),
					new OleDbParameter("@Money", OleDbType.Decimal),
					new OleDbParameter("@Category", OleDbType.VarChar,255),
					new OleDbParameter("@LogDate", OleDbType.Date),
					new OleDbParameter("@Memo", OleDbType.VarChar,255)};
			parameters[0].Value = model.Saler;
			parameters[1].Value = model.Product;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.Unit;
			parameters[5].Value = model.Num;
			parameters[6].Value = model.Money;
			parameters[7].Value = model.Category;
			parameters[8].Value = model.LogDate;
			parameters[9].Value = model.Memo;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(RestaurantMIS.Model.Buy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Buy set ");
			strSql.Append("[Saler]=@Saler,");
			strSql.Append("[Product]=@Product,");
			strSql.Append("[Type]=@Type,");
			strSql.Append("[Price]=@Price,");
			strSql.Append("[Unit]=@Unit,");
			strSql.Append("[Num]=@Num,");
			strSql.Append("[Money]=@Money,");
			strSql.Append("[Category]=@Category,");
			strSql.Append("[LogDate]=@LogDate,");
			strSql.Append("[Memo]=@Memo");
			strSql.Append(" where [ID]=@ID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.BigInt),
					new OleDbParameter("@Saler", OleDbType.VarChar,255),
					new OleDbParameter("@Product", OleDbType.VarChar,255),
					new OleDbParameter("@Type", OleDbType.VarChar,255),
					new OleDbParameter("@Price", OleDbType.Decimal),
					new OleDbParameter("@Unit", OleDbType.VarChar,255),
					new OleDbParameter("@Num", OleDbType.Decimal),
					new OleDbParameter("@Money", OleDbType.Decimal),
					new OleDbParameter("@Category", OleDbType.VarChar,255),
					new OleDbParameter("@LogDate", OleDbType.Date),
					new OleDbParameter("@Memo", OleDbType.VarChar,255)};
            parameters[0].Value = model.ID;
			parameters[1].Value = model.Saler;
			parameters[2].Value = model.Product;
			parameters[3].Value = model.Type;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.Unit;
			parameters[6].Value = model.Num;
			parameters[7].Value = model.Money;
			parameters[8].Value = model.Category;
			parameters[9].Value = model.LogDate;
			parameters[10].Value = model.Memo;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Buy ");
			strSql.Append(" where ID=@ID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = ID;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RestaurantMIS.Model.Buy GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Saler,Product,Type,Price,Unit,Num,Money,Category,LogDate,Memo from Buy ");
			strSql.Append(" where ID=@ID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = ID;

			RestaurantMIS.Model.Buy model=new RestaurantMIS.Model.Buy();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.Saler=ds.Tables[0].Rows[0]["Saler"].ToString();
				model.Product=ds.Tables[0].Rows[0]["Product"].ToString();
				model.Type=ds.Tables[0].Rows[0]["Type"].ToString();
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				model.Unit=ds.Tables[0].Rows[0]["Unit"].ToString();
				if(ds.Tables[0].Rows[0]["Num"].ToString()!="")
				{
                    model.Num = decimal.Parse(ds.Tables[0].Rows[0]["Num"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(ds.Tables[0].Rows[0]["Money"].ToString());
				}
				model.Category=ds.Tables[0].Rows[0]["Category"].ToString();
				if(ds.Tables[0].Rows[0]["LogDate"].ToString()!="")
				{
					model.LogDate=DateTime.Parse(ds.Tables[0].Rows[0]["LogDate"].ToString());
				}
				model.Memo=ds.Tables[0].Rows[0]["Memo"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Saler,Product,Type,Price,Unit,Num,Money,Category,LogDate,Memo ");
			strSql.Append(" FROM Buy ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Bit),
					new OleDbParameter("@OrderType", OleDbType.Bit),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "Buy";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        public List<string> GetDistinctCol(string colName, string category)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DISTINCT ");
            strSql.Append(colName);
            strSql.Append(" FROM Buy ");
            if (!string.IsNullOrEmpty(category))
            {
                strSql.Append("WHERE Category = '" + category + "'");
            }
            DataTable dt = DbHelperOleDb.Query(strSql.ToString()).Tables[0];
            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row[0].ToString());
            }

            return list;
        }

        /// <summary>
        /// 结账
        /// </summary>
        public void Pay(string saler,string date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Buy ");
            strSql.Append("Set HasPaid=true");
            strSql.Append(" Where Saler='" + saler + "'");
            strSql.AppendFormat(" And LogDate<#{0}#", date);

            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }

		#endregion  成员方法
	}
}

