using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 90f;
    public TextMeshProUGUI timeText;
    [SerializeField] Canvas timeOverGameOverCanvas;
    bool timeOver = false;

    private void Start() 
    {
        timeOverGameOverCanvas.enabled = false;    
    }

    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        DisplayTime(timeValue);
        if(timeValue == 0 && !timeOver)
        {
            timeOver = true;
            Debug.Log("Time Over Game Over");
            timeOverGameOverCanvas.enabled = true;
            FindObjectOfType<WeaponSwitcher>().enabled = false;
            var firstPersonControllerCamera = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            var mouseLook = firstPersonControllerCamera.m_MouseLook;
            mouseLook.SetCursorLock(false);
            firstPersonControllerCamera.enabled = false;
            FindObjectOfType<Weapon>().allowFire = false;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
