using UnityEngine;

public class ObjectInStantiate : MonoBehaviour {
    public GameObject prefab;
    public float minTime;
    public float maxTime;
    public float minYPosition;
    public float maxYPosition;
    public float xPosition;

    private void Start()
    {
        float timeToInvoke = Random.Range(minTime, maxTime);
        InvokeRepeating("Instantiate", 2, timeToInvoke);
    }
   

    void Instantiate()
    {
        float y = Random.Range(minYPosition, maxYPosition);
        Instantiate(prefab, new Vector2(xPosition, y), prefab.transform.rotation);
    }
}
