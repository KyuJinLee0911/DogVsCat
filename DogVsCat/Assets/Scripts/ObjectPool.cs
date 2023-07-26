using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance;
    [SerializeField]
    private GameObject food;

    Queue<Food> poolingObjectQueue = new Queue<Food>();

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);

        Initialize(20);
    }

    public static ObjectPool Instance()
    {
        if (!instance)
        {
            instance = FindObjectOfType(typeof(ObjectPool)) as ObjectPool;
            if (instance == null)
                Debug.Log("no singleton Objs");
        }
        return instance;
    }

    void Initialize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private Food CreateNewObject()
    {
        var obj = Instantiate(food).GetComponent<Food>();
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        return obj;
    }

    public static Food GetObject()
    {
        if(instance.poolingObjectQueue.Count > 0)
        {
            var obj = instance.poolingObjectQueue.Dequeue();
            obj.gameObject.SetActive(true);
            obj.transform.SetParent(null);
            return obj;
        }
        else
        {
            var newObj = instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(Food obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(instance.transform);
        instance.poolingObjectQueue.Enqueue(obj);
    }
}
