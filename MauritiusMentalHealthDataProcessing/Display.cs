using System.Xml.Linq;

namespace MauritiusMentalHealthDataProcessing
{
    internal class Display
    {

        public void ShowPrograms(XDocument doc)
        {
            Console.WriteLine("--- Available Mental Health Programs ---");

            var programs = doc.Elements("MentalHealthPrograms")
              .Elements("Programs")
             .Elements("Program")
             .Select(f => new
             {
                 name = f.Element("ProgramName")?.Value ?? "Unknown Name",
                 id = f.Element("ProgramID")?.Value ?? "N/A",
                 year= f.Element("ProgramYear")?.Value ?? "N/A",
                 targetParticipants = (int?)f.Element("TargetParticipants") ?? 0,
                 peopleServed = (int?)f.Element("PeopleServed") ?? 0,
                 allocatedBudget =(int?) f.Element("AllocatedBudget") ?? 0,
                 satisfactionScore = (int?)f.Element("SatisfactionScore") ?? 0,
                 minimumRequiredScore = (int?)f.Element("MinimumRequiredScore") ?? 0,
                 status = f.Element("Status")?.Value ?? "N/A",
                 lastUpdated = f.Element("LastUpdated")?.Value ?? "N/A",
             });

            
            foreach (var p in programs)
            {
                while ((p.peopleServed < p.targetParticipants) && (p.satisfactionScore < p.minimumRequiredScore))
                {
                    Console.WriteLine(new string('=', 50));

                    // Header: [ID] Name
                    Console.WriteLine($"[{p.id}] {p.name}");
                    Console.WriteLine(new string('-', 50));

                    // Logistics
                    Console.WriteLine($"Year:   {p.year}");
                    Console.WriteLine($"Status: {p.status}");

                    // Metrics 
                    Console.WriteLine($"\n--- METRICS ---");
                    Console.WriteLine($"{"Target:",-10} {p.targetParticipants:N0}");
                    Console.WriteLine($"{"Served:",-10} {p.peopleServed:N0}");
                    Console.WriteLine($"{"Budget:",-10} {p.allocatedBudget:C0}");

                    // Performance
                    Console.WriteLine($"\n--- PERFORMANCE ---");
                    Console.WriteLine($"Score: {p.satisfactionScore} / {p.minimumRequiredScore} (Min)");

                    // Footer
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine($"Last Updated: {p.lastUpdated}");
                    Console.WriteLine("\n");
                }
                


            }


            Console.WriteLine("--------------------------------------------------");
        }


    }
}
