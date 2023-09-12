using System.Collections;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] MoneySets;
    [SerializeField] private GameObject[] AsteroidSets;

    private Vector3 spawnPos = new Vector3(0,8,0);

    private float spawnDelay;
    private float envSpeed;
    private float speedScaleMult = 0.05f;

    private void Start()
    {
        StartCoroutine(SpawnEnvironment());
        spawnDelay = 2.5f;
        envSpeed = 2f;
    }
    private void Update()
    {
        EnvSpeedScale();
    }

    private void EnvSpeedScale()
    {
        envSpeed += speedScaleMult * Time.deltaTime;

        if (spawnDelay <= 1f)
        {
            spawnDelay = 1f;
        }
        else
        {
            spawnDelay -= 0.01f * Time.deltaTime;  
        }
    }

    IEnumerator SpawnEnvironment()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            if (Random.Range(0, 1f) <= 0.4f)
            {
                GameObject go = Instantiate(MoneySets[Random.Range(0, MoneySets.Length)]);
                SpawnGO(go);
            }
            else
            {
                GameObject go = Instantiate(AsteroidSets[Random.Range(0, AsteroidSets.Length)]);
                SpawnGO(go);
            }            
        }        
    }

    private void SpawnGO(GameObject go)
    {
        go.transform.position = spawnPos;
        go.GetComponent<Environment>().SetEnvSpeed(envSpeed);
    }
}
