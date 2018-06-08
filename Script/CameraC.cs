using UnityEngine;
using System.Collections;

public class CameraC : MonoBehaviour {

    private GameObject MainCam;
    private GameObject SubCam;
    private GameObject secondCam;

    void Start () {
        MainCam = GameObject.Find("MainCamera");
        SubCam = GameObject.Find("FPC");
        secondCam = GameObject.Find("FPC2");

        SubCam.SetActive(false);
    }

    void Update () {
        if(Input.GetKeyDown("space")){
            if(MainCam.activeSelf){
                MainCam.SetActive (false);
                SubCam.SetActive (true);
            }else{
                MainCam.SetActive (true);
                SubCam.SetActive (false);
            }
        }
        if(Input.GetKeyDown("c")){
            if(MainCam.activeSelf){
                MainCam.SetActive (false);
                secondCam.SetActive (true);
            }else{
                MainCam.SetActive (true);
                secondCam.SetActive (false);
            }
        }
    }

}
