using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float xPos;
    public float zPos;

    public float spawnRate;
    public float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 10;
        nextSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckToSpawn();
    }

    void CheckToSpawn()
    {
        if (Time.time > nextSpawn)
        {
            xPos = Random.Range(-100, 100);
            zPos = Random.Range(-100, -200);

            Instantiate(Enemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            Debug.Log("Spawned Enemy");
            nextSpawn = Time.time + spawnRate;
        }
    }
}
