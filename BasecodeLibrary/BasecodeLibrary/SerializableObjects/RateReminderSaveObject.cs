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
    public class RateReminderSaveObject : FlagSaveObject, ISerializeableObject
    {
        public static string ObjectName = "RateReminderSaveObject";

        [DataMember]
        public int RunTimes { get; set; }

        public RateReminderSaveObject()
        {
            objectName = ObjectName;
        }
        public override DataContractSerializer GetSerializer()
        {
            return new DataContractSerializer(typeof(RateReminderSaveObject));
        }
    }
}
