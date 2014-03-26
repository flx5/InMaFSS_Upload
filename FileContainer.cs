using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InMaFSS
{
    public class FileContainer
    {
        public String file;
        public String mimeType;

        public FileContainer(String file, String mimeType)
        {
            this.file = file;
            this.mimeType = mimeType;
        }
    }
}
