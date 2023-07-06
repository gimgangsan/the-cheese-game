using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBoard : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float maxEnergy;
    private bool reset;
    public GameObject PlayerObj;
    public GameObject GameOverManu;

    void Start()
    {
        ResetValue();
    }

    public void ResetValue()    //------------------------------------------------------------- 값 초기화
    {
        slider.maxValue = maxEnergy;    // 최대 에너지
        slider.value = maxEnergy;       // 현재 에너지
    }

    void Update()   //------------------------------------------------------------------------- 에너지 감소  &  게임 종료
    {
        if(slider.value>0)              // 게임 종료 후에도 에너지를 넣어주면 재작동
        {
            if (player.energy == 1)
            {
                slider.value += 10;
                player.energy = 0;
            }
            if (player.hurt)
            {
                slider.value -= Time.deltaTime * 20;
            }
            slider.value -= Time.deltaTime * 3;     // 초당 3만큼 에너지 감소
            reset = true;
        }
        else if(reset)                  // reset이 true일 때만 게임 종료 코드가 실행됨
        {
            PlayerObj.SetActive(false);         // 게임 종료 코드
            GameOverManu.SetActive(true);
            reset = false;                      // 더이상 게임 종료 코드가 실행되지 않도록
        }
    }
}
