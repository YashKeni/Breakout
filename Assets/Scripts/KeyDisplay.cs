using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class KeyDisplay : MonoBehaviour
{
    TextMeshProUGUI keyText;
    Key key;
    // Start is called before the first frame update
    void Start()
    {
        keyText = GetComponent<TextMeshProUGUI>();
        key = FindObjectOfType<Key>();
    }

    // Update is called once per frame
    void Update()
    {
        keyText.text = ": " + key.GetCurrentKeyValue().ToString();
    }
}
