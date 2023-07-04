using Microsoft.AspNetCore.Http;
using ShiphrahAndPuahMBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiphrahAndPuahMBS.Businesslayer.Repository
{
    public interface IHelpSeekerRepository
    {
        String NewHelpRequest(HelpSeeker newRequest, String filePath);
        string uploadEmployeeIDImageOrPDF(IFormFile IdFile, String filePath);
        string uploadDoctorPrescriptionImageOrPDF(IFormFile prescriptionFile, String filePath);

        string uploadMedicalBillImageOrPDF(IFormFile billFile, String filePath);
    }
}
