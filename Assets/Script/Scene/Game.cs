using System;
using System.Collections.Generic;
using DG.Tweening;
using Script.Manager;
using Script.Role.Data;
using Script.Window;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script
{
    public class Game : MonoBehaviour
    {
        public static Game instance;
        private GameObject _dragObj;

        public Text numText;
        public Text crystalCntText;
        public Text coinText;
        public Button pauseBtn;
        public Button addSpeedBtn;
        public Button startFightBtn;
        public Button retreatBtn;
        
        private void Awake()
        {
            instance = this;
            pauseBtn.onClick.AddListener(() => { WindowMgr.instance.ShowWindow<PauseWindow>();});
        }

        private void FixedUpdate()
        {
            if (_dragObj != null)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 10;
                _dragObj.transform.position =pos;
                if (!_dragObj.activeSelf)
                {
                    _dragObj.SetActive(true);
                }
                
            }
        }
        

        public void Move(bool state, int heroId,StanceEnum stanceEnum)
        {
            if (state)
            {
                _dragObj = FightMgr.instance.GetHeroModel(heroId);
                
                FightMgr.instance.ShowHighlight(stanceEnum);
            }
            else
            {
                FightMgr.instance.CloseHighlight(heroId,stanceEnum);
                _dragObj.SetActive(false);
                _dragObj = null;
                
            }
        }
    }
}