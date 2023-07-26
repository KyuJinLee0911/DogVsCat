using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CatType
{
    CT_NORMAL = 0,
    CT_FAT = 1,
    CT_PIRATE = 2
}

public class Cat : MonoBehaviour
{
    bool isFull = false;
    public CatType catType;
    float energy = 0;
    float full = 5.0f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            if (energy < full)
            {
                energy += 1.0f;
                ObjectPool.ReturnObject(other.gameObject.GetComponent<Food>());
                gameObject.transform.Find("Hungry/Canvas/Front").transform.localScale = new Vector3(energy / full, 1, 1);
            }
            else
            {
                if (!isFull)
                {
                    GameManager.Instance().AddCat();
                    gameObject.transform.Find("Hungry").gameObject.SetActive(false);
                    gameObject.transform.Find("Full").gameObject.SetActive(true);

                    isFull = true;
                }
            }
        }
    }

    private void Start()
    {
        if(catType == CatType.CT_FAT)
            full = 10.0f;
    }

    private void OnEnable()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30.0f;

        transform.position = new Vector3(x, y, 0);
    }



    void FixedUpdate()
    {
        transform.position += new Vector3(0.0f, -0.05f, 0.0f);

        if (transform.position.y < -16.0f)
            GameManager.Instance().GameOver();

        if (energy < full)
        {
            if (catType == CatType.CT_NORMAL)
                transform.position += new Vector3(0.0f, -0.05f, 0.0f);
            else if (catType == CatType.CT_FAT)
                transform.position += new Vector3(0, -0.03f, 0);
        }
        else
        {
            if (transform.position.x > 0)
                transform.position += new Vector3(0.05f, 0.0f, 0.0f);
            else
                transform.position -= new Vector3(0.05f, 0.0f, 0.0f);
            // StartCoroutine(CatSpawner.ReturnObject(this, 3.0f));
            Destroy(gameObject, 3.0f);
        }
    }
}
