using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float xSpeed = 4f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3f;

    [SerializeField]float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField]float positionYawFactor = -5f;
    [SerializeField]float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool IsControllerEnabled = true;

    [SerializeField] GameObject[] guns;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsControllerEnabled == true)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
       
    }

    void OnPlayerDeath()
    {
        IsControllerEnabled = false;
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.position.y * positionPitchFactor ;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlPitchFactor;


        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xoffset = horizontalThrow * xSpeed * Time.deltaTime;

        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yoffset = verticalThrow * xSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xoffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yoffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire1"))
        {
            SetGunActive(true);
        }

        else
        {
            SetGunActive(false);
        }
    }


    private void SetGunActive(bool isactive)
    {
        foreach (GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isactive;

        }
    }

}
