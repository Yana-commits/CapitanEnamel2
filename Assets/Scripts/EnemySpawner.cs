using Game.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int poolCount;
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float border;
    [SerializeField]
    private LevelRepository level;
    private int Index=0;
    public static Dictionary<GameObject,Enemy> enemies;
    public Queue<GameObject> currentEnemies;
    void Start()
    {
        enemies = new Dictionary<GameObject, Enemy>();
        currentEnemies = new Queue<GameObject>();

        enemyPrefab = level.LevelList[Index].fallinEnemy.enemy;

        for (int i = 0; i < poolCount; i++)
        {
            var prefab = Instantiate(enemyPrefab);
            var script = prefab.GetComponent<Enemy>();
            prefab.SetActive(false);
            enemies.Add(prefab, script);
            currentEnemies.Enqueue(prefab);
        }

        Enemy.EnemyReturn += ReturnEnemy;

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        if (spawnTime == 0)
        {
            Debug.Log("No spawn time");
            spawnTime = 2;
        }
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if (currentEnemies.Count > 0)
            {
                var enemy = currentEnemies.Dequeue();
                var script = enemies[enemy];
                enemy.SetActive(true);
                
                script.Init(level, Index);

                float xPos = Random.Range(-border, border);
                enemy.transform.position = new Vector2(xPos, transform.position.y);
            }
        }
    }

    private void ReturnEnemy(GameObject enemy)
    {
        enemy.transform.position = transform.position;
        enemy.SetActive(false);
        currentEnemies.Enqueue(enemy);
        //Debug.Log("mmm");
    }
}
