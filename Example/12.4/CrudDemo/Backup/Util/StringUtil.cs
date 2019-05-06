using System;

namespace CrudDemo.Util
{
	public class StringUtil
	{

		public static bool isNotBlank(string str)
		{
			return ! isBlank( str );
		}
		public static bool isBlank(string str)
		{
			return str==null || str.Length==0;
		}

		public static string AddSqlWhere (ref string strSql,  string fieldName, string op, string fieldValue )
		{
			if( fieldName=="" || fieldValue=="" ) return strSql;
			fieldValue = fieldValue.Trim().Replace("'","");
			op = op.Trim().ToLower();

			if( op=="" || op==null ) op="=";
			if( op=="like" && (fieldValue.IndexOf("%")<0 && fieldValue.IndexOf("_")<0 ) )
				fieldValue = "%" + fieldValue + "%";

			string where = fieldName + " " + op + " '"  + fieldValue  + "'" ;

			return AddSqlWhere(ref strSql, where );
		}
		public static string AddSqlWhere (ref string strSql,  string filter )
		{
			if( filter==null || filter.Trim() == "" ) return strSql;
			
			if( strSql.Trim().ToLower().EndsWith("where") ) return strSql = strSql +  filter;
			if( strSql.Trim().ToLower().EndsWith("and") ) return strSql = strSql +  filter;

			//这里有个bug，如果是子查询有where，而主查询没有where，这里是不对的，所以要求主查询最好有个where 1=1
			if( strSql.Trim().ToLower().IndexOf("where") >= 0 ) return strSql = strSql +  " and " + filter;
			return strSql = strSql +  " where " + filter;
		}

		public static string MakeUpdateSql( string [] fields, string []values, string table, string where )
		{
			string strUpdate = "update ["+ table + "] set ";
			for( int i=0; i<fields.Length; i++ )
			{
				string key = fields[i];
				string val = values[ i ];
				if( val == null ) val = ""; //为了容错性，将没有的参数都当做空
				val = val.Replace("'", ""); //为了避免sql注入问题，将单引号全部去掉
				
				strUpdate += key + "='" + val + "',";
			}
			strUpdate = strUpdate.TrimEnd(',') + " where " + where; //改成以报案号为准 2009-8-29

			return strUpdate;

		}

		public static string MakeWhereByComma (string field, string val )
		{
			if( val == ""|| val==null ) return "";
			string [] words = val.Split(",".ToCharArray()); //按逗号多选的功能
			string sf = "";
			for(int i=0; i<words.Length;i++)
			{
				string w = words[i].Trim();
				if( w=="" ) continue;
				if( sf != "" ) sf += " or ";
				sf += field + " = '" + w +"' ";
			}
			if( sf == "" ) return "";
			return "(" + sf + ")";
		}
		public static string MakeWhereLikeByComma (string field, string val )
		{
			if( val == ""|| val==null ) return "";
			string [] words = val.Split(",".ToCharArray()); //按逗号多选的功能
			string sf = "";
			for(int i=0; i<words.Length;i++)
			{
				string w = words[i].Trim();
				if( w=="" ) continue;
				if( sf != "" ) sf += " or ";
				sf += field + " like '%" + w +"%' ";
			}
			if( sf == "" ) return "";
			return "(" + sf + ")";
		}


		public static string MakeInsertSql(  string [] fields, string []values, string table )
		{
			string strInsertFld = "";
			string strInsertVal = "";
			for( int i=0; i<fields.Length; i++ )
			{
				string key = fields[i];
				string val = values[ i ];
				if( val == null ) val = ""; //为了容错性，将没有的参数都当做空
				val = val.Replace("'", ""); //为了避免sql注入问题，将单引号全部去掉
				
				strInsertFld += key + ",";
				strInsertVal += "'" + val + "',";
			}
			string strInsert = "insert into "+ table + "( " + strInsertFld.TrimEnd(',') + " ) values (" + strInsertVal.TrimEnd(',' ) + ")";

			return strInsert;
		}


	}
}
