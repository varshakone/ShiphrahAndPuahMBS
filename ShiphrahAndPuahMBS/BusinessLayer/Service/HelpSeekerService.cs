using ShiphrahAndPuahMBS.Businesslayer.Repository;
using ShiphrahAndPuahMBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiphrahAndPuahMBS.Businesslayer.Service
{
    public class HelpSeekerService : IHelpSeekerService
    {
        private readonly IHelpSeekerRepository _helpSeekerRepository;
        public HelpSeekerService(IHelpSeekerRepository helpSeekerRepository)
        {
            _helpSeekerRepository = helpSeekerRepository;
        }

        // Save new help seekers's details in Excel file
        //Each file saved under folder named with Employee Full Name present in Uploaded_Files 
        public string NewHelpRequest(HelpSeeker newRequest, string filePath)
        {
            try
            {
                String helpResult = string.Empty;
                String result= _helpSeekerRepository.NewHelpRequest(newRequest, filePath);
                if(result !=null)
                {
                    helpResult = result;
                }
                return helpResult;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
