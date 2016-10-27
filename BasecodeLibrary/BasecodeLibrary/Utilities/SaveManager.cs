using BasecodeLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BasecodeLibrary.Utilities
{
    public static class SaveManager
    {

        public static void SaveObject(ISerializeableObject value)
        {
            Serialize(value, new FileStream(ApplicationData.Current.RoamingFolder.Path
                + @"\" + value.objectName + ".russ", FileMode.OpenOrCreate));
        }

        public static void OverWriteSaveObject(ISerializeableObject value)
        {
            Serialize(value, new FileStream(ApplicationData.Current.RoamingFolder.Path
              + @"\" + value.objectName + ".russ", FileMode.Truncate));
        }

        public static Object GetObject(string objectName, Type targetType)
        {
            return Deserialize(new FileStream(ApplicationData.Current.RoamingFolder.Path
                 + @"\" + objectName + ".russ", FileMode.OpenOrCreate), targetType);
        }

        public static bool SaveObjectExists(string objectName, Type targetType)
        {
            try
            {
                using (FileStream stream = new FileStream(ApplicationData.Current.RoamingFolder.Path
                   + @"\" + objectName + ".russ", FileMode.Open))
                {
                    return stream.CanRead;
                }
            }
            catch
            {
                return false;
            }
        }

        private static void Serialize(ISerializeableObject objectToSerialize, FileStream stream)
        {
            try
            {
                DataContractSerializer serializer = objectToSerialize.GetSerializer();
                serializer.WriteObject(stream, objectToSerialize);
                stream.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to Serialize");
                Debug.WriteLine(ex.Message);
            }
        }

        private static Object Deserialize(FileStream stream, Type targetType)
        {
            Object returnValue = null;
            try
            {
                DataContractSerializer serializer =
                      new DataContractSerializer(targetType);

                stream.Position = 0;
                returnValue = serializer.ReadObject(stream);
                stream.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to Deserialize");
                Debug.WriteLine(ex.Message);
            }
            return returnValue;
        }
    }

}
