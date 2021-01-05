using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class RecordDisplayer : MonoBehaviour
{
    public static RecordDisplayer instance{get; private set;}
    public string saveFileName;
    [Tooltip("存档数目，一般设为4，如要调整需要调整UI")]
    public int N = 4;
    PlayerData playerData;
    public GameObject GameManager;
    TimeManager timeManager;
    RankItemPlayer rankItemPlayer;
    int m_Index;

    void Awake()
    {
        instance = this;
        timeManager = GameManager.GetComponent<TimeManager>();
        if(saveFileName == null) 
        {
            Debug.LogError("File Name is null");
            return;
        }
        playerData = SaveSystem.Load(saveFileName);
        if(playerData == null) playerData = new PlayerData(N);
        Debug.Log("Load Record Time:" + playerData.m_N);
    }

    void Start()
    {
        rankItemPlayer = GetComponentInChildren<RankItemPlayer>();
        m_Index = 0;
    }

    // Start is called before the first frame update

    public void AddPlayerData()
    {
        Debug.Log("save Record to RAM:" + timeManager.TimeRemaining);
        playerData.AddRecord(timeManager.TimeRemaining, UISystem.instance.GetKeyNumber());
        SaveSystem.Save(playerData, saveFileName);
    }

    public string GetSaveTime()
    {
        if(playerData.records[m_Index] == null) return null;
        else return playerData.records[m_Index].saveTime;
    }

    public int GetRecordIndex()
    {
        if(m_Index < N) 
        {
            m_Index += 1;
            return m_Index;
        }
        else 
        {
            Debug.Log("调用获取记录编号的次数超过了记录本身的最长限制");
            return 0;
        }
    }

    public float GetRecordTime()
    {
        return playerData.records[m_Index - 1].recordTime;
    }

    public bool GetNewestStatus()
    {
        return playerData.records[m_Index - 1].m_IsNewest;
    }

    /* public Record[] GetRecords()
    {
        if(playerData == null) return null;
        else return playerData.records;
    } */
    
}
