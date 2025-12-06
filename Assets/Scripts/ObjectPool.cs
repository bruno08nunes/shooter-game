using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] float amount;
    [SerializeField] bool allowCreation;

    List<GameObject> objects = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0;i < objects.Count;i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                return objects[i];
            }
        }

        if (allowCreation)
        {
            GameObject item = Instantiate(prefab);
            objects.Add(item);
            return item;
        }

         return null;
    }
}
