using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using RestaurantMIS.DBUtility;//请先添加引用
namespace RestaurantMIS.DAL
{
	/// <summary>
	/// 数据访问类Income。
	/// </summary>
	public class Income
	{
		public Income()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Income");
			strSql.Append(" where ID=@ID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(RestaurantMIS.Model.Income model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Income(");
			strSql.Append("[IncomeSum],[IncomeMoneySum],[DishMoney],[WineMoney],[OtherMoney],[IncomeLendSum],[ReturnSum],[LogDate],[Memo])");
			strSql.Append(" values (");
			strSql.Append("@IncomeSum,@IncomeMoneySum,@DishMoney,@WineMoney,@OtherMoney,@IncomeLendSum,@ReturnSum,@LogDate,@Memo)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@IncomeSum", OleDbType.Decimal),
					new OleDbParameter("@IncomeMoneySum", OleDbType.Decimal),
					new OleDbParameter("@DishMoney", OleDbType.Decimal),
					new OleDbParameter("@WineMoney", OleDbType.Decimal),
					new OleDbParameter("@OtherMoney", OleDbType.Decimal),
					new OleDbParameter("@IncomeLendSum", OleDbType.Decimal),
					new OleDbParameter("@ReturnSum", OleDbType.Decimal),
					new OleDbParameter("@LogDate", OleDbType.Date),
					new OleDbParameter("@Memo", OleDbType.VarChar,255)};
			parameters[0].Value = model.IncomeSum;
			parameters[1].Value = model.IncomeMoneySum;
			parameters[2].Value = model.DishMoney;
			parameters[3].Value = model.WineMoney;
			parameters[4].Value = model.OtherMoney;
			parameters[5].Value = model.IncomeLendSum;
			parameters[6].Value = model.ReturnSum;
			parameters[7].Value = model.LogDate;
			parameters[8].Value = model.Memo;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(RestaurantMIS.Model.Income model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Income set ");
			strSql.Append("ID=@ID,");
			strSql.Append("IncomeSum=@IncomeSum,");
			strSql.Append("IncomeMoneySum=@IncomeMoneySum,");
			strSql.Append("DishMoney=@DishMoney,");
			strSql.Append("WineMoney=@WineMoney,");
			strSql.Append("OtherMoney=@OtherMoney,");
			strSql.Append("IncomeLendSum=@IncomeLendSum,");
			strSql.Append("ReturnSum=@ReturnSum,");
			strSql.Append("LogDate=@LogDate,");
			strSql.Append("Memo=@Memo");
			strSql.Append(" where ID=@ID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4),
					new OleDbParameter("@IncomeSum", OleDbType.Decimal),
					new OleDbParameter("@IncomeMoneySum", OleDbType.Decimal),
					new OleDbParameter("@DishMoney", OleDbType.Decimal),
					new OleDbParameter("@WineMoney", OleDbType.Decimal),
					new OleDbParameter("@OtherMoney", OleDbType.Decimal),
					new OleDbParameter("@IncomeLendSum", OleDbType.Decimal),
					new OleDbParameter("@ReturnSum", OleDbType.Decimal),
					new OleDbParameter("@LogDate", OleDbType.Date),
					new OleDbParameter("@Memo", OleDbType.VarChar,255)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.IncomeSum;
			parameters[2].Value = model.IncomeMoneySum;
			parameters[3].Value = model.DishMoney;
			parameters[4].Value = model.WineMoney;
			parameters[5].Value = model.OtherMoney;
			parameters[6].Value = model.IncomeLendSum;
			parameters[7].Value = model.ReturnSum;
			parameters[8].Value = model.LogDate;
			parameters[9].Value = model.Memo;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Income ");
			strSql.Append(" where ID=@ID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = ID;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RestaurantMIS.Model.Income GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,IncomeSum,IncomeMoneySum,DishMoney,WineMoney,OtherMoney,IncomeLendSum,ReturnSum,LogDate,Memo from Income ");
			strSql.Append(" where ID=@ID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = ID;

			RestaurantMIS.Model.Income model=new RestaurantMIS.Model.Income();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IncomeSum"].ToString()!="")
				{
					model.IncomeSum=decimal.Parse(ds.Tables[0].Rows[0]["IncomeSum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IncomeMoneySum"].ToString()!="")
				{
					model.IncomeMoneySum=decimal.Parse(ds.Tables[0].Rows[0]["IncomeMoneySum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DishMoney"].ToString()!="")
				{
					model.DishMoney=decimal.Parse(ds.Tables[0].Rows[0]["DishMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["WineMoney"].ToString()!="")
				{
					model.WineMoney=decimal.Parse(ds.Tables[0].Rows[0]["WineMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OtherMoney"].ToString()!="")
				{
					model.OtherMoney=decimal.Parse(ds.Tables[0].Rows[0]["OtherMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IncomeLendSum"].ToString()!="")
				{
					model.IncomeLendSum=decimal.Parse(ds.Tables[0].Rows[0]["IncomeLendSum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReturnSum"].ToString()!="")
				{
					model.ReturnSum=decimal.Parse(ds.Tables[0].Rows[0]["ReturnSum"].ToString());
				}
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
			strSql.Append("select ID,IncomeSum,IncomeMoneySum,DishMoney,WineMoney,OtherMoney,IncomeLendSum,ReturnSum,LogDate,Memo ");
			strSql.Append(" FROM Income ");
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
			parameters[0].Value = "Income";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

