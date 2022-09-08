using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;

    bool idle;
    bool book;
    bool phone;
    bool flash;
    void Update()
    {
        if(rb.velocity.magnitude>0) // if is moving
        {
            //direction move player
            anim.SetFloat("directionX",rb.velocity.x); // parameter float is egual to velocity x
            anim.SetFloat("directionY",rb.velocity.y); // parameter float is egual to velocity y

            if (idle == true) // if for not to repeat;
            {
                idle = false;
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", true);
                anim.SetBool("Book", false);
                anim.SetBool("Phone", false);
                anim.SetTrigger("TriggerWalk");
            }

        }
        else // idle
        {
            if (idle == false) // if for not to repeat;
            {
                idle = true;
                anim.SetBool("Idle", true);
                anim.SetBool("Walk", false);
                anim.SetTrigger("TriggerIdle");
            }
        }
    }
}
