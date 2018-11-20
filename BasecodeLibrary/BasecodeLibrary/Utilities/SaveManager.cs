using BasecodeLibrary.Interfaces;
using Newtonsoft.Json;
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

        /// <summary>
        /// Checks to see if a file exists in the local application working directory 
        /// </summary>
        /// <param name="filename">The file name (and extension if it has one) of the file you wish to check if exists.</param>
        /// <returns>Returns true if the file exists</returns>
        public static async Task<bool> FileExists(string filename)
        {
            return await ApplicationData.Current.LocalFolder.TryGetItemAsync(filename) != null;
        }

        /// <summary>
        /// Serializes an object to json and saves it to disk with the filename passed in. 
        /// </summary>
        /// <param name="fileName">The file name (and extension if you want) of the file you wish to save</param>
        /// <param name="serializeableObject">The object you wish to serialze and save to disk</param>
        public static async void SaveJsonFile(string fileName, object serializeableObject)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string settingsJson = JsonConvert.SerializeObject(serializeableObject);
            await FileIO.WriteTextAsync(sampleFile, settingsJson);
        }

        /// <summary>
        /// Gets a file from disk with the filename passed in of type T.
        /// </summary>
        /// <typeparam name="T">The type of the file you wish returned</typeparam>
        /// <param name="filename">The name of the file saved to disk</param>
        /// <returns>Returns an instance of type T</returns>
        public static async Task<T> GetJsonFile<T>(string filename)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync(filename);
            string file = await FileIO.ReadTextAsync(sampleFile);
            return JsonConvert.DeserializeObject<T>(file);
        }
    }

}
