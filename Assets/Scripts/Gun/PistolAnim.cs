using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAnim : MonoBehaviour
{
    
    public bool checkingMag;
    public float CheckMagRetDelay;
    public Transform pistolSlide;
    public Transform slideReturn;
    public float PistolSlideX;
    public float returnSpeed;
    

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RecoilAction();
        }
        else
        {
            ReturnSlide();
        }

    }
    public void RecoilAction()
    {
        pistolSlide.localPosition = new Vector3(PistolSlideX, pistolSlide.localPosition.y, pistolSlide.localPosition.z);
        ReturnSlide();
    }
    public void ReturnSlide()
    {
        pistolSlide.localPosition = Vector3.Lerp(pistolSlide.localPosition, slideReturn.localPosition, returnSpeed * Time.deltaTime);
    }
    
}
