using UnityEngine;

public class SpikeBehaviour : MonoBehaviour
{
    Transform player;
    Animator obstacleAnimator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        obstacleAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.position.z < player.position.z - 5)
        {
            gameObject.SetActive(false);
        }
    }        
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            PlayerController playerC = player.GetComponent<PlayerController>();
            ParticleSystem bloodEffect = player.transform.Find("BloodEffect").GetComponent<ParticleSystem>();

            EventManager.onPlayerDied();

            if (obstacleAnimator != null) 
            {
                obstacleAnimator.enabled = false;
            }

            bloodEffect.Play();
            playerC.ResetCamFollow();
            playerC.StartAnimationGladiator("DyingTrigger");
        }
    }
}
