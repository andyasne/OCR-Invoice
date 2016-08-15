# OCR-Invoice
a console application that would run on Windows server to scan user’s Bill and Receipts, 
which are either captured by camera or in form of an electronic file like pdf etc. 
1. All the invoices/receipts will be uploaded on server in a folder 
2. The uploaded invoices/receipts will be scanned by OCR app and extract following information from the file and put them in database table
- Vendor/Party Name  
- Invoice date         
- Tax amount      
- Total amount  
- Line items(Item Name, Item Qty, Item rate, Item Tax &amp; Item Amount) 
3. The processing of OCR should be done with 90% of accuracy
4. Application designed be able to handle the noise &amp; quality of the uploaded invoice images.

C# , tessreact OCR , imagemagick and openCV 
