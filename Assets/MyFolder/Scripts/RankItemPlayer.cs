using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using TMPro;

public class RankItemPlayer : MonoBehaviour
{
    public GameObject[] rankItems; 
    public float displayInterval = 1.0f;
    float m_DisplayInterval;
    int m_Index;

    /* public void UpdateToTMP_Text(Record[] records)
    {
        m_RecordLength = records.Length;
        for(int i=0; i<m_RecordLength; i++)
        {
            TMP_Text[] texts = rankItems[i].GetComponentsInChildren<TMP_Text>();
            texts[0].text = "#" + (i+1).ToString();
            texts[1].text = records[i].saveTime;
            texts[2].text = records[i].recordTime.ToString();
        }
    } */

    // Start is called before the first frame update
    void Start()
    {
        m_DisplayInterval = 0;
        m_Index = 0;   //先禁用自动更新
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Index >= rankItems.Length) return;
        if(m_DisplayInterval<=0)
        {
            rankItems[m_Index].SetActive(true);
            m_DisplayInterval = displayInterval;
            m_Index += 1;
        }
        else
        {
            m_DisplayInterval -= Time.deltaTime;
        }
    }
}
