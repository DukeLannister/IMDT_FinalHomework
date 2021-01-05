using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{

    public float PanelDuringTime = 1.0f;
    float m_DuringTime;
    
    void OnEnable()
    {
        m_DuringTime = PanelDuringTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_DuringTime > 0)
        {
            m_DuringTime -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
