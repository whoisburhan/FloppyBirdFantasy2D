using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GS.FloppyBirdFantasy2D
{
    public class BirdController : MonoBehaviour
    {
        [SerializeField] private float jumpSpeed = 200f;
        private Rigidbody2D rb2d;
        private bool jump = false;
        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (GameManager.Instance.IsPlaying)
            {
                TouchInput();
                ButtonInput();
            }
        }

        private void FixedUpdate()
        {
            if (jump)
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(Vector2.up * jumpSpeed);
                jump = false;
            }
        }

        private void TouchInput()
        {
            if (Input.touchCount > 0)
            {
                Touch[] touches = Input.touches;
                foreach (Touch touch in touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        jump = true;
                    }
                }
            }
        }

        private void ButtonInput()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Obstacles"))
            {
                Debug.Log("PILLER HIT");
            }
        }
    }
}