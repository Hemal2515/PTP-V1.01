using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bomb")
        {
            AudioManager.instances.BombBlast();
            Destroy(this.gameObject);
        }
        if(collision.collider.tag == "ColorBall")
        {
            AudioManager.instances.BombBlast();
            Destroy(this.gameObject);
            UIManager.instance.LevelFail();
        }
    }
    
}
