using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Finding : MonoBehaviour
{
    private static float Heuristic(Block a, Block b)
    {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }

    static List<Block> ReconstructPath(Dictionary<Block, Block> CameFrom, Block current)
    {
        var TotalPath = new List<Block> { current };
        while(CameFrom.ContainsKey(current))
        {
            current = CameFrom[current];
            TotalPath.Insert(0, current);
        }
        return TotalPath;
    }
    public static List<Block> FindPath(Block start, Block target)
    {
        var OpenSet = new List<Block> { start };
        var CameFrom = new Dictionary<Block, Block>();
        var GScore = new Dictionary<Block, float> { [start] = 0 };
        var FScore = new Dictionary<Block, float> { [start] = Heuristic(start, target) };

        while(OpenSet.Count > 0)
        {
            Block current = OpenSet[0];
            foreach(var node in OpenSet)
            {
                if (FScore.ContainsKey(node) && FScore[node] < FScore[current]) current = node;
            }
            if (current == target) return ReconstructPath(CameFrom, current);

            OpenSet.Remove(current);
            foreach(var neighbor in current.Neighbors)
            {
                if (!neighbor.isWalkable) continue;
                float TentativeGScore = GScore[current] + 1;
                if(!GScore.ContainsKey(neighbor) || TentativeGScore < GScore[neighbor])
                {
                    CameFrom[neighbor] = current;
                    GScore[neighbor] = TentativeGScore;
                    FScore[neighbor] = TentativeGScore + Heuristic(neighbor, target);
                    if (!OpenSet.Contains(neighbor)) OpenSet.Add(neighbor);
                }
            }
        }
        return null;
    }
}
