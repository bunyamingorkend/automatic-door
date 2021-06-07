using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject baal;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - baal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = distance + baal.transform.position;
    }
}
