using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using RestaurantMIS.DBUtility;//请先添加引用
namespace RestaurantMIS.DAL
{
    /// <summary>
    /// 数据访问类PayOrderItem。
    /// </summary>
    public class PayOrderItem
    {
        public PayOrderItem()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PayOrderItem");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(RestaurantMIS.Model.PayOrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PayOrderItem(");
            strSql.Append("ID,PayOrderID,Category,ItemName,Price,Amount,Sum)");
            strSql.Append(" values (");
            strSql.Append("@ID,@PayOrderID,@Category,@ItemName,@Price,@Amount,@Sum)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4),
					new OleDbParameter("@PayOrderID", OleDbType.Integer,4),
					new OleDbParameter("@Category", OleDbType.VarChar,255),
					new OleDbParameter("@ItemName", OleDbType.VarChar,255),
					new OleDbParameter("@Price", OleDbType.Decimal),
					new OleDbParameter("@Amount", OleDbType.Integer,4),
					new OleDbParameter("@Sum", OleDbType.Decimal)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PayOrderID;
            parameters[2].Value = model.Category;
            parameters[3].Value = model.ItemName;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.Amount;
            parameters[6].Value = model.Sum;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RestaurantMIS.Model.PayOrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PayOrderItem set ");
            strSql.Append("ID=@ID,");
            strSql.Append("PayOrderID=@PayOrderID,");
            strSql.Append("Category=@Category,");
            strSql.Append("ItemName=@ItemName,");
            strSql.Append("Price=@Price,");
            strSql.Append("Amount=@Amount,");
            strSql.Append("Sum=@Sum");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4),
					new OleDbParameter("@PayOrderID", OleDbType.Integer,4),
					new OleDbParameter("@Category", OleDbType.VarChar,255),
					new OleDbParameter("@ItemName", OleDbType.VarChar,255),
					new OleDbParameter("@Price", OleDbType.Decimal),
					new OleDbParameter("@Amount", OleDbType.Integer,4),
					new OleDbParameter("@Sum", OleDbType.Decimal)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PayOrderID;
            parameters[2].Value = model.Category;
            parameters[3].Value = model.ItemName;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.Amount;
            parameters[6].Value = model.Sum;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PayOrderItem ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RestaurantMIS.Model.PayOrderItem GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PayOrderID,Category,ItemName,Price,Amount,Sum from PayOrderItem ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            RestaurantMIS.Model.PayOrderItem model = new RestaurantMIS.Model.PayOrderItem();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayOrderID"].ToString() != "")
                {
                    model.PayOrderID = int.Parse(ds.Tables[0].Rows[0]["PayOrderID"].ToString());
                }
                model.Category = ds.Tables[0].Rows[0]["Category"].ToString();
                model.ItemName = ds.Tables[0].Rows[0]["ItemName"].ToString();
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Amount"].ToString() != "")
                {
                    model.Amount = int.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sum"].ToString() != "")
                {
                    model.Sum = decimal.Parse(ds.Tables[0].Rows[0]["Sum"].ToString());
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
            strSql.Append("select ID,PayOrderID,Category,ItemName,Price,Amount,Sum ");
            strSql.Append(" FROM PayOrderItem ");
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
            parameters[0].Value = "PayOrderItem";
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

