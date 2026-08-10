using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Animator anim;
    public Block placedBlock;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
}
