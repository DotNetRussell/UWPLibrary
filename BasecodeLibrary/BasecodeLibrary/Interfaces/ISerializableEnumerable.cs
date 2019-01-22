﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasecodeLibrary.Interfaces
{
    public interface ISerializableEnumerable : ISerializeableObject
    {
        IEnumerable<ISerializeableObject> SerializableObjects { get; }
        string objectName { get; }
    }
}
