using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SkillLevelIndex {

    public SkillLevelUI ui;
    public SkillLevelTable data;

    public Image[] xpBar;
    public Image[] backXpBar;
    public TextMeshProUGUI[] levelText;
    public TextMeshProUGUI[] totalXpText;
    public TextMeshProUGUI[] xpThisLevelText;

    public int[] level;
    public float[] reqXp;
    public float[] currentXp;
    public float[] totalXp;

    public void SetSelection()
    {
        setXpBar();
        setBackXpBar();
        setLevelText();
        setTotalXpText();
        setXpThisLevelText();

        setLevel();
        setReqXp();
        setCurrentXp();
        setTotalXp();
    }

    void setXpBar()
    {
        xpBar = new Image[8];
        xpBar[0] = null;
        xpBar[1] = ui.xpBarArchitect;
        xpBar[2] = ui.xpBarArchivist;
        xpBar[3] = ui.xpBarAstrologer;
        xpBar[4] = ui.xpBarEnchanter;
        xpBar[5] = ui.xpBarGardener;
        xpBar[6] = ui.xpBarSummoner;
        xpBar[7] = ui.xpBarSurveyor;
        xpBar[8] = ui.xpBarWarlock;
    }

    void setBackXpBar()
    {
        backXpBar = new Image[8];
        backXpBar[0] = null;
        backXpBar[1] = ui.backXpBarArchitect;
        backXpBar[2] = ui.backXpBarArchivist;
        backXpBar[3] = ui.backXpBarAstrologer;
        backXpBar[4] = ui.backXpBarEnchanter;
        backXpBar[5] = ui.backXpBarGardener;
        backXpBar[6] = ui.backXpBarSummoner;
        backXpBar[7] = ui.backXpBarSurveyor;
        backXpBar[8] = ui.backXpBarWarlock;
    }

    void setLevelText()
    {
        levelText = new TextMeshProUGUI[8];
        levelText[0] = null;
        levelText[1] = ui.levelTextArchitect;
        levelText[2] = ui.levelTextArchivist;
        levelText[3] = ui.levelTextAstrologer;
        levelText[4] = ui.levelTextEnchanter;
        levelText[5] = ui.levelTextGardener;
        levelText[6] = ui.levelTextSummoner;
        levelText[7] = ui.levelTextSurveyor;
        levelText[8] = ui.levelTextWarlock;
    }

    void setTotalXpText()
    {
        totalXpText = new TextMeshProUGUI[8];
        totalXpText[0] = null;
        totalXpText[1] = ui.totalXpTextArchitect;
        totalXpText[2] = ui.totalXpTextArchivist;
        totalXpText[3] = ui.totalXpTextAstrologer;
        totalXpText[4] = ui.totalXpTextEnchanter;
        totalXpText[5] = ui.totalXpTextGardener;
        totalXpText[6] = ui.totalXpTextSummoner;
        totalXpText[7] = ui.totalXpTextSurveyor;
        totalXpText[8] = ui.totalXpTextWarlock;
    }

    void setXpThisLevelText()
    {
        xpThisLevelText = new TextMeshProUGUI[8];
        xpThisLevelText[0] = null;
        xpThisLevelText[1] = ui.totalXpTextArchitect;
        xpThisLevelText[2] = ui.totalXpTextArchivist;
        xpThisLevelText[3] = ui.totalXpTextAstrologer;
        xpThisLevelText[4] = ui.totalXpTextEnchanter;
        xpThisLevelText[5] = ui.totalXpTextGardener;
        xpThisLevelText[6] = ui.totalXpTextSummoner;
        xpThisLevelText[7] = ui.totalXpTextSurveyor;
        xpThisLevelText[8] = ui.totalXpTextWarlock;
    }

    void setLevel()
    {
        level = new int[8];
        level[0] = 0;
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
        reqXp = new float[8];
        reqXp[0] = 0f;
        reqXp[1] = data.architectReqXp;
        reqXp[2] = data.archivistReqXp;
        reqXp[3] = data.astrologerReqXp;
        reqXp[4] = data.enchanterReqXp;
        reqXp[5] = data.gardenerReqXp;
        reqXp[6] = data.summonerReqXp;
        reqXp[7] = data.surveyorReqXp;
        reqXp[8] = data.warlockReqXp;
    }

    void setCurrentXp()
    {
        currentXp = new float[8];
        currentXp[0] = 0f;
        currentXp[1] = data.architectCurrentXp;
        currentXp[2] = data.archivistCurrentXp;
        currentXp[3] = data.astrologerCurrentXp;
        currentXp[4] = data.enchanterCurrentXp;
        currentXp[5] = data.gardenerCurrentXp;
        currentXp[6] = data.summonerCurrentXp;
        currentXp[7] = data.surveyorCurrentXp;
        currentXp[8] = data.warlockCurrentXp;
    }

    void setTotalXp()
    {
        totalXp = new float[8];
        totalXp[0] = 0f;
        totalXp[1] = data.architectTotalXp;
        totalXp[2] = data.archivistTotalXp;
        totalXp[3] = data.astrologerTotalXp;
        totalXp[4] = data.enchanterTotalXp;
        totalXp[5] = data.gardenerTotalXp;
        totalXp[6] = data.summonerTotalXp;
        totalXp[7] = data.surveyorTotalXp;
        totalXp[8] = data.warlockTotalXp;
    }
}
