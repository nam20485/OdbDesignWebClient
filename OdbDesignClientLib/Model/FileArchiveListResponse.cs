using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odb.Client.Lib.Model
{
   public class FileArchiveListResponse
    {
        public FileLoadedInfo[] FileArchives { get; set; }

        public class FileLoadedInfo
        {
            public string Name { get; set; }
            public bool Loaded { get; set; }
        }
    }
}