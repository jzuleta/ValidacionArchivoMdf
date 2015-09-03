using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    public class Utilities
    {
        public static int[] createArrayIndex(CheckedListBox.CheckedIndexCollection collection)
        {
            int[] arr = new int[collection.Count];
            for (var x = 0; x < arr.Length; x++)
                arr[x] = collection[x];
         
            return arr;
        }

        public static bool checkCountDb(string path)
        {
            var dbsPaths = Directory.EnumerateFiles(path, "*.mdf", SearchOption.AllDirectories);
            var dbsDirectories = dbsPaths.Select(x => Path.GetDirectoryName(x));
            var countDbPaths = dbsDirectories.GroupBy(n => n).
                     Select(group => new {
                             dbPath = group.Key,
                             Count = group.Count()
                         });

            return countDbPaths.GroupBy(x => x.Count)
                               .Select(x => x.First())
                               .ToArray().Length == 1;
        }
    }
}
