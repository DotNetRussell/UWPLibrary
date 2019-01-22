using BasecodeLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasecodeLibrary.Utilities
{
    public class SerializableEnumerable : ISerializableEnumerable
    {
        public IEnumerable<ISerializeableObject> SerializableObjects { get; set; }

        public string objectName { get; set; }
        
        public DataContractSerializer GetSerializer()
        {
            return new DataContractSerializer(typeof(SerializableEnumerable));
        }
    }
}
