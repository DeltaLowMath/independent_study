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
    public gameObject energyOrb;
    public gameObject energyRay;

    public float spellVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpellBook();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            CastSpell();
        }
    }

    void SpellBook()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            spell = energyBall;
            spellVelocity = 32;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            spell = energyBolt;
            spellVelocity = 40;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            spell = energyDisc;
            spellVelocity = 24;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            spell = energyWall;
            spellVelocity = 16;
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            spell = energyOrb;
            spellVelocity = 8;
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            spell = energyRay;
            spellVelocity = 0;
        }
    }

    void CastSpell()
    {
        GameObject cast = Instantiate(spell, transform.position, transform.rotation);
        spell.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, spellVelocity, 0));
    }
}
