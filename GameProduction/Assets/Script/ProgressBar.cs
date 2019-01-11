using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    
    public Image progressBar;
    float timeAmt;
    float time;

    public static bool isTimeUp;

    public TextMeshProUGUI timeText;
    //[SerializeField]private float currentAmount;
    //[SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        timeAmt = 25;
        //progressBar = this.GetComponent<Image>();
        time = timeAmt;
        isTimeUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.doingSetup)
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
}
