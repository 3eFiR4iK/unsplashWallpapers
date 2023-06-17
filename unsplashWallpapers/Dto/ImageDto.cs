using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unsplashWallpapers.Dto
{
    internal class ImageDto
    {
        public string Id { get; set; }

        public string DownloadUri { get; set; }

        public string? RealPath { get; set; }

        public ImageDto(string Id, string DownloadUri)
        { 
            this.Id = Id;
            this.DownloadUri = DownloadUri;
        }

        public ImageDto(string Id, string DownloadUri, string RealPath)
        {
            this.Id = Id;
            this.DownloadUri = DownloadUri;
            this.RealPath = RealPath;
        }
    }
}
