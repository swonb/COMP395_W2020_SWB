using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileViaPhysics : MonoBehaviour
{
    //Jan.22nd
    public Vector3 VInit = Vector3.zero; // Initial Velocity
    public Vector3 PInit = Vector3.zero; // Initial Position
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        PInit = transform.position;
        rb=GetComponent<Rigidbody>();
        rb.velocity = VInit;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
