using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillManager : MonoBehaviour {

    [Tooltip("Player")] public GameObject leader;
    [Tooltip("Skill Card Slots")] public GameObject[] cardSlot;
    [Tooltip("Skill Card Prefab")] public GameObject[] skillCardPrefab;
    [Tooltip("Skill Animation Prefab")] public GameObject[] skillAnimation;
    [Tooltip("Extra Animation Prefab")] public GameObject[] extraSkillAnimation;
    [Tooltip("audio clips")] public AudioClip[] audioClips;
    [Tooltip("layer of a enemy fighters")] public LayerMask enemyLayer;

    AudioSource aus;
    GameObject tmpSkill;
    GameObject[] skillCard;
    int[] skillCode;

    enum skillType
    {
        dash,
        explosion,
        heal,
        ice,
        light,
        slash,
        teleport
    }

	// Use this for initialization
	void Start () {
        aus = GetComponent<AudioSource>();
        skillCard = new GameObject[4];
        skillCode = new int[4];

        if (PlayerPrefs.GetInt("skill_0") != null)
        {
            skillCode[0] = PlayerPrefs.GetInt("skill_0");
            skillCode[1] = PlayerPrefs.GetInt("skill_1");
            skillCode[2] = PlayerPrefs.GetInt("skill_2");
            skillCode[3] = PlayerPrefs.GetInt("skill_3");
        }
        else
        {
            skillCode[0] = -1;
            skillCode[1] = -1;
            skillCode[2] = -1;
            skillCode[3] = -1;
        }

        for (int i = 0; i < 4; i++)
        {
            if (skillCode[i] >= 0)
            {
                skillCard[i] = Instantiate(skillCardPrefab[skillCode[i]], cardSlot[i].transform.position, Quaternion.identity);
                skillCard[i].transform.localScale = new Vector3(1.6f, 1.6f, 1);
                skillCard[i].transform.parent = cardSlot[i].transform;
            }
        }
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
            case 4:
                light();
                break;
            case 5:
                slash();
                break;
            case 6:
                teleport();
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
        fixedLeaderPos.z = 30;
        fixedLeaderPos.x += 50;
        tmpSkill = Instantiate(skillAnimation[3], fixedLeaderPos, new Quaternion(0, 180, 0, 0));
        Destroy(tmpSkill, 0.2f);
       // fixedLeaderPos.x -= 10;
        fixedLeaderPos.y += 15;
        tmpSkill = Instantiate(skillAnimation[3], fixedLeaderPos, Quaternion.identity);
        Destroy(tmpSkill, 0.2f);
       // fixedLeaderPos.x -= 10;
        fixedLeaderPos.y += 15;
        tmpSkill = Instantiate(skillAnimation[3], fixedLeaderPos, new Quaternion(0, 180, 0, 0));
        Destroy(tmpSkill, 0.2f);
        fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.z = 30;
        fixedLeaderPos.x -= 50;
        tmpSkill = Instantiate(skillAnimation[3], fixedLeaderPos, Quaternion.identity);
        Destroy(tmpSkill, 0.2f);
        //fixedLeaderPos.x += 10;
        fixedLeaderPos.y += 15;
        tmpSkill = Instantiate(skillAnimation[3], fixedLeaderPos, new Quaternion(0, 180, 0, 0));
        Destroy(tmpSkill, 0.2f);
        //fixedLeaderPos.x += 10;
        fixedLeaderPos.y += 15;
        tmpSkill = Instantiate(skillAnimation[3], fixedLeaderPos, Quaternion.identity);
        Destroy(tmpSkill, 0.2f);

        Collider2D[] enemies = Physics2D.OverlapCircleAll(leader.transform.position, 60, enemyLayer);
        if (enemies.Length > 0) // if there are receivers of a punch
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].transform.gameObject.GetComponent<fighterScript>().getAttacked(true, 120, false, 1, new Vector2(50, 50)); // sends attack information to a receiver
            }
        }
        aus.PlayOneShot(audioClips[3]);
    }

    void light()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        //fixedLeaderPos.y -= 10;
        fixedLeaderPos.z = 30;
        tmpSkill = Instantiate(skillAnimation[4], fixedLeaderPos, Quaternion.identity);
        tmpSkill.transform.localScale = new Vector3(3, 1, 1);
        tmpSkill.transform.parent = leader.transform;
        Destroy(tmpSkill, 1.1f);

        Collider2D[] enemies = Physics2D.OverlapCircleAll(leader.transform.position, 50, enemyLayer);
        if (enemies.Length > 0) // if there are receivers of a punch
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].transform.gameObject.GetComponent<fighterScript>().getAttacked(true, 150, false, 1, new Vector2(50, 50)); // sends attack information to a receiver
            }
        }
        aus.PlayOneShot(audioClips[4]);
    }

    void slash()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        //fixedLeaderPos.y -= 10;
        fixedLeaderPos.z = 30;
        tmpSkill = Instantiate(skillAnimation[5], fixedLeaderPos, Quaternion.identity);
        tmpSkill.transform.localScale = new Vector3(3, 2, 1);
        tmpSkill.transform.parent = leader.transform;
        Destroy(tmpSkill, 1.1f);

        Collider2D[] enemies = Physics2D.OverlapCircleAll(leader.transform.position, 95, enemyLayer);
        if (enemies.Length > 0) // if there are receivers of a punch
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].transform.gameObject.GetComponent<fighterScript>().getAttacked(true, 100, false, 1, new Vector2(50, 50)); // sends attack information to a receiver
            }
        }
        aus.PlayOneShot(audioClips[5]);
    }

    void teleport()
    {
        Vector3 fixedLeaderPos = leader.transform.position;
        fixedLeaderPos.z = 30;
        tmpSkill = Instantiate(skillAnimation[6], fixedLeaderPos, Quaternion.identity);
        tmpSkill.transform.localScale = new Vector3(2, 1, 1);
        tmpSkill.transform.parent = leader.transform;
        Destroy(tmpSkill, 0.3f);
        aus.PlayOneShot(audioClips[6]);
    }
}
