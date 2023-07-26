using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    private static CatSpawner instance;
    [SerializeField]
    private GameObject[] cats;

    public Queue<Cat> poolingObjectQueue = new Queue<Cat>();
    public Transform normalCatParent;
    public Transform fatCatParent;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        // Initialize(10, 0);
        // Initialize(10, 1);

    }

    public static CatSpawner Instance()
    {
        if (!instance)
        {
            instance = FindObjectOfType(typeof(CatSpawner)) as CatSpawner;
            if (instance == null)
                Debug.Log("no singleton Objs");
        }
        return instance;
    }

    // void Initialize(int count, int type)
    // {
    //     for (int i = 0; i < count; i++)
    //     {
    //         poolingObjectQueue.Enqueue(CreateNewObject(type));
    //     }
    // }

    // private Cat CreateNewObject(int type)
    // {
    //     var obj = Instantiate(cats[type]).GetComponent<Cat>();
    //     obj.gameObject.SetActive(false);
    //     if (type == 0)
    //         obj.transform.SetParent(normalCatParent);
    //     else if (type == 1)
    //         obj.transform.SetParent(fatCatParent);
    //     return obj;
    // }

    // public static Cat GetObject(int type)
    // {
    //     if (instance.poolingObjectQueue.Count > 0)
    //     {
    //         if (type == 0)
    //         {
    //             var obj = instance.poolingObjectQueue.Dequeue();
    //             obj.gameObject.SetActive(true);
    //             return obj;
    //         }
    //         else
    //         {
    //             var newObj = instance.CreateNewObject(type);
    //             newObj.gameObject.SetActive(true);
    //             return newObj;
    //         }

    //     }
    //     else
    //     {
    //         var newObj = instance.CreateNewObject(type);
    //         newObj.gameObject.SetActive(true);
    //         return newObj;
    //     }
    // }

    // public static IEnumerator ReturnObject(Cat obj, float t)
    // {
    //     yield return new WaitForSeconds(t);
    //     obj.gameObject.SetActive(false);
    //     instance.poolingObjectQueue.Enqueue(obj);
    // }
}



