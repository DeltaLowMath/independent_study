using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class LevelData {

    public int[] levelStore;
    public float[] xpRequiredStore;
    public float[] xpCurrentStore;
    public float[] xpTotalStore;

    void Start()
    {
        levelStore = new int[9];
        xpRequiredStore = new float[9];
        xpCurrentStore = new float[9];
        xpTotalStore = new float[9];
    }
    public LevelData(SkillLevelIndex index)
    {
        for (int i = 0; i < 9; i++)
        {
            levelStore[i] = index.level[i];
            xpRequiredStore[i] = index.xpRequired[i];
            xpCurrentStore[i] = index.xpCurrent[i];
            xpTotalStore[i] = index.xpTotal[i];
        }
    }
}
