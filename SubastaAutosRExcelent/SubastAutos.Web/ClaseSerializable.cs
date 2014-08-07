using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace SubastAutos.Web
{   
    [DataContract]
    public class ClaseSerializable
    {
        [DataMember]
        public IQueryable lista { set; get; }
        [DataMember]
        public Object objeto { set; get; }
    }
    [DataContract]
    public class PictureFile
    {
        [DataMember]
        public string PictureName { get; set; }

        [DataMember]
        public byte[] PictureStream { get; set; }
    }
}