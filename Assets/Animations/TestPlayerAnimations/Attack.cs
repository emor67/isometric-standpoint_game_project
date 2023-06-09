using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            AttackMove();
        }

        if (Input.GetMouseButtonDown(1))
        {
            BlockMove();
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            DodgeMove();
        }
    }
    



    void AttackMove()
    {
        anim.SetTrigger("Attack");
    }

    void BlockMove()
    {
        anim.SetTrigger("Block");
    }

    void DodgeMove()
    {
        anim.SetTrigger("Dodge");
    }
}
