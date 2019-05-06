using System;
using System.Collections.Generic;
using System.Text;

namespace CrudDemo.Biz
{
    public class UserBiz
    {
        public static bool CheckUserPassword(string userName, string password)
        {
            string sql = string.Format("select count(*) from [User] where UserName='{0}' and Password='{1}'",
                userName, password);

            int cnt = Convert.ToInt32( DAL.AccessDB.ExecuteScalar(sql));
            return cnt != 0;
        }
    }
}
