using System.Xml.Linq;

namespace MauritiusMentalHealthDataProcessing
{
    public class Reading
    {
        public XDocument ReadXmlFile()
        {
            XDocument doc = XDocument.Load("/xml/acme_mental_health_programs.xml");
            return doc;
        }

        



    }
}
