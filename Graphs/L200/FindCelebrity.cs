using System.Collections.Generic;

namespace CodeHub.Graphs.L200
{
/*  Suppose you are at a party with n people (labeled from 0 to n — 1) and among them, there may exist one celebrity. The definition of a celebrity
    is that all the other n — 1 people know him/her but he/she does not know any of them. Now you want to find out who the celebrity is or verify 
    that there is not one. The only thing you are allowed to do is to ask questions like: "Hi, A. Do you know B?" to get information of whether 
    A knows B. You need to find out the celebrity (or verify there is not one) by asking as few questions as possible (in the asymptotic sense).
    You are given a helper function bool knows(a, b) which tells you whether A knows B. Implement a function int findCelebrity(n). There will be 
    exactly one celebrity if he/she is in the party. Return the celebrity’s label if there is a celebrity in the party. 
    If there is no celebrity, return -1.

    Solution Explaination:

    https://medium.com/@joylovemercy/277-find-the-celebrity-linear-comparison-o-n-step-by-step-explanation-w-graph-8928230c6e
*/

    class Party
    {
        List<Vertex<int>> people;
        int numberOfPeople;

        public Party(int n)
        {
            numberOfPeople = n;
            people = new List<Vertex<int>>();
            for(int index=0; index<numberOfPeople; index++)
            {
                AddPeople(index);
            }
        }

        public void AddPeople(int label)
        {
            people.Add(new Vertex<int>(label));
        }

        public void AddRelation(int source, int destination)
        {
            Vertex<int> sourceVertex = people[source];
            Vertex<int> destinationVertex = people[destination];
            sourceVertex.Edges.Add(new Edge<int>(destinationVertex, 1));
        }

        private bool Knows(int person1, int person2)
        {
            return people[person1].Edges.Exists(edge => edge.Neighbour.Data == person2);
        }

        public int FindCelebrity()
        {
            int potentialCelebrity = 0;
            for(int people=1; people < numberOfPeople; people++)
            {
                if(Knows(potentialCelebrity, people))
                    potentialCelebrity = people;
            }
            
            for(int people=0; people < numberOfPeople; people++)
            {
                if(potentialCelebrity == people)
                    continue;
                if(Knows(potentialCelebrity, people) || !Knows(people, potentialCelebrity))
                    return -1;
            }

            return potentialCelebrity;
        }
    }
}