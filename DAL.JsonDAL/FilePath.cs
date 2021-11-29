using System;

namespace DAL.JsonDAL
{
    internal static class FilePath
    {
        //private static string JsonFilesPath = AppDomain.CurrentDomain.BaseDirectory + @"App_Data\";

        private static string JsonFilesPath = AppDomain.CurrentDomain.BaseDirectory;

        public static string JsonNotesPath = JsonFilesPath + "Notes.json";

        public static string JsonСompletedTasksPath = JsonFilesPath + "СompletedTasks.json";
    }
}
