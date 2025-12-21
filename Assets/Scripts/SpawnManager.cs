using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] groundObstaclePrefab, flyObstaclePrefab;

    private Vector3 spawnPos;

    public float[] flyHeights = { 0, 2, 6 };

    public float minSpawnTime = 3f;
    public float maxSpawnTime = 6f;

    public bool isGameOver = false;

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(minSpawnTime);

        while (isGameOver == false)
        {
            int obstacleType = Random.Range(0, 2);

            if (obstacleType == 0)
            {
                SpawnGround();
            }
            else
            {
                SpawnAir();
            }


            float randomDelay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomDelay);
        }
    }

    private void SpawnAir()
    {
        int index = Random.Range(0, flyObstaclePrefab.Length);
        int heightIndex = Random.Range(0, flyHeights.Length);

        Vector3 pos = new Vector3(transform.position.x, transform.position.y + flyHeights[heightIndex],transform.position.z);

        GameObject flyOb = Instantiate(flyObstaclePrefab[index], pos, Quaternion.identity);
        flyOb.transform.Rotate(0, 180f, 0);
    }

    private void SpawnGround()
    {
        int index = Random.Range(0, groundObstaclePrefab.Length);
        Vector3 pos = transform.position;
        Instantiate(groundObstaclePrefab[index],pos, Quaternion.identity);
    }
}
