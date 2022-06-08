using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public LevelInformation levelInformation;
    public GameObject colorBallPrefab;
    public GameObject greyBallPrefab;
    [SerializeField] Transform ballParent;

    public Transform colorBallTransform;
    public Transform greyBallTransform;

    private void Start()
    {
        //Spawn colorBall
        for (int i = 0; i < levelInformation.colorBallNumber; i++)
        {
            GameObject obj = Instantiate(colorBallPrefab, colorBallTransform.position, Quaternion.identity, ballParent);
            obj.GetComponent<SpriteRenderer>().color = GameManager.instances.color[Random.Range(0, GameManager.instances.color.Count)];
        }

        //Spawn Greyball
        for (int k = 0; k < levelInformation.greyBallPosition.Count; k++)
        {
            for (int i = 0; i < levelInformation.greyBallNumber[k]; i++)
            {
                Instantiate(greyBallPrefab, levelInformation.greyBallPosition[k].transform.position, Quaternion.identity, ballParent);
            }
        }

    }



}

