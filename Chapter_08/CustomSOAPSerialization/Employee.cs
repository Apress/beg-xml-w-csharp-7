using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace WindowsApplication45
{
    [Serializable]
    public class Employee :ISerializable
    {
        public Employee()
        {

        }

        protected Employee(SerializationInfo info, StreamingContext context)
        {
            EmployeeID = (int)info.GetValue("EmpCode", typeof(int));
            FirstName = (string)info.GetValue("FName", typeof(string));
            LastName = (string)info.GetValue("LName", typeof(string));
            Notes = (string)info.GetValue("Remarks", typeof(string));
            HomePhone = "";
        }

        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HomePhone { get; set; }

        public string Notes { get; set; }


        private string Encode(string str)
        {
            byte[] data = ASCIIEncoding.ASCII.GetBytes(str);
            return Convert.ToBase64String(data);
        }

        private string Decode(string str)
        {
            byte[] data=Convert.FromBase64String(str);
            return ASCIIEncoding.ASCII.GetString(data);
        }

        [OnSerializing]
        public void OnSerializing(StreamingContext context)
        {
            FirstName = Encode(FirstName);
            LastName = Encode(LastName);
            HomePhone = Encode(HomePhone);
            Notes = Encode(Notes);
        }

        [OnSerialized]
        public void OnSerialized(StreamingContext context)
        {
            FirstName = Decode(FirstName);
            LastName = Decode(LastName);
            HomePhone = Decode(HomePhone);
            Notes = Decode(Notes);
        }

        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            //no code here
        }

        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            FirstName = Decode(FirstName);
            LastName = Decode(LastName);
            HomePhone = Decode(HomePhone);
            Notes = Decode(Notes);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EmpCode", EmployeeID, typeof(int));
            info.AddValue("FName", FirstName, typeof(string));
            info.AddValue("LName", LastName, typeof(string));
            info.AddValue("Remarks", Notes, typeof(string));
        }
    }
}
