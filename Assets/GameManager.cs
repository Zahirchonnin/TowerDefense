using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button StartWave, SpeedUp;
    [SerializeField] TextMeshProUGUI CurrentWave, Money;

    void Start()
    {
        GlobalData.MoneyText = Money;
        SpeedUp.onClick.AddListener(() =>{Time.timeScale = (Time.timeScale == 1) ? 3 : 1;});
        StartWave.onClick.AddListener(CallWave);
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.AliveSlimes == 0)
            StartWave.interactable = true;
    }
    void CallWave()
    {
        if (GlobalData.lose)
            GlobalData.wave--;
        GlobalData.lose = false;
        GlobalData.wave++;
        GlobalData.NextWave();
        CurrentWave.SetText($"Wave\n{GlobalData.wave}");
        StartWave.interactable = false;
    }
}
