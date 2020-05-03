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
        public Toggle retreatToggle;
        
        private void Awake()
        {
            instance = this;
            pauseBtn.onClick.AddListener(() => { WindowMgr.instance.ShowWindow<PauseWindow>();});
            retreatToggle.onValueChanged.AddListener(Retreat);
            startFightBtn.onClick.AddListener(() =>
            {
                FightMgr.instance.InstantiateMonster();
                startFightBtn.gameObject.SetActive(false);
            });
        }

        private void Retreat(bool state)
        {
            FightMgr.instance.Retreat(state);
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

        public void DisplayNum(int now, int all)
        {
            numText.text = now.ToString() + "/" + all;
        }

        public void DisplayCoin()
        {
            coinText.text = FightMgr.instance.coin.ToString();
        }

        public void ShowCrystalCnt()
        {
            crystalCntText.text = FightMgr.instance.crystalCnt.ToString();
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