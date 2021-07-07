using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]    Paddle paddle1;
    [SerializeField]    float pushX = 2f;
    [SerializeField]    float pushY = 10f;
    [SerializeField]    AudioClip[] BallSounds;

    //States
    bool hasStarted = false; 
    Vector3 DifferenceBallToPaddle;
    
    //Cached Component References
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        DifferenceBallToPaddle = this.transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallPaddle();
            LaunchOnLeftClick();
        }
       
    }

    void LockBallPaddle()
    {
        //Debug.Log(DifferenceBallToPaddle);
        Vector3 PaddlePosition = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, paddle1.transform.position.z);
        this.transform.position = PaddlePosition + DifferenceBallToPaddle;
    }
    void LaunchOnLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(pushX, pushY);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = BallSounds[UnityEngine.Random.Range(0, BallSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
        
    }

}
