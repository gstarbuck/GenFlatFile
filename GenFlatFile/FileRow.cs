using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFlatFile
{
    public class FileRow
    {
        public string Barcode { get; set; }
        public string ScanID { get; set; }
        public string ScanDate { get; set; }
        public string ScannerName { get; set; }
    }
}
