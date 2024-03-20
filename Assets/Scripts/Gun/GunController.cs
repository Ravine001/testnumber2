using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform g_Default;
    public Transform g_HoldUp;
    public Transform g_AimPos;
    public Transform g_WeaponHolder;

    public bool g_defaultVal;
    public bool g_holdingUp;
    public bool g_Aiming;

    public float sp_DefToHold;
    public float sp_HoldToDef;
    public float sp_HoldToAim;

    [SerializeField] private KeyCode HoldUp;
    [SerializeField] private KeyCode Aim;

    public PlayerMovementAdvanced p_Controller;

    private void Start()
    {
        // starts off at default positioning.
        g_WeaponHolder.localRotation = Quaternion.Euler(g_Default.localRotation.x, g_Default.localRotation.y, g_Default.localRotation.z);

        // changes bools to correct ones
        g_defaultVal = true;
        g_holdingUp = false;
        g_Aiming = false;
    }   

    private void Update()
    {
        // Updates voids

        inputDetection();
        holsterDetection();

    }

    private void inputDetection()
    {
        if (Input.GetKeyDown(HoldUp))
        {
            if (g_holdingUp)
            {
                g_defaultVal = true;
                g_holdingUp = false;
                g_Aiming = false;
                
            }
            else if (!g_holdingUp)
            {
                g_defaultVal = false;
                g_holdingUp = true;
                g_Aiming = false;
            }
            
            




            

        }
        if (Input.GetKeyDown(Aim) && g_holdingUp)
        {
            g_defaultVal = false;
            g_holdingUp = false;
            g_Aiming = true;
        }
        else if (Input.GetKeyUp(Aim) && g_holdingUp)
        {
            g_defaultVal = false;
            g_holdingUp = false;
            g_Aiming = false;
        }


    }

    private void holsterDetection()
    {
    
        // When Default Value is true, Lerps to default position
        if (g_defaultVal)
        {
            g_WeaponHolder.localRotation = Quaternion.Lerp(g_WeaponHolder.localRotation, g_Default.localRotation, sp_HoldToDef * Time.deltaTime);
            g_WeaponHolder.localPosition = Vector3.Lerp(g_WeaponHolder.localPosition, g_Default.localPosition, sp_HoldToDef * Time.deltaTime);
        }


        if (g_holdingUp)
        {
            g_WeaponHolder.localRotation = Quaternion.Lerp(g_WeaponHolder.localRotation, g_HoldUp.localRotation, sp_DefToHold * Time.deltaTime);
            g_WeaponHolder.localPosition = Vector3.Lerp(g_WeaponHolder.localPosition, g_HoldUp.localPosition, sp_DefToHold * Time.deltaTime);
        }

        if (g_Aiming)
        {
            g_WeaponHolder.localPosition = Vector3.Lerp(g_WeaponHolder.localPosition, g_AimPos.localPosition, sp_HoldToAim * Time.deltaTime);
            g_WeaponHolder.localRotation = Quaternion.Lerp(g_WeaponHolder.localRotation, g_AimPos.localRotation, sp_HoldToAim * Time.deltaTime);
            
        }


    }

}
