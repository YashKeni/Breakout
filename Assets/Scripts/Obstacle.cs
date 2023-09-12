using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Energy energySlot;
    [SerializeField] public int energyRequired;  
    [SerializeField] float duration = 2f;
    public Vector3 endPos;
    private Vector3 startPos;
    private float elapsedTime;
    public bool isNear;
    public bool readyToMove;
    public bool objMoved;
    Player player;
    Obstacle obs;
    AudioSource movingSound;
    [SerializeField] GameObject notEnoughEnergyText;

    void Start()
    {
        obs = GetComponent<Obstacle>();
        movingSound = GetComponent<AudioSource>();
        startPos = transform.position;
        readyToMove = false;
        notEnoughEnergyText.SetActive(false);
        objMoved = false;
    }

    void Update()
    {
        if(readyToMove)
        {
            SlideObject();
        }
    }

    void SlideObject()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / duration;
        transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, percentageComplete));
        if(gameObject.transform.position == endPos)
        {
            isNear = false;
            readyToMove = false;
            if(energySlot.GetCurrentEnergy() >= energyRequired)
            {
                FindObjectOfType<Player>().UseEnergy(energyRequired);
                objMoved = true;
                notEnoughEnergyText.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(
            other.gameObject.tag == "Player" && 
            gameObject.tag == "Obstacle" && 
            Input.GetKeyDown(KeyCode.E) &&
            energySlot.GetCurrentEnergy() >= energyRequired &&
            !objMoved)
        {
            EnoughEnergy();
        }
        else if(
            other.gameObject.tag == "Player" && 
            gameObject.tag == "Obstacle" && 
            Input.GetKeyDown(KeyCode.E) &&
            energySlot.GetCurrentEnergy() < energyRequired &&
            !objMoved)
        {
            NotEnoughEnergy();
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        isNear = true;    
    }
    private void OnTriggerExit(Collider other) 
    {
        isNear = false;    
    }

    void EnoughEnergy()
    {
        movingSound.Play();
        readyToMove = true;
    }

    void NotEnoughEnergy()
    {
        Debug.Log("Not Enough Energy");
        StartCoroutine(ShowNotMoveableText());
    }

    IEnumerator ShowNotMoveableText()
    {
        notEnoughEnergyText.SetActive(true);
        yield return new WaitForSeconds(3f);
        notEnoughEnergyText.SetActive(false);
    }
}
