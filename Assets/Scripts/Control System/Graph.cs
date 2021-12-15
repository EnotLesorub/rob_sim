using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    private List<List<float[]>> Vertex = new List<List<float[]>>(); // [0] - vertex num, [1] - coordinates, [2..n] - connected points
    private List<int[]> Task = new List<int[]>(); // [0] - point where task was detected, [1-3] - direction vector
    private float[] vertex_num = new float[] {0};


    void Start()
    {
        Vertex = null;
        Task = null;
    }

    void Update()
    {
        
    }

    public void add_vertex(float[] coord, float[] dir_vec) // dir_vec = [prev_point_num, i, j, k, distance]
    {
        List<float[]> temp = new List<float[]>();
        temp.Add(vertex_num);
        temp.Add(coord);
        temp.Add(dir_vec);

        for(int i = 0; i < Vertex.Count; i++)
        {
            if(Vertex.Count != 0)
            {
                if (coord == Vertex[i][1])
                {
                    Vertex[i].Add(dir_vec);
                    return;
                }
            }             
        }

        Vertex.Add(temp);
        vertex_num[0] += 1;
    }

    public void add_task(int point_num, int[] dir_vec)
    {
        int[] temp = new int[] { point_num, dir_vec[0], dir_vec[1], dir_vec[2] };
        Task.Add(temp);
    }

    public int[] take_task()
    {
        int[] ans = Task[Task.Count - 1];
        Task.RemoveAt(Task.Count - 1);
        return ans;
    }
}
