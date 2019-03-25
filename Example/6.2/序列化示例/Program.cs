using System;

using System.IO;

using System.Runtime.Serialization;

using System.Runtime.Serialization.Formatters.Binary;

 

namespace SerializationTest

{

  [Serializable]

  class Book {

      public string name;

      //public double price;

      public int num=13; //如果book的版本变了，反序列化时，这个默认值不会被执行

      public string [] reader;

 

      override public string ToString(){

          return name + ":" //+ price 

              + ":" + string.Join(",",reader)

              + ":" + num;

      }

  }

  class Program

  {

      static void Main(string[] args)

      {

 

      }

 

      static void TestBinary()

      {

          BinaryFormatter formatter = new BinaryFormatter();

 

          //Serialization of String Object

          Book book = new Book();

          book.name = "学习C#";

          book.price = 123.45;

          book.reader = new string[]{ "张三", "李四", "王五"};

 

          FileStream stream = new FileStream("C:\\StrObj.t", FileMode.Create, FileAccess.Write ,

            FileShare.None);

          formatter.Serialize(stream, book);

          stream.Close();

 

 

          //Deserialization of String Object

          FileStream readstream = new FileStream("C:\\StrObj.t", FileMode.Open , FileAccess.Read ,

            FileShare.Read );

          Book book2 = (Book)formatter.Deserialize(readstream);

          readstream.Close();

          Console.WriteLine(book2);

          Console.ReadLine();

 

      }

  }

}