using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    //public time passed variable
    public float myTimer = 0f;
    //public fixed update time
    public float myFixedTimer = 0f;
    //explicit references to the enemy, player, and score
    public GameObject myCollectible;
    public GameObject myPlayer;
    public TextMeshProUGUI myScore;
    WASD playerScript;
    float playerScore = 0;

    public float spawnInterval = .5f;
    public float spawnTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        playerScript = myPlayer.GetComponent<WASD>();
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
            Instantiate(myCollectible);
            Debug.Log("enemy spawn");
        }
        //because gameManager has an explicit connection to the player, we
        //can reference the player components, including WASD.cs, and find our score
        playerScore = playerScript.collectedScore;
        myScore.text = playerScore.ToString();
    }
    void FixedUpdate()
    {
        //add time passed between each physics frame
        myFixedTimer += Time.fixedDeltaTime;
    }
}
