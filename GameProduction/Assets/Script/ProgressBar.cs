using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    
    public Image progressBar;
    static float timeAmt;
    static float time;

    public static bool isTimeUp;
    public static float initialTime = 20;

    public TextMeshProUGUI timeText;
    //[SerializeField]private float currentAmount;
    //[SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        timeAmt = initialTime;
        //progressBar = this.GetComponent<Image>();
        time = timeAmt;
        isTimeUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.doingSetup || MenuStats.IsTutorial == 1)
            return;

        if (time > 0)
        {
            time -= Time.deltaTime;
            progressBar.GetComponent<Image>().fillAmount = time / timeAmt;
            timeText.text = "Time : " + time.ToString("F");
        }
        else
        {
            isTimeUp = true;
        }
        
    }

    public static void ResetTime()
    {
        timeAmt = initialTime;
        time = timeAmt;
    }
}
