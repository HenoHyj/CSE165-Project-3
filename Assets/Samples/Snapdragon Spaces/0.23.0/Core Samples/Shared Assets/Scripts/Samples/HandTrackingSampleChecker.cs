/******************************************************************************
 * File: HandTrackingSampleChecker.cs
 * Copyright (c) 2023-2024 Qualcomm Technologies, Inc. and/or its subsidiaries. All rights reserved.
 *
 ******************************************************************************/

using UnityEngine;
using UnityEngine.UI;
#if UNITY_ANDROID && !UNITY_EDITOR
using System.Linq;
using UnityEngine.Android;
using UnityEngine.XR.OpenXR;
#endif

namespace Qualcomm.Snapdragon.Spaces.Samples
{
    [RequireComponent(typeof(Button))]
    public class HandTrackingSampleChecker : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        private void OnEnable()
        {
            _button.interactable = CheckRuntimeCameraPermissions();
        }

        private void OnValidate()
        {
            _button = _button ? _button : GetComponent<Button>();
        }

        private void Start()
        {
#if !QCHT_UNITY_CORE
            _button.interactable = false;
#endif
        }

        private bool CheckRuntimeCameraPermissions()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            var activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            var runtimeChecker = new AndroidJavaClass("com.qualcomm.snapdragon.spaces.serviceshelper.RuntimeChecker");

            if ( !runtimeChecker.CallStatic<bool>("CheckCameraPermissions", new object[] { activity }) )
            {
                Debug.LogError("Snapdragon Spaces Services has no camera permissions! Hand Tracking feature disabled.");
                return false;
            }
#endif
            return true;
        }
    }
}
