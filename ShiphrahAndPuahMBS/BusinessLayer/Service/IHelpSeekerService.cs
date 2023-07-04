using ShiphrahAndPuahMBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiphrahAndPuahMBS.Businesslayer.Service
{
    public interface IHelpSeekerService
    {
        String NewHelpRequest(HelpSeeker newRequest, String filePath);
    }
}
