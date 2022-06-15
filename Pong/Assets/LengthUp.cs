using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthUp : PowerUp
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
            Collider2D Pad = GameObject.Find("Pad " + Playerside).GetComponent<Collider2D>();
            StartCoroutine(lengthenPowerUp(Pad));
           
        }
    }

    IEnumerator lengthenPowerUp(Collider2D Pad){      
       Growth(Pad);
       sprdr.enabled = false;
       coll.enabled = false;
       yield return new WaitForSeconds(5f);
       Shrink(Pad);
       ReturnAmount(1);       
    }

    void Growth(Collider2D Pad){
         Pad.transform.localScale = new Vector2(
            Pad.transform.localScale.x,
            Pad.transform.localScale.y * multiplier
        );
    }
    void Shrink(Collider2D Pad){
         Pad.transform.localScale = new Vector2(
            Pad.transform.localScale.x,
            Pad.transform.localScale.y / multiplier
        );
    }

    IEnumerator ReturnAmount2(){
        yield return new WaitForSeconds(9f);
        FindObjectOfType<ItemSpawner>().spawnAmount++;
        Destroy(gameObject);
    }
}
