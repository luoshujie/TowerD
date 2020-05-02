using System;
using UnityEngine;

namespace Script
{
    public class CameraMgr : MonoBehaviour
    {
        private Camera _camera;
        private void Awake()
        {
            _camera = GetComponent<Camera>();
            float designWidth = 1334;
            float designHeight = 750; 
            float designOrthographicSize = 5f; 
            float designScale = designWidth / designHeight;
            float scaleRate = (float) Screen.width / (float) Screen.height;
            if (scaleRate > designScale)
            {
                float scale = scaleRate / designScale;
                _camera.orthographicSize = 5f / scale;
            }
            else
            {
                _camera.orthographicSize = 5f;
            }
        }
    }
}