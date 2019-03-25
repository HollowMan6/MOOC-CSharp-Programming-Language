using System;
using System.IO;
class  ListAllFiles 
{
    public static void Main(string[] args)
    { 
        ListFiles( new DirectoryInfo( @"c:\workspace"));
    }
 
    public static void ListFiles( FileSystemInfo info )
    {
        if( ! info.Exists ) return;
 
        DirectoryInfo dir = info as DirectoryInfo;
        if( dir == null ) return; //不是目录
         
        FileSystemInfo [] files = dir.GetFileSystemInfos();
        for( int i=0; i<files.Length; i++)
        {
            FileInfo file = files[i] as FileInfo;
            if( file != null ) // 是文件
            {
                Console.WriteLine( 
                    file.FullName + "\t" + file.Length );
            }
            else    //是目录
            {
                ListFiles( files[i] );  //对于子目录,进行递归调用
            }
        }
    }
}