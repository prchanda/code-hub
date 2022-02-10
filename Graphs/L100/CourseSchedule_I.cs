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

*/

    class CourseSchedule_I<T>
    {
        List<AdvancedVertex<T>> courses;
        Dictionary<T, int> indexLookup;
        T[,] courseDependencies;
        
        public CourseSchedule_I(T[,] dependencies)
        {
            courseDependencies = dependencies;
            courses = new List<AdvancedVertex<T>>(dependencies.GetLength(0));
            indexLookup = new Dictionary<T, int>();
            for (int row = 0; row < dependencies.GetLength(0); row++)
            {
                if(!indexLookup.ContainsKey(dependencies[row, 0]))
                {
                    courses.Add(new AdvancedVertex<T>(dependencies[row, 0], dependencies[row,0]));
                    indexLookup.Add(dependencies[row, 0], courses.Count - 1);
                }
                if(!indexLookup.ContainsKey(dependencies[row, 1]))
                {
                    courses.Add(new AdvancedVertex<T>(dependencies[row, 1], dependencies[row,1]));
                    indexLookup.Add(dependencies[row, 1], courses.Count - 1);
                }
            }
        }

        private T GetParent(T child)
        {
            int childIndex = indexLookup[child];
            return courses[childIndex].Parent;
        }

        private T Find(T child)
        {
            T parent = GetParent(child);
            AdvancedVertex<T> childVertex = courses[indexLookup[child]];
            if(!child.Equals(parent))
            {
                childVertex.Parent = Find(parent);
            }
            return parent;
        }

        private void Union(T set1Representative, T set2Representative)
        {
            int set1RepresentativeIndex = indexLookup[set1Representative];
            int set2RepresentativeIndex = indexLookup[set2Representative];
            if(courses[set1RepresentativeIndex].Rank < courses[set2RepresentativeIndex].Rank)
                courses[set1RepresentativeIndex].Parent = set2Representative;
            else if (courses[set2RepresentativeIndex].Rank < courses[set1RepresentativeIndex].Rank)
                courses[set2RepresentativeIndex].Parent = set1Representative;
            else
            {
                courses[set1RepresentativeIndex].Parent = set2Representative;
                courses[set2RepresentativeIndex].Rank++;
            }
        }

        public bool IsPossibleToTakeAllCourses()
        {
            for (int row = 0; row < courseDependencies.GetLength(0); row++)
            {
                if(!Find(courseDependencies[row, 0]).Equals(Find(courseDependencies[row, 1])))
                {
                    Union(courseDependencies[row, 0], courseDependencies[row, 1]);
                }
                else
                    return false;
            }
            return true;
        }
    }
}