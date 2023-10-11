using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            {0,1,0,1,0,0},
            {1,0,1,1,0,0 },
            {0,1,0,0,0,0 },
            {1,1,0,1,1,0 },
            {0,0,0,1,0,1 },
            { 0,0,0,0,1,0}
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>(){1,3},
            new List<int>(){0,2,3},
            new List<int>(){1},
            new List<int>(){0,1,4},
            new List<int>(){3,5},
            new List<int>(){4},
        };
        //우선 now부터
        //now와 연결된 정점들을 하나씩 확인해서 아직 미발견 상태라면 방문한다
        bool[] visited = new bool[6];
        

        public void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;
            for(int i = 0; i < adj.GetLength(0); i++)
            {
                if (adj[now,i] == 0)
                    continue;
                if (visited[i])
                    continue;
                DFS(i);
            }
        }
        public void DFS2(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;
            for(int next = 0; next < adj2[now].Count; next++)
            {
                if (visited[adj2[now][next]])
                    continue;
                DFS2(adj2[now][next]);
            }
        }
        
        public void BFS(int start)
        {
            bool[] found = new bool[6];
            int[] parent = new int[6];
            int[] distance = new int[6];
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            found[start] = true;
            parent[start] = start;
            distance[start] = 0; 
            while (q.Count > 0) 
            {
                int now = q.Dequeue();
                Console.WriteLine(now);
                for(int next = 0; next<6; next++)
                {
                    if (adj[now, next] == 0)
                        continue;
                    if (found[next])
                        continue;
                    q.Enqueue(next);
                    found[next] = true;
                    parent[next] = now;
                    distance[next] = distance[now] + 1;
                }
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.BFS(0);
        }
    }
    class PGraph
    {
        

        public void DFS(int next)
        {
            
        }
    }

    class Solution
    {
        public int solution(int[] nums)
        {
            int answer = 0;
            List<int> sumList = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    if (i == j)
                        continue;
                    for (int k = j; k < nums.Length; k++)
                    {
                        if (i == k)
                            continue;
                        if (j == k)
                            continue;
                        sumList.Add(nums[i] + nums[j] + nums[k]);
                    }

                }
            }
            for (int i = 0; i < sumList.Count; i++)
            {
                for (int j = 2; j < sumList.Count; j++)
                {

                    answer++;
                }
            }
            return answer;
        }
    }
    //public class Solution
    //{
    //    public int solution(int n, int[,] computers)
    //    {
    //        bool[] visited = new bool[n];
    //        int answer = 0;
    //        SearchAll(0, visited, computers, n);
    //        return answer;
    //    }
    //    public void DFS(int now, bool[] visited, int[,] computers, int n)
    //    {
    //        Console.WriteLine(now);
    //        visited[now] = true;
    //        for (int next = 0; next < n; next++)
    //        {
    //            if (visited[next])
    //                continue;
    //            if (computers[now, next] == 0 || now == next)
    //                continue;
    //            DFS(next, visited, computers,n);
    //        }
    //    }
    //    public int SearchAll(int now, bool[] visited, int[,] computers, int n)
    //    {
    //        int answer = 0;
    //        for (int i = 0; i < n; i++)
    //        {
    //            if (visited[i] == false)
    //            {
    //                DFS(i, visited, computers,n);
    //                answer++;
    //            }
    //        }

    //        return answer;
    //    }
    //}
}
