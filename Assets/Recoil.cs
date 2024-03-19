using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public Transform recoilObj;
    public Transform recoilReturn;
    public Transform recoilObjCalc;
    public float RecoilX;
    public float RecoilY;
    public float RecoilZ;
    public float RecoilKickZ;
    public float RecoilMaxX;
    public float RecoilMaxY;
    public float RecoilMaxZ;
    public float RecoilKickMaxZ;
    public float ReturnSpeed;
    public float KickReturnSpeed;
    public float RecoilSpeed;

    public GameObject MuzzleFlashObj;
    public GameObject Flashlight;

    public GameObject Bullet;
    public Transform BulletSpawn;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RecoilAction();
        }
        else
        {
            Return();
        }
        
    }

    public void RecoilAction()
    {
        recoilObj.localRotation = Quaternion.Euler(Random.Range(RecoilX, RecoilMaxX) + recoilObjCalc.localRotation.x, Random.Range(RecoilY, RecoilMaxY) + recoilObjCalc.localRotation.y, Random.Range(RecoilZ, RecoilMaxZ) + recoilObjCalc.localRotation.z);
        recoilObj.localPosition = new Vector3(recoilObj.localPosition.x, recoilObj.localPosition.y, Random.Range(RecoilKickZ, RecoilKickMaxZ));
        StartCoroutine(MuzzleFlash());
        GameObject NewBullet = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.rotation);
        
    }

    private void Return()
    {
        recoilObj.localRotation = Quaternion.Lerp(recoilObj.localRotation, recoilReturn.localRotation, Time.deltaTime * ReturnSpeed);
        recoilObj.localPosition = Vector3.Lerp(recoilObj.localPosition, recoilReturn.localPosition, Time.deltaTime * KickReturnSpeed);
        
    }
    IEnumerator MuzzleFlash()
    {
        MuzzleFlashObj.SetActive(true);
        
        yield return new WaitForSeconds(0.01f);
        MuzzleFlashObj.SetActive(false);
        
    }
}
