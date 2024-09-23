using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class eyeballTracking : MonoBehaviour
{
    GameObject myTarget;
    // Start is called before the first frame update
    void Start()
    {
        myTarget = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = myTarget.transform.position - transform.position;
        Debug.DrawRay(transform.position, delta, Color.yellow);
        Debug.DrawRay(transform.position, Vector3.up, Color.cyan);

        float angleDelta = Vector3.Angle(delta, Vector3.up);
        Debug.Log("current angle: " + angleDelta);

        transform.Rotate(Vector3.forward, angleDelta);
    }

}
