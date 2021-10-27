using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public GameObject RefSpike;

    void Start()
    {
        Application.targetFrameRate = 60;
        RefSpike.SetActive(false);
    }

    void Update()
    {
        if (Random.Range(0, 100) > 98)
        {
            Instantiate(RefSpike, RefSpike.transform.position, Quaternion.identity).SetActive(true);
        }
    }
}
