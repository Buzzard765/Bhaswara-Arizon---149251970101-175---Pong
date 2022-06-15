using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadSpeedUp : PowerUp
{
    public float multiplier;
    public string Playerside;
    SpriteRenderer sprdr;
    Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        sprdr = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        StartCoroutine(ReturnAmount2());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name.Contains("Ball")){
            PadMovement Pad = GameObject.Find("Pad " + Playerside).GetComponent<PadMovement>();
            StartCoroutine(increasePadSpeed(Pad));
           
        }
    }

    IEnumerator increasePadSpeed(PadMovement Pad){
        Pad.speed *= multiplier;
        sprdr.enabled = false;
        coll.enabled = false;
        yield return new WaitForSeconds(5f);
        Pad.speed /= multiplier;       
        ReturnAmount(1); 
    }
    IEnumerator ReturnAmount2(){
        yield return new WaitForSeconds(9f);
        FindObjectOfType<ItemSpawner>().spawnAmount++;
        Destroy(gameObject);
    }
}
