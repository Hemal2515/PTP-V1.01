using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instances;

    public List<Color> color = new List<Color>();

    public bool IsGamePaused = true;

    // Start is called before the first frame update
    void Start()
    {
        if(instances != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instances = this;
        }
    }

    
}
