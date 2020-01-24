using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float rotationRadius = 10;

    public float rotationSpeed = 30; //angular speed
    //
    private Vector3 oldPos;
    private Vector3 oldVelocity;
    private Vector3 oldAcceleration;

    //Jan.17th
    public bool started = false;
    public float rotationRadiusX = 10;
    public float rotationRadiusZ = 5;

    //
    public float p = 2;
    public float k = 3;

    //Jan.22nd
    public Vector3 VInit = Vector3.zero; // Initial Velocity
    public Vector3 PInit = Vector3.zero; // Initial Position
    public float TInit = 0;

    public Vector3 PTarget = Vector3.zero; // Target Position


    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
        oldVelocity = VInit;
        oldAcceleration = Physics.gravity;

        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void SimulateCircularMovement()
    {
        float t = Time.fixedTime;
        Vector3 newPos = new Vector3(Mathf.Cos(t), 0f, Mathf.Sin(t));
        newPos = rotationRadius * newPos;
        newPos.y = .5f;
        this.transform.position = newPos;

        Vector3 newVel = (newPos - oldPos) / Time.deltaTime;
        Vector3 newAcceleration = (newVel - oldVelocity) / Time.deltaTime;

        oldPos = newPos;
        oldVelocity = newVel;
        oldAcceleration = newAcceleration;

    }
    void SimulateEllipticMovement()
    {
        float t = Time.fixedTime;
        float Xt = Mathf.Cos(t*p) * rotationRadiusX/2.0f;
        float Zt = Mathf.Sin(t*k) * rotationRadiusZ/2.0f;
        Vector3 newPos = new Vector3(Xt, 0f, Zt);
        newPos.y = .1f;
        this.transform.position = newPos;

        Vector3 newVel = (newPos - oldPos) / Time.deltaTime;
        Vector3 newAcceleration = (newVel - oldVelocity) / Time.deltaTime;

        oldPos = newPos;
        oldVelocity = newVel;
        oldAcceleration = newAcceleration;
    }
    void SimulateProjectileMovement()
    {
        float t = Time.fixedTime;
        Vector3 newPos = new Vector3(0, 0, 0);
        //float ElapsedTime = t - TInit;

        //Vector3 MyGravity = new Vector3(0, -1, 0);
        Vector3 MyGravity = Physics.gravity;

        newPos = PInit + VInit * (t - TInit) +MyGravity * (t-TInit) * (t - TInit)/2f;



        //newPos.y = .1f;
        this.transform.position = newPos;

        Vector3 newVel = (newPos - oldPos) / Time.deltaTime;
        Vector3 newAcceleration = (newVel - oldVelocity) / Time.deltaTime;

        oldPos = newPos;
        oldVelocity = newVel;
        oldAcceleration = newAcceleration;
    }




    private void FixedUpdate()
    {

        if (started)
        {
            //SimulateCircularMovement();
            //SimulateEllipticMovement();
            SimulateProjectileMovement();


        }

    }

    private void OnDrawGizmos()
    {
        //Velocity
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, oldVelocity);
        print(oldVelocity);


        //acceleration
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position,oldAcceleration);
        print(oldAcceleration);


    }

    //UI related
    public void START()
    {
        TInit = Time.fixedTime;
        started = true;
    }
    public void STOP()
    {
        started = false;
    }

}
