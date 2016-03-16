using OCRApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OCRApp
{
    class Identify
    {
       public  enum dataType
        {
            
            System_Int32 = 1,
            System_Int64 = 2,
            System_Double = 3,
            System_DateTime = 4,
            System_String = 5
        }
        public List<row> RemoveSpace(List<row> preSapce)

        {


            string findpreSpace = "";
            
            for (int i = 0; i <= preSapce.Count - 1; i++)
            {
                if (preSapce[i].word != null)
                {
                    if (Regex.IsMatch(preSapce[i].word, @"\d\.$"))
                    {
                        findpreSpace = preSapce[i].word;
                    }

                    if (preSapce[i].word == ".")
                    {
                        if (preSapce[i - 1].type == 1 || preSapce[i - 1].type == 2)
                            if (preSapce[i + 1].type == 1 || preSapce[i + 1].type == 2)
                            {
                                preSapce[i - 1].word = preSapce[i - 1].word + preSapce[i].word + preSapce[i + 1].word;
                                preSapce[i - 1].type = 3;
                                preSapce[i].word = "";
                                preSapce[i].type = 5;
                                preSapce[i + 1].word = "";
                                preSapce[i + 1].type = 5;
                            }
                    }
                }
            }
                return preSapce;
        }
        public dataType StringType(string str)
        {

            string[] formats = {"M/d/yyyy", "M/d/yyyy",
                   "MM/dd/yyyy", "M/d/yyyy",
                   "M/d/yyyy", "M/d/yyyy",
                   "M/d/yyyy", "M/d/yyyy",
                   "MM/dd/yyyy", "M/dd/yyyy"};
            Int32 intValue;
            Int64 bigintValue;
            double doubleValue;
            DateTime dateValue;
            
           
            if(str!= null )
            { 
            Regex rgx = new Regex("\\$");
            str = rgx.Replace(str, "");
            }

            if (str == "") return dataType.System_String;

            else if (Int32.TryParse(str, out intValue))
                return dataType.System_Int32;
            else if (Int64.TryParse(str, out bigintValue))
                return dataType.System_Int64;
            else if (double.TryParse(str, out doubleValue))
                return dataType.System_Double;
            else if (DateTime.TryParseExact(str, formats,
                              new CultureInfo("en-US"),
                              DateTimeStyles.None, out dateValue))
                return dataType.System_DateTime;
            else return dataType.System_String;

        }


    }
}
