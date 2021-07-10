using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D marioBody;
    public float maxSpeed = 10;
    private bool onGroundState = true;
    public float upSpeed;
    private float moveHorizontal;
    private SpriteRenderer marioSprite;
    private bool faceRightState = true;
    private  Animator marioAnimator;
    private AudioSource marioAudio;

    void OnCollisionEnter2D(Collision2D col)
    {
      if (col.gameObject.CompareTag("Ground")) onGroundState = true;
      if (col.gameObject.CompareTag("Obstacles")) onGroundState = true;
    }
    void  PlayJumpSound(){
      marioAudio.PlayOneShot(marioAudio.clip);
    }

    void Start()
    { 
        Application.targetFrameRate = 30;
        marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>();
        marioAnimator  =  GetComponent<Animator>();
        marioAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate(){ 
       if (Input.GetKeyDown("space") && onGroundState){
          marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
          onGroundState = false;
      }
      if (Input.GetKeyUp("a") || Input.GetKeyUp("d")){
            // stop
            marioBody.velocity = Vector2.zero;
        }    
      float moveHorizontal = Input.GetAxis("Horizontal");

      if (Mathf.Abs(moveHorizontal) > 0){
          Vector2 movement = new Vector2(moveHorizontal, 0);
          if (marioBody.velocity.magnitude < maxSpeed){
                  marioBody.AddForce(movement * speed);
            } 
          }
    }
    
    void Update(){
      
      marioAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));
      marioAnimator.SetBool("onGround", onGroundState);
      if (Input.GetKeyDown("a") && faceRightState){
        if (Mathf.Abs(marioBody.velocity.x) <  1){ 
	      marioAnimator.SetTrigger("onSkid");
      }
          faceRightState = false;
          marioSprite.flipX = true;
      }

      if (Input.GetKeyDown("d") && !faceRightState){
        if (Mathf.Abs(marioBody.velocity.x) < 1){ 
	      marioAnimator.SetTrigger("onSkid");
      }
          faceRightState = true;
          marioSprite.flipX = false;
      }

    }

}