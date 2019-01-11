using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Life : MonoBehaviour
{

    TextMeshProUGUI LifeText;
    // Start is called before the first frame update
    void Start()
    {
        LifeText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeText.SetText("X " + LevelManager.Life.ToString());
    }
}
