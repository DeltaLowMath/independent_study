using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SkillLevelIndex : MonoBehaviour
{
    public SkillLevelTable data;

    public Image[] xpBar;
    public Image[] xpBackBar;

    public TextMeshProUGUI[] levelText;
    public TextMeshProUGUI[] xpTotalText;
    public TextMeshProUGUI[] xpThisLevelText;

    public int[] level;
    public float[] xpRequired;
    public float[] xpCurrent;
    public float[] xpTotal;

    void Awake()
    {
        data = this.gameObject.GetComponent<SkillLevelTable>();
    }

    public void SetSelect()
    {
        xpBar = GetComponents<Image>();
        xpBackBar = GetComponents<Image>();
        levelText = GetComponents<TextMeshProUGUI>();
        xpTotalText = GetComponents<TextMeshProUGUI>();
        xpThisLevelText = GetComponents<TextMeshProUGUI>();

        setLevel();
        setReqXp();
        setCurrentXp();
        setTotalXp();
    }

    void setLevel()
    {
        level = new int[9];
        level[0] = data.level;
        level[1] = data.architectLevel;
        level[2] = data.archivistLevel;
        level[3] = data.astrologerLevel;
        level[4] = data.enchanterLevel;
        level[5] = data.gardenerLevel;
        level[6] = data.summonerLevel;
        level[7] = data.surveyorLevel;
        level[8] = data.warlockLevel;
    }

    void setReqXp()
    {
        xpRequired = new float[9];
        xpRequired[0] = data.reqXp;
        xpRequired[1] = data.architectReqXp;
        xpRequired[2] = data.archivistReqXp;
        xpRequired[3] = data.astrologerReqXp;
        xpRequired[4] = data.enchanterReqXp;
        xpRequired[5] = data.gardenerReqXp;
        xpRequired[6] = data.summonerReqXp;
        xpRequired[7] = data.surveyorReqXp;
        xpRequired[8] = data.warlockReqXp;
    }

    void setCurrentXp()
    {
        xpCurrent = new float[9];
        xpCurrent[0] = data.currentXp;
        xpCurrent[1] = data.architectCurrentXp;
        xpCurrent[2] = data.archivistCurrentXp;
        xpCurrent[3] = data.astrologerCurrentXp;
        xpCurrent[4] = data.enchanterCurrentXp;
        xpCurrent[5] = data.gardenerCurrentXp;
        xpCurrent[6] = data.summonerCurrentXp;
        xpCurrent[7] = data.surveyorCurrentXp;
        xpCurrent[8] = data.warlockCurrentXp;
    }

    void setTotalXp()
    {
        xpTotal = new float[9];
        xpTotal[0] = data.totalXp;
        xpTotal[1] = data.architectTotalXp;
        xpTotal[2] = data.archivistTotalXp;
        xpTotal[3] = data.astrologerTotalXp;
        xpTotal[4] = data.enchanterTotalXp;
        xpTotal[5] = data.gardenerTotalXp;
        xpTotal[6] = data.summonerTotalXp;
        xpTotal[7] = data.surveyorTotalXp;
        xpTotal[8] = data.warlockTotalXp;
    }
}
