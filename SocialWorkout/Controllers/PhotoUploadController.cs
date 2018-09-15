using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SocialWorkout.Controllers
{
    public class PhotoUploadController : ApiController
    {

        public ActionResult AsyncUpload()
        {
            //Creating new userCTRL for updating IMGsrc for spesific user
            var usersCTRL = new UsersController();
            var TrainersCTRL = new TrainersController();

            HttpPostedFile file = HttpContext.Current.Request.Files["file"];


            string userId = HttpContext.Current.Request.Headers["id"];
            string Trainer = HttpContext.Current.Request.Headers["train"];




            // Saves the file name
            string fileName = userId+file.FileName;

            if (Trainer == null) { 
            var user = usersCTRL.Get(userId);

            user.ImgSrc = fileName;

            usersCTRL.Put(user);
            }
            else
            {
                var trainer = TrainersCTRL.Get(userId);
                trainer.ImgSrc = fileName;
                TrainersCTRL.Put(trainer);

            }


            // Specifies the target location for the uploaded files
            string targetLocation = HttpContext.Current.Server.MapPath("~/Content/UsersPhotos/");


        
            // Specifies the maximum size allowed for the uploaded files (700 kb)
            int maxFileSize = 1024 * 700;

            // Checks whether or not the request contains a file and if this file is empty or not
            if (file == null || file.ContentLength <= 0)
            {
                throw new HttpException("File is not specified");
            }

            // Checks that the file size does not exceed the allowed size
            if (file.ContentLength > maxFileSize)
            {
                throw new HttpException("File is too big");
            }

            // Checks that the file is an image
            if (!file.ContentType.Contains("image"))
            {
                throw new HttpException("Invalid file type");
            }

            try
            {
                string path = System.IO.Path.Combine(targetLocation, fileName);
                file.SaveAs(path);

            }
            catch (Exception e)
            {
                throw new HttpException("Invalid file name");
            }
            return new EmptyResult();
        }

    }
}
