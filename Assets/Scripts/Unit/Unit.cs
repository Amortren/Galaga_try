using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private Projectail projectail;
    [SerializeField]
    public Transform _position;
    [SerializeField]
    private float aSpeed;
    private int poolCount = 10;
    public Transform _Rposition;



    private MyMonoPool<Projectail> projectailPool;
    private void Awake()
    {
        projectailPool = new MyMonoPool<Projectail>(projectail, poolCount, _Rposition);
    }

    void Start()
    {

        StartCoroutine(Fire());

    }

    IEnumerator Fire()
    {

        while (gameObject.activeInHierarchy)
        {
            ProjectailSpawn();
            yield return new WaitForSeconds(aSpeed);
            
        }

    }


    public void ASpeedUP(float i)
    {
        if (aSpeed >= 0.1)
        {
            aSpeed -= i;

        }

    }
    private void ProjectailSpawn()
    {
        var tail = projectailPool.GetFreeElement();
        tail.transform.position = _position.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            FindObjectOfType<Manager>().minusLives();
            FindObjectOfType<UnitSpawner>().IsAlive();
            Destroy(gameObject);
        }
    }

}
