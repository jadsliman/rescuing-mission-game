using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public Animator a;

    private void Start()
    {
        a = GetComponent<Animator>();
    }
}
