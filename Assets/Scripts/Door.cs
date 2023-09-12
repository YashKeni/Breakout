using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Key key;
    [SerializeField] int keyRequired;
    public bool isNear;
    public bool isOpen;
    public bool isExitDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isNear && !isOpen  && isExitDoor == false && Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
        }

        else if(isNear && isOpen  && isExitDoor == false && Input.GetKeyDown(KeyCode.E))
        {
            CloseDoor();
        }

        else if(isNear && !isOpen && isExitDoor && Input.GetKeyDown(KeyCode.E))
        {
            if(key.GetCurrentKeyValue() >= keyRequired)
            {
                FindObjectOfType<Player>().UseKey(keyRequired);
                OpenDoor();
            }
            
        }

        else if(isNear && isOpen && isExitDoor && Input.GetKeyDown(KeyCode.E))
        {
            CloseDoor();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            isNear = true;
        }   
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            isNear = false;
        }   
    }

    void OpenDoor()
    {
        GetComponent<Animator>().SetTrigger("open");
        isOpen = true;
    }

    void CloseDoor()
    {
        GetComponent<Animator>().SetTrigger("close");
        isOpen = false;
    }

}
