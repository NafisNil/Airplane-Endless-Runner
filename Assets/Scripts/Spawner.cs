using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject plane;
    [SerializeField] GameObject[] point; 
    [SerializeField] float spawnRate = 1f;
    [SerializeField] float minHeight = -1f;
    [SerializeField] float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        InvokeRepeating(nameof(EnemySpawn), -1.5f, 1.5f);
        InvokeRepeating(nameof(PointSpawner), -2.5f, 2.5f);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
        CancelInvoke(nameof(EnemySpawn));
        CancelInvoke(nameof(PointSpawner));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        GameObject pipes = Instantiate(prefab, this.transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

    void EnemySpawn()
    {
        Vector3 pos = plane.transform.position;
        pos.y = Random.Range(-3f, 3f);
        GameObject enemy = Instantiate(plane, pos, Quaternion.identity);

    }

    void PointSpawner()
    {
        int rand = Random.Range(0, 2);
        Vector3 pos = plane.transform.position;
        pos.y = Random.Range(-3f, 3f);
        GameObject enemy = Instantiate(point[rand], pos, Quaternion.identity);
    }
}
