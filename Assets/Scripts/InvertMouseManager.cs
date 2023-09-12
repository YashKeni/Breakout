using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvertMouseManager : MonoBehaviour
{
    public GameObject toggler;
    private void Start() 
    {
        print("Invert mouse status: "+toggler.GetComponent<Toggle>().isOn);
    }
    public void InvertMouse(bool tog)
    {
        Debug.Log("Invert mouse status: "+tog);
        var firstPersonControllerCamera = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        var mouseLook = firstPersonControllerCamera.m_MouseLook;
        mouseLook.SetInvertMouse(); 
    }
}
