using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace pharmacy2
{
    public class fileupload
    {
        private readonly IWebHostEnvironment _webhostenvironment;

        //private object _webhostingenvironment;

        public fileupload(IWebHostEnvironment webHostEnvironment)
        {
            _webhostenvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file,string name)
        {
            if (file == null) return "";
            var path = _webhostenvironment.WebRootPath + "\\images\\daro\\" +name+ file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return name+file.FileName;
            //
        }
        public string Upload_banner(IFormFile file)
        {
            if (file == null) return "";
            var path = _webhostenvironment.WebRootPath + "\\images\\banner\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;
            //
        }

        public string Uploadvideo(IFormFile file)
        {
            if (file == null) return "";
            var path = _webhostenvironment.WebRootPath + "\\videos\\daro\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            path = path.Split("wwwroot")[1];
            return path;

            //
        }
    }
}