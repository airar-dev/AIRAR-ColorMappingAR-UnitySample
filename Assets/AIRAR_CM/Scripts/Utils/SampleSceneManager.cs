/*===============================================================================================
Copyright(c) 2019-2024 AIR.AR All Rights Reserved.  

Version 1.0.0. 2024.08.05.
 ===============================================================================================*/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

public class SampleSceneManager : MonoBehaviour
{
    public void LoadSampleScene(string sceneName)
    {
        XRManagerSettings xrManagerSettings = XRGeneralSettings.Instance.Manager;
        xrManagerSettings.DeinitializeLoader();

        SceneManager.LoadScene(sceneName);
        
        xrManagerSettings.InitializeLoaderSync();
    }
}