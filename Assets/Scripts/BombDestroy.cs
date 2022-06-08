using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //A bomb collides with a bomb
        if (collision.collider.tag == "Bomb")
        {
            AudioManager.instances.BombBlast();
            Destroy(this.gameObject);
        }

        //The Bomb collides with Colorball and Greyball
        if (collision.collider.tag == "ColorBall" || collision.collider.tag == "GreyBall")
        {
            AudioManager.instances.BombBlast();
            Destroy(this.gameObject);
            UIManager.instance.LevelFail();
        }
    }

}
