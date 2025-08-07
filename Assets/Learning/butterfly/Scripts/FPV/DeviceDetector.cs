using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace fpv
{
    public class DeviceDetector : MonoBehaviour
    {
        public static PlatformType GetCurrentPlatform()
        {
            if (IsXrPresent())
            {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
                return PlatformType.DesktopVR;  // Link testing
#elif UNITY_ANDROID
            return PlatformType.AndroidVR;  // Quest build
#endif
            }
    
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            return PlatformType.Desktop;        // Regular desktop
#elif UNITY_ANDROID  
        return PlatformType.Mobile;         // Phone build
#endif
        }

        public static bool IsXrPresent()
        {
            var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
            SubsystemManager.GetSubsystems<XRDisplaySubsystem>(xrDisplaySubsystems);
            foreach (var xrDisplay in xrDisplaySubsystems)
            {
                if (xrDisplay.running)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

public enum PlatformType
{
    Desktop,      // Windows + Keyboard + controller
    DesktopVR,    // Windows + VR (Link detected)
    AndroidVR,    // Android + VR 
    Mobile        // Android + Touch
}