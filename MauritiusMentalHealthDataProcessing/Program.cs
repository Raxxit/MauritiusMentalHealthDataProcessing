using System.Xml.Linq;

namespace MauritiusMentalHealthDataProcessing
{
    internal class Program 
    { 

        static void Main(string[] args)
        {

            Reading reader = new Reading();
            XDocument doc = reader.ReadXmlFile();
            bool isValid = reader.ValidateXml(doc);
            if (isValid)
            {
                Display display = new Display();
                display.ShowPrograms(doc);
            }
            else
            {
                Console.WriteLine("Exiting due to XML validation errors.");
            }

        }


    }
}