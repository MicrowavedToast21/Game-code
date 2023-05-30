using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            thrusterForce();
        }
        else 
        {
            StopThrusting();
        }
    }
    
    void ProcessRotation()
    {
       if (Input.GetKey(KeyCode.A))
       {
           leftThrusterRotation();
       }
       else if (Input.GetKey(KeyCode.D))
       {
           rightThrusterRotation();
       }
       else
       {
        StopThrusterParticles();
       }
    }

    void thrusterForce()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            if (!mainEngineParticles.isPlaying) 
            {
                mainEngineParticles.Play();
            }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    void StopThrusterParticles()
    {
        rightThrusterParticles.Stop();
        leftThrusterParticles.Stop();
    }

    void leftThrusterRotation()
    {
        applyRotation(rotationThrust);
           if (!leftThrusterParticles.isPlaying)
           {
            leftThrusterParticles.Play();
           }
    }

    void rightThrusterRotation()
    {
      applyRotation(-rotationThrust);
           if (!rightThrusterParticles.isPlaying)
           {
            rightThrusterParticles.Play();
           }   
    }

    private void applyRotation(float rotationThisFrame) 
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward* rotationThisFrame* Time.deltaTime);
        rb.freezeRotation = false;
    }
}