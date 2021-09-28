using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMonoPool<T> where T : MonoBehaviour 
{
   public T prefab { get; }
   public Transform container { get; }

    private List<T> pool;

    public MyMonoPool(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        this.CreatePool(count);
    }

    private void CreatePool(int count)
    {
        this.pool = new List<T>();
        for (int i = 0; i < count; i++)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = UnityEngine.Object.Instantiate(this.prefab, this.container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var mono in pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }
    public T GetFreeElement()
    {
        if (this.HasFreeElement(out var element))
        {
            return element;
        }
        else
        {
            return this.CreateObject(true);
        }
    }
    public bool HasActiveElement()
    {
        foreach (var mono in pool)
        {
            if (mono.gameObject.activeInHierarchy)
            {
               
                return true;
            }
        }
        
        return false;

    }
}
