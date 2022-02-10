using System.Collections.Generic;

namespace CodeHub.Graphs.L200
{
/*  There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where 
    prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

    For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
    Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. 
    If it is impossible to finish all courses, return an empty array.

    Example 1:

    Input: numCourses = 2, prerequisites = [[1,0]]
    Output: [0,1]
    Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].
    
    Example 2:

    Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
    Output: [0,2,1,3]
    Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
    So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].
    
    Example 3:

    Input: numCourses = 1, prerequisites = []
    Output: [0]


    Solution Explaination:

    1. The main idea is to detect if there is a circular dependency bewteen the courses, if thats true then it's not possible to take
       all the courses.

    2. In order to return the ordering of courses we are going to implement topological sort using DFS.
    
    3. We keep a recursion stack consisting of vertices visited on a graph walk. If at point of time we hit a vertex which is present in
       recursion stack, then we have a cycle.
*/

    class CourseSchedule_II
    {
        List<Vertex<int>> vertices;
        Dictionary<int, int> indexLookup;
        
        public CourseSchedule_II(int vertexCount, int[][] prerequisites)
        {
            vertices = new List<Vertex<int>>();
            indexLookup = new Dictionary<int, int>();
            for(int vertexIndex = 0; vertexIndex < vertexCount; vertexIndex++)
            {
                AddVertex(vertexIndex);
            }
            for(int row=0; row<prerequisites.Length; row++)
            {
                AddEdge(prerequisites[row][1], prerequisites[row][0]);
            }
        }
        
        private void AddVertex(int dataLabel)
        {
            vertices.Add(new Vertex<int>(dataLabel));
            indexLookup.Add(dataLabel, vertices.Count-1);
        }
        
        private void AddEdge(int sourceLabel, int destinationLabel)
        {
            int sourceIndex = indexLookup[sourceLabel];
            int destinationIndex = indexLookup[destinationLabel];
            vertices[sourceIndex].Edges.Add(new Edge<int>(vertices[destinationIndex], 1));
        }
        
        private bool IsCyclic(int sourceVertex, HashSet<int> visitedVertices, HashSet<int> recursionStack, Stack<int> topSortOutput)
        {
            visitedVertices.Add(sourceVertex);
            recursionStack.Add(sourceVertex);
            
            var edges = vertices[sourceVertex].Edges;
            foreach(var edge in edges)
            {            
                if(recursionStack.Contains(edge.Neighbour.Data))
                    return true;
                else if(!visitedVertices.Contains(edge.Neighbour.Data))
                {
                    if(IsCyclic(indexLookup[edge.Neighbour.Data], visitedVertices, recursionStack, topSortOutput))
                        return true;
                }
            }
            topSortOutput.Push(sourceVertex);
            recursionStack.Remove(sourceVertex);
            return false;
        }
        
        public int[] TopSort()
        {
            HashSet<int> visitedVertices = new HashSet<int>();
            HashSet<int> recursionStack = new HashSet<int>();
            Stack<int> output = new Stack<int>();
            bool result = IsCyclic(0, visitedVertices, recursionStack, output);
            if(!result)
            {
                for(int index=0; index<vertices.Count; index++)
                {
                    if(!visitedVertices.Contains(vertices[index].Data))
                    {
                        result = IsCyclic(index, visitedVertices, recursionStack, output);
                        if(result)
                            break;
                    }
                }    
            }
            int[] topSortOutput = new int[0];
            if(!result)
            {
                topSortOutput = new int[output.Count];
                int index=0;
                while(output.Count>0)
                {
                    topSortOutput[index++]=output.Pop();
                }    
            }              
            return topSortOutput;
        }
    }
}