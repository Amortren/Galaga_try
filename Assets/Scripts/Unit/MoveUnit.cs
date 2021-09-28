using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnit : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        transform.position = new Vector3(0f, 0f, -1.55f);
    }


    void Update()
    {
        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float position))
        {
            Vector3 worldPosition = ray.GetPoint(position);

            float x = worldPosition.x;
            float y = worldPosition.z;
            if (x>=-4f && x<=4f)
            {
                if (y >= -1.55f && y <= 1.6f)
                {
                    this.transform.position = new Vector3(x, 0, y);
                }
            }

            


        }
    }
}
