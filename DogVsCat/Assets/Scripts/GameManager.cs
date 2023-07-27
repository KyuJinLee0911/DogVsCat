using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject retryBtn;
    int level = 1;
    int cat = 0;
    public Text levelText;
    public GameObject levelFront;

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeFood", 0.0f, 0.2f);
        InvokeRepeating("SpawnCat", 0.0f, 1.0f);
    }

    public static GameManager Instance()
    {
        if (!instance)
        {
            instance = FindObjectOfType(typeof(GameManager)) as GameManager;

            if (instance == null)
                Debug.Log("no singleton objs");
        }

        return instance;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void MakeFood()
    {
        ObjectPool.GetObject();
    }

    void SpawnCat()
    {
        Instantiate(normalCat);
        if(level == 1)
        {
            float p = Random.Range(0, 10);
            if(p<2) Instantiate(normalCat);
        }
        else if(level == 2)
        {
            float p = Random.Range(0, 10);
            if(p<5) Instantiate(normalCat);
        }
        else if(level == 3)
        {
            float p = Random.Range(0, 10);
            if(p<5) Instantiate(normalCat);

            Instantiate(fatCat);
        }
        else if(level >= 4)
        {
            float p = Random.Range(0, 10);
            if(p<5) Instantiate(normalCat);

            Instantiate(pirateCat);
        }
        
    }

    public void AddCat()
    {
        cat += 1;
        level = cat / 5;

        levelText.text = level.ToString();
        levelFront.transform.localScale = new Vector3((cat - level* 5) / 5.0f, 1, 1);
    }
}
