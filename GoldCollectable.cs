using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollectable : MonoBehaviour {

    public GameObject Player;
    public GameObject Collectable;
    public LevelStats LevelStatsScript;
	[SerializeField]
	bool collectableSelected;
	[SerializeField]
	Material gold;
	public string test;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.Find("Player");
        Collectable = this.gameObject;
		gold = Collectable.transform.GetChild(0).GetComponent<Renderer>().material;

        LevelStatsScript = Player.GetComponent<LevelStats>();
	}

	void Update(){

		print(gold.GetInt("_PowerFresnel"));

		if(collectableSelected == true){
			gold.SetInt("_PowerFresnel", 1);
		}else if(collectableSelected == false){
			gold.SetInt("_PowerFresnel", 20);
		}
	

	}

    public void CollectableSelectedTrue()
    {
        collectableSelected = true;
    }

    public void CollectableSelectedFalse()
    {
        collectableSelected = false;
    }

    public void collectObject()
    {
        LevelStatsScript.LevelOneClass.NumberOfCollectalbesCollected = LevelStatsScript.LevelOneClass.NumberOfCollectalbesCollected + 1;
        Destroy(Collectable);
    }
}
