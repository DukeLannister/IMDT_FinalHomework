using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFadeIn : MonoBehaviour
{
    bool m_IsFading;
    TMP_Text[] m_TextArray; 
    Color m_Color;
    RecordDisplayer recordDisplayer;
    bool status;

    void OnEnable()
    {
        m_IsFading = true;
    }
    // Start is called before the first frame update
     void Awake()
    {
        m_IsFading = false;
        m_TextArray = GetComponentsInChildren<TMP_Text>();
    }

    void Start()
    {
        recordDisplayer = GetComponentInParent<RecordDisplayer>();
        m_Color = new Color(1, 1, 1, 0.01f);
        string tempSaveTime = recordDisplayer.GetSaveTime();   //通过获取存档时间是否为空，来得知该条记录是否已达到实际存储的最高记录条目数，如果是，那么就不再给接下来两项赋值，如果不是，正常给赋值
        if(tempSaveTime == null)
        {
            return;
        }
        m_TextArray[0].text = "#" + recordDisplayer.GetRecordIndex().ToString();
        m_TextArray[1].text = tempSaveTime;
        m_TextArray[2].text = recordDisplayer.GetRecordTime().ToString();
        if(status = recordDisplayer.GetNewestStatus())
        {
            m_TextArray[3].text = "New Record";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsFading)
        {
            foreach(TMP_Text text in m_TextArray)
            {
                text.color = m_Color;
            }
            m_Color.a += 0.01f;
            if(m_Color.a > 1.0f) 
            {
                m_IsFading = false;
                if(status)
                {
                    foreach(TMP_Text text in m_TextArray)
                    {
                        text.color = Color.yellow;
                    }
                }
            }
        }
    }
}
