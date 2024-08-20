/*===============================================================================================
Copyright(c) 2019-2024 AIR.AR All Rights Reserved.  

Version 1.0.0. 2024.08.05.
 ===============================================================================================*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace AirarCm
{
    /*
    * A sample script that can track single marker image.
    */
    public class SingleCmController : MonoBehaviour
    {
        [Header("▶3D Content")]
        [Tooltip("Please set the name of the prefab to be the same as the name of the marker image.")]
        [SerializeField]
        private GameObject prefab;

        [Space(1)]
        [Header("▶Guide UI")]
        [Tooltip("Setting the option to true indicates if the marker is out of the screen area.")]
        [SerializeField]
        private bool isGuideOn = true;
        [SerializeField]
        private Color correctStateMaterialColor = new Color(0f, 1f, 0f, 0.3f);
        [SerializeField]
        private Color wrongStateMaterialColor = new Color(1f, 0f, 0f, 0.3f);

        [Space(1)]
        [Header("▶Debug UI")]
        [Tooltip("If the option is set to true, a log will be displayed on the screen.")]
        [SerializeField]
        bool isShowLog = false;
        [SerializeField]
        private GameObject logSet;
        [SerializeField]
        private Text logText;

        private GameObject trackable;
        private CMTrackableHandler cmTrackableHandler;

        private string status = "";
        private string trackingInfo = "";
        private string errorInfo = "";

        private void Awake()
        {
            logSet.SetActive(isShowLog);

            if (prefab == null)
            {
                Debug.LogError("Prefab is null.");
                status = "Prefab is null.";
                ShowInfo();

                return;
            }
        }

        void OnEnable()
        {
            ARTrackedImageManager trackedImageManager = FindFirstObjectByType<ARTrackedImageManager>();

            if (trackedImageManager != null)
            {
                // If you delete the codes in the two lines below, the coloring function does not work properly.
                cmTrackableHandler = new CMTrackableHandler(trackedImageManager);
                cmTrackableHandler.OnTrackedImagesChangedEvent += OnTrackedImagesChanged;

                cmTrackableHandler.SetGuide(isGuideOn, correctStateMaterialColor, wrongStateMaterialColor);

                status = "Initialization completed";
            }
            else
            {
                Debug.LogError("ARTrackedImageManager does not exist in the scene.");
                status = "ARTrackedImageManager does not exist in the scene.";
            }

            ShowInfo();
        }

        void OnDestroy()
        {
            if (cmTrackableHandler != null)
            {
                cmTrackableHandler.OnDestroy();
                cmTrackableHandler.OnTrackedImagesChangedEvent -= OnTrackedImagesChanged;
            }
        }

        private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            List<ARTrackedImage> addedImages = eventArgs.added;
            List<ARTrackedImage> updatedImages = eventArgs.updated;
            List<ARTrackedImage> removedImages = eventArgs.removed;

            // Load
            foreach (ARTrackedImage added in addedImages)
            {
                string name = added.referenceImage.name;

                if (name.Equals(prefab.name))
                {
                    if (trackable == null)
                    {
                        // If you delete the codes in the two lines below, the coloring function does not work properly.
                        trackable = Instantiate(prefab, added.gameObject.transform);
                        trackable.name = name;

                        trackingInfo += "Load: " + name + "\n";
                        ShowInfo();
                    }
                }
            }

            // Found/Lost
            foreach (ARTrackedImage updated in updatedImages)
            {
                string name = updated.referenceImage.name;

                if (name.Equals(prefab.name))
                {
                    if (trackable != null)
                    {
                        if (updated.trackingState == TrackingState.Tracking)
                        {
                            if (!trackable.activeSelf)
                            {
                                trackable.SetActive(true);
                                trackingInfo += "Found: " + name + "\n";
                            }
                        }
                        else
                        {
                            if (trackable.activeSelf)
                            {
                                trackable.SetActive(false);
                                trackingInfo += "Lost: " + name + "\n";
                            }
                        }

                        ShowInfo();
                    }
                }
            }
        }

        private void ShowInfo()
        {
            if (!isShowLog)
            {
                return;
            }

            string logInfo = string.Format(
                "status: {0}\n" +
                "tracking info: {1}\n" +
                "error info: {2}"
                , status,
                trackingInfo,
                errorInfo);

            logText.text = logInfo;
        }
        public void OnClickColoring3DButton()
        {
            try
            {
                errorInfo = "";

                if (trackable == null || !trackable.activeSelf)
                {
                    errorInfo = "The 3D currently being augmented does not exist.";
                }
                else
                {
                    cmTrackableHandler.RunCm();
                }
            }
            catch (System.Exception e)
            {
                errorInfo = e.Message;
            }

            ShowInfo();
        }
    }
}