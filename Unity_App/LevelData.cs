using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class LevelData {

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

    [Header("Warlock Data")]
    public int warlockLevel;
    public float warlockReqXp;
    public float warlockCurrentXp;
    public float warlockTotalXp;

    
    public LevelData (SkillLevelCalculator player)
    {
        astrologerLevel = player.astrologerLevel;
        astrologerReqXp = player.astrologerReqXp;
        astrologerCurrentXp = player.astrologerCurrentXp;
        astrologerTotalXp = player.astrologerTotalXp;

        enchanterLevel = player.enchanterLevel;
        enchanterReqXp = player.enchanterReqXp;
        enchanterCurrentXp = player.enchanterCurrentXp;
        enchanterTotalXp = player.enchanterTotalXp;

        gardenerLevel = player.gardenerLevel;
        gardenerReqXp = player.gardenerReqXp;
        gardenerCurrentXp = player.gardenerCurrentXp;
        gardenerTotalXp = player.gardenerTotalXp;

        summonerLevel = player.summonerLevel;
        summonerReqXp = player.summonerReqXp;
        summonerCurrentXp = player.summonerCurrentXp;
        summonerTotalXp = player.summonerTotalXp;

        warlockLevel = player.warlockLevel;
        warlockReqXp = player.warlockReqXp;
        warlockCurrentXp = player.warlockCurrentXp;
        warlockTotalXp = player.warlockTotalXp;
    }
}