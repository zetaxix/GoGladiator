using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] float speed;
    [SerializeField] float laneDistance;
    [SerializeField] float laneSwitchDuration = 0.2f;
    int currentLane = 0; // -1: Sol, 0: Orta, 1: Sað

    [Header("Jump")]
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [Header("Challange")]
    [SerializeField] float challangeTime;
    private float timeCount;

    private Rigidbody rb;
    private bool isGrounded;

    private CameraFollow camFollow;
    private float startCamPosZ;

    private ParticleSystem runEffect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        camFollow = Camera.main.GetComponent<CameraFollow>();
        runEffect = transform.Find("RunEffect").GetComponent<ParticleSystem>();

        startCamPosZ = camFollow.offset.z;
    }

    private void Update()
    {
        if (GameManager.Instance.GameOver) { return; }

        StartAnimationGladiator("RunTrigger");
        GetRunEffect();

        MoveForward();
        CheckGround();

        // Zamanla oyuncunun hýzý artsýn
        AutomaticIncreaseSpeed();
    }

    void GetRunEffect()
    {
        if (isGrounded) 
        {
            runEffect.gameObject.SetActive(true);
            runEffect.Play(); 
        }
    }

    public void StartAnimationGladiator(string TriggerText)
    {
        Animator animator = transform.Find("Gladiator").GetComponent<Animator>();
        animator.SetTrigger(TriggerText);
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void ResetCamFollow()
    {
        camFollow.offset.z = startCamPosZ;
    }

    public void AutomaticIncreaseSpeed()
    {
        timeCount += Time.deltaTime;

        if (timeCount > challangeTime)
        {   speed += 1;
            camFollow.offset.z += 0.08f;
            timeCount = 0; }
    }

    public void ChangeLane(int direction)
    {
        int targetLane = Mathf.Clamp(direction + currentLane, -1, 1);
        if (targetLane == currentLane) return;

        currentLane = targetLane;

        float targetX = currentLane * laneDistance;

        transform.DOMoveX(targetX, laneSwitchDuration).SetEase(Ease.OutQuad);
    }

    public void Jump()
    {
        if (isGrounded) 
        {
            runEffect.Stop();
            StartAnimationGladiator("JumpTrigger");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
