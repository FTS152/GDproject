using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charSelectManagerScript : MonoBehaviour {

    public Text skillContentData;
    public GameObject[] skillCard;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void skillSelect(GameObject skillCard)
    {
        skillContentData.text = skillContentData.text + "\n" + skillCard.name;
        skillCard.GetComponent<Button>().interactable = false;
    }
}
