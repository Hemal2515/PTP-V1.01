using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pin : MonoBehaviour
{
    //public Rigidbody2D pinRigidbody2D;
    private int pinSpeed = 5;
    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;
    private Touch touch;

    private float time = 0.01f;
    [SerializeField] private bool clicked;
    Vector2 dir;



    private void Update()
    {
        // Multiple Touch Input
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                // Debug.Log("<color=red>TouchPos: </color>" + touchPos);
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(t.position), Vector2.zero);

                if (t.phase == TouchPhase.Moved || t.phase == TouchPhase.Ended)
                {
                    if (hit && hit.collider.gameObject == gameObject && !GameManager.instances.IsGamePaused)
                    {

                        clicked = true;
                        AudioManager.instances.PullThePin();
                        //dir = (posA.transform.position - posB.transform.position).normalized;
                        //pinRigidbody2D.AddForce(-dir * pinSpeed, ForceMode2D.Impulse);

                    }
                }

            }
        }
    }
    void FixedUpdate()
    {
        if (clicked)
        {
            //The pin slid to the opposite side
            this.transform.position = Vector3.Lerp(posA.position, posB.position, time);
            time += Time.fixedDeltaTime * pinSpeed;
            Invoke("PinDestroy", 1f);
        }
    }


    private void PinDestroy()
    {
        Destroy(this.gameObject);
    }

    //Mouse Input
    private void OnMouseUp()
    {
        if (!GameManager.instances.IsGamePaused)
        {
            clicked = true;
            AudioManager.instances.PullThePin();
        }

    }



}
