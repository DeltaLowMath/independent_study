using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    GameObject spell;
    public GameObject energyBall;
    public GameObject energyBolt;
    public GameObject energyDisc;
    public GameObject energyWall;
    public GameObject energyOrb;
    public GameObject energyRay;
    public float spellVelocity = 0f;

    void Update()
    {
        SpellBook();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CastSpell();
        }
    }

    void SpellBook()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            spell = energyBall;
            spellVelocity = 32f;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            spell = energyBolt;
            spellVelocity = 40f;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            spell = energyDisc;
            spellVelocity = 24f;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            spell = energyWall;
            spellVelocity = 4f;
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            spell = energyOrb;
            spellVelocity = 8f;
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            spell = energyRay;
            spellVelocity = 16f;
        }
    }

    void CastSpell()
    {
        GameObject cast = Instantiate(spell, transform.position, transform.rotation);
        cast.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, (spellVelocity * 15)));
    }
}
