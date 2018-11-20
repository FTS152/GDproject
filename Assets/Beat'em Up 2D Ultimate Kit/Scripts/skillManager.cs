using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillManager : MonoBehaviour {

    [Tooltip("Player")] public GameObject leader;
    [Tooltip("Skill Card Slots")] public GameObject[] cardSlot;
    [Tooltip("Skill Animation Prefab")] public GameObject[] skillAnimation;

    GameObject tmpSkill;
    float time;

    enum skillType
    {
        dash,
        explosion,
        heal
    }

	// Use this for initialization
	void Start () {
        time = 0;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}

    public void useSkill(int type)
    {
        switch (type)
        {
            case 0:
                dash();
                break;
            case 1:
                explosion();
                break;
            case 2:
                heal();
                break;
        }
    }

    void dash()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.x += 20;
        tmpSkill = Instantiate(skillAnimation[0], fixedLeaderPos, Quaternion.identity);
    }

    void explosion()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.x -= 10;
        tmpSkill = Instantiate(skillAnimation[1], fixedLeaderPos, Quaternion.identity);
    }

    void heal()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.x -= 10;
        fixedLeaderPos.y -= 5;
        tmpSkill = Instantiate(skillAnimation[2], fixedLeaderPos, Quaternion.identity);
        time = 0;
        while (time < 1350) {};
        tmpSkill.SetActive(false);
    }

}
