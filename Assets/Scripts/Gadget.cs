using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gadget : MonoBehaviour
{
    public Animator anim;
    public Block placedBlock;
    public int id;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
}