using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBrick : MonoBehaviour
{
    public GameObject debris;
    private bool broken = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per fra  me
    void Update()
    {
        
    }
    void  OnTriggerEnter2D(Collider2D col){
	if (col.gameObject.CompareTag("Player") &&  !broken){
		broken  =  true;
		for (int x =  0; x<5; x++){
			Instantiate(debris, transform.position, Quaternion.identity);
		}
		gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled  =  false;
		gameObject.transform.parent.GetComponent<BoxCollider2D>().enabled  =  false;
		GetComponent<EdgeCollider2D>().enabled  =  false;

		
	}
}
}
