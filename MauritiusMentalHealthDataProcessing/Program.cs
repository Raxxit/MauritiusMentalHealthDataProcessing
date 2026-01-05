using System.Xml.Linq;

namespace MauritiusMentalHealthDataProcessing
{
    internal class Program 
    { 

        static void Main(string[] args)
        {
            Reading reading = new Reading();
            XDocument doc = reading.ReadXmlFile();
            bool isValid = reading.ValidateXml(doc);
        }


    }
}