using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual IEnumerator StartState()
    {
        yield break;
    }
    public virtual IEnumerator PlayButton()
    {
        yield break;
    }
    public virtual IEnumerator PauseButton()
    {
        yield break;
    }
    public virtual IEnumerator GameOver()
    {
        yield break;
    }

}
