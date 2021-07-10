using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableMush : MonoBehaviour
{
    private  Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody  =  GetComponent<Rigidbody2D>();
        rigidBody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        rigidBody.AddForce(Vector2.right * 3, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        rigidBody.AddForce(Vector2.right, ForceMode2D.Impulse);
    }
}
