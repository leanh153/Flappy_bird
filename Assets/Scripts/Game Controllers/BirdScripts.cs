using UnityEngine;
/// <summary>
/// this class is all bird's behavior
/// </summary>

public class BirdScripts : MonoBehaviour
{
    public static BirdScripts instance;
    private Rigidbody2D myRigidBody;
    // animator to play the animation
    private Animator anim;
    private float bounceSpeed = 200f;
    public bool isAlive;
    public AudioSource audioSource;
    // these are all audio sound clips of the bird
    public AudioClip flapClip, pointClip, deadClip, coinClip, bombExplosion;
    

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        isAlive = true;
      
       
    }

    private void FixedUpdate()
    {
        

        if (isAlive)
        {
            // Handle Bird's fly logic
            if(Input.GetMouseButtonDown(0))
            {
                // set velocity 0 for the bird
                myRigidBody.velocity = Vector2.zero;
                anim.SetTrigger("flap");
                // add for y axis
                myRigidBody.AddForce(new Vector2(0, bounceSpeed));
                // play the flap clip
                audioSource.PlayOneShot(flapClip);
               

            }
           
        }

    }

    // this get the bird's position on the x axis
    public float GetPositionX()
    {
        return transform.position.x;
    }


    private void OnCollisionEnter2D(Collision2D target)
    {
        // Handle OnConllisionEnter2D
        if ( target.gameObject.tag == "Ground" || target.gameObject.tag == "Pipe" 
            || target.gameObject.tag=="Bullet" )
        {
            
            anim.SetTrigger("dead");
            isAlive = false;
            audioSource.PlayOneShot(deadClip);
            GamePlayerController.instance.PlayerDeadShowScore();
        }

        if ( target.gameObject.tag=="Bomb"  )
        {
            
            anim.SetTrigger("dead");
            isAlive = false;
            audioSource.PlayOneShot(bombExplosion);
            GamePlayerController.instance.PlayerDeadShowScore();
        }

        
    }
    
    // add 1 point for trigger PipeHolder and 2 points for triggering coin
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "PipeHolder")
        {
            // Handle OntriggerEnter2D
            GamePlayerController.instance.SetScrore();
            audioSource.PlayOneShot(pointClip);
        }

        if ( target.gameObject.tag == "Coin" )
        {
            GamePlayerController.instance.score++;
            GamePlayerController.instance.SetScrore();
            audioSource.PlayOneShot(coinClip);
            // destroy coin
            Destroy(target.gameObject);
        }
    }

}
