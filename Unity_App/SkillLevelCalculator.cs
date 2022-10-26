using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SkillLevelCalculator : MonoBehaviour
{
    public int xp;
    public int level;
    public float reqXp;
    public float currentXp;
    public float totalXp;

    private float lerpTimer;
    private float delayTimer;

    [Header("Xp Bar")]
    public Image xpBar;
    public Image backXpBar;
    public int fillTime;
    public int delay;

    [Header("Entries")]
    public TMPro.TMP_Dropdown dropSelect;
    public TMP_InputField xpEntry;
    public bool logged = false;

    [Header("Architect Data")]
    public int architectLevel;
    public float architectReqXp;
    public float architectCurrentXp;
    public float architectTotalXp;

    [Header("Archivist Data")]
    public int archivistLevel;
    public float archivistReqXp;
    public float archivistCurrentXp;
    public float archivistTotalXp;

    [Header("Astrologer Data")]
    public int astrologerLevel;
    public float astrologerReqXp;
    public float astrologerCurrentXp;
    public float astrologerTotalXp;

    [Header("Enchanter Data")]
    public int enchanterLevel;
    public float enchanterReqXp;
    public float enchanterCurrentXp;
    public float enchanterTotalXp;

    [Header("Gardener Data")]
    public int gardenerLevel;
    public float gardenerReqXp;
    public float gardenerCurrentXp;
    public float gardenerTotalXp;

    [Header("Summoner Data")]
    public int summonerLevel;
    public float summonerReqXp;
    public float summonerCurrentXp;
    public float summonerTotalXp;

    [Header("Surveyor Data")]
    public int surveyorLevel;
    public float surveyorReqXp;
    public float surveyorCurrentXp;
    public float surveyorTotalXp;

    [Header("Warlock Data")]
    public int warlockLevel;
    public float warlockReqXp;
    public float warlockCurrentXp;
    public float warlockTotalXp;

    [Header("Architect UI")]
    public Image xpBarArchitect;
    public Image backXpBarArchitect;
    public TextMeshProUGUI levelTextArchitect;
    public TextMeshProUGUI totalXpTextArchitect;
    public TextMeshProUGUI xpThisLevelArchitect;

    [Header("Archivist UI")]
    public Image xpBarArchivist;
    public Image backXpBarArchivist;
    public TextMeshProUGUI levelTextArchivist;
    public TextMeshProUGUI totalXpTextArchivist;
    public TextMeshProUGUI xpThisLevelArchivist;

    [Header("Astologer UI")]
    public Image xpBarAstrologer;
    public Image backXpBarAstrologer;
    public TextMeshProUGUI levelTextAstrologer;
    public TextMeshProUGUI totalXpTextAstrologer;
    public TextMeshProUGUI xpThisLevelAstrologer;

    [Header("Enchanter UI")]
    public Image xpBarEnchanter;
    public Image backXpBarEnchanter;
    public TextMeshProUGUI levelTextEnchanter;
    public TextMeshProUGUI totalXpTextEnchanter;
    public TextMeshProUGUI xpThisLevelEnchanter;

    [Header("Gardener UI")]
    public Image xpBarGardener;
    public Image backXpBarGardener;
    public TextMeshProUGUI levelTextGardener;
    public TextMeshProUGUI totalXpTextGardener;
    public TextMeshProUGUI xpThisLevelGardener;

    [Header("Summoner UI")]
    public Image xpBarSummoner;
    public Image backXpBarSummoner;
    public TextMeshProUGUI levelTextSummoner;
    public TextMeshProUGUI totalXpTextSummoner;
    public TextMeshProUGUI xpThisLevelSummoner;

    [Header("Surveyor UI")]
    public Image xpBarSurveyor;
    public Image backXpBarSurveyor;
    public TextMeshProUGUI levelTextSurveyor;
    public TextMeshProUGUI totalXpTextSurveyor;
    public TextMeshProUGUI xpThisLevelSurveyor;

    [Header("Warlock UI")]
    public Image xpBarWarlock;
    public Image backXpBarWarlock;
    public TextMeshProUGUI levelTextWarlock;
    public TextMeshProUGUI totalXpTextWarlock;
    public TextMeshProUGUI xpThisLevelWarlock;

    [Header("UI")]
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI totalXpText;
    public TextMeshProUGUI xpThisLevel;

    void Start()
    {
        xpBar.fillAmount = currentXp / reqXp;
        backXpBar.fillAmount = currentXp / reqXp;
        reqXp = CalculateReqXp();
        levelText.text = "Level " + level;
    }

    void Update()
    {
        UpdateXpUI();
        if (logged)
        {
            GainXpFlatRate(xp);
            totalXpText.text = "Total XP " + totalXp;
            if (dropSelect.value == 1)
            {
                architectTotalXp = totalXp;
            }
            else if (dropSelect.value == 2)
            {
                archivistTotalXp = totalXp;
            }
            else if (dropSelect.value == 3)
            {
                astrologerTotalXp = totalXp;
            }
            else if (dropSelect.value == 4)
            {
                enchanterTotalXp = totalXp;
            }
            else if (dropSelect.value == 5)
            {
                gardenerTotalXp = totalXp;
            }
            else if (dropSelect.value == 6)
            {
                summonerTotalXp = totalXp;
            }
            else if (dropSelect.value == 7)
            {
                surveyorTotalXp = totalXp;
            }
            else if (dropSelect.value == 8)
            {
                warlockTotalXp = totalXp;
            }
        }
        logged = false;
        if (!logged)
        {
            if (dropSelect.value == 1)
            {
                architectLevel = level;
                architectCurrentXp = currentXp;
                architectReqXp = reqXp;
            }
            else if (dropSelect.value == 2)
            {
                archivistLevel = level;
                archivistCurrentXp = currentXp;
                archivistReqXp = reqXp;
            }
            else if (dropSelect.value == 3)
            {
                astrologerLevel = level;
                astrologerCurrentXp = currentXp;
                astrologerReqXp = reqXp;
            }
            else if (dropSelect.value == 4)
            {
                enchanterLevel = level;
                enchanterCurrentXp = currentXp;
                enchanterReqXp = reqXp;
            }
            else if (dropSelect.value == 5)
            {
                gardenerLevel = level;
                gardenerCurrentXp = currentXp;
                gardenerReqXp = reqXp;
            }
            else if (dropSelect.value == 6)
            {
                summonerLevel = level;
                summonerCurrentXp = currentXp;
                summonerReqXp = reqXp;
            }
            else if (dropSelect.value == 7)
            {
                surveyorLevel = level;
                surveyorCurrentXp = currentXp;
                surveyorReqXp = reqXp;
            }
            else if (dropSelect.value == 8)
            {
                warlockLevel = level;
                warlockCurrentXp = currentXp;
                warlockReqXp = reqXp;
            }
        }
        if (currentXp > reqXp)
            LevelUp();
    }

    public void UpdateXpUI()
    {
        float xpFraction = currentXp / reqXp;
        float fillXp = xpBar.fillAmount;
        if (fillXp < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
            if(delayTimer > delay)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / fillTime;
                xpBar.fillAmount = Mathf.Lerp(fillXp, backXpBar.fillAmount, percentComplete);
            }
        }
        xpThisLevel.text = "XP " + currentXp + "/" + reqXp;
    }

    public void GainXpFlatRate(float xpGained)
    {
        currentXp += xpGained;
        totalXp += xpGained;
        lerpTimer = 0f;
    }

    public void LevelUp()
    {
        level++;
        xpBar.fillAmount = 0f;
        backXpBar.fillAmount = 0f;
        currentXp = Mathf.RoundToInt(currentXp - reqXp);
        reqXp = CalculateReqXp();
        levelText.text = "Level " + level;
    }

    private int CalculateReqXp()
    {
        int solveForReqXp = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForReqXp = (4 * (level) * (4 * (level)));
        }
        return solveForReqXp;
    }

    public void addXp()
    {
        int.TryParse(xpEntry.text, out xp);
        logged = true;
    }

    public void classSelector()
    {
        if (dropSelect.value == 1)
        {
            level = architectLevel;
            levelText = levelTextArchitect;

            reqXp = architectReqXp;
            totalXp = architectTotalXp;
            currentXp = architectCurrentXp;

            totalXpText = totalXpTextArchitect;
            xpThisLevel = xpThisLevelArchitect;

            xpBar = xpBarArchitect;
            backXpBar = backXpBarArchitect;
        }
        else if (dropSelect.value == 2)
        {
            level = archivistLevel;
            levelText = levelTextArchivist;

            reqXp = archivistReqXp;
            totalXp = archivistTotalXp;
            currentXp = archivistCurrentXp;

            totalXpText = totalXpTextArchivist;
            xpThisLevel = xpThisLevelArchivist;

            xpBar = xpBarArchivist;
            backXpBar = backXpBarArchivist;
        }
        else if (dropSelect.value == 3)
        {
            level = astrologerLevel;
            levelText = levelTextAstrologer;

            reqXp = astrologerReqXp;
            totalXp = astrologerTotalXp;
            currentXp = astrologerCurrentXp;

            totalXpText = totalXpTextAstrologer;
            xpThisLevel = xpThisLevelAstrologer;

            xpBar = xpBarAstrologer;
            backXpBar = backXpBarAstrologer;
        }
        else if (dropSelect.value == 4)
        {
            level = enchanterLevel;
            levelText = levelTextEnchanter;

            reqXp = enchanterReqXp;
            totalXp = enchanterTotalXp;
            currentXp = enchanterCurrentXp;

            totalXpText = totalXpTextEnchanter;
            xpThisLevel = xpThisLevelEnchanter;

            xpBar = xpBarEnchanter;
            backXpBar = backXpBarEnchanter;
        }
        else if (dropSelect.value == 5)
        {
            level = gardenerLevel;
            levelText = levelTextGardener;

            reqXp = gardenerReqXp;
            totalXp = gardenerTotalXp;
            currentXp = gardenerCurrentXp;

            totalXpText = totalXpTextGardener;
            xpThisLevel = xpThisLevelGardener;

            xpBar = xpBarGardener;
            backXpBar = backXpBarGardener;
        }
        else if (dropSelect.value == 6)
        {
            level = summonerLevel;
            levelText = levelTextSummoner;

            reqXp = summonerReqXp;
            totalXp = summonerTotalXp;
            currentXp = summonerCurrentXp;

            totalXpText = totalXpTextSummoner;
            xpThisLevel = xpThisLevelSummoner;

            xpBar = xpBarSummoner;
            backXpBar = backXpBarSummoner;
        }
        else if (dropSelect.value == 7)
        {
            level = surveyorLevel;
            levelText = levelTextSurveyor;

            reqXp = surveyorReqXp;
            totalXp = surveyorTotalXp;
            currentXp = surveyorCurrentXp;

            totalXpText = totalXpTextSurveyor;
            xpThisLevel = xpThisLevelSurveyor;

            xpBar = xpBarSurveyor;
            backXpBar = backXpBarSurveyor;
        }
        else if (dropSelect.value == 8)
        {
            level = warlockLevel;
            levelText = levelTextWarlock;

            reqXp = warlockReqXp;
            totalXp = warlockTotalXp;
            currentXp = warlockCurrentXp;

            totalXpText = totalXpTextWarlock;
            xpThisLevel = xpThisLevelWarlock;

            xpBar = xpBarWarlock;
            backXpBar = backXpBarWarlock;
        }
    }

    public void SaveData()
    {
        SaveLoadLevelData.SaveData(this);
        Debug.Log("File Saved");
    }

    public void LoadData()
    {
        LevelData levelData = SaveLoadLevelData.LoadData();

        architectLevel = levelData.architectLevel;
        architectReqXp = levelData.architectReqXp;
        architectCurrentXp = levelData.architectCurrentXp;
        architectTotalXp = levelData.architectTotalXp;

        archivistLevel = levelData.archivistLevel;
        archivistReqXp = levelData.archivistReqXp;
        archivistCurrentXp = levelData.archivistCurrentXp;
        archivistTotalXp = levelData.archivistTotalXp;

        astrologerLevel = levelData.astrologerLevel;
        astrologerReqXp = levelData.astrologerReqXp;
        astrologerCurrentXp = levelData.astrologerCurrentXp;
        astrologerTotalXp = levelData.astrologerTotalXp;

        enchanterLevel = levelData.enchanterLevel;
        enchanterReqXp = levelData.enchanterReqXp;
        enchanterCurrentXp = levelData.enchanterCurrentXp;
        enchanterTotalXp = levelData.enchanterTotalXp;

        gardenerLevel = levelData.gardenerLevel;
        gardenerReqXp = levelData.gardenerReqXp;
        gardenerCurrentXp = levelData.gardenerCurrentXp;
        gardenerTotalXp = levelData.gardenerTotalXp;

        summonerLevel = levelData.summonerLevel;
        summonerReqXp = levelData.summonerReqXp;
        summonerCurrentXp = levelData.summonerCurrentXp;
        summonerTotalXp = levelData.summonerTotalXp;

        surveyorLevel = levelData.surveyorLevel;
        surveyorReqXp = levelData.surveyorReqXp;
        surveyorCurrentXp = levelData.surveyorCurrentXp;
        surveyorTotalXp = levelData.surveyorTotalXp;

        warlockLevel = levelData.warlockLevel;
        warlockReqXp = levelData.warlockReqXp;
        warlockCurrentXp = levelData.warlockCurrentXp;
        warlockTotalXp = levelData.warlockTotalXp;

        Debug.Log("File Loaded");
    }
}
