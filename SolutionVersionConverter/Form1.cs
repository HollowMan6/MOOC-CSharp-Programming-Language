using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SolutionVersionConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.txtFolder.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ConvertInPath(new DirectoryInfo(this.txtFolder.Text.Trim()));
            MessageBox.Show("ok!");
        }

        void ConvertInPath(DirectoryInfo path)
        {
            if(! path.Exists) return;

            foreach (FileInfo file in path.GetFiles())
            {
                string filepath = file.FullName;
                if (filepath.ToLower().EndsWith(".sln"))
                    ConvertSln(filepath);
                else if (filepath.ToLower().EndsWith(".csproj"))
                    ConvertPrj(filepath); 
                else if (filepath.ToLower().EndsWith(".config"))
                    ConvertCfg(filepath); 
            }

            foreach( DirectoryInfo subpath in path.GetDirectories() )
            {
                ConvertInPath(subpath);
            }
        }
        void ConvertSln(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            string content = sr.ReadToEnd();
            sr.Close();
            if (content.IndexOf("Microsoft Visual Studio Solution File, Format Version 12.00")>=0)
            {
                content = content.Replace("Microsoft Visual Studio Solution File, Format Version 12.00",
                    "Microsoft Visual Studio Solution File, Format Version 11.00");
                content = content.Replace("# Visual Studio 2013",
                    "# Visual Studio 2010");
                content = content.Replace("# Visual Studio 2012",
                    "# Visual Studio 2010");
                content = content.Replace("# Visual Studio Express 2013 for Windows Desktop",
                    "# Visual Studio 2010");
                content = content.Replace("# Visual Studio Express 2012 for Windows Desktop",
                    "# Visual Studio 2010");
                StreamWriter sw = new StreamWriter(path,false, Encoding.UTF8);
                sw.Write(content);
                sw.Close();
            }
        }
        void ConvertPrj(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            string content = sr.ReadToEnd();
            sr.Close();
            if (content.IndexOf("<TargetFrameworkVersion>v4.5</TargetFrameworkVersion>")>=0)
            {
                content = content.Replace("<TargetFrameworkVersion>v4.5</TargetFrameworkVersion>",
                    "<TargetFrameworkVersion>v4.0</TargetFrameworkVersion>");
                content = content.Replace("<ProjectGuid>",
                    "<ProductVersion>8.0.30703</ProductVersion><ProjectGuid>");
                content = content.Replace("<SignManifests>true</SignManifests>",
                    "<SignManifests>false</SignManifests>");

                StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
                sw.Write(content);
                sw.Close();
            }
        }
        void ConvertCfg(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            string content = sr.ReadToEnd();
            sr.Close();
            if (content.IndexOf("<supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.5\" />")>=0)
            {
                content = content.Replace("<supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.5\" />",
                    "<supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.0\" />");

                StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
                sw.Write(content);
                sw.Close();
            }
        }
    }
}
