using System;
using UnityEngine;

namespace Script.Manager
{
    public class TextureMgr : MonoBehaviour
    {
        public static TextureMgr instance;
        private string path = "Sprite/";

        private void Awake()
        {
            instance = this;
        }

        public Sprite GetSprite(int id)
        {
            return Resources.Load<Sprite>(path + id);
        }
    }
}
