using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] int diff;
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randowmFactor = 0.1f;

    // state
    Vector2 paddleToBallVector;
    bool hastarted = false;

    // Cashed component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Use this for initialization
    void Start ()
    {
        paddleToBallVector.y = transform.position.y - paddle1.transform.position.y;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hastarted)
        {
            LockBallToPaddle();

            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {

        if (Input.GetMouseButtonDown(0))
        {
            hastarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randowmFactor), 
            Random.Range(0f, randowmFactor));
        if (hastarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }       
    }
}
