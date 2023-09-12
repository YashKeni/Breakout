using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBarrier : MonoBehaviour
{
    Timer timer;

    [SerializeField] GameObject levelPassCanvas;
    [SerializeField] int levelPassDelay;

    private void Start() 
    {
        timer = FindObjectOfType<Timer>();
        levelPassCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Finish")
        {
            // timer.
            timer.enabled = false;
            float time = timer.timeValue;
            Debug.Log(Mathf.RoundToInt(time));
            StartCoroutine(WaitForLevelPass());
        }    
    }

    IEnumerator WaitForLevelPass()
    {
        yield return new WaitForSeconds(levelPassDelay);
        ActivatePassCanvas();
        
    }

    public void ActivatePassCanvas()
    {
        levelPassCanvas.SetActive(true);
        var firstPersonControllerCamera = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        var mouseLook = firstPersonControllerCamera.m_MouseLook;
        mouseLook.SetCursorLock(false);
        firstPersonControllerCamera.enabled = false;
        FindObjectOfType<Weapon>().allowFire = false;
    }
}
