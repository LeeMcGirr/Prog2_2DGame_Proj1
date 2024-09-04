using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    //public time passed variable
    public float myTimer = 0f;
    //public fixed update time
    public float myFixedTimer = 0f;
    public GameObject myEnemy;
    public float spawnInterval = .5f;
    public float spawnTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
        // Update is called once per frame
    void Update()
    {
        //add time passed between frames
        myTimer += Time.deltaTime;

        //track enemy spawn time here
        spawnTimer += Time.deltaTime;
        //once the interval is hit, trigger an enemy spawn and reset timer
        if(spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Instantiate(myEnemy);
            Debug.Log("enemy spawn");
        }
    }
    void FixedUpdate()
    {
        //add time passed between each physics frame
        myFixedTimer += Time.fixedDeltaTime;
    }
}
