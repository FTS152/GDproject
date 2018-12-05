using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillManager : MonoBehaviour {

    [Tooltip("Player")] public GameObject leader;
    [Tooltip("Skill Card Slots")] public GameObject[] cardSlot;
    [Tooltip("Skill Animation Prefab")] public GameObject[] skillAnimation;
    [Tooltip("audio clips")] public AudioClip[] audioClips;

    AudioSource aus;
    GameObject tmpSkill;

    enum skillType
    {
        dash,
        explosion,
        heal,
        ice
    }

	// Use this for initialization
	void Start () {
        aus = GetComponent<AudioSource>();
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
            case 3:
                ice();
                break;
        }
    }

    void dash()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.x += 20;
        tmpSkill = Instantiate(skillAnimation[0], fixedLeaderPos, Quaternion.identity);
        Destroy(tmpSkill, 1);
        leader.GetComponent<fighterScript>().attack();
        aus.PlayOneShot(audioClips[0]);
    }

    void explosion()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.x -= 10;
        tmpSkill = Instantiate(skillAnimation[1], fixedLeaderPos, Quaternion.identity);
        Destroy(tmpSkill, 0.8f);
        leader.GetComponent<fighterScript>().attack();
        aus.PlayOneShot(audioClips[1]);
    }

    void heal()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.x -= 10;
        fixedLeaderPos.y -= 5;
        tmpSkill = Instantiate(skillAnimation[2], fixedLeaderPos, Quaternion.identity);
        tmpSkill.transform.parent = leader.transform;
        leader.GetComponent<fighterScript>().applyHealth(20);
        Destroy(tmpSkill, 1);
        aus.PlayOneShot(audioClips[2]);
    }

    void ice()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.x += 10;
        tmpSkill = Instantiate(skillAnimation[3], fixedLeaderPos, Quaternion.identity);
        Destroy(tmpSkill, 0.2f);
        fixedLeaderPos.x -= 10;
        fixedLeaderPos.y += 10;
        tmpSkill = Instantiate(skillAnimation[3], fixedLeaderPos, Quaternion.identity);
        Destroy(tmpSkill, 0.2f);
        fixedLeaderPos.y -= 35;
        tmpSkill = Instantiate(skillAnimation[3], fixedLeaderPos, Quaternion.identity);
        Destroy(tmpSkill, 0.2f);
        fixedLeaderPos.x -= 10;
        fixedLeaderPos.y -= 25;
        tmpSkill = Instantiate(skillAnimation[3], fixedLeaderPos, Quaternion.identity);
        Destroy(tmpSkill, 0.2f);
        fixedLeaderPos.y += 70;
        tmpSkill = Instantiate(skillAnimation[3], fixedLeaderPos, Quaternion.identity);
        Destroy(tmpSkill, 0.2f);
        leader.GetComponent<fighterScript>().attack();
        aus.PlayOneShot(audioClips[3]);
    }
}
