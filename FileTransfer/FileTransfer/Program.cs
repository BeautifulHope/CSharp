﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            //string[] more = PathAndIni.filePath_splite;
            //foreach (var item in more)
            //{
            //    Console.WriteLine(item);
            //}
            function.ZipAndMove();
            //ZipFileHelper.prase();
        }
    }
}