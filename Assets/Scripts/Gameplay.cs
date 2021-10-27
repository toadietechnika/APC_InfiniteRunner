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
        StartCoroutine(CreateObstacles());
    }

    //Coroutines
    IEnumerator CreateObstacles()
    {
        float[] _spikeTimes = new float[] 
        { 0.75f, 0.75f, 0.5f, 0.75f, 0.75f, 0.75f, 0.45f, 0.82f };
        int[] _spikeCount = new int[]
        { 1, 2, 1, 1, 1, 3, 1, 2, 1, 2 };

        int _spikePos = Random.Range(0, _spikeTimes.Length);

        yield return new WaitForSeconds(3.5f);

        while (true)
        {
            int _nextSpikeCount = _spikeCount[(int)Mathf.Repeat(_spikePos + 1, _spikeCount.Length)];
            for (int i = 0; i < _nextSpikeCount; i++)
            {
                Instantiate(RefSpike, RefSpike.transform.position, Quaternion.identity).SetActive(true);

                if (i < _nextSpikeCount)
                    yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(_spikeTimes[_spikePos]);
            _spikePos = (int)Mathf.Repeat(_spikePos + 1, _spikeTimes.Length);
        }
    }
}
