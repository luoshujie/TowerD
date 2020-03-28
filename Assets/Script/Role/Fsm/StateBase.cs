using System.Collections.Generic;
using UnityEngine;

namespace Script.Role.Fsm
{
    public abstract class StateBase
    {
        protected FsmSystem Fsm;
        protected StateId StateId;
        protected Animator Anim;

        public StateId Id
        {
            get => StateId;
            set => StateId = value;
        }

        public Dictionary<Transition, StateId> map = new Dictionary<Transition, StateId>();

        protected StateBase(Animator ansim)
        {
            Anim = ansim;
        }

        /// <summary>
        /// 添加转换
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="stateId"></param>
        public void AddTransition(Transition trans, StateId stateId)
        {
            if (trans==Transition.NullTransition)
            {
                Debug.LogError("NullTransition");
                return;
            }

            if (stateId==StateId.NullStateId)
            {
                Debug.LogError("NullStateID");
                return;
            }

            if (map.ContainsKey(trans))
            {
                Debug.LogError("Trans is over");
                return;
            }
            map.Add(trans,stateId);
        }

        /// <summary>
        /// 删除转换
        /// </summary>
        /// <param name="trans"></param>
        public void DeleteTransition(Transition trans)
        {
            if (trans == Transition.NullTransition)
            {
                Debug.LogError("NullTransition");
                return;
            }

            if (map.ContainsKey(trans))
            {
                map.Remove(trans);
                return;
            }
            Debug.LogError("trans is not on map");
        }

        //根据转换条件返回状态ID
        public StateId GetOutputState(Transition trans)
        {
            if (map.ContainsKey(trans))
            {
                return map[trans];
            }

            return StateId.NullStateId;
        }
        
        /// <summary>
        /// 用于进入状态前，设置进入状态的条件
        /// 在进入当前状态之前，FSM系统会自动调用
        /// </summary>
        public virtual void DoBeforeEntering(){}
        
        /// <summary>
        /// 用于离开状态时的变量重置
        /// 在更改为新状态之前，FSM系统会自动调用
        /// </summary>
        public virtual void DoBeforeLeaving(){}
        
        public abstract void CheckTransition( );

     
        public abstract void Act( );
    }
}