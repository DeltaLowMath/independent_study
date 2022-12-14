using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SkillLevelIndex : MonoBehaviour
{
    SkillLevelUI ui;
    SkillLevelTable data;
    SkillLevelCalculator main;

    public int take;
    public int pass;
    public bool loadKey = false;

    public Dictionary<int, Image> xpBar = new Dictionary<int, Image>();
    public Dictionary<int, Image> xpBackBar = new Dictionary<int, Image>();
    public Dictionary<int, TextMeshProUGUI> levelText = new Dictionary<int, TextMeshProUGUI>();
    public Dictionary<int, TextMeshProUGUI> xpTotalText = new Dictionary<int, TextMeshProUGUI>();
    public Dictionary<int, TextMeshProUGUI> xpThisLevelText = new Dictionary<int, TextMeshProUGUI>();
    public Dictionary<int, float> xpRequired = new Dictionary<int, float>();
    public Dictionary<int, float> xpCurrent = new Dictionary<int, float>();
    public Dictionary<int, float> xpTotal = new Dictionary<int, float>();
    public Dictionary<int, int> level = new Dictionary<int, int>();

    void Awake()
    {
        ui = this.gameObject.GetComponent<SkillLevelUI>();
        data = this.gameObject.GetComponent<SkillLevelTable>();
        main = this.gameObject.GetComponent<SkillLevelCalculator>();
    }

    void Start()
    {
        /*setUI();
        setData();*/
    }

    public void setUI()
    {
        setXpBar();
        setXpBackBar();
        setLevelText();
        setXpTotalText();
        setXpThisLevelText();
    }

    public void setData()
    {
        setLevel();
        setReqXp();
        setCurrentXp();
        setTotalXp();
    }

    public void Save()
    {
        SaveLoadLevelData.SaveData(this);
        Debug.Log("File Saved");
    }

    public void Load()
    {
        loadKey = true; int i; i = take; pass = i;
        if (i > 8)
        {
            loadKey = false;
        }
        LevelData levelData = SaveLoadLevelData.LoadData();
        xpRequired[i] = levelData.xpRequiredStore[i];
        xpCurrent[i] = levelData.xpCurrentStore[i];
        xpTotal[i] = levelData.xpTotalStore[i];
        level[i] = levelData.levelStore[i];
        i++;
        Debug.Log("File Loaded");
    }

    void setXpBar()
    {
        xpBar.Add(0, main.xpBar);
        xpBar.Add(1, ui.xpBarArchitect);
        xpBar.Add(2, ui.xpBarArchivist);
        xpBar.Add(3, ui.xpBarAstrologer);
        xpBar.Add(4, ui.xpBarEnchanter);
        xpBar.Add(5, ui.xpBarGardener);
        xpBar.Add(6, ui.xpBarSummoner);
        xpBar.Add(7, ui.xpBarSurveyor);
        xpBar.Add(8, ui.xpBarWarlock);
    }

    void setXpBackBar()
    {
        xpBackBar.Add(0, main.xpBackBar);
        xpBackBar.Add(1, ui.backXpBarArchitect);
        xpBackBar.Add(2, ui.backXpBarArchivist);
        xpBackBar.Add(3, ui.backXpBarAstrologer);
        xpBackBar.Add(4, ui.backXpBarEnchanter);
        xpBackBar.Add(5, ui.backXpBarGardener);
        xpBackBar.Add(6, ui.backXpBarSummoner);
        xpBackBar.Add(7, ui.backXpBarSurveyor);
        xpBackBar.Add(8, ui.backXpBarWarlock);
    }

    void setLevelText()
    {
        levelText.Add(0, main.levelText);
        levelText.Add(1, ui.levelTextArchitect);
        levelText.Add(2, ui.levelTextArchivist);
        levelText.Add(3, ui.levelTextAstrologer);
        levelText.Add(4, ui.levelTextEnchanter);
        levelText.Add(5, ui.levelTextGardener);
        levelText.Add(6, ui.levelTextSummoner);
        levelText.Add(7, ui.levelTextSurveyor);
        levelText.Add(8, ui.levelTextWarlock);
    }

    void setXpTotalText()
    {
        xpTotalText.Add(0, main.xpTotalText);
        xpTotalText.Add(1, ui.totalXpTextArchitect);
        xpTotalText.Add(2, ui.totalXpTextArchivist);
        xpTotalText.Add(3, ui.totalXpTextAstrologer);
        xpTotalText.Add(4, ui.totalXpTextEnchanter);
        xpTotalText.Add(5, ui.totalXpTextGardener);
        xpTotalText.Add(6, ui.totalXpTextSummoner);
        xpTotalText.Add(7, ui.totalXpTextSurveyor);
        xpTotalText.Add(8, ui.totalXpTextWarlock);
    }

    void setXpThisLevelText()
    {
        xpThisLevelText.Add(0, main.xpThisLevelText);
        xpThisLevelText.Add(1, ui.xpThisLevelArchitect);
        xpThisLevelText.Add(2, ui.xpThisLevelArchivist);
        xpThisLevelText.Add(3, ui.xpThisLevelAstrologer);
        xpThisLevelText.Add(4, ui.xpThisLevelEnchanter);
        xpThisLevelText.Add(5, ui.xpThisLevelGardener);
        xpThisLevelText.Add(6, ui.xpThisLevelSummoner);
        xpThisLevelText.Add(7, ui.xpThisLevelSurveyor);
        xpThisLevelText.Add(8, ui.xpThisLevelWarlock);
    }

    void setReqXp()
    {
        xpRequired.Add(0, data.reqXp);
        xpRequired.Add(1, data.architectReqXp);
        xpRequired.Add(2, data.archivistReqXp);
        xpRequired.Add(3, data.astrologerReqXp);
        xpRequired.Add(4, data.enchanterReqXp);
        xpRequired.Add(5, data.gardenerReqXp);
        xpRequired.Add(6, data.summonerReqXp);
        xpRequired.Add(7, data.surveyorReqXp);
        xpRequired.Add(8, data.warlockReqXp);
    }

    void setCurrentXp()
    {
        xpCurrent.Add(0, data.currentXp);
        xpCurrent.Add(1, data.architectCurrentXp);
        xpCurrent.Add(2, data.archivistCurrentXp);
        xpCurrent.Add(3, data.astrologerCurrentXp);
        xpCurrent.Add(4, data.enchanterCurrentXp);
        xpCurrent.Add(5, data.gardenerCurrentXp);
        xpCurrent.Add(6, data.summonerCurrentXp);
        xpCurrent.Add(7, data.surveyorCurrentXp);
        xpCurrent.Add(8, data.warlockCurrentXp);
    }

    void setTotalXp()
    {
        xpTotal.Add(0, data.totalXp);
        xpTotal.Add(1, data.architectTotalXp);
        xpTotal.Add(2, data.archivistTotalXp);
        xpTotal.Add(3, data.astrologerTotalXp);
        xpTotal.Add(4, data.enchanterTotalXp);
        xpTotal.Add(5, data.gardenerTotalXp);
        xpTotal.Add(6, data.summonerTotalXp);
        xpTotal.Add(7, data.surveyorTotalXp);
        xpTotal.Add(8, data.warlockTotalXp);
    }

    void setLevel()
    {
        level.Add(0, data.level);
        level.Add(1, data.architectLevel);
        level.Add(2, data.archivistLevel);
        level.Add(3, data.astrologerLevel);
        level.Add(4, data.enchanterLevel);
        level.Add(5, data.gardenerLevel);
        level.Add(6, data.summonerLevel);
        level.Add(7, data.surveyorLevel);
        level.Add(8, data.warlockLevel);
    }
}