using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class StateMachine : MonoBehaviour
{
    // All state machine can use
    private Dictionary<Type, BaseState> _avaliableState;

    public BaseState CurrentState { get; private set; }

    public event Action<BaseState> OnStateChanged;

    internal void SetStates(Dictionary<Type, BaseState> state)
    {
        _avaliableState = state;
    }

    private void Update()
    {

        if (CurrentState == null) {
            CurrentState = _avaliableState.Values.First();
        }

        var nextState = CurrentState?.Tick();

        if (nextState != null && nextState != CurrentState?.GetType()) {
            SwitchToNewState(nextState);
        }
        
    }

    private void SwitchToNewState(Type nextState)
    {
        CurrentState = _avaliableState[nextState];
        OnStateChanged?.Invoke(CurrentState);
    }
}
