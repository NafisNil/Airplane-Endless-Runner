using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    float leftEdge;
    // Start is called before the first frame update
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float rand = Random.Range(7f, 9f);
        transform.position += Vector3.left * rand * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        };
    }
}
