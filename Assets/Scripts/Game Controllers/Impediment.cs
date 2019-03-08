using UnityEngine;
/// <summary>
/// this instantiate impediment for the game
/// these gameobjet are disable by default
/// </summary>
public class Impediment : MonoBehaviour {
    // bullet prefab to create if the score great than 20
    public GameObject bulletPrefab;
    // bomb prefab to create if the score great than 40
    public GameObject bombPrefab;

    private void Update()
    {
        if ( GamePlayerController.instance.score > 20   )
        {
            bulletPrefab.SetActive(true);
        }
        


        if ( GamePlayerController.instance.score > 40 )
        {
            bombPrefab.SetActive(true);
        }
        
    }
}
