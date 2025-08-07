using System.Collections.Generic;
using UnityEngine;

namespace fpv
{
    public class InputManager: MonoBehaviour
    {
        public List<IInputSource> inputSources = new List<IInputSource>();
        private IInputSource activeSource;

        void Start()
        {
            PlatformType platform = DeviceDetector.GetCurrentPlatform();
            CreateInputSourcesForPlatform(platform);

            foreach (var source in inputSources)
            {
                source.OnBecameActive += SwitchToSource;

            }
            activeSource = inputSources[0];
        }

        private void CreateInputSourcesForPlatform(PlatformType platform)
        {
            switch (platform)
            {
                case PlatformType.Desktop:
                    inputSources.Add(new KeyboardInputSource());
                    //inputSources.Add(new GamepadInputSource());
                    break;
                case PlatformType.Mobile:
                    //inputSources.Add(new TouchInputSource()); 
                    break;
                case PlatformType.DesktopVR:
                case PlatformType.AndroidVR:
                    // inputSources.Add(new VRInputSource()); 
                    // inputSources.Add(new KeyboardInputSource()); 
                    break;
            }
        }

        private void SwitchToSource(IInputSource newSource)
        {
            activeSource = newSource;
        }

        public FlightInput GetFlightInput()
        {
            return activeSource?.GetInput() ?? FlightInput.Zero;
        }
    
    }
}
