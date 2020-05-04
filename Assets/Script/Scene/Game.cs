using System;
using System.Collections.Generic;
using DG.Tweening;
using Script.Manager;
using Script.Role.Data;
using Script.Role.Skill;
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
        public Image addSpeedImg;
        public Sprite oneSprite;
        public Sprite twoSprite;

        public Button bigMoveBtn;
        public Image bigMoveImg;

        public Image redPanel;
        public GameObject skillOkTips;

        public bool gameState;

        private void Awake()
        {
            instance = this;
            pauseBtn.onClick.AddListener(() => { WindowMgr.instance.ShowWindow<PauseWindow>(); });
            retreatToggle.onValueChanged.AddListener(Retreat);
            bigMoveBtn.onClick.AddListener(() =>
            {
                currentEnergy = 0;
                bigMoveImg.fillAmount = currentEnergy * 1f / maxEnergy;
                bigMoveBtn.interactable = false;
                skillOkTips.SetActive(false);
                new BigMoveSkill(10).UseSkill();
            });
            addSpeedBtn.onClick.AddListener(() =>
            {
                if (Time.timeScale > 1)
                {
                    Time.timeScale = 1;
                    addSpeedImg.sprite = oneSprite;
                }
                else
                {
                    Time.timeScale = 2;
                    addSpeedImg.sprite = twoSprite;
                }
            });
            startFightBtn.onClick.AddListener(() =>
            {
                gameState = true;
                FightMgr.instance.InstantiateMonster();
                startFightBtn.gameObject.SetActive(false);
            });
            bigMoveImg.fillAmount = currentEnergy * 1f / maxEnergy;
            bigMoveBtn.interactable = false;
        }

        private int currentEnergy = 0;
        private int maxEnergy = 20;

        public void AddEnergy(int value)
        {
            currentEnergy += value;
            if (currentEnergy >= maxEnergy)
            {
                currentEnergy = maxEnergy;
                bigMoveBtn.interactable = true;
                skillOkTips.SetActive(true);
            }

            bigMoveImg.fillAmount = currentEnergy * 1f / maxEnergy;
        }

        private Sequence _sequence;

        public void ShowRedPanel()
        {
            if (_sequence != null)
            {
                return;
            }

            _sequence = DOTween.Sequence().Append(redPanel.DOColor(Color.white, 0.5f).SetEase(Ease.Linear))
                .Append(redPanel.DOColor(new Color(1, 1, 1, 0), 0.5f).SetEase(Ease.Linear)).AppendCallback(
                    () => { _sequence = null; });
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
                _dragObj.transform.position = pos;
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

        public void Move(bool state, int heroId, StanceEnum stanceEnum)
        {
            if (state)
            {
                _dragObj = FightMgr.instance.GetHeroModel(heroId);

                FightMgr.instance.ShowHighlight(stanceEnum);
            }
            else
            {
                FightMgr.instance.CloseHighlight(heroId, stanceEnum);
                _dragObj.SetActive(false);
                _dragObj = null;
            }
        }
    }
}