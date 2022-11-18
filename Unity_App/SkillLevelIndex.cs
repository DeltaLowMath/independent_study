using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SkillLevelIndex : MonoBehaviour
{
    Image[] xpBar;
    public Image xpBarArchitect;
    public Image xpBarArchivist;
    public Image xpBarAstrologer;
    public Image xpBarEnchanter;
    public Image xpBarGardener;
    public Image xpBarSummoner;
    public Image xpBarSurveyor;
    public Image xpBarWarlock;

    private void Start()
    {
        xpBar = new Image[8];
        xpBar[0] = null;
        xpBar[1] = xpBarArchitect;
        xpBar[2] = xpBarArchivist;
        xpBar[3] = xpBarAstrologer;
        xpBar[4] = xpBarEnchanter;
        xpBar[5] = xpBarGardener;
        xpBar[6] = xpBarSummoner;
        xpBar[7] = xpBarSurveyor;
        xpBar[8] = xpBarWarlock;
    }
}
