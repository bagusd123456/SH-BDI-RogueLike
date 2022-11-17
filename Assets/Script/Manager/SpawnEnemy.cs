//#define DEFAULTCODING

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnEnemy : MonoBehaviour
{
    public Vector2 minSpawnPos;
    public Vector2 maxSpawnPos;
    public Vector3 offset;
    public Transform player;

    public float spawnInterval = 1f;
    public int enemyMax;
    public GameObject[] enemyPrefab;
    public List<GameObject> enemyList = new List<GameObject>();

    public Queue<GameObject> enemyQueue = new Queue<GameObject>();

    public int waveIndex;
    public List<int> enemyWaveList;
    public int enemyKilled;

    public static SpawnEnemy Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.Count < enemyMax)
        {
            var GO = GetFromPool();

            enemyList.Add(GO);
        }

        foreach (var item in enemyList)
        {
            if (item.GetComponent<CharacterBase>().isDead)
            {
                enemyList.Remove(item);
                enemyKilled++;
                AddToPool(item);
            }
        }

        for (int i = 0; i < enemyList.Count; i++)
        {
            if (!enemyList[i].activeInHierarchy)
                enemyList.RemoveAt(i);
        }
    }

    public Vector2 TargetSpawn()
    {
        float xPosition = Random.Range(minSpawnPos.x, maxSpawnPos.y);
        float zPosition = Random.Range(maxSpawnPos.x, maxSpawnPos.y);

        Vector2 pos = new Vector2(xPosition, zPosition);
        return pos;
    }

    public IEnumerator Spawn(float interval)
    {
        yield return new WaitForSeconds(interval);
        if (enemyList.Count < enemyMax)
        {
            enemyList.Add(Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length - 1)]));
        }
    }

    public GameObject GetFromPool()
    {
        if (enemyQueue.Count == 0)
            GrowPool();

        var instance = enemyQueue.Dequeue();
        instance.SetActive(true);
        instance.GetComponent<NavMeshAgent>().enabled = false;
        instance.transform.position = gameObject.transform.position;
        
        instance.GetComponent<CharacterBase>().isDead = false;
        instance.GetComponent<CharacterBase>().currentHP = instance.GetComponent<CharacterBase>().baseHP;
        instance.GetComponent<NavMeshAgent>().enabled = true;
        //instance.GetComponent<Animator>().ResetTrigger("isDead");
        return instance;
    }

    private void GrowPool()
    {
        for (int i = 0; i < 10; i++)
        {
            var instanceToAdd = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length - 1)],transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        enemyQueue.Enqueue(instance);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(player.position, new Vector3(minSpawnPos.x, 2, minSpawnPos.y));

        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(player.position, new Vector3(maxSpawnPos.x, 2, maxSpawnPos.y));
    }

#if DEFAULTCODING
    private void Script()
    {
        var player = GameObject.FindObjectOfType<PlayerCharacter>();

        if (!canSpawn)
        {
            currentCooldownTime = cooldownTime;
            return;
        }

        if (currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
        }
        else
        {
            currentCooldownTime -= Time.deltaTime;
            Spawn(enemyCharacters[RandomRange(0, enemyCharacters.Count)]);
        }
    }

    public void SpawnPooling()
    {
        var z = enemyList.Find(x => !x.GetComponent<EnemyCharacter>().isDead && x.activeInHierarchy);
        if (z != null)
        {
            var enemy = z.GetComponent<EnemyCharacter>();
            enemy.enabled = true;
            enemy.isDead = false;
            enemy.transform.position = Vector3.zero;
        }
    }
#endif
}
