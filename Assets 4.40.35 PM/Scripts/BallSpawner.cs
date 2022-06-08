using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject colorBallPrefab;
    public GameObject greyBallPrefab;
    [SerializeField] Transform ballParent;

    public Transform colorBallTransform;
    public Transform greyBallTransform;

    private void Start()
    {
        for (int i = 0; i < LevelManager.instaces.StoreLevel[LevelManager.instaces.currentLevel].colorBallNumber; i++)
        {
            GameObject obj = Instantiate(colorBallPrefab, colorBallTransform.position, Quaternion.identity, ballParent);
            obj.GetComponent<SpriteRenderer>().color = GameManager.instances.color[Random.Range(0, GameManager.instances.color.Count)];
        }

        for (int k = 0; k < LevelManager.instaces.StoreLevel[LevelManager.instaces.currentLevel].grayBallPosition.Count; k++)
        {
            for (int i = 0; i < LevelManager.instaces.StoreLevel[LevelManager.instaces.currentLevel].greyBallNumber[k]; i++)
            {
                Instantiate(greyBallPrefab, LevelManager.instaces.StoreLevel[LevelManager.instaces.currentLevel].grayBallPosition[k].transform.position, Quaternion.identity, ballParent);
            }
        }
        
    }
    
    

}

