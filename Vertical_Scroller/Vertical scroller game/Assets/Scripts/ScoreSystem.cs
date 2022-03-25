using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public GameObject GameComponents;
    public GameObject FinalScreen;
    private EnemiesSpawning EnemiesSpawning;
    private UpgradeMenu upgradeMenu;
    [HideInInspector] public int score;
    public TMP_Text Text_Score;
    [HideInInspector] public int currency;
    public TMP_Text Text_Currency;
    [HideInInspector] public int health;
    public TMP_Text Text_health;

    private GameObject EnemyParentObject;
    // Start is called before the first frame update
    void Start()
    {
        EnemyParentObject = GameObject.Find("ParentObject");
        EnemiesSpawning = gameObject.GetComponent<EnemiesSpawning>();
        upgradeMenu = gameObject.GetComponent<UpgradeMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        Text_Score.text = score.ToString();
        Text_Currency.text = currency.ToString();
        Text_health.text = health.ToString();

        if(score>100 && EnemiesSpawning.TimeBetweenRocks <= 0.5f)
        EnemiesSpawning.TimeBetweenRocks = (100f-(score/100))*0.01f;

        if(health <= 0){
            Debug.Log("Game Over");
            GameOver();
        }
    }

    void AddOnePoint() => score += 1;

    public void AddPoints(int increase) => score += increase;
    public void AddCurrency(int increase) => currency += increase;
    void PauseGame() => Time.timeScale = 0;
    void ResumeGame() => Time.timeScale = 1;

    public void GameOver(){
        FinalScreen.transform.Find("Score").GetComponent<TMP_Text>().text = score.ToString();
        PauseGame();
        foreach(Transform child in EnemyParentObject.transform){
            Destroy(child.gameObject);
        }
        CancelInvoke("AddOnePoint");

        GameComponents.transform.Find("Player").position = new Vector2();
        FinalScreen.SetActive(true);
        GameComponents.SetActive(false);
    }

    public void StartGame(){
        FinalScreen.SetActive(false);
        GameComponents.SetActive(true);
        ResumeGame();
        score = 0;
        currency = 0;
        health = 3;
        InvokeRepeating("AddOnePoint",1,1);
    }

}
