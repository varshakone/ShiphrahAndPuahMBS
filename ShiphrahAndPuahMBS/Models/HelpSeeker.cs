using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
namespace ShiphrahAndPuahMBS.Models
{
    public class HelpSeeker
    {
        [Required(ErrorMessage = "Please type your full name")]
        public string Full_Name { get; set; }

        [Required(ErrorMessage = "Please type organization name")]
        public string Organization_Name { get; set; }

        [Required(ErrorMessage = "Please type your employee ID")]
        public string Employee_ID { get; set; }



        [Required(ErrorMessage = "Please select employee ID image file or pdf file")]
        [DataType(DataType.Upload)]
        public IFormFile Employee_IDImageOrPDF { get; set; }


        [Required(ErrorMessage = "Please type your mobile number")]
        
        public long MobileNumber { get; set; }


        [Required(ErrorMessage = "Please type your Residential Location")]
        public string Residential_Location { get; set; }


        [Required(ErrorMessage = "Please type Medical Ailment and support required")]
        public String Support_Required { get; set; }


        [Required(ErrorMessage = "Please type your medical bill amount")]
        public long Medical_BillAmount { get; set; }


        [Required(ErrorMessage = "Please select doctor prescription file ")]
        [DataType(DataType.Upload)]
        public IFormFile Doctor_PrescriptionImageOrPDF { get; set; }


        [Required(ErrorMessage = "Please select medical bill file either image or pdf ")]
        [DataType(DataType.Upload)]
        public IFormFile Medical_BillImageOrPDF { get; set; }


       public long Medical_AmountSanctioned { get; set; }



    }
}
