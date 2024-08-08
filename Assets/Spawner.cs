using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obsticlePrefabs;
    [SerializeField] private Transform obstacleParents;
    public float obsticleSpawnTime = 2f;
    public float obstacleSpeed = 1f;
    private float timeUntilObsticaleSpawn;
    private void Start() {
        GameManager.Instance.onGameOver.AddListener(ClearObsticles);
    }
    private void Update() {
        if(GameManager.Instance.isPlaying){
           SpawnLoop();
        }
    }
    private void SpawnLoop(){
        timeUntilObsticaleSpawn+=Time.deltaTime;
        if(timeUntilObsticaleSpawn>=obsticleSpawnTime){
            Spawn();
            timeUntilObsticaleSpawn = 0f;
        }

    }

    private void ClearObsticles(){
        foreach(Transform child in obstacleParents){
            Destroy(child.gameObject);
        }
    }

    private void Spawn(){
        GameObject obstacleToSpawn=obsticlePrefabs[Random.Range(0,obsticlePrefabs.Length)];
        GameObject spawnedObstacle=Instantiate(obstacleToSpawn,transform.position,Quaternion.identity);
        spawnedObstacle.transform.parent = obstacleParents;
        Rigidbody2D obstacleRB=spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity=Vector2.left*obstacleSpeed;

    }
}
