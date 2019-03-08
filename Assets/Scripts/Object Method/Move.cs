using UnityEngine;

public class Move : MonoBehaviour {

    private Rigidbody2D mRidgidbody2D;
    private float moveSpeed = 3f;


    private void Start()
    {
        mRidgidbody2D = GetComponent<Rigidbody2D>();
        mRidgidbody2D.velocity = new Vector2(-moveSpeed, 0);
    }


}
