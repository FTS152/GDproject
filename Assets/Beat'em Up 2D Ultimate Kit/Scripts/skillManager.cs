using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillManager : MonoBehaviour {

    [Tooltip("Player")] public GameObject leader;
    [Tooltip("Skill Card Slots")] public GameObject[] cardSlot;
    [Tooltip("Skill Animation Prefab")] public GameObject[] skillAnimation;

    GameObject tmpSkill;

    enum skillType
    {
        dash,
        explosion,
        heal
    }

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
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
        Destroy(tmpSkill, 1);
    }

    void explosion()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.x -= 10;
        tmpSkill = Instantiate(skillAnimation[1], fixedLeaderPos, Quaternion.identity);
        Destroy(tmpSkill, 1);
    }

    void heal()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.x -= 10;
        fixedLeaderPos.y -= 5;
        tmpSkill = Instantiate(skillAnimation[2], fixedLeaderPos, Quaternion.identity);
        Destroy(tmpSkill, 1);
    }

}
