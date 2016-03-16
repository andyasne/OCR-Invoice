using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OCRApp
{
    class Program
    {
        static void Main(string[] args)
        {

            
            string targetDirectory = @"C:\OCR\File\";
            
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            //foreach (string fileName in fileEntries)
            //{
            //    Console.WriteLine("Processed file '{0}'.", fileName);

            //}
            OCRApp.PDFProcessing.ConvertPDF(targetDirectory);
            OCRApp.ImageProcessing.GetIMagesOnly(targetDirectory);
            
            Console.ReadLine();

        }
    }
}
