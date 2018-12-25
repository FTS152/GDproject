using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillManager : MonoBehaviour {

    [Tooltip("Player")] public GameObject leader;
    [Tooltip("Skill Card Slots")] public GameObject[] cardSlot;
    [Tooltip("Skill Animation Prefab")] public GameObject[] skillAnimation;
    [Tooltip("audio clips")] public AudioClip[] audioClips;
    [Tooltip("layer of a enemy fighters")] public LayerMask enemyLayer;

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
        fixedLeaderPos.z = 30;
        tmpSkill = Instantiate(skillAnimation[0], fixedLeaderPos, Quaternion.identity);
        tmpSkill.transform.localScale = new Vector3(3, 3, 1);
        Destroy(tmpSkill, 1);
        tmpSkill = Instantiate(skillAnimation[0], fixedLeaderPos, new Quaternion(0, 180, 0, 0));
        tmpSkill.transform.localScale = new Vector3(3, 3, 1);
        Destroy(tmpSkill, 1);

        Collider2D[] enemies = Physics2D.OverlapCircleAll(leader.transform.position, 250, enemyLayer);
        if (enemies.Length > 0) // if there are receivers of a punch
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (System.Math.Abs(enemies[i].transform.position.y - leader.transform.position.y) < 30)
                {
                    enemies[i].transform.gameObject.GetComponent<fighterScript>().getAttacked(true, 150, false, 1, new Vector2(50, 50)); // sends attack information to a receiver
                }
            }
        }
        aus.PlayOneShot(audioClips[0]);
    }

    void explosion()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.z = 30;
        tmpSkill = Instantiate(skillAnimation[1], fixedLeaderPos, Quaternion.identity);
        tmpSkill.transform.localScale = new Vector3(2, 2, 1);
        Destroy(tmpSkill, 0.8f);

        Collider2D[] enemies = Physics2D.OverlapCircleAll(leader.transform.position, 100, enemyLayer);
        if (enemies.Length > 0) // if there are receivers of a punch
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].transform.gameObject.GetComponent<fighterScript>().getAttacked(true, 100, false, 1, new Vector2(50, 50)); // sends attack information to a receiver
            }
        }
        aus.PlayOneShot(audioClips[1]);
    }

    void heal()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.y -= 10;
        fixedLeaderPos.z = 30;
        tmpSkill = Instantiate(skillAnimation[2], fixedLeaderPos, Quaternion.identity);
        tmpSkill.transform.localScale = new Vector3(2, 2, 1);
        tmpSkill.transform.parent = leader.transform;
        leader.GetComponent<fighterScript>().applyHealth(20);
        Destroy(tmpSkill, 1);
        aus.PlayOneShot(audioClips[2]);
    }

    void ice()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.x += 10;
        fixedLeaderPos.z = 30;
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
        //leader.GetComponent<fighterScript>().attack();
        aus.PlayOneShot(audioClips[3]);
    }
}
