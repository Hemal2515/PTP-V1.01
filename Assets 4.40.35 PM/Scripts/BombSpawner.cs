using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombParent;
    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < LevelManager.instaces.StoreLevel[LevelManager.instaces.currentLevel].bombNumber; i++)
        {
            Instantiate(bombPrefab, LevelManager.instaces.StoreLevel[LevelManager.instaces.currentLevel].bombPosition[i].transform.position, Quaternion.identity,bombParent);
            
        }
    }

    
    

}
