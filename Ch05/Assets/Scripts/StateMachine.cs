using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State<T>
{
    protected StateMachine<T> stateMachine;
    protected T context;

    public State()
    {

    }

    internal void SetStateAndContext(StateMachine<T> stateMachine, T context)
    {
        this.stateMachine = stateMachine;
        this.context = context;

        OnInitailized();
    }

    public virtual void OnInitailized()
    {

    }

    public virtual void OnEnter()
    {

    }

    public abstract void Update(float deltaTime);

    public virtual void OnExit()
    {

    }
}


public sealed class StateMachine<T>
{
    private T context;

    private State<T> currentState;
    public State<T> CurrentState => currentState;

    private State<T> previousState;
    public State<T> PreviousState => previousState;

    private float elapsedTimeinState;
    public float ElapsedTimeinState => elapsedTimeinState;

    private Dictionary<System.Type, State<T>> states = new Dictionary<System.Type, State<T>>();

    public StateMachine(T context, State<T> initialState)
    {
        this.context = context;

        AddState(initialState);
        currentState = initialState;
        currentState.OnEnter();
    }

    public void AddState(State<T> state)
    {
        state.SetStateAndContext(this, context);
        states[state.GetType()] = state;
    }

    public void Update(float deltaTime)
    {
        elapsedTimeinState += deltaTime;

        currentState.Update(deltaTime);
    }

    public R ChangeState<R>() where R : State<T>
    {
        var newType = typeof(R);
        if(currentState.GetType() == newType)
        {
            return currentState as R;
        }

        if(currentState != null)
        {
            currentState.OnExit();
        }

        previousState = currentState;
        currentState = states[newType];
        currentState.OnEnter();
        elapsedTimeinState = 0.0f;

        return currentState as R;
    }
}
