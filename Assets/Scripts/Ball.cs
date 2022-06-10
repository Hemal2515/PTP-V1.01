using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bomb")
        {
            Destroy(this.gameObject);
        }

        if (collision.collider.tag == "BottomWall")
        {
            UIManager.instance.LevelFail();
        }


        //Colorball collides with Greyball, Change the greyball tag and add the ball script in greyball
        if (collision.collider.tag == "GreyBall")
        {
            AudioManager.instances.SingleBallPop();
            collision.collider.gameObject.tag = "ColorBall";
            collision.collider.gameObject.AddComponent<Ball>();
            collision.collider.GetComponent<SpriteRenderer>().color = GameManager.instances.color[Random.Range(0, GameManager.instances.color.Count)];
            //Shaking();
        }


    }



    void Shaking()
    {
        //Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * 10);
        ////newPos.y = transform.position.y;
        //newPos.z = transform.position.z;

        //transform.position = newPos;

        transform.position = new Vector2(Mathf.Sin(Time.time * 0.1f) * 0.1f, 0);
    }
}
