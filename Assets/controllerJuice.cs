using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerJuice : MonoBehaviour
{
    SpriteRenderer myRender;
    Material myMat;
    AudioSource collisionAudio;
    public AudioClip[] hitSound;
    // Start is called before the first frame update
    void Start()
    {
        //myMat= GetComponent<Material>();
        myRender = GetComponent<SpriteRenderer>();
        collisionAudio = GetComponent<AudioSource>();
        myMat = myRender.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Collectible")
       {
            //code that runs when we hit a collectible in here
            //let's change the color of the player material for about .5f
            StartCoroutine(changeColor(.5f));
            Debug.Log("collided with a collectible, called coroutines");
       }

       collisionAudio.clip = hitSound[Random.Range(0, hitSound.Length)];
       collisionAudio.Play();
    }

    public IEnumerator changeColor(float time)
    {
        //code above the return executed immediately
        myMat.color = Color.red;
        yield return new WaitForSeconds(time);
        //code after executes after TIME seconds have passed
        myMat.color = Color.white;
    }
}
