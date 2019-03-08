using UnityEngine;
// this class demonstrate the bomb behavior On collision event
public class BombScript : MonoBehaviour {

    public GameObject explosionPrefab;
    
    private void OnCollisionEnter2D(Collision2D target)
    {
        
        if ( target.gameObject.tag == "Ground" )
        {
            // destroy game object after 1 second 
            Destroy(gameObject, 1f);
        }

        if ( target.gameObject.tag =="Bird" )
        {
            // instantiate explosion gameobject at this gameobject's postition and explosionPrefab's rotation
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        
    }


}
