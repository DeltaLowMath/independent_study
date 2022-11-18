using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SkillLevelCalculator : MonoBehaviour
{
    //public SkillLevelTable data;
    SkillLevelIndex _index;

    float lerpTimer;
    float delayTimer;
    public int delay;
    public int fillTime;

    int i;
    int xp;

    [Header("Input")]
    public TMPro.TMP_Dropdown dropSelect;
    public TMP_InputField xpInput;
    public bool logged = false;

    void Awake()
    {
        _index = this.gameObject.GetComponent<SkillLevelIndex>();
    }

    void Start()
    {
        _index.SetSelect();
    }

    void Update()
    {
        i = dropSelect.value;
        Debug.Log(_index.xpTotalText[i]);
        XpUIUpdate();
        if (logged)
        {
            XpGainFlatRate(xp);
            _index.xpTotalText[i].text = "Total Xp " + _index.xpTotal[i];
        }
        logged = false;
        if (_index.xpCurrent[i] > _index.xpRequired[i])
        {
            LevelUp();
        }
    }

    public void XpUIUpdate()
    {
        float xpFraction = _index.xpCurrent[i] / _index.xpRequired[i];
        float xpFill = _index.xpBar[i].fillAmount;
        if (xpFill < xpFraction)
        {
            delayTimer += Time.deltaTime;
            _index.xpBackBar[i].fillAmount = xpFraction;
            if (delayTimer > delay)
            {
                lerpTimer += Time.deltaTime;
                float percentFull = lerpTimer / fillTime;
                _index.xpBar[i].fillAmount = Mathf.Lerp(xpFill, _index.xpBackBar[i].fillAmount, percentFull);
            }
        }
        _index.xpThisLevelText[i].text = "XP" + _index.xpCurrent[i] + "/" + _index.xpRequired[i]; 
    }

    public void XpGainFlatRate(float xpGained)
    {
        _index.xpCurrent[i] += xpGained;
        _index.xpTotal[i] += xpGained;
        lerpTimer = 0f;
    }

    public void LevelUp()
    {
        _index.level[i]++;
        _index.xpBar[i].fillAmount = 0f;
        _index.xpBackBar[i].fillAmount = 0f;
        _index.xpCurrent[i] = Mathf.RoundToInt(_index.xpCurrent[i] - _index.xpRequired[i]);
        _index.xpRequired[i] = XpReqCalculate();
        _index.levelText[i].text = "Level " + _index.level[i];
    }

    public int XpReqCalculate()
    {
        int solveForXpRequried = 0;
        for (int levelCycle = 1; levelCycle <= _index.level[i]; levelCycle++)
        {
            solveForXpRequried = (4 * (_index.level[i]) * (4 * (_index.level[i])));
        }
        return solveForXpRequried;
    }

    public void XpAdd()
    {
        int.TryParse(xpInput.text, out xp);
        logged = true;
    }
}