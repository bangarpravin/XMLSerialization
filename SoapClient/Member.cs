using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapClient
{
    [Serializable]
    [XmlRoot("MemberDetails")]
    public class Member
    {
        [XmlElement("MemberName")]
        public string Name { get; set; }
        
        [XmlElement("MemberEmail")]
        public string Email { get; set; }

        public int Age { get; set; }

        [XmlIgnore]
        public DateTime JoiningDate { get; set; }

        [XmlAttribute("PlatinumMember")]
        public bool IsPlatinumMember { get; set; }


    }
}
