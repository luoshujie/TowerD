using System.Collections.Generic;
using UnityEngine;

namespace Script.Role.Fsm
{
    public class FsmSystem
    {
        private List<StateBase> StateList;
        
        private StateId _currentStateId;

        public StateId CurrentStateID
        {
            get => _currentStateId;
        }

        private StateBase _currentState;

        public StateBase CurrentState
        {
            get => _currentState;
        }

        public FsmSystem()
        {
            StateList=new List<StateBase>();
        }

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="state"></param>
        public void AddState(StateBase state)
        {
            if (state==null)
            {
                Debug.LogError("state is null");
                return;
            }

            if (StateList.Count==0)
            {
                StateList.Add(state);
                _currentState = state;
                _currentStateId = state.Id;
                return;
            }

            foreach (StateBase s in StateList)
            {
                if (s.Id==state.Id)
                {
                    Debug.LogError("已经存在这个状态"+s);
                    return;
                }
            }
            StateList.Add(state);
        }

        /// <summary>
        /// 删除状态
        /// </summary>
        /// <param name="id"></param>
        public void DeleteState(StateId id)
        {
            if (id==StateId.NullStateId)
            {
                Debug.LogError("id id nullStateID");
                return;
            }

            foreach (StateBase s in StateList)
            {
                if (s.Id==id)
                {
                    StateList.Remove(s);
                    return;
                }
            }
            Debug.LogError("不存在这个状态");
        }

        public void PerformTransition(Transition trans)
        {
            if (trans==Transition.NullTransition)
            {
                Debug.LogError("trans is nullTransition");
                return;
            }
            //获取转换对应得状态ID
            StateId stateId = _currentState.GetOutputState(trans);
            if (stateId==StateId.NullStateId)
            {
                Debug.LogError("id is nullStateID");
                return;
            }

            //更新当前的状态ID
            _currentStateId = stateId;
            foreach (StateBase state in StateList)
            {
                if (state.Id==_currentStateId)
                {
                    _currentState.DoBeforeLeaving();
                    _currentState = state;
                    _currentState.DoBeforeEntering();
                    break;
                }
            }
        }
    }
}
