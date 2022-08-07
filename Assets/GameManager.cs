using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public NPC npc;
    public Text npcText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YukariGit()
    {
        npc.directionVector = Vector3.up;
        npc.konusmaVar = true;
        npc.playernpcTemas = false;
        npc.GetComponent<CircleCollider2D>().enabled = false;
        
        
    }

    public void AssagiGit()
    {
        npc.directionVector = Vector3.down;
        npc.konusmaVar = true;
        npc.playernpcTemas = false;
        npc.GetComponent<CircleCollider2D>().enabled = false;

    }

    public void SagaGit()
    {
        npc.directionVector = Vector3.right;
        npc.konusmaVar = true;
        npc.playernpcTemas = false;
        npc.GetComponent<CircleCollider2D>().enabled = false;

    }

    public void SolaGit()
    {
        npc.directionVector = Vector3.left;
        npc.konusmaVar = true;
        npc.playernpcTemas = false;
        npc.GetComponent<CircleCollider2D>().enabled = false;

    }
}
