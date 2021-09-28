using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int score;
    [SerializeField]
    private int HP;
    private int _HP;
    [SerializeField]
    private float ASUnitUP;
    




    private void Awake()
    {
        _HP = HP;
    }
    
    
    private void Die()
    {
       
        FindObjectOfType<Manager>().plusScore(score);
        FindObjectOfType<Unit>().ASpeedUP(ASUnitUP);
        gameObject.SetActive(false);
        HP =_HP;
    }

    public void GetDamage(int i) 
    {
        
        HP -= i;
        if (HP<=0)
        {
            Die();
        }
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Projectail>() != null)
        {
            GetDamage(1);
        }
    }

    
}
