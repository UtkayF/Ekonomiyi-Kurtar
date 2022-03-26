using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Speed : MonoBehaviour
{

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = new Vector3(0,0,-22);
    }


}
