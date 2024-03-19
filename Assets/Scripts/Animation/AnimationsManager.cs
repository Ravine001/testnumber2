using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    public Animator anim;
    public bool isCantering;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            anim.SetBool("IsAiming", true);
            anim.SetBool("IsCantering", false);
        }
        else if (!Input.GetKey(KeyCode.Mouse1)){
            anim.SetBool("IsAiming", false);
            anim.SetBool("IsCantering", false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isCantering)
            {
                
                anim.SetBool("IsCantering", false);
                anim.SetBool("IsAiming", false);
                isCantering = false;
            }
            else if (!isCantering)
            {
                
                anim.SetBool("IsCantering", true);
                anim.SetBool("IsAiming", false);
                isCantering = true;
            }
            
        }
        
    }
}
