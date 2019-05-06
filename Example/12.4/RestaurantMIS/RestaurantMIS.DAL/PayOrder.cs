using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using RestaurantMIS.DBUtility;//请先添加引用
namespace RestaurantMIS.DAL
{
    /// <summary>
    /// 数据访问类PayOrder。
    /// </summary>
    public class PayOrder
    {
        public PayOrder()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PayOrder");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(RestaurantMIS.Model.PayOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PayOrder(");
            strSql.Append("ID,RoomID,Category,FoodSum,WineSum,CigaretteSum,OtherSum,TotalSum,RealSum,LogDate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@RoomID,@Category,@FoodSum,@WineSum,@CigaretteSum,@OtherSum,@TotalSum,@RealSum,@LogDate)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4),
					new OleDbParameter("@RoomID", OleDbType.Integer,4),
					new OleDbParameter("@Category", OleDbType.VarChar,255),
					new OleDbParameter("@FoodSum", OleDbType.Decimal),
					new OleDbParameter("@WineSum", OleDbType.Decimal),
					new OleDbParameter("@CigaretteSum", OleDbType.Decimal),
					new OleDbParameter("@OtherSum", OleDbType.Decimal),
					new OleDbParameter("@TotalSum", OleDbType.Decimal),
					new OleDbParameter("@RealSum", OleDbType.Decimal),
					new OleDbParameter("@LogDate", OleDbType.Date)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.RoomID;
            parameters[2].Value = model.Category;
            parameters[3].Value = model.FoodSum;
            parameters[4].Value = model.WineSum;
            parameters[5].Value = model.CigaretteSum;
            parameters[6].Value = model.OtherSum;
            parameters[7].Value = model.TotalSum;
            parameters[8].Value = model.RealSum;
            parameters[9].Value = model.LogDate;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RestaurantMIS.Model.PayOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PayOrder set ");
            strSql.Append("ID=@ID,");
            strSql.Append("RoomID=@RoomID,");
            strSql.Append("Category=@Category,");
            strSql.Append("FoodSum=@FoodSum,");
            strSql.Append("WineSum=@WineSum,");
            strSql.Append("CigaretteSum=@CigaretteSum,");
            strSql.Append("OtherSum=@OtherSum,");
            strSql.Append("TotalSum=@TotalSum,");
            strSql.Append("RealSum=@RealSum,");
            strSql.Append("LogDate=@LogDate");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4),
					new OleDbParameter("@RoomID", OleDbType.Integer,4),
					new OleDbParameter("@Category", OleDbType.VarChar,255),
					new OleDbParameter("@FoodSum", OleDbType.Decimal),
					new OleDbParameter("@WineSum", OleDbType.Decimal),
					new OleDbParameter("@CigaretteSum", OleDbType.Decimal),
					new OleDbParameter("@OtherSum", OleDbType.Decimal),
					new OleDbParameter("@TotalSum", OleDbType.Decimal),
					new OleDbParameter("@RealSum", OleDbType.Decimal),
					new OleDbParameter("@LogDate", OleDbType.Date)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.RoomID;
            parameters[2].Value = model.Category;
            parameters[3].Value = model.FoodSum;
            parameters[4].Value = model.WineSum;
            parameters[5].Value = model.CigaretteSum;
            parameters[6].Value = model.OtherSum;
            parameters[7].Value = model.TotalSum;
            parameters[8].Value = model.RealSum;
            parameters[9].Value = model.LogDate;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PayOrder ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RestaurantMIS.Model.PayOrder GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,RoomID,Category,FoodSum,WineSum,CigaretteSum,OtherSum,TotalSum,RealSum,LogDate from PayOrder ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            RestaurantMIS.Model.PayOrder model = new RestaurantMIS.Model.PayOrder();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoomID"].ToString() != "")
                {
                    model.RoomID = int.Parse(ds.Tables[0].Rows[0]["RoomID"].ToString());
                }
                model.Category = ds.Tables[0].Rows[0]["Category"].ToString();
                if (ds.Tables[0].Rows[0]["FoodSum"].ToString() != "")
                {
                    model.FoodSum = decimal.Parse(ds.Tables[0].Rows[0]["FoodSum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WineSum"].ToString() != "")
                {
                    model.WineSum = decimal.Parse(ds.Tables[0].Rows[0]["WineSum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CigaretteSum"].ToString() != "")
                {
                    model.CigaretteSum = decimal.Parse(ds.Tables[0].Rows[0]["CigaretteSum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OtherSum"].ToString() != "")
                {
                    model.OtherSum = decimal.Parse(ds.Tables[0].Rows[0]["OtherSum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalSum"].ToString() != "")
                {
                    model.TotalSum = decimal.Parse(ds.Tables[0].Rows[0]["TotalSum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RealSum"].ToString() != "")
                {
                    model.RealSum = decimal.Parse(ds.Tables[0].Rows[0]["RealSum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LogDate"].ToString() != "")
                {
                    model.LogDate = DateTime.Parse(ds.Tables[0].Rows[0]["LogDate"].ToString());
                }
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,RoomID,Category,FoodSum,WineSum,CigaretteSum,OtherSum,TotalSum,RealSum,LogDate ");
            strSql.Append(" FROM PayOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "PayOrder";
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

