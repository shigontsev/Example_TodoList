using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.JsonDAL
{
    internal static class FilePath
    {
        //private static string JsonFilesPath = AppDomain.CurrentDomain.BaseDirectory + @"App_Data\";

        private static string JsonFilesPath = AppDomain.CurrentDomain.BaseDirectory;

        public static string JsonNotesPath = JsonFilesPath + "Notes.json";

        public static string JsonСompletedTasks = JsonFilesPath + "СompletedTasks.json";
    }
}
