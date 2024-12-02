using System.Threading;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 2f;
    [SerializeField] float heightRange = 1f;
    [SerializeField] GameObject _pipe;

    float timer;
    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if(timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }


        timer += Time.deltaTime;
    }

    void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0,Random.Range(-heightRange, heightRange));
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        Destroy(pipe, 8f);
    }
}
