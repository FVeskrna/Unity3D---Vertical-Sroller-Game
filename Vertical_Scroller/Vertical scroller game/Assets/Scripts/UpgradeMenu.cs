using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    public GameObject UpgradeMenuObject;
    public Abilities PlayerAbilities;
    private bool ispaused;
    private ScoreSystem ScoreSystem;
    
    
    public GameObject FireRateMenu;
    private TMP_Text Firerate_Current_text;
    private int Firerate_Current;
    private TMP_Text Firerate_Cost_text;
    private int Firerate_Cost;

    public GameObject BulletSpeedMenu;
    private TMP_Text BulletSpeed_Current_text;
    private int BulletSpeed_Current;
    private TMP_Text BulletSpeed_Cost_text;
    private int BulletSpeed_Cost;

    public GameObject AddHealthMenu;
    private TMP_Text AddHealth_Current_text;
    private int AddHealth_Current;
    private TMP_Text AddHealth_Cost_text;
    private int AddHealth_Cost;


    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem = gameObject.GetComponent<ScoreSystem>();
        ResetAll();

        Firerate_Cost_text = FireRateMenu.transform.Find("Cost").GetComponent<TMP_Text>();
        Firerate_Current_text = FireRateMenu.transform.Find("CurrentLevel").GetComponent<TMP_Text>();

        BulletSpeed_Cost_text = BulletSpeedMenu.transform.Find("Cost").GetComponent<TMP_Text>();
        BulletSpeed_Current_text = BulletSpeedMenu.transform.Find("CurrentLevel").GetComponent<TMP_Text>();

        AddHealth_Cost_text = AddHealthMenu.transform.Find("Cost").GetComponent<TMP_Text>();
        AddHealth_Current_text = AddHealthMenu.transform.Find("CurrentLevel").GetComponent<TMP_Text>();

        ispaused = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(!ispaused){
                PauseGame();
                ispaused = true;
                UpgradeMenuObject.SetActive(true);
            }
            else{
                ResumeGame();
                ispaused = false;
                UpgradeMenuObject.SetActive(false);
            }
        }

    }

    void PauseGame() => Time.timeScale = 0;
    void ResumeGame() => Time.timeScale = 1;

    public void UpgradeFireRate(){
        if(Firerate_Cost > ScoreSystem.currency)
        return;

        ScoreSystem.currency -= Firerate_Cost;
        Firerate_Cost *= 2;
        Firerate_Current++;
        Firerate_Cost_text.text = Firerate_Cost.ToString();
        Firerate_Current_text.text = Firerate_Current.ToString();

        PlayerAbilities.TimeBetweenShots -= 0.025f;
    }

    public void UpgradeBulletSpeed(){
        if(BulletSpeed_Cost > ScoreSystem.currency)
        return;

        ScoreSystem.currency -= BulletSpeed_Cost;
        BulletSpeed_Cost *= 2;
        BulletSpeed_Current++;
        BulletSpeed_Cost_text.text = BulletSpeed_Cost.ToString();
        BulletSpeed_Current_text.text = BulletSpeed_Current.ToString();

        PlayerAbilities.BulletSpeed -= 0.25f;
    }

    public void AddHealth(){
        if(AddHealth_Cost > ScoreSystem.currency)
        return;

        ScoreSystem.currency -= AddHealth_Cost;
        AddHealth_Cost *= 2;
        AddHealth_Current++;
        AddHealth_Cost_text.text = AddHealth_Cost.ToString();
        AddHealth_Current_text.text = AddHealth_Current.ToString();

        ScoreSystem.health++;
    }

    public void ResetAll(){
        Firerate_Current = 0;
        Firerate_Cost = 50;
        PlayerAbilities.TimeBetweenShots = 0.6f;
        BulletSpeed_Current = 0;
        BulletSpeed_Cost = 50;
        PlayerAbilities.BulletSpeed = 3f;
    }
}
