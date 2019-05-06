using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using RestaurantMIS.DBUtility;
using System.Collections.Generic;//请先添加引用
namespace RestaurantMIS.DAL
{
	/// <summary>
	/// 数据访问类Cigarette。
	/// </summary>
	public class Cigarette
	{
		public Cigarette()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Cigarette");
			strSql.Append(" where ID=@ID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(RestaurantMIS.Model.Cigarette model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Cigarette(");
			strSql.Append("[Name],[Type],[Unit],[YesterdayStorkNum],[TodayInNum],[TodayOutNum],[TodayStorkNum],[Price],[IncomeSum],[LogDate],[Memo])");
			strSql.Append(" values (");
			strSql.Append("@Name,@Type,@Unit,@YesterdayStorkNum,@TodayInNum,@TodayOutNum,@TodayStorkNum,@Price,@IncomeSum,@LogDate,@Memo)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Name", OleDbType.VarChar,255),
					new OleDbParameter("@Type", OleDbType.VarChar,255),
					new OleDbParameter("@Unit", OleDbType.VarChar,255),
					new OleDbParameter("@YesterdayStorkNum", OleDbType.Integer,4),
					new OleDbParameter("@TodayInNum", OleDbType.Integer,4),
					new OleDbParameter("@TodayOutNum", OleDbType.Integer,4),
					new OleDbParameter("@TodayStorkNum", OleDbType.Integer,4),
					new OleDbParameter("@Price", OleDbType.Decimal),
					new OleDbParameter("@IncomeSum", OleDbType.Decimal),
					new OleDbParameter("@LogDate", OleDbType.Date),
					new OleDbParameter("@Memo", OleDbType.VarChar,50)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Unit;
			parameters[3].Value = model.YesterdayStorkNum;
			parameters[4].Value = model.TodayInNum;
			parameters[5].Value = model.TodayOutNum;
			parameters[6].Value = model.TodayStorkNum;
			parameters[7].Value = model.Price;
			parameters[8].Value = model.IncomeSum;
			parameters[9].Value = model.LogDate;
			parameters[10].Value = model.Memo;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(RestaurantMIS.Model.Cigarette model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Cigarette set ");
			strSql.Append("ID=@ID,");
			strSql.Append("Name=@Name,");
			strSql.Append("Type=@Type,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("YesterdayStorkNum=@YesterdayStorkNum,");
			strSql.Append("TodayInNum=@TodayInNum,");
			strSql.Append("TodayOutNum=@TodayOutNum,");
			strSql.Append("TodayStorkNum=@TodayStorkNum,");
			strSql.Append("Price=@Price,");
			strSql.Append("IncomeSum=@IncomeSum,");
			strSql.Append("LogDate=@LogDate,");
			strSql.Append("Memo=@Memo");
			strSql.Append(" where ID=@ID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4),
					new OleDbParameter("@Name", OleDbType.VarChar,255),
					new OleDbParameter("@Type", OleDbType.VarChar,255),
					new OleDbParameter("@Unit", OleDbType.VarChar,255),
					new OleDbParameter("@YesterdayStorkNum", OleDbType.Integer,4),
					new OleDbParameter("@TodayInNum", OleDbType.Integer,4),
					new OleDbParameter("@TodayOutNum", OleDbType.Integer,4),
					new OleDbParameter("@TodayStorkNum", OleDbType.Integer,4),
					new OleDbParameter("@Price", OleDbType.Decimal),
					new OleDbParameter("@IncomeSum", OleDbType.Decimal),
					new OleDbParameter("@LogDate", OleDbType.Date),
					new OleDbParameter("@Memo", OleDbType.VarChar,50)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.Unit;
			parameters[4].Value = model.YesterdayStorkNum;
			parameters[5].Value = model.TodayInNum;
			parameters[6].Value = model.TodayOutNum;
			parameters[7].Value = model.TodayStorkNum;
			parameters[8].Value = model.Price;
			parameters[9].Value = model.IncomeSum;
			parameters[10].Value = model.LogDate;
			parameters[11].Value = model.Memo;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Cigarette ");
			strSql.Append(" where ID=@ID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = ID;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RestaurantMIS.Model.Cigarette GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Name,Type,Unit,YesterdayStorkNum,TodayInNum,TodayOutNum,TodayStorkNum,Price,IncomeSum,LogDate,Memo from Cigarette ");
			strSql.Append(" where ID=@ID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = ID;

			RestaurantMIS.Model.Cigarette model=new RestaurantMIS.Model.Cigarette();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Type=ds.Tables[0].Rows[0]["Type"].ToString();
				model.Unit=ds.Tables[0].Rows[0]["Unit"].ToString();
				if(ds.Tables[0].Rows[0]["YesterdayStorkNum"].ToString()!="")
				{
					model.YesterdayStorkNum=int.Parse(ds.Tables[0].Rows[0]["YesterdayStorkNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TodayInNum"].ToString()!="")
				{
					model.TodayInNum=int.Parse(ds.Tables[0].Rows[0]["TodayInNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TodayOutNum"].ToString()!="")
				{
					model.TodayOutNum=int.Parse(ds.Tables[0].Rows[0]["TodayOutNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TodayStorkNum"].ToString()!="")
				{
					model.TodayStorkNum=int.Parse(ds.Tables[0].Rows[0]["TodayStorkNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IncomeSum"].ToString()!="")
				{
					model.IncomeSum=decimal.Parse(ds.Tables[0].Rows[0]["IncomeSum"].ToString());
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
			strSql.Append("select ID,Name,Type,Unit,YesterdayStorkNum,TodayInNum,TodayOutNum,TodayStorkNum,Price,IncomeSum,LogDate,Memo ");
			strSql.Append(" FROM Cigarette ");
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
			parameters[0].Value = "Cigarette";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        public List<string> GetDistinctCol(string colName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DISTINCT ");
            strSql.Append(colName);
            strSql.Append(" FROM Cigarette ");

            DataTable dt = DbHelperOleDb.Query(strSql.ToString()).Tables[0];
            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row[0].ToString());
            }

            return list;
        }

        public string GetYesterdayStork(DateTime date, string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Top 1 TodayStorkNum ");
            strSql.Append(" FROM Cigarette Where LogDate<= #");
            strSql.Append(date);
            strSql.Append("# And Name= '");
            strSql.Append(name);
            strSql.Append("' order by LogDate desc");

            DataTable dt = DbHelperOleDb.Query(strSql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

		#endregion  成员方法
	}
}

