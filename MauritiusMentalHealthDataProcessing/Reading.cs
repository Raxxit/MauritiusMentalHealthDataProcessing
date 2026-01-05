using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace MauritiusMentalHealthDataProcessing
{
    public class Reading
    {
        public XDocument ReadXmlFile()
        {
            XDocument doc = XDocument.Load("xml/acme_mental_health_programs.xml");
            return doc;
        }

        //Validation logic

        public bool ValidateXml(XDocument doc)
        {

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "xml/acmeSchema.xsd");

            bool isValid = true;
            string errorMessage = "";

            doc.Validate(schemas, (o, e) =>
            {
                isValid = false;
                errorMessage += e.Message + "\n";
            });


            //debugging

            //if (!isValid)
            //{
            //    Console.WriteLine("XML Validation Errors:\n" + errorMessage);
            //}
            //else
            //{
            //    Console.WriteLine("XML is valid against the schema.");

            //}
            
            return isValid;

        }




    }
}
