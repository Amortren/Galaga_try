using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0.003f, 0, 0);
        if (transform.position.x < -5f || transform.position.x > 5f)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.z < -1.6f || transform.position.z > 1.9f)
        {
            gameObject.SetActive(false);
        }
    }
}
