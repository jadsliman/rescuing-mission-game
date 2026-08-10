using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Vector3Int GridPosition;
    public List<Block> Neighbors = new List<Block>();
    public bool isWalkable = true;
    public Animator ab; public int id;

    private void Start()
    {
        ab = GetComponent<Animator>();
    }
}
