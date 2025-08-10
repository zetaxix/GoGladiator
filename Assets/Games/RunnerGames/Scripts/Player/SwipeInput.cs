using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private float swipeThreshold = 50;

    [SerializeField] private PlayerController player; // PlayerController scriptini referans alacaðýz

    [SerializeField] AudioSource jumpSound;

    private void Update()
    {
        if (GameManager.Instance.GameOver) { return; }

        TouchInput();
    }

    void TouchInput()
    {
        if (GameManager.Instance.GameOver) { return; }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Ýlk parmak dokunuþu

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;
                    DetectSwipe();
                    break;
            }
        }
    }

    void DetectSwipe()
    {
        Vector2 swipe = endTouchPosition - startTouchPosition;

        if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y)) // Yatay swipe kontrolü
        {
            if (swipe.x > swipeThreshold) // saða kaydýrma
            {
                player.ChangeLane(1);
            }
            else if (swipe.x < -swipeThreshold) // sola kaydýrma
            {
                player.ChangeLane(-1);
            }
        }else if (swipe.y > swipeThreshold) // Zýplama iþlemi
        {
            player.Jump();
            jumpSound.Play();
        }  
    }
}
