using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    
    public string questName;
    public int[] npc_number;

    public QuestData(string name, int[] npc)
	{
        questName = name;
        npc_number = npc;
	}
}
