using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private Unit unit;
   
    private Vector3 e;


    private void Start()
    {
        e = new Vector3(0f, 0f, -1.55f);
       
    }

   
    public void IsAlive() 
    {
        StartCoroutine(Alive());
        Debug.Log("Alive");
    }
   public IEnumerator Alive()
   {
        Debug.Log("IsAlive");
        yield return new WaitForSeconds(2f);
        Instantiate(unit, e, Quaternion.identity);





    }

}
