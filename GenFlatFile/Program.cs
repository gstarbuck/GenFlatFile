using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFlatFile
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Get data from Access */
            //var dbConnStr = @"Provier=Microsoft.ACE.OLEDB.15.0;Data Source=C:\Users\Guy Starbuck\Documents\Database1.accdb";
            var dbConnStr = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\Users\Guy Starbuck\Documents\Database1.accdb";
            
            var conn = new OdbcConnection(dbConnStr);

            conn.Open();

            OdbcCommand cmd = new OdbcCommand("SELECT * FROM Scanners INNER JOIN ScansTable ON Scanners.ID = ScansTable.Scanner");

            var reader = cmd.ExecuteReader();

            /* Load into POCO structure */
            var rows = new SortedSet<FileRow>();

            while (reader.Read())
            {
                var barcode = reader.GetString(2) + "-" + reader.GetString(3);
                var scannerName = reader.GetString(1);
                var scanDate = reader.GetString(4);
                var scanId = reader.GetString(2);

                var row = new FileRow()
                {
                    Barcode = barcode,
                    ScannerName = scannerName,
                    ScanDate = scanDate,
                    ScanID = scanId 
                };
                rows.Add(row);
            }

            /* Write out to CSV */
        }
    }
}
