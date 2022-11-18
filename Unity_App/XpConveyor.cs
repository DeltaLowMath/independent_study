using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpConveyor : MonoBehaviour
{
    SkillLevelCalculator main;

    void Awake()
    {
        main = this.gameObject.GetComponent<SkillLevelCalculator>();
    }
    public IEnumerator ConveyXp()
    {
        main.CalculateXp(1, 100, 10);
        yield return new WaitForSeconds(4);
        main.CalculateXp(5, 200, 10);
        yield return new WaitForSeconds(4);
        main.CalculateXp(3, 100, 10);
        yield return new WaitForSeconds(4);
        main.CalculateXp(7, 400, 10);
        yield return new WaitForSeconds(4);
        main.CalculateXp(4, 100, 10);
        yield return new WaitForSeconds(4);
        main.CalculateXp(2, 200, 10);
        yield return new WaitForSeconds(4);
        main.CalculateXp(6, 100, 10);
        yield return new WaitForSeconds(4);
        main.CalculateXp(8, 500, 10);
        yield return new WaitForSeconds(4);
    }
}
