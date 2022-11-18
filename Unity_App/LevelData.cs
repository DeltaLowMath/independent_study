using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class LevelData {
    
    public Dictionary<int, float> xpRequiredStore = new Dictionary<int, float>();
    public Dictionary<int, float> xpCurrentStore = new Dictionary<int, float>();
    public Dictionary<int, float> xpTotalStore = new Dictionary<int, float>();
    public Dictionary<int, int> levelStore = new Dictionary<int, int>();
    public LevelData(SkillLevelIndex index)
    {
        for (int i = 0; i <= 8; i++)
        {
            xpRequiredStore.Add(i, index.xpRequired[i]);
            xpCurrentStore.Add(i, index.xpCurrent[i]);
            xpTotalStore.Add(i, index.xpTotal[i]);
            levelStore.Add(i, index.level[i]);
        }
    }
}