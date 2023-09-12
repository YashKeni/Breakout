using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuCanvas;
    public bool isPaused;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        AudioListener.pause = true;
        var firstPersonControllerCamera = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        var mouseLook = firstPersonControllerCamera.m_MouseLook;
        mouseLook.SetCursorLock(false);
        firstPersonControllerCamera.enabled = false;
        FindObjectOfType<Weapon>().allowFire = false;
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
        var firstPersonControllerCamera = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        var mouseLook = firstPersonControllerCamera.m_MouseLook;
        mouseLook.SetCursorLock(true);
        firstPersonControllerCamera.enabled = true;
        FindObjectOfType<Weapon>().allowFire = true;
    }
}
