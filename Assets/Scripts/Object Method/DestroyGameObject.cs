using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        // this destroy game object after 7 seconds
        Destroy(gameObject, 7f);
    }


}
