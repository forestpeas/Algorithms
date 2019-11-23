using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1125. Smallest Sufficient Team
     * 
     * In a project, you have a list of required skills req_skills, and a list of people.  The i-th
     * person people[i] contains a list of skills that person has.
     * 
     * Consider a sufficient team: a set of people such that for every required skill in req_skills,
     * there is at least one person in the team who has that skill.  We can represent these teams by
     * the index of each person: for example, team = [0, 1, 3] represents the people with skills
     * people[0], people[1], and people[3].
     * 
     * Return any sufficient team of the smallest possible size, represented by the index of each person.
     * 
     * You may return the answer in any order.  It is guaranteed an answer exists. 
     * 
     * Example 1:
     * 
     * Input: req_skills = ["java","nodejs","reactjs"], people = [["java"],["nodejs"],["nodejs","reactjs"]]
     * Output: [0,2]
     * 
     * Example 2:
     * 
     * Input: req_skills = ["algorithms","math","java","reactjs","csharp","aws"], people = [["algorithms","math","java"],["algorithms","math","reactjs"],["java","csharp","aws"],["reactjs","csharp"],["csharp","math"],["aws","java"]]
     * Output: [1,2]
     *  
     * Constraints:
     * 1 <= req_skills.length <= 16
     * 1 <= people.length <= 60
     * 1 <= people[i].length, req_skills[i].length, people[i][j].length <= 16
     * Elements of req_skills and people[i] are (respectively) distinct.
     * req_skills[i][j], people[i][j][k] are lowercase English letters.
     * Every skill in people[i] is a skill in req_skills.
     * It is guaranteed a sufficient team exists.
     */
    public class Smallest_Sufficient_Team
    {
        public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people)
        {
            // This is an NP Complete problem: https://en.wikipedia.org/wiki/Set_cover_problem
            // Every skill can be represented as an integer. Every skill combination can also 
            // be represented as an integer.
            var skills = new Dictionary<string, int>();
            for (int i = 0; i < req_skills.Length; i++) skills.Add(req_skills[i], i);

            // teams[skill] is the minimum sufficient team for this "skill".
            // For each person, we combine this person with all the skill combinations we already
            // had and see if the new combination covers more skills or if it needs less people.
            var teams = new Dictionary<int, List<int>> { [0] = new List<int>() };
            for (int i = 0; i < people.Count; i++)
            {
                int skill = 0;
                foreach (string s in people[i]) skill |= 1 << skills[s];

                var masks = teams.Keys.ToArray();
                foreach (int mask in masks)
                {
                    int comb = skill | mask;
                    if (!teams.ContainsKey(comb) || teams[comb].Count > 1 + teams[mask].Count)
                    {
                        var newTeam = new List<int>(teams[mask]) { i };
                        teams[comb] = newTeam;
                    }
                }
            }

            return teams[(1 << req_skills.Length) - 1].ToArray();
        }
    }
}
