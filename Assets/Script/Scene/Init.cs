using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Scene
{
    public class Init : MonoBehaviour
    {
        void Start()
        {
            DOTween.Sequence().InsertCallback(3, () => { SceneManager.LoadScene("Home"); });
        }
        
    }
}
