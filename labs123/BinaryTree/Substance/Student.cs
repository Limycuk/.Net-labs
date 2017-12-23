using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Substance
{
    [Serializable()]
    public class Student : ISerializable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TestName { get; set; }
        public int Mark { get; set; }
        public DateTime TestDay { get; set; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", FirstName);
            info.AddValue("LastName", LastName);
            info.AddValue("TestName", TestName);
            info.AddValue("Mark", Mark);
            info.AddValue("TestDay", TestDay);
        }
    }
}
