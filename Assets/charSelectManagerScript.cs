using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charSelectManagerScript : MonoBehaviour {

    public Text skillContentData;
    public GameObject[] skillCard;

    private bool[] skillData;
    private int skillSum;
    private string[] prefName;

    // Use this for initialization
    void Start () {
        skillData = new bool[7];
        skillSum = 0;
        prefName = new string[4];
        prefName[0] = "skill_0";
        prefName[1] = "skill_1";
        prefName[2] = "skill_2";
        prefName[3] = "skill_3";

        for(int i = 0; i < 4; i++)
        {
            PlayerPrefs.SetInt(prefName[i], -1);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void skillSelect(int num)
    {
        if (skillData[num])
        {
            skillCard[num].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            skillData[num] = false;
            skillSum--;
        }
        else if (skillSum < 4)
        {
            skillCard[num].GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f, 1);
            skillData[num] = true;
            skillSum++;
        }
        skillDataRefresh();
    }

    public void skillDataRefresh()
    {
        string tmp = "";
        for (int i=0;i<skillData.Length; i++)
        {
            if (skillData[i])
            {
                tmp = tmp + "\n" + skillCard[i].name;
            }
        }
        skillContentData.text = tmp;
    }

    public void skillComfirm()
    {
        int j = 0;
        for (int i = 0; i < skillData.Length; i++)
        {
            if (skillData[i])
            {
                PlayerPrefs.SetInt(prefName[j], i);
                j++;
            }
        }
    }
}
