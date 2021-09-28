using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerWithPool : MonoBehaviour
{
    private Enemy[] enemies;
    [SerializeField]
    private int minValue;
    [SerializeField]
    private int maxValue;
    private int _value;
    private bool IsSpawn = true;
    [SerializeField]
    private Transform _Eposition;

    [SerializeField]
    private int poolCount;
    [SerializeField]
    private Enemy smallEnemy;
    [SerializeField]
    private Enemy largeEnemy;
    [SerializeField]
    private Enemy Boss;

    private MyMonoPool<Enemy> SmallPool;
    private MyMonoPool<Enemy> LargePool;
    private MyMonoPool<Enemy> BossPool;

    private void Awake()
    {
        SmallPool = new MyMonoPool<Enemy>(smallEnemy, poolCount, transform);
        LargePool = new MyMonoPool<Enemy>(largeEnemy, poolCount, transform);
        BossPool = new MyMonoPool<Enemy>(Boss, poolCount, transform);
    }

    private void Start()
    {
        InvokeRepeating("SpawnActive", 1f, 2f);
    }
    private void Update ()
    {

        if (IsSpawn == true)
        {
            IsSpawn = false;
            Debug.Log(IsSpawn);
            StartCoroutine(SpawnEnemies());
            
        }

    }
    private void SpawnActive ()
    {
        if (SmallPool.HasActiveElement() == false)
        {
            if (LargePool.HasActiveElement() == false)
            {
                if (BossPool.HasActiveElement() == false)
                {
                    IsSpawn = true;

                }
            }
        }
    }

    private IEnumerator SpawnEnemies()
    {
        IsSpawn = false;
        _value = Random.Range(minValue, maxValue);


        for (int i = 1; i <= _value + 1; i++)
        {

            if (i % 5 == 0)
            {
                EnemySpawn(LargePool);            
                yield return new WaitForSeconds(1f);
                

            }
            if (i % 10 == 0)
            {
                EnemySpawn(BossPool);
                yield return new WaitForSeconds(1f);
                
            }
            if (i % 5 != 0 && i % 10 != 0)
            {
                EnemySpawn(SmallPool);
                yield return new WaitForSeconds(1f);
                
            }

            if (minValue >= 101)
            {
                SceneManager.LoadScene(3);
            }



        }


        minValue += 5;
        maxValue += 5;
        
    }
    private void EnemySpawn(MyMonoPool<Enemy> Type)
    {
        var tail = Type.GetFreeElement();
        tail.transform.position = _Eposition.position;
    }

    

}
