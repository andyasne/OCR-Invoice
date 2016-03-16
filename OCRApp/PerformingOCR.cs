using OCRApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace OCRApp
{
    class PerformingOCR
    {

        public static List<row> DoOCR1(string imageDir)
        {
            if (imageDir != null)//&& imageDir.fil > 0) check file exist 
            {

                var Rowlist = new List<row>();
               
                using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                {
                    // have to load Pix via a bitmap since Pix doesn't support loading a stream.
                    engine.SetVariable("tessedit_char_whitelist", "16.00ABCDEFGHIJKLMNOPQRSTUVWXYZ(quick) brown { fox} jumps!over the $3,456.78 < lazy >: #90 dog & duck/goose, as 12.5% of Email from aspammer@website.com is spam?");
                    // engine.DefaultPageSegMode = PageSegMode.AutoOsd;
                    // engine.SetVariable("tessedit_char_whitelist", "0123456789,/ABCDEFGHIJKLMNOPQRSTUVWXYZ.abcdefghijklmnopqrstuvwxyz():!'$");
                    Pix pixImage = Pix.LoadFromFile(imageDir);
                    // pixImage = pixImage.Deskew();
                    //Scew scew;
                    //pixImage = pixImage.Deskew(new ScewSweep(range: 90), Pix.DefaultBinarySearchReduction, Pix.DefaultBinaryThreshold, out scew);
                    //pixImage.Save(@"C:\OCR\EnhancedImage\deskew.tiff", ImageFormat.Tiff);
                    using (var image = new System.Drawing.Bitmap(imageDir))
                    {
                        using (var pix = PixConverter.ToPix(image))
                        {
                           // pix.Deskew();
                            
                            using (var page = engine.Process(pix))
                            {
                                Console.WriteLine("Mean confidence: {0:p}", page.GetMeanConfidence());

                                Console.WriteLine(page.GetText());
                                var i = 1;
                                var j = 1;
                                using (var iter = page.GetIterator())
                                {
                                    iter.Begin();
                                    do
                                    {
                                        do
                                        {
                                            // Console.WriteLine("in-looop");
                                            do
                                        {

                                            Console.WriteLine("Line {0}", i);


                                            j = 1;
                                            do

                                            {


                                                //if (iter.GetText(PageIteratorLevel.Word) != "")
                                                // strWord = iter.GetText(PageIteratorLevel.Word).GetType().GetGenericTypeDefinition();

                                                Console.WriteLine("word:{0}  ", iter.GetText(PageIteratorLevel.Word));
                                                Identify strType = new Identify();



                                                Rowlist.Add(new row
                                                {
                                                    line = i,
                                                    colomun = j,
                                                    type = Convert.ToInt16(strType.StringType(iter.GetText(PageIteratorLevel.Word))),
                                                    word = iter.GetText(PageIteratorLevel.Word)

                                                });
                                                j = j + 1;

                                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));


                                            i++;
                                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                    } while (iter.Next(PageIteratorLevel.Block));
                                    var k = Rowlist;
                                }

                            }
                        }
                    }
                }
                
                return Rowlist;
            }
            else return null;
            

        }

 
    }
}

