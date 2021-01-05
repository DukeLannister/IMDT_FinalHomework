using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISystem : MonoBehaviour
{
    public static UISystem instance {get; private set;}
    public TMP_Text keysText;
    int m_KeyNums;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        m_KeyNums = UserInfoManager.instance.info.keyNumber;
        if(m_KeyNums < 10) keysText.text = "00" + m_KeyNums;
        else if(m_KeyNums < 100) keysText.text = "0" + m_KeyNums;
        else keysText.text = m_KeyNums.ToString(); 
        //m_OriginalSize = mask.rectTransform.rect.width;
    }

    public void AddKey()
    {
        m_KeyNums += 1;
        if(m_KeyNums < 10) keysText.text = "00" + m_KeyNums;
        else if(m_KeyNums < 100) keysText.text = "0" + m_KeyNums;
        else keysText.text = m_KeyNums.ToString();
        UserInfoManager.instance.info.SetKeyNumber(m_KeyNums);
    }

    public int GetKeyNumber()
    {
        return m_KeyNums;
    }

    public void decreaseKey(int num)
    {
        m_KeyNums -= num;
        if(m_KeyNums < 10) keysText.text = "0" + m_KeyNums;
        else keysText.text = m_KeyNums.ToString(); 
    }

}
