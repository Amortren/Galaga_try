using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
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

}
