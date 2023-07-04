﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using ShiphrahAndPuahMBS.Businesslayer.Service;
using ShiphrahAndPuahMBS.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;

namespace ShiphrahAndPuahMBS.Controllers
{
    public class HelpSeekerController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly IHelpSeekerService _helpSeekerService;
        public HelpSeekerController(IHelpSeekerService helpSeekerService, IHostingEnvironment hostingEnvironment)
        {
            _helpSeekerService = helpSeekerService; _hostingEnvironment = hostingEnvironment;
        }

        //Generates the new form for Help Seekers.

        [HttpGet]
        public ActionResult newHelpRequest()
        {
            try
            {
                HelpSeeker newHelpRequest = new HelpSeeker();
                return View(newHelpRequest);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }

        // Submit new help request coming from help seekers.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult newHelpRequest(HelpSeeker newHelpRequest)
        {
            try
            {

                var filePath = _hostingEnvironment.ContentRootPath + "\\Uploaded_Files";

                //ViewBag.FilePath = ;
                var helpResult = _helpSeekerService.NewHelpRequest(newHelpRequest, filePath);
                ViewBag.result = helpResult;
                return View();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }



        // permits to download all files uploaded by user. 
        // While downloading zips the folder of all files.
        [HttpGet]
        public ActionResult downloadFiles([FromQuery] String Full_Name)
        {
            try
            {
             String[] files= Directory.GetFiles(_hostingEnvironment.ContentRootPath + "\\Uploaded_Files\\" + Full_Name);

                MemoryStream stream = new MemoryStream();
                
                    using(var zipArchive = new ZipArchive(stream, ZipArchiveMode.Create, true))
                    {
                        foreach (String file in files)
                        {
                            zipArchive.CreateEntryFromFile(file, Path.GetFileName(file));
                        }
                    }
                    stream.Position = 0;
                    return File(stream, "application/zip", Full_Name+ ".zip");
                
                
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }

        // List names of allow Help Seekers.
        // Allows admin to access those names and download all Excel,Image/pdf files

        [HttpGet]
        public ActionResult ResponseUsers()
        {
            try
            {
                var filePath = _hostingEnvironment.ContentRootPath + "\\Uploaded_Files";
                DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
                
                var folderList = directoryInfo.GetDirectories();
                
                List<ResponseUser> users = new List<ResponseUser>();
                foreach (var folder in folderList)
                {
                    users.Add(new ResponseUser() { Full_Name = folder.Name });
                }

                return View(users);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }
    }
}
