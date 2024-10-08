namespace Nsu.Hackathon.Problem.Manager;

using Preferences;
using Worker;
using TeamBuilding;

public class HackathonManager(EmployeeRepository employeeRepository)
{
    public void StartHackathonCertainTimes(int numberOfTimesToStart)
    {
        var statisticsManager = new StatisticsManager();
        var juniors = employeeRepository.Juniors;
        var teamLeads = employeeRepository.TeamLeads;

        for (var i = 0; i < numberOfTimesToStart; i++)
        {
            Console.WriteLine($"Hackathon № {i + 1} started.");
            var juniorsWishlist =
                WishlistsGenerator.GenerateWishlists(juniors, teamLeads);
            var teamLeadsWishlist =
                WishlistsGenerator.GenerateWishlists(teamLeads, juniors);
            var teams =
                TeamBuildingStrategy.BuildTeams(teamLeads, juniors, teamLeadsWishlist, juniorsWishlist);

            statisticsManager.AddStatistics(teams, teamLeadsWishlist, juniorsWishlist);

            statisticsManager.PrintCurrentHarmonicMean();
        }

        statisticsManager.SummarizeResults();
        statisticsManager.PrintResults();
    }
}