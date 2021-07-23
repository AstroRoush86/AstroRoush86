using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerActionManager : MonoBehaviour
{
    private GameObject targeted;
    private int swapInt;
    private int actionInt;
    public GameObject[] UIobjs;
    public cardAction[] cardactions;
    public GameObject moveLight;
    private List<GameObject> actionEffects = new List<GameObject>();
    public List<GameObject> myBionicle = new List<GameObject>();

    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            myBionicle.Add(gameObject.transform.GetChild(i).gameObject);
        }
        actionEffects.Add(moveLight);

        for (int i = 0; i < cardactions.Length; i++)
        {
            if (cardactions.Length == 0)
                Debug.Log("shut up");
            else
            {
                Debug.Log(cardactions[i].title);
            }
        }

        if(targeted == null)
        {
            targeted = myBionicle[swapInt % 2];
            GameObject.Find("Camera").transform.LookAt(myBionicle[swapInt % 2].transform);
            swapInt += 1;
        }
    }

    //opens up UI to select card
    public void card()
    {
        Debug.Log("card");
        for (int i = 0; i < UIobjs.Length; i++)
        {
            if (i == 0)
            {
                
            }
            else
                UIobjs[i].SetActive(false);
        }
        UIobjs[4].SetActive(true);
        UIobjs[5].SetActive(true);
    }

    //opens up UI to move Bionicle
    public void move()
    {
        moveLight.SetActive(true);
        Debug.Log("move"); 
        for (int i = 0; i < UIobjs.Length; i++)
        {
            if (i == 1)
            {

            }
            else
                UIobjs[i].SetActive(false);
        }
        UIobjs[4].SetActive(true);
        UIobjs[5].SetActive(true);
    }

    //opens up UI to Shoo
    public void shoot()
    {
        Debug.Log("shoot");
        for (int i = 0; i < UIobjs.Length; i++)
        {
            if (i == 2)
            {

            }
            else
                UIobjs[i].SetActive(false);
        }
        UIobjs[4].SetActive(true);
        UIobjs[5].SetActive(true);
    }

    //swaps between each Bionicle
    public void swap()
    {
        Debug.Log("swap");
        GameObject.Find("Camera").transform.LookAt(myBionicle[swapInt%2].transform);
        targeted = myBionicle[swapInt % 2];
        swapInt += 1;
        if (targeted.GetComponent<bionicleInfo>().ammo == 0)
        {
            UIobjs[2].SetActive(false);
        }
        else
        {
            UIobjs[2].SetActive(true);
        }
    }

    //executes action
    public void execute()
    {
        Debug.Log("execute");
    }

    //returns to main UI hub
    public void Return()
    {
        Debug.Log("return");
        for (int i = 0; i < 4; i++)
        {
            UIobjs[i].SetActive(true);
        }
        UIobjs[5].SetActive(false);
        UIobjs[4].SetActive(false);
        for (int i = 0; i < actionEffects.Count; i++)
        {
            actionEffects[i].SetActive(false);
        }
    }

    //attacks selected enemy
    public void attack()
    {
        Debug.Log("attack");
    }

    //loots selected lootable object
    public void loot()
    {
        Debug.Log("loot");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("lootable"))
        {
            UIobjs[7].SetActive(true);
        }
        if (other.CompareTag("attackable"))
        {
            UIobjs[6].SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("lootable"))
        {
            UIobjs[7].SetActive(false);
        }
        if (other.CompareTag("attackable"))
        {
            UIobjs[6].SetActive(false);
        }
    }
}
