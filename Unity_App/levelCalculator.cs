using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelCalculator : MonoBehaviour
{

    public int lvl = 0;
    public int xp;
    public int xp2lvl;

    void Update()
    {
        xp = 4 * (lvl) * (4 * (lvl));
        xp2lvl = 4 * (lvl) * (4 * (lvl)) - 4 * (lvl - 1) * (4 * (lvl - 1));

        if (Input.GetKeyDown("space"))
        {
            print(xp);
        }
    }
}
