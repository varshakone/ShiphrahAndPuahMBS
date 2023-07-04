using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using ShiphrahAndPuahMBS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiphrahAndPuahMBS.Businesslayer.Repository
{
    public class HelpSeekerRepository : IHelpSeekerRepository
    {

        // Save new help seekers's details in Excel file
        //Each file saved under folder named with Employee Full Name present in Uploaded_Files 
        public string NewHelpRequest(HelpSeeker newRequest, String filePath)
        {
            string requestResult = null;
            if(Directory.Exists(filePath))
            {
                List<HelpSeeker> table = new List<HelpSeeker>();
                table.Add(newRequest);
                var dResult = Directory.CreateDirectory(filePath + "\\" + newRequest.Full_Name);
                if (dResult.Exists)
                {
                    filePath = filePath + "\\" + newRequest.Full_Name;
                    table.Add(newRequest);
                    FileStream fileLocation = new FileStream(filePath + "\\" + newRequest.Full_Name + ".xls", FileMode.CreateNew, FileAccess.ReadWrite);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelPackage pack = new ExcelPackage(fileLocation);

                    ExcelWorksheet ws = pack.Workbook.Worksheets.Add("NewHelp");
                    ws.Cells["A1"].LoadFromCollection(table, true, TableStyles.Light1);
                    pack.Save();
                    var id = this.uploadEmployeeIDImageOrPDF(newRequest.Employee_IDImageOrPDF, filePath);
                    var prescription= this.uploadDoctorPrescriptionImageOrPDF(newRequest.Doctor_PrescriptionImageOrPDF, filePath); 
                    var bill= this.uploadMedicalBillImageOrPDF(newRequest.Medical_BillImageOrPDF, filePath);
                    if(bill!=String.Empty && id !=String.Empty && prescription!= String.Empty )
                    {
                        requestResult = "Request Submitted Successfully";
                    }
               }
            }
            else
            {
               var pResult= Directory.CreateDirectory(filePath);
                var eResult = Directory.CreateDirectory(filePath + "\\" + newRequest.Full_Name);
                if (pResult.Exists && eResult.Exists)
                {
                    filePath = filePath+"\\" + newRequest.Full_Name;
                    List<HelpSeeker> table = new List<HelpSeeker>();
                    table.Add(newRequest);
                    FileStream fileLocation = new FileStream(filePath + "\\" + newRequest.Full_Name + ".xls", FileMode.CreateNew, FileAccess.ReadWrite);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelPackage pack = new ExcelPackage(fileLocation);

                    ExcelWorksheet ws = pack.Workbook.Worksheets.Add("NewHelp");
                    ws.Cells["A1"].LoadFromCollection(table, true, TableStyles.Light1);
                    pack.Save();
                    var id = this.uploadEmployeeIDImageOrPDF(newRequest.Employee_IDImageOrPDF, filePath);
                    var prescription = this.uploadDoctorPrescriptionImageOrPDF(newRequest.Doctor_PrescriptionImageOrPDF, filePath);
                    var bill = this.uploadMedicalBillImageOrPDF(newRequest.Medical_BillImageOrPDF, filePath);
                    if (bill != String.Empty && id != String.Empty && prescription != String.Empty)
                    {
                        requestResult = "Request Submitted Successfully";
                    }
                }
            }
           
            return requestResult;
        }

        //Upload the Employee ID Image or pdf file in Uploaded_files folder of content path
        //Each file saved under folder named with Employee Full Name present in Uploaded_Files 
        public string uploadEmployeeIDImageOrPDF(IFormFile IdFile, String filePath)
        {
            string filename= IdFile.FileName;
            string fresult = string.Empty;
            using(FileStream fstream = new FileStream(Path.Combine(filePath,filename),FileMode.Create))
            {
                IdFile.CopyTo(fstream);
                fresult = "File Uploaded";
            }
            
            return fresult;
        }

        //Upload the Doctor Prescription Image or pdf file in Uploaded_files folder of content path
        //Each file saved under folder named with Employee Full Name present in Uploaded_Files 
        public string uploadDoctorPrescriptionImageOrPDF(IFormFile prescriptionFile, String filePath)
        {
            string filename = prescriptionFile.FileName;
            string fresult = string.Empty;
            using (FileStream fstream = new FileStream(Path.Combine(filePath, filename), FileMode.Create))
            {
                prescriptionFile.CopyTo(fstream);
                fresult = "File Uploaded";
            }

            return fresult;
        }

        //Upload the medical bill Image or pdf file in Uploaded_files folder of content path
        //Each file saved under folder named with Employee Full Name present in Uploaded_Files 
        public string uploadMedicalBillImageOrPDF(IFormFile billFile, String filePath)
        {
            string filename = billFile.FileName;
            string fresult = string.Empty;
            using (FileStream fstream = new FileStream(Path.Combine(filePath, filename), FileMode.Create))
            {
                billFile.CopyTo(fstream);
                fresult = "File Uploaded";
            }

            return fresult;
        }
    }
}
