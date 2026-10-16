using System.Threading;
using Random = UnityEngine.Random;
using UnityEngine;
using System.Collections;

public class Enemy_spawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    protected float spawnRate = 6;
    private float timer = 2;
    private float repeatedRate;
    private Vector2 screenBorder;
    void Start()
    {
        screenBorder = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        repeatedRate = timer * 1.1f;
        InvokeRepeating("Spawn",timer,repeatedRate);
    }
    protected virtual void Spawn()
    {
        float minPoint = -screenBorder.x/2f;
        float maxPoint = screenBorder.x/2f;
        int index = Random.Range(0,enemyPrefabs.Length);
        Instantiate(enemyPrefabs[index], new Vector3(Random.Range(minPoint, maxPoint),transform.position.y,0),Quaternion.identity);
    }
}