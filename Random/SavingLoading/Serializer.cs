using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SavingLoading
{
    public class Serializer<T>
    {
        private static string _path
        {
            get { return $"{Directory.GetCurrentDirectory()}/data.io"; }
        }
        public static void Save(T item)
        {
            FileStream file;
            BinaryFormatter bf = new BinaryFormatter();

            if(File.Exists(_path))
                file = File.Open(_path, FileMode.Open);

            else
                file = File.Create(_path);

            bf.Serialize(file, item);
            file.Close();
        }

        public static T Load()
        {
            if(File.Exists(_path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(_path, FileMode.Open);
                object data = bf.Deserialize(file);
                return (T)data;

            }
            return default(T);
        }
    }
}