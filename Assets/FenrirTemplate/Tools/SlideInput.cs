﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fenrir.Tools
{
    public class SlideInput : MonoBehaviour
    {
        private Vector2 firstPos;

        public ListeningMode listeningMode;
        private System.Action platformSpecialController;
        public System.Action<Vector2> onSlide;
        private Vector3 lastPos;
        public System.Action onTap;



        private void Start()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                case RuntimePlatform.IPhonePlayer:
                    platformSpecialController = MobileController;
                    break;

                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.LinuxEditor:
                    platformSpecialController = PcController;
                    break;
            }

        }

        private void SetlisteninMode(ListeningMode _listeningMode) => listeningMode = _listeningMode;

        private void MobileController()
        {
            if (listeningMode == ListeningMode.Swipe)
            {
                if (Input.touchCount > 0)
                {
                    Touch t = Input.GetTouch(0);
                    switch (t.phase)
                    {
                        case TouchPhase.Began:
                            firstPos = t.position;
                            lastPos = firstPos;
                            break;
                        case TouchPhase.Moved:
                            Vector2 Delta = (Vector2)lastPos - t.position;
                            onSlide?.Invoke(Delta);
                            lastPos = t.position;
                            break;
                        case TouchPhase.Ended:
                            firstPos = Vector2.zero;
                            break;
                    }
                }
            }
            else if (listeningMode == ListeningMode.Tap)
            {
                if (Input.touchCount > 0)
                {
                    Touch t = Input.GetTouch(0);
                    switch (t.phase)
                    {
                        case TouchPhase.Ended:
                            onTap?.Invoke();
                            break;
                    }
                }
            }

        }
        private void PcController()
        {
            if (listeningMode == ListeningMode.Swipe)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    firstPos = Input.mousePosition;
                    lastPos = firstPos;
                }
                if (Input.GetMouseButton(0))
                {
                    Vector3 Delta = lastPos - Input.mousePosition;
                    onSlide?.Invoke(Delta);
                    lastPos = Input.mousePosition;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    firstPos = Vector2.zero;
                }
            }
            else if (listeningMode == ListeningMode.Tap)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    onTap?.Invoke();
                }
            }
        }


        // Update is called once per frame
        void Update()
        {
            platformSpecialController?.Invoke();
        }

        public enum ListeningMode
        {
            Swipe = 0, Tap = 1,
        }
    }

}

