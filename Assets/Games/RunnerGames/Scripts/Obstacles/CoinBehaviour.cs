using DG.Tweening;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        if (transform.position.z < player.transform.position.z - 5 )
        {
            gameObject.SetActive( false );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            EventManager.OnPlayerColected();
        }
    }
}
