using UnityEngine;

namespace Script.Window
{
    public class TipsWindow : MonoBehaviour
    {
        private float time = 3;

        private void Start()
        {
            Invoke(nameof(Close), time);
        }

        private void Close()
        {
            Destroy(gameObject);
        }
    }
}