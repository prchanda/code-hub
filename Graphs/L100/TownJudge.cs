using System;
using System.Collections.Generic;

namespace CodeHub.Graphs.L100
{
/*  In a town, there are N people labelled from 1 to N. There is a rumor that one of these people is secretly the town judge.
    If the town judge exists, then:
        1. The town judge trusts nobody.
        2. Everybody (except for the town judge) trusts the town judge.
        3. There is exactly one person that satisfies properties 1 and 2.

    You are given trust, an array of pairs trust[i] = [a, b] representing that the person labelled a trusts the person labelled b.
    If the town judge exists and can be identified, return the label of the town judge. Otherwise, return -1.

    Example 1:
    Input: N = 2, trust = [[1,2]]
    Output: 2

    Example 2:
    Input: N = 3, trust = [[1,3],[2,3]]
    Output: 3

    Example 3:
    Input: N = 3, trust = [[1,3],[2,3],[3,1]]
    Output: -1

    Example 4:
    Input: N = 3, trust = [[1,2],[2,3]]
    Output: -1

    Example 5:
    Input: N = 4, trust = [[1,3],[1,4],[2,3],[2,4],[4,3]]
    Output: 3
    
    Note:
    1. 1 <= N <= 1000
    2. trust.length <= 10000
    3. trust[i] are all different
    4. trust[i][0] != trust[i][1]
    5. 1 <= trust[i][0], trust[i][1] <= N


    Solution Explaination:

    1. Note down the number of trusts each person has on other in terms of number of incoming/outgoing edges, where each edge represent a trust.
    2. If there is an incoming edge to a vertex / person increase the trust level of a person by 1, else if there is an outgoing edge decrease by 1.
    3. At the end check which person has Trust Level = Number of Person - 1, that person is the town judge.

*/

    class TownJudge
    {
        int numberOfPersons;

        public TownJudge(int N)
        {
            numberOfPersons = N;
        }

        public int Find(int[,] trusts)
        {
            Dictionary<int, int> trustLookup = new Dictionary<int, int>();
            int townJudgeLabel = -1;
            for (int row = 0; row < trusts.GetLength(0); row++)
            {
                int trustingPerson = trusts[row, 0];
                int trustedPerson = trusts[row, 1];
                if(trustLookup.ContainsKey(trustingPerson))
                    trustLookup[trustingPerson]--;
                else
                    trustLookup.Add(trustingPerson, -1);
                if(trustLookup.ContainsKey(trustedPerson))
                    trustLookup[trustedPerson]++;
                else
                    trustLookup.Add(trustedPerson, 1);                
            }
            foreach (KeyValuePair<int,int> kvp in trustLookup)
            {
                if(kvp.Value == numberOfPersons-1)
                {
                    townJudgeLabel = kvp.Key;
                    break;
                }
            }
            return townJudgeLabel;
        }
    }
}