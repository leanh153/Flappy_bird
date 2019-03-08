using UnityEngine;
/// <summary>
/// this class allocate all pipe holder when game start
/// </summary>
public class PipeAllocate : MonoBehaviour
{

    public GameObject[] pipeHolders;
    public static float pipeMin = -1;
    public static float pipeMax = 1;
    public static float distance = 3f;
    
    private float lastPositionX;
    // Use this for initialization
    void Start()
    {
        lastPositionX = 4;
        for ( int i = 0; i < pipeHolders.Length; i++ )
        {

           float positionY = Random.Range(pipeMin, pipeMax);
            pipeHolders[i].transform.position = new Vector2(lastPositionX + distance, positionY);
            lastPositionX = pipeHolders[i].transform.position.x;

        }

    }

}
