using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public GameObject Player;
    public int Health;
    private int AmountOfIncrease;
    private int AmountOfDecrease;

	// Use this for initialization
	void Start () {
        Player = this.gameObject;
        Health = 100;

        AmountOfIncrease = 20;
        AmountOfDecrease = 20;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Health <= 0)
        {
            Destroy(Player);
        }
	}

    public void DecreaseHealth()
    {
       Health = Health - AmountOfDecrease;
    }

    public void IncreaseHealth()
    {
        if (Health < 100)
        {
            if (Health >= 80)
            {
                Health = Health + (100 - Health);
            }
            else if (Health < 80)
            {
                Health = Health + AmountOfIncrease;
            }
        }
    }
    public void FallDamage()
    {
        Health = 0;
    }
}
