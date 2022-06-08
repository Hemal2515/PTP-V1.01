using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombParent;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(bombPrefab, new Vector3(transform.position.x+i,transform.position.y,0), Quaternion.identity,bombParent);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

}
