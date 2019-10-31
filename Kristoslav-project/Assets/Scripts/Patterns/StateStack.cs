using System;
using System.Collections;
using System.Collections.Generic;
public class StateStack 
{
    Stack<State> stack = new Stack<State>();

    public void Push(State newState)
    {
        if (newState == null)
        {
            Logger.StateStackDebug("Pushing NULL into the stack");
            
        }
        
        if (IsStackEmpty() == false)
        {
            Logger.StateStackDebug("Call OnPressed on " + stack.Peek());
            stack.Peek().OnPressed();
        }

        stack.Push(newState);

        newState.OnPushed();
        Logger.StateStackDebug("Call OnPushed on " + newState);
    }

    public bool IsStackEmpty()
    {
        return stack.Count <= 0;
    }

    public State Pop()
    {
        State result = null;
        if (IsStackEmpty())
        {
            Logger.StateStackDebug("Popping an empty stack");
            return result;
        }

        Logger.StateStackDebug("Call OnPop on" + result);
        result = stack.Pop();
        result.OnPopped();

        if (!IsStackEmpty())
        {
            Logger.StateStackDebug("Call OnReturn Peek on" + stack.Peek());
            stack.Peek().OnReturnPeek();
        }
        return result;
    }

    public void EmptyStack()
    {
        while (IsStackEmpty() == false)
        {
            Pop();
        }
    }

    public State GetPeek()
    {
        if (stack.Count > 0) {
            return stack.Peek();
        } else {
            return null;
        }
    }

    public bool Contains(State playingState)
    {
        return stack.Contains(playingState);
    }
}
