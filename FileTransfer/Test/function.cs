using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Test
{
    class function
    {
        public static void ZipAndMove()
        {

            string content = @"agcsmallmacsmallgggsmallytx";
            string sourcePath = @"G:\TestReport_ForNAS\ETAB107\2022-07-12\5ABD225X010001 2022-07-30 153419";
            string zipPath = @"G:\TestReport\5ABD225X010001 2022-07-12 153419.zip";
            string backupPath = @"G:\TestReport\\ETAB107\2022-07-12";

            string small = @"G:\TestReport_ForNAS";

            Console.WriteLine(sourcePath.Split('\\')[1]);
            string[] resultString = Regex.Split(sourcePath, "[A-Z0-9]{14}", RegexOptions.IgnoreCase);
            foreach (string i in resultString)
                Console.WriteLine(i.ToString());
        }
    }
}
