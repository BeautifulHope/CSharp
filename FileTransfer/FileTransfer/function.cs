using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO.Compression;
using System.Text.RegularExpressions;

namespace FileTransfer
{
    class function
    {
        /// <summary>
        /// 获得指定路径下所有文件和子文件夹
        /// </summary>
        public static void delteDirectoryAndFile(string targetPath)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(targetPath);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            di.Delete(true);
        }


        /// <summary>
        /// 获得指定路径下所有文件名
        /// </summary>
        /// <param name="sw">文件写入流</param>
        /// <param name="path">文件写入流</param>
        /// <param name="indent">输出时的缩进量</param>
        public static void getFileName(string path)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (FileInfo f in root.GetFiles())
            {
                Console.WriteLine(f.Name);
            }
        }

        /// <summary>
        /// 获得指定路径下所有子目录名
        /// </summary>
        /// <param name="sw">文件写入流</param>
        /// <param name="path">文件夹路径</param>
        /// <param name="indent">输出时的缩进量</param>
        public static void getDirectory(string path, ArrayList al)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            int targetPathLength = 72;//path的长度
            if (path.Split('\\')[1] == "TestReport_ForNAS")
            {
                ;
            }
            else
            {
                //51-"G:\--------\ETAB106\2022-07-12\5ABD225X010001 2022-07-30 153415"
                targetPathLength = path.Split('\\')[1].Length + 55;
            }

            //int num = 0;
            foreach (DirectoryInfo d in root.GetDirectories())
            {
                //Console.WriteLine("d.FullName:" + d.FullName);
                //Console.WriteLine("d.Length:" + d.FullName.ToString().Length);
                if ((d.FullName.ToString().Length > 0))
                {
                    getDirectory(d.FullName,al);
                    if ((d.FullName.ToString().Length == targetPathLength))
                    {
                        al.Add(d.FullName);
                    }
                    //Console.WriteLine("------------------------");
                }
                else
                {
                    continue;
                }
                //Console.WriteLine("------------" + num.ToString() + "------------");
                //num++;
            }
        }

        /// <summary>
        /// 获得所有目标文件夹的所有子目录名
        /// </summary>
        /// <param name="sw">文件写入流</param>
        /// <param name="path">文件夹路径</param>
        /// <param name="indent">输出时的缩进量</param>
        public static ArrayList GetSourceFilePath()
        {

            //存储目标文件夹的所有子目录名
            ArrayList sourceFilePath = new ArrayList();
            ArrayList targetFilePath = new ArrayList();


            ////获取当前程序所在的文件路径
            string binPath = Directory.GetCurrentDirectory();
            //string parentPath = Directory.GetParent(binPath).FullName;//上级目录
            string rootPath = binPath.Split('\\')[0] + "\\" + "TestReport_ForNAS";
            targetFilePath.Add(rootPath);
            //
            //
            //for multi path
            targetFilePath.Add("G:\\TestReport_ForNAS2");

            //Console.WriteLine(binPath);
            //Console.WriteLine(rootPath);
            LogHelper.Info(String.Format("rootPath:{0}", rootPath));

            for (int i = 0; i < targetFilePath.Count; i++)
            {
                getDirectory(targetFilePath[i].ToString(), sourceFilePath);
            }

            //foreach (var item in sourceFilePath)
            //{
            //    LogHelper.Info(String.Format("{0}:::{1}:::{2}", num, item.ToString().Length, item));
            //    Console.WriteLine("{0}:::{1}:::{2}", num++, item.ToString().Length, item);
            //}


            return sourceFilePath;
        }


        public static void prase(string sourcePath,string zipPath, string backupPath)
        {
            //sourcePath = @"G:\TestReport_ForNAS\ETAB107\2022-07-12\5ABD225X010001 2022-07-30 153419";
            //zipPath =    @"G:\TestReport\5ABD225X010001 2022-07-12 153419.zip";
            //backupPath = @"G:\TestReport\\ETAB107\2022-07-12\";

            //创建目标文件夹

            string pathString = 

            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("path \"{0}\" already exists.", pathString);
                LogHelper.Info(String.Format("path \"{0}\" already exists.", pathString));
            }

            //删除重复zip文件
            if (System.IO.File.Exists(Path.GetFullPath(zipPath)))
            {
                File.Delete(Path.GetFullPath(zipPath));
                LogHelper.Info(Path.GetFullPath(zipPath) + " deleted..");
            }
            else
            {
                LogHelper.Info(Path.GetFullPath(zipPath) + " not exist..");
            }

            ZipFile.CreateFromDirectory(sourcePath, zipPath);
            if (backupPath != "")
            {
                ZipFile.ExtractToDirectory(zipPath, backupPath);
            }
        }

        public static void ZipAndMove()
        {
            //source file path list
            ArrayList sourceFilePath = GetSourceFilePath();
            //gener zip file path
            string GenerZipPath = Directory.GetCurrentDirectory().Split('\\')[0] + "\\" + "TestReport";
            //LogHelper.Info("==========" + GenerZipPath + "=========");
            ////获取当前程序所在的文件路径
            string binPath = Directory.GetCurrentDirectory();
            //string parentPath = Directory.GetParent(binPath).FullName;//上级目录
            String rootPath = binPath.Split('\\')[0] + "\\" + "TestReport_ForNAS";
            string tempPath;

            for (int i = 0; i < sourceFilePath.Count; i++)
            {
                //LogHelper.Info(String.Format("{0}:::{1}:::{2}", i, sourceFilePath[i].ToString().Length, sourceFilePath[i]));
                //构造zip的目标path
                tempPath = GenerZipPath + Regex.Split(sourceFilePath[i].ToString(), sourceFilePath[i].ToString().Split('\\')[1],
                    RegexOptions.IgnoreCase)[1] + ".zip";
                LogHelper.Info(String.Format("{0}:::{1}->{2}", "GenerZipPath", sourceFilePath[i], tempPath));

                //生成zip并且备份
                prase(sourceFilePath[i].ToString(), tempPath, "");


                //string[] resultString = Regex.Split(sourceFilePath[i].ToString(), sourceFilePath[i].ToString().Split('\\')[1], 
                //    RegexOptions.IgnoreCase);
            }
        }

    }
}
