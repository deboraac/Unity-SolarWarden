using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour {

    public GameObject towerPrefab;
    private GameObject tower;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool naoExisteUmaTower()
    {
        return tower == null;
    }

    void OnMouseUp()
    {
  
        if (naoExisteUmaTower())
        {
            tower = Instantiate(towerPrefab, transform.position, Quaternion.identity);      
        }
        else if (canUpgradeTower())
        {
            tower.GetComponent<TowerData>().increaseLevel();
        }
    }

    private bool canUpgradeTower()
    {
        if (tower != null)
        {
            TowerData towerData = tower.GetComponent<TowerData>();
            TowerLevel nextLevel = towerData.getNextLevel();
            if (nextLevel != null)
            {
                return true;
            }
        }
        return false;
    }

}
