// See https://aka.ms/new-console-template for more information
using SoapClient;
using System.Xml.Serialization;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");

calculator.CalculatorSoapClient client = new calculator.CalculatorSoapClient(calculator.CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);
var c = client.Add(12, 12);
Console.WriteLine(client.Subtract(50, 25));
Console.WriteLine(c);
Console.WriteLine(client.Divide(50, 25));

SerializeObjectToXmlString();
SerializeObjectToXmlFile();
SerializeListToXmlFile();
DeSerializeXmlFileToList();
DeSerializeXmlFileToObject();


static void SerializeObjectToXmlString()
{

    var member = new Member
    {
        Name = "John",
        Email = "abc@gmail.com",
        Age = 12,
        JoiningDate = DateTime.Now,
        IsPlatinumMember = true
    };

    var xmlSerializer = new XmlSerializer(typeof(Member));
    using (var writer = new StringWriter())
    {
        xmlSerializer.Serialize(writer, member);
        var xmlcontent = writer.ToString();
        Console.WriteLine(xmlcontent);
        DeSerializeXmlStringToObject(xmlcontent);
    }
}

static void SerializeObjectToXmlFile()
{

    var member = new Member
    {
        Name = "John",
        Email = "abc@gmail.com",
        Age = 12,
        JoiningDate = DateTime.Now,
        IsPlatinumMember = true
    };

    var xmlSerializer = new XmlSerializer(typeof(Member));
    using (var writer = new StreamWriter(@"D:\Learnings\Sample Applications\SoapClient\SoapClient\sample01.xml"))
    {
        xmlSerializer.Serialize(writer, member);
        
    }
}

static void SerializeListToXmlFile()
{

    var memberList = new List<Member>
    {
       new Member
       {
        Name = "John",
        Email = "abc@gmail.com",
        Age = 12,
        JoiningDate = DateTime.Now,
        IsPlatinumMember = true

       },
       new Member
       {
        Name = "Raju",
        Email = "Raju@gmail.com",
        Age = 14,
        JoiningDate = DateTime.Now,
        IsPlatinumMember = false

       },
       new Member
       {
        Name = "Sanju",
        Email = "Sanju@gmail.com",
        Age = 16,
        JoiningDate = DateTime.Now,
        IsPlatinumMember = false

       }

    };

    var xmlSerializer = new XmlSerializer(typeof(List<Member>));
    using (var writer = new StreamWriter(@"D:\Learnings\Sample Applications\SoapClient\SoapClient\sample02.xml"))
    {
        xmlSerializer.Serialize(writer, memberList);

    }
}

static void DeSerializeXmlFileToList()
{
    var xmlSerializer = new XmlSerializer(typeof(List<Member>));
    using (var reader = new StreamReader(@"D:\Learnings\Sample Applications\SoapClient\SoapClient\sample02.xml"))
    {
        var members= (List<Member>)xmlSerializer.Deserialize(reader);

    }
}

static void DeSerializeXmlFileToObject()
{
    var xmlSerializer = new XmlSerializer(typeof(Member));
    using (var reader = new StreamReader(@"D:\Learnings\Sample Applications\SoapClient\SoapClient\sample01.xml"))
    {
        var members = (Member)xmlSerializer.Deserialize(reader);

    }
}

static void DeSerializeXmlStringToObject(string xmlstring)
{
    var xmlSerializer = new XmlSerializer(typeof(Member));

    using (var reader = new StringReader(xmlstring))
    {
        var members = (Member)xmlSerializer.Deserialize(reader);
    }
    
}