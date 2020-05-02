using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Scene
{
    public class Init : MonoBehaviour
    {

        public Button startBtn;
        public Slider slider;
        public Animator animator;
        private float animTime;
        public Text valueText;
        void Start()
        {
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++)
            {
                if (clips[i].name=="Start")
                {
                    animTime = clips[i].length;
                    Debug.LogWarning(animTime);
                }
            }
            startBtn.onClick.AddListener(() =>
            {
                startBtn.gameObject.SetActive(false);
                animator.Play("Start");
                Invoke(nameof(ShowSlider),animTime);
            });
        }

        private void ShowSlider()
        {
            valueText.text = 0 + "%";
            slider.value = 0;
            slider.gameObject.SetActive(true);
            DOTween.To(() => slider.value, x =>
            {
                slider.value = x;
                valueText.text = (x * 100).ToString("F1")+"%";
            }, 1, 3).OnComplete(() =>
            {
                SceneManager.LoadScene("Home");
            });
        }
        
    }
}
