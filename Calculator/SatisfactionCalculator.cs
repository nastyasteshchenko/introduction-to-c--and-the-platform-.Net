namespace Nsu.Hackathon.Problem.Calculator;

using Preferences;
using TeamBuilding;

public static class SatisfactionCalculator
{
    public static List<int> CalculateSatisfaction(List<Team> teams,
        List<Wishlist> teamLeadsWishlists, List<Wishlist> juniorsWishlists)
    {
        var juniorsDesiredEmployees =
            juniorsWishlists.ToDictionary(w => w.Employee, w => w.DesiredEmployees);
        var teamLeadsDesiredEmployees =
            teamLeadsWishlists.ToDictionary(w => w.Employee, w => w.DesiredEmployees);

        var satisfaction = new List<int>();
        foreach (var team in teams)
        {
            var teamLeadSatisfactionIndex = juniorsWishlists.Count -
                                            teamLeadsDesiredEmployees[team.TeamLead].IndexOf(team.Junior);
            var juniorSatisfactionIndex = teamLeadsWishlists.Count -
                                          juniorsDesiredEmployees[team.Junior].IndexOf(team.TeamLead);
            satisfaction.Add(teamLeadSatisfactionIndex);
            satisfaction.Add(juniorSatisfactionIndex);
        }

        return satisfaction;
    }
}