using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using RestaurantMIS.DBUtility;//请先添加引用
using System.Collections.Generic;//请先添加引用
namespace RestaurantMIS.DAL
{
    /// <summary>
    /// 数据访问类CaiDan。
    /// </summary>
    public class CaiDan
    {
        public CaiDan()
        { }

        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CaiDan");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(RestaurantMIS.Model.CaiDan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CaiDan(");
            strSql.Append("[Category],[Name],[Price],[LogDate])");
            strSql.Append(" values (");
            strSql.Append("@Category,@Name,@Price,@LogDate)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@Category", OleDbType.VarChar,255),
					new OleDbParameter("@Name", OleDbType.VarChar,255),
					new OleDbParameter("@Price", OleDbType.Decimal),
					new OleDbParameter("@LogDate", OleDbType.Date)};
            parameters[0].Value = model.Category;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.LogDate;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RestaurantMIS.Model.CaiDan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CaiDan set ");
            if (model.Category != null)
            {
                strSql.Append("Category='" + model.Category + "',");
            }
            if (model.Name != null)
            {
                strSql.Append("Name='" + model.Name + "',");
            }

            strSql.Append("Price=" + model.Price + ",");

            if (model.LogDate != null)
            {
                strSql.Append("LogDate='" + model.LogDate + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where ID=" + model.ID + " ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CaiDan ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RestaurantMIS.Model.CaiDan GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Category,Name,Price,LogDate from CaiDan ");
            strSql.Append(" where ID=@ID ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = ID;

            RestaurantMIS.Model.CaiDan model = new RestaurantMIS.Model.CaiDan();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Category = ds.Tables[0].Rows[0]["Category"].ToString();
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
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
            strSql.Append("select ID,Category,Name,Price,LogDate ");
            strSql.Append(" FROM CaiDan ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        public List<string> GetDistinctCol(string colName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DISTINCT ");
            strSql.Append(colName);
            strSql.Append(" FROM CaiDan ");

            DataTable dt = DbHelperOleDb.Query(strSql.ToString()).Tables[0];
            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row[0].ToString());
            }

            return list;
        }

        #endregion  成员方法
    }
}

