using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string Color;
    public Block PlacedBlock, UnlockBlock;
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
}
