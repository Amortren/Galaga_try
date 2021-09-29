using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int score;
    [SerializeField]
    private int maxHP;
    private int currentHP;
    [SerializeField]
    private float ASUnitUP;
    




    private void Awake()
    {
        currentHP = maxHP;
    }
    
    
    private void Die()
    {
       
        FindObjectOfType<Manager>().plusScore(score);
        FindObjectOfType<Unit>().ASpeedUP(ASUnitUP);
        gameObject.SetActive(false);
        maxHP =currentHP;
    }

    public void GetDamage(int i) 
    {
        
        maxHP -= i;
        if (maxHP<=0)
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
