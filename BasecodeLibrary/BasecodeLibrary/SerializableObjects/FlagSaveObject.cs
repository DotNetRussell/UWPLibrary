using BasecodeLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasecodeLibrary.SerializableObjects
{
    [DataContract]
    public class FlagSaveObject : ISerializeableObject
    {
        [DataMember]
        public string objectName
        {
            get;
            set;
        }

        [DataMember]
        public bool Flag { get; set; }

        public virtual DataContractSerializer GetSerializer()
        {
            return new DataContractSerializer(typeof(FlagSaveObject));
        }
    }
}
