using UnityEngine;

public class BGReposition : MonoBehaviour
{
    
    // Get background x size based on BoxCollider2D component
    private BoxCollider2D conllider2D; 
    // value of Background size x axis
    private float environmentLength;

    // Use this for initialization
    private void Start()
    {
       
        conllider2D = GetComponent<BoxCollider2D>();
        environmentLength = conllider2D.size.x;
    }

    private void Update()
    {
        // move to the new x position of this object if its x position smaller 
        // than its size. negative value because this object move to the left
        if (transform.position.x < -environmentLength)
        {
            RePositionEnvironment();
        }
    }

    private void RePositionEnvironment()
    {
        // this contain 2 Environment object so need to move to * 2f position and 
        // don't move on the y axis
        Vector2 groundOffSet = new Vector2(environmentLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffSet;
    }


}




