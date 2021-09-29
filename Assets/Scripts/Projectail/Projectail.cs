using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Projectail : MonoBehaviour 
{
    
    [SerializeField]
    private float speed;
    [SerializeField]
    

    public int damage = 1;
    private Vector3 direction;
    private Vector3 Spam;


    private void Awake()
    {
        direction = new Vector3(0, 0, speed);
        
        
    }
    private void Start()
    {
        transform.position = FindObjectOfType<Unit>()._position.position;
    }


    private void Update()
    {
        
        transform.position += direction;
        if (transform.position.z > 1.9f)
        {
            gameObject.SetActive(false);
            
        }

    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            gameObject.SetActive(false);
        }
    }





}
