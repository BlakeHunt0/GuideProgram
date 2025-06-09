using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace GuideProgram
{
    public class Dijkstra
    {
        public class Path
        {
            //gets the ID and distance of each city from the start city
            public Dictionary<int, double> Distances { get; set; }
            //maps the shortest path found thus far but saving the cities ID, then its placement in the path
            public Dictionary<int, int> Previous { get; set; }
        }

        //I don't like the Dictionary<> graph here, it feels messy. "oh yeah just put in the entire area you are querying into the method real quick"
        //TODO: make separate regions to path out with this, then find the best route from there. This could be states since we already have this in the database.
        //TODO: make a method that finds all of the states we will pass through to reduce the amount of data we have to process. Then send that data to the dijkstraResult method. then return that data to a method that can plot the path on the map.
        //TODO: saving interstates as sort of arterial connections between states could help us get directional control beteween states. if I was going to oregon i would head down I5, if i was going to idaho I would head east on I90.

        /// <summary>
        /// Dijkstra's algorithm to find the shortest path from a starting city to all other cities in the graph.
        /// </summary>
        /// <param name="startCityId"></param>
        /// <param name="graph"></param>
        /// <returns></returns>
        public Path dijkstra(int startCityId, Dictionary<int, List<(int neighborId, double distance)>> graph)
        {
            //data to put into the returned path
            var distances = new Dictionary<int, double>();
            var previous = new Dictionary<int, int>();

            //I took this code snippet for the queue from a stack overflow answer. I would've never thought of it myself, and i am contemplating weither i should make a much longer code consisting of many statements, sorting the cities by distance and then processing them. Which is more like the code that I make.
            //I don't feel confident in my understanding of the Comparer class to take credit for it.
            //The current comparer will sort it by distance in a much shorter format.

            //create the basic queue of cities to process, and sort them by distance from the current virt.
            var queue = new SortedSet<(double distance, int cityId)>(Comparer<(double distance, int cityId)>.Create((a, b) =>
            {
                int compare = a.distance.CompareTo(b.distance);
                if (compare == 0)
                {
                    return a.cityId.CompareTo(b.cityId);
                }
                return compare;
            }));

            //set all future virts to infinity, 
            foreach (var cityId in graph.Keys)
            {
                distances[cityId] = double.PositiveInfinity;
            }

            //except the start city.
            distances[startCityId] = 0;

            //we start at the starting city.
            queue.Add((0, startCityId));

            //while there are still cities to process
            while (queue.Count > 0)
            {
                //get the virt with the current shortest distance
                var current = queue.First();

                //get the current city's ID
                int currentCityId = current.cityId;

                //see if the current city is a floater virt with no edges to follow
                if (!graph.ContainsKey(currentCityId))
                {
                    continue;
                }

                //foreach neighbor of the current city
                foreach (var (neighborId, distance) in graph[currentCityId])
                {
                    //calculate a supposed new shortest distance.
                    double newDist = distances[currentCityId] + distance;

                    //if the newDist is shorter than the known shortest distance
                    if (newDist < distances[neighborId])
                    {
                        //get the old distance
                        var oldDist = (distances[neighborId], neighborId);

                        //and remove it if it was the last best distance
                        if (queue.Contains(oldDist))
                        {
                            queue.Remove(oldDist);
                        }

                        //update to the new best distance/path
                        distances[neighborId] = newDist;
                        previous[neighborId] = currentCityId;
                        queue.Add((newDist, neighborId));
                    }
                }

                //remove the current city from the queue since it has been processed
                queue.Remove(current);
            }

            //return the best path found
            return new Path
            {
                Distances = distances,
                Previous = previous
            };
        }

        public List<int> GetPath(int startCityId, int endCityId, Dictionary<int, int> previous)
        {
            var path = new List<int>();
            int current = endCityId;

            while (current != startCityId)
            {
                path.Add(current);

                if (!previous.ContainsKey(current))
                {
                    return null;
                }

                current = previous[current];
            }

            path.Add(startCityId);
            path.Reverse();

            return path;
        }
    }
}
