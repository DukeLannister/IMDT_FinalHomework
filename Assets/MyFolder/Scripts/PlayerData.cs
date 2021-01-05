using System;
using UnityEngine;
using Tools;

namespace Tools{
    [Serializable]
    public class PlayerData 
    {
       public int m_MoneyNumber{get; private set;}
       public Record[] records{get; private set;}
       public int m_N{get; set;}
       int end;
       public PlayerData()
       {
           m_N = 4;
           records = new Record[m_N];    //默认为4个存档点
           m_MoneyNumber = 0;
           end = 0;
       }
       public PlayerData(int N)   //类初始化构造函数
       {
           m_N = N;   //最多的存档数
           records = new Record[m_N];    //生成存档循环链表
           m_MoneyNumber = 0;
           end = 0;
       }

       public void AddRecord(float recordTime, int newMoney = 0, int rank = 1)
       {
           for(int t=0; t<end; t++)
           {
               records[t].SetNewest(false);
           }
           records[end] = new Record(DateTime.Now, recordTime);
           for(int t=end; t>0; t--)
           {
               if(records[t].recordTime > records[t-1].recordTime)
               {
                   Record tempRecord = records[t-1];
                   records[t-1] = records[t];
                   records[t] = tempRecord;
               }
           }
           if(end < m_N - 1) end += 1;
           m_MoneyNumber = newMoney;
       }

       public void GetLatestSavePoint()   //默认获得最近的存档点的名称
       {
           //UI 声明PlayerData的类型并控制和输出记录。
       }
    }
}

