using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SkillLevelCalculator : MonoBehaviour
{
    SkillLevelIndex index;
    SkillLevelTable data;
    SkillLevelUI ui;
    XpConveyor convey;

    float lerpTimer;
    float delayTimer;
    int delay = 1;
    int fillTime = 160;

    int xp;
    int level;
    float xpRequired;
    float xpCurrent;
    float xpTotal;

    IEnumerator coroutine;
    int selectReference;
    int i;

    public Image xpBar;
    public Image xpBackBar;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI xpTotalText;
    public TextMeshProUGUI xpThisLevelText;

    [Header("Input")]
    public TMPro.TMP_Dropdown dropSelect;
    public TMP_InputField xpInput;
    public bool logged = false;

    void Awake()
    {
        index = this.gameObject.GetComponent<SkillLevelIndex>();
        data = this.gameObject.GetComponent<SkillLevelTable>();
        ui = this.gameObject.GetComponent<SkillLevelUI>();
        convey = this.gameObject.GetComponent<XpConveyor>();
    }

    void Start()
    {
        index.setData();
        index.setUI();
        coroutine = convey.ConveyXp();
        StartCoroutine(coroutine);
    }

    void Update()
    {
        i = selectReference;
        LevelCalculate(i, xp);
    }

    public void LevelCalculate(int i, int xp)
    {
        if (i > 0)
        {
            SkillDataSelector();
            SkillUISelector();
            XpUIUpdate();
            if (logged)
            {
                XpGainFlatRate(xp);
                xpTotalText.text = "Total Xp " + xpTotal;
            }
            logged = false;
            if (xpCurrent > xpRequired)
            {
                LevelUp();
            }
            SkillUIStore();
            SkillDataStore();
        }
    }

    public void SkillUISelector()
    {
        xpBar = index.xpBar[i];
        xpBackBar = index.xpBackBar[i];
        levelText = index.levelText[i];
        xpTotalText = index.xpTotalText[i];
        xpThisLevelText = index.xpThisLevelText[i];
    }

    void SkillDataSelector()
    {
        xpRequired = index.xpRequired[i];
        xpCurrent = index.xpCurrent[i];
        xpTotal = index.xpTotal[i];
        level = index.level[i];
    }

    void SkillUIStore()
    {
        index.xpBar[i] = xpBar;
        index.xpBackBar[i] = xpBackBar;
        index.levelText[i] = levelText;
        index.xpTotalText[i] = xpTotalText;
        index.xpThisLevelText[i] = xpThisLevelText;
    }

    void SkillDataStore()
    {
        index.xpRequired[i] = xpRequired;
        index.xpCurrent[i] = xpCurrent;
        index.xpTotal[i] = xpTotal;
        index.level[i] = level;
    }

    public void XpUIUpdate()
    {
        float xpFraction = xpCurrent / xpRequired;
        float xpFill = xpBar.fillAmount;
        if (xpFill < xpFraction)
        {
            delayTimer += Time.deltaTime;
            xpBackBar.fillAmount = xpFraction;
            if (delayTimer > delay)
            {
                lerpTimer += Time.deltaTime;
                float percentFull = lerpTimer / fillTime;
                xpBar.fillAmount = Mathf.Lerp(xpFill, xpBackBar.fillAmount, percentFull);
            }
        }
        xpThisLevelText.text = "XP" + xpCurrent + " / " + xpRequired; 
    }

    public void XpGainFlatRate(float xpGained)
    {
        xpCurrent += xpGained;
        xpTotal += xpGained;
        lerpTimer = 0f;
    }

    public void LevelUp()
    {
        level++;
        xpBar.fillAmount = 0f;
        xpBackBar.fillAmount = 0f;
        xpCurrent = Mathf.RoundToInt(xpCurrent - xpRequired);
        xpRequired = XpReqCalculate();
        levelText.text = "Level " + level;
    }

    public int XpReqCalculate()
    {
        int solveForXpRequried = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForXpRequried = (4 * (level) * (4 * (level)));
        }
        return solveForXpRequried;
    }

    public void XpAdd()
    {
        int.TryParse(xpInput.text, out xp);
        logged = true;
    }
    void XpLogManual()
    {
        if (index.loadKey)
        {
            i = index.pass;
            LevelCalculate(i, xp);
            index.take = i;
            index.Load();
        }
        else
        {
            i = dropSelect.value;
            LevelCalculate(i, xp);
        }
    }

    public void CalculateXp(int skill, int hours, int xpAmount)
    {
        if (skill > 0)
        {
            xp = hours * (xpAmount * 10);
            logged = true;
            selectReference = skill;
        }
    }
}