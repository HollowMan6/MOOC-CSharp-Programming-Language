using System;
using System.Xml;

class Test 
{
	static void Main()
	{
		XmlDocument xd = new XmlDocument();
		try
		{
			xd.Load(@".\BookList.xml");
		}
		catch( XmlException e )
		{
			Console.WriteLine("Exception caught:  "+ e.ToString());
		}
		XmlNode doc = xd.DocumentElement;
   
		if( doc.HasChildNodes )
		{
			processChildren(doc,  0);
		}
	}
	static void processChildren( XmlNode xn, int level)
	{ //
		string istr;
		istr = indent(level);
		switch( xn.NodeType )
		{
			case XmlNodeType.Comment:
				Console.WriteLine(istr +  "<!--" + xn.Value +  "-->");
				break;
			case XmlNodeType.ProcessingInstruction:
				Console.WriteLine(istr + "<?" + xn.Name +  " " + xn.Value +" ?>");
				break;
			case XmlNodeType.Text:
				Console.WriteLine(istr + xn.Value);
				break;
			case XmlNodeType.Element:
				XmlNodeList ch = xn.ChildNodes;
				Console.Write(istr + "<" + xn.Name);

				XmlAttributeCollection atts = xn.Attributes; //处理属性
				if( atts != null )
				{
					foreach( XmlNode at in atts )
					{
						Console.Write( " "  + at.Name + "=" + at.Value);
					}
				}
				Console.WriteLine(">");

				foreach(XmlNode nd in ch )
				{
					processChildren(nd,  level + 2); //对子结点递归调用
				}
				Console.WriteLine(istr + "</" + xn.Name+ ">");
				break;
		}
		
	}

	static string indent( int i )
	{
		if( i==0 ) return "";
		return new String( ' ', i );
	}
}
