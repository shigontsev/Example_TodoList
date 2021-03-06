using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DAL.JsonDAL
{
    internal static class JsonDAO<T>
    {

        /// <summary>
        /// Получения коллекции из файла
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        internal static List<T> Deserialize(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<T>();

            List<T> users;
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    users = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return users == null? new List<T>(): users;
        }

        /// <summary>
        /// Запись коллекции в файл
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="list"></param>
        internal static void Serialize(string filePath, List<T> list)
        {
            if (!File.Exists(filePath))
            {
                using(FileStream f = new FileStream(filePath, FileMode.CreateNew))
                { }
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(list));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
