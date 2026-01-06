using System;
using System.Collections.Generic;

namespace MauritiusMentalHealthDataProcessing
{
    internal class Sorting
    {
        private List<DriverRisk> _risk;

        public Sorting(List<DriverRisk> risk)
        {
            _risk = risk;
        }

        public void SortRisks()
        {
            Console.WriteLine("\n=== SORTING ===");

            var listToSort = new List<DriverRisk>(_risk);

            Console.WriteLine("\nSort 1: By Risk Level (A-Z):");
            listToSort.Sort((a, b) => a.RiskLevel.CompareTo(b.RiskLevel));

            foreach (var item in listToSort)
            {
                Console.WriteLine($"{item.RiskLevel}: {item.DriverID}");
            }

            Console.WriteLine("\nSort 2: By Number of Incidents (high to low):");
            listToSort.Sort((a, b) => b.NumberOfIncidents.CompareTo(a.NumberOfIncidents));

            foreach (var item in listToSort)
            {
                Console.WriteLine($"{item.NumberOfIncidents}: {item.DriverID}");
            }
        }
    }
}
