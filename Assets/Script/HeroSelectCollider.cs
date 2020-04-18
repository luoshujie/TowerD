using System;
using UnityEngine;

namespace Script
{
    public class HeroSelectCollider : MonoBehaviour
    {
        private void OnMouseDown()
        {
            transform.parent.SendMessage(nameof(SendMessage),SendMessageOptions.DontRequireReceiver);
        }
    }
}
