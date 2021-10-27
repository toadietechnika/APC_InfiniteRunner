using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * 6.5f);

        //Research on Object Pooling for better object management
        if (transform.position.x < -12f)
            Destroy(gameObject);
    }
}
