using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUpload.ViewModel
{
    public class File
    {
        public string FilePath { get; set; }
        public long FileID { get; set; }
        public string FileName { get; set; }
    }

    public static class UploadsViewModel
    {
        public static List<File> Uploads { get; set; }

        static UploadsViewModel()
        {
            Uploads = new List<File>();
        }
    }
}