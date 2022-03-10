using System.Collections.Generic;

namespace CodeHub.Graphs.L100
{
/*  There are a total of n courses you have to take, labeled from 0 to n - 1. Some courses may have prerequisites, for example to take course 0
    you have to first take course 1, which is expressed as a pair: [0,1].

    Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?

    Example 1:
    
    2, [[1,0]]
    There are a total of 2 courses to take. To take course 1 you should have finished course 0. So it is possible.

    Example 2:
    2, [[1,0],[0,1]]
    There are a total of 2 courses to take. To take course 1 you should have finished course 0, and to take course 0 you should also have finished 
    course 1. So it is impossible.


    Solution Explaination:

    1. The main idea is to detect if there is a circular dependency bewteen the courses, if thats true then it's not possible to take
       all the courses.

    2. To detect a cycle in a directed graph using DFS.
*/

    class CourseSchedule_I<T>
    {
        AdjacencyList<T> courses;
        Dictionary<T, int> indexLookup;
        T[,] courseDependencies;
        
        public CourseSchedule_I(T[,] dependencies)
        {
            courseDependencies = dependencies;
            courses = new AdjacencyList<T>(true);
            indexLookup = new Dictionary<T, int>();
            for (int row = 0; row < dependencies.GetLength(0); row++)
            {
                if(!indexLookup.ContainsKey(dependencies[row, 0]))
                {
                    courses.AddVertex(dependencies[row, 0]);                    
                    indexLookup.Add(dependencies[row, 0], courses.Vertices.Count - 1);
                }
                if(!indexLookup.ContainsKey(dependencies[row, 1]))
                {
                    courses.AddVertex(dependencies[row, 1]);                    
                    indexLookup.Add(dependencies[row, 1], courses.Vertices.Count - 1);
                }
                courses.AddEdge(dependencies[row, 1], dependencies[row, 0]);
            }
        }

        public bool IsPossibleToTakeAllCourses()
        {            
            T sourceVertex = courses.Vertices[0].Data;
            HashSet<T> visited = new HashSet<T>();
            HashSet<T> recursionStack = new HashSet<T>();
            bool isCyclic = IsCyclic(sourceVertex, visited, recursionStack);
            if(!isCyclic)
            {
                for (int index = 0; index < courses.Vertices.Count; index++)
                {
                    if(!visited.Contains(courses.Vertices[index].Data))
                    {
                        if(IsCyclic(courses.Vertices[index].Data, visited, recursionStack))
                        {
                            isCyclic = true;
                            break;
                        }
                    }
                }
            }

            return !isCyclic;
        }        

        public bool IsCyclic(T vertex, HashSet<T> visited, HashSet<T> recursionStack)
        {
            if(recursionStack.Contains(vertex))
                return true;
            
            if(visited.Contains(vertex))
                return false;

            visited.Add(vertex);
            recursionStack.Add(vertex);
            var neighbours = courses.GetNeighbours(vertex);         

            foreach (var neighbour in neighbours)
            {
                if(IsCyclic(neighbour, visited, recursionStack))
                    return true;
            }

            recursionStack.Remove(vertex);
            return false;
        }
    }
}