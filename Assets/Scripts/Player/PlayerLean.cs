using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLean : MonoBehaviour
{
    public float leanSpeed;
    public KeyCode leanLeft;
    public KeyCode leanRight;
    public float leanReturnSpeed;


    public Transform defaultLean;
    public Transform leanObject;
    public Transform m_Camera;
    public Transform leanCalculationObject;

    public float l_rotLeft;
    public float l_rotRight;

    private void Start()
    {
        leanObject.localRotation = Quaternion.Euler(0, 0, 0);
        leanCalculationObject.localRotation = Quaternion.Euler(0, 0, 0);

    }

    public void Update()
    {
        leanCalculation();
    }

    private void leanCalculation()
    {
        if (Input.GetKey(leanLeft))
        {
            leanCalculationObject.localRotation = Quaternion.Euler(0, 0, l_rotLeft);
            leanObject.localRotation = Quaternion.Lerp(leanObject.localRotation, leanCalculationObject.localRotation, leanSpeed * Time.deltaTime);
            m_Camera.localRotation = Quaternion.Lerp(m_Camera.localRotation, leanCalculationObject.localRotation, leanSpeed * Time.deltaTime);
        }
        else
        {
            leanCalculationObject.localRotation = Quaternion.Euler(0, 0, 0);
            leanObject.localRotation = Quaternion.Lerp(leanObject.localRotation, leanCalculationObject.localRotation, leanReturnSpeed * Time.deltaTime);
            m_Camera.localRotation = Quaternion.Lerp(m_Camera.localRotation, leanCalculationObject.localRotation, leanReturnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(leanRight))
        {
            leanCalculationObject.localRotation = Quaternion.Euler(0, 0, l_rotRight);
            leanObject.localRotation = Quaternion.Lerp(leanObject.localRotation, leanCalculationObject.localRotation, leanSpeed * Time.deltaTime);
            m_Camera.localRotation = Quaternion.Lerp(m_Camera.localRotation, leanCalculationObject.localRotation, leanSpeed * Time.deltaTime);
        }
        else
        {
            leanCalculationObject.localRotation = Quaternion.Euler(0, 0, 0);
            leanObject.localRotation = Quaternion.Lerp(leanObject.localRotation, leanCalculationObject.localRotation, leanReturnSpeed * Time.deltaTime);
            m_Camera.localRotation = Quaternion.Lerp(m_Camera.localRotation, leanCalculationObject.localRotation, leanReturnSpeed * Time.deltaTime);
        }
    }
}
