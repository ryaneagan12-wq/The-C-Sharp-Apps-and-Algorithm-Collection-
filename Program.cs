using System;
using System.IO;
using System.Collections.Generic;

class Graph
{
    bool[] visited;
    List<List<int>> graph = new List<List<int>>();

    public static void Main(string[] args)
    {
        Graph g = new Graph();

        g.graph.Add(new List<int> { 1, 2 });
        g.graph.Add(new List<int> { 3 });
        g.graph.Add(new List<int>());
        g.graph.Add(new List<int>());

        g.visited = new bool[4]; 

        g.Visit(0);

    }
    public void Visit(int room)
    {
        visited[room] = true;

        foreach(int next in graph[room])
        {
            if (!visited[next])
            {
                Visit(next);
            }
        }
        Console.WriteLine(room);
    }
}