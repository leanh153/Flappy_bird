using UnityEngine;
/// <summary>
/// this class change the pipeHolder to the new position
/// </summary>
public class PipeReposition : MonoBehaviour
{
    private float birdPosition;

    // Update is called once per frame
    private void Update()
    {

        if ( BirdScripts.instance != null )
        {
            // get the x position of the bird
            birdPosition = BirdScripts.instance.GetPositionX();

        }
        // PipeAllocate.distance == 2.5f by default
        
        if ( birdPosition > transform.position.x + (3 * PipeAllocate.distance) )
        {
            PipeHolderRePosition();
        }
        
    }

    private void PipeHolderRePosition()
    {
        // after change position this pipeHolder also change its y axis value
        float positionY = Random.Range(PipeAllocate.pipeMin, PipeAllocate.pipeMax);
        // move 8 time PipeAllocate.distance because containing 8 pipeHolder in the scenery
        Vector2 move = new Vector2(PipeAllocate.distance * 8f, positionY);
        transform.position = (Vector2)transform.position + move;
    }

}
