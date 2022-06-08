using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public LevelInformation levelInformation;
    public GameObject bombPrefab;
    public Transform bombParent;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levelInformation.bombNumber; i++)
        {
            Instantiate(bombPrefab, levelInformation.bombPosition[i].transform.position, Quaternion.identity, bombParent);

        }
    }




}
