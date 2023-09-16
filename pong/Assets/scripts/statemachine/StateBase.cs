using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase {
    public virtual void OnStateEnter(object o = null) {

    }public virtual void OnStateStay() {

    }public virtual void OnStateExit() {

    }
}
public class statePlaying : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        ballbase b = (ballbase)o;
        gamemaneger.Instance.StartGame();
    }

}
public class stateResetPosition : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        gamemaneger.Instance.ResetBall();
    }
}
    public class stateEndGame : StateBase
    {
        public override void OnStateEnter(object o = null)
        {
            base.OnStateEnter(o);
            gamemaneger.Instance.showMenu();
        }
    }