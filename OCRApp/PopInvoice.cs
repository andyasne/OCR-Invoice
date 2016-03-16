using OCRApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OCRApp
{
    class PopInvoice
    {
        public static Invoice poplateInvoice(List<row> pageItem, string fileName)
        {
            int whereTotal=0;
            
            var total = new List<string> { "Total", "Total dues" };
            Invoice currentInvoice = new Invoice();
            for (int i = pageItem.Count - 1; i >= 0; i--)
            {
                if (pageItem[i].word != null)
                    
                {
                    if (pageItem[i].word.ToUpper() == "TOTAL".ToUpper()  || pageItem[i].word.ToUpper() == "T0TAL:".ToUpper() || pageItem[i].word.ToUpper() == "T0ta1".ToUpper() || pageItem[i].word.ToUpper() == "TOTA1".ToUpper() || pageItem[i].word.ToUpper() == "payment".ToUpper()) 
                {
                    whereTotal = i;
                        for (int j = whereTotal; j <= pageItem.Count - 1; j++)
                        {
                            if (pageItem[whereTotal].line != pageItem[j].line) break;

                            if (pageItem[j].type == 3  )
                            {
                                currentInvoice.TotalAmount = pageItem[j].word;
                                int whereLineItem = 0;
                                double itemAmount = 0;

                                string iteamName = "";
                                double itemQty = 0;

                                for (int k= whereTotal; k >= 0; k-- )
                                {

                                    if (whereLineItem != 0 && whereLineItem != pageItem[k].line)
                                    {
                                        whereLineItem = 0;
                                        Lineitem lineIteam = new Lineitem();
                                        lineIteam.ItemAmount = itemAmount;
                                        lineIteam.ItemQty = itemQty;
                                        lineIteam.ItemName = iteamName;
                                        currentInvoice.Lineitems.Add(lineIteam);
                                        iteamName = "";
                                    }

                                    if (pageItem[whereTotal].line != pageItem[k].line)
                                    {
                                        

                                        if (pageItem[k].type == 3 && whereLineItem == 0)
                                        {
                                            whereLineItem = pageItem[k].line;

                                            Regex rgx = new Regex("\\$");
                                            string  str = rgx.Replace(pageItem[k].word, "");
                                            itemAmount  = Convert.ToDouble(str);

                                            
                                        }

                                        if (whereLineItem == pageItem[k].line)
                                        {
                                            
                                            if (pageItem[k].type == 1 || pageItem[k].type == 2)
                                                itemQty = Convert.ToDouble(pageItem[k].word);
                                            else if (pageItem[k].type == 5 && pageItem[k].word != "$")
                                                iteamName =   pageItem[k].word + " "+iteamName;

                                        }
                                        

                                    }
                                }
                            }
                        }
                    }
                if (pageItem[i].type==4)
                    {
                        //IFormatProvider monthFirst = IFormatProvider("MM/dd/yyyy");
                        currentInvoice.InvoiceDate =Convert.ToDateTime( pageItem[i].word);
                    }
                    
                }
             }
            int currentLine = 0;
            string vName = "";
            for (int i = 0; i <= pageItem.Count -1 ; i++)
            {
                if (vName != "")
                {
                    if (currentLine != pageItem[i].line && currentLine != 0)
                    {
                        currentInvoice.VendorName = vName;
                        break;
                    }
                }
                    if (pageItem[i].type== 5 && pageItem[i].word != null)
                { 
                    if (pageItem[i].word.Trim() != "")
                        vName = vName + " " + pageItem[i].word;
                    if (currentLine == 0)
                        currentLine = pageItem[i].line;
                }
            }
            currentInvoice.InvoiceID = fileName;
            if(currentInvoice.TotalAmount == null)
            {
                //advanced Total finder 
                for (int i = pageItem.Count - 1; i >= 0; i--)
                {
                    
                    if (pageItem[i].type == 3 && currentInvoice.TotalAmount == null)
                    {

                        currentInvoice.TotalAmount = pageItem[i].word;
                        int whereLineItem = 0;
                        double itemAmount = 0;

                        string iteamName = "";
                        double itemQty = 0;
                        whereTotal = i;
                        for (int k = whereTotal; k >= 0; k--)
                        {

                            if (whereLineItem != 0 && whereLineItem != pageItem[k].line)
                            {
                                whereLineItem = 0;
                                Lineitem lineIteam = new Lineitem();
                                lineIteam.ItemAmount = itemAmount;
                                lineIteam.ItemQty = itemQty;
                                lineIteam.ItemName = iteamName;
                                currentInvoice.Lineitems.Add(lineIteam);
                                iteamName = "";
                            }

                            if (pageItem[whereTotal].line != pageItem[k].line)
                            {


                                if (pageItem[k].type == 3 && whereLineItem == 0)
                                {
                                    whereLineItem = pageItem[k].line;

                                    Regex rgx = new Regex("\\$");
                                    string str = rgx.Replace(pageItem[k].word, "");
                                    itemAmount = Convert.ToDouble(str);


                                }

                                if (whereLineItem == pageItem[k].line)
                                {

                                    if (pageItem[k].type == 1 || pageItem[k].type == 2)
                                        itemQty = Convert.ToDouble(pageItem[k].word);
                                    else if (pageItem[k].type == 5 && pageItem[k].word != "$")
                                        iteamName = pageItem[k].word + " " + iteamName;

                                }


                            }
                        }
                    }
                }

            }
            return currentInvoice;
        }
    }
}
