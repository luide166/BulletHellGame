using System.Collections;

internal class RoundState : State
{
    private RoundSystem roundSystem;

    public RoundState(RoundSystem roundSystem)
    {
        this.roundSystem = roundSystem;
    }

    public override IEnumerator StartState()
    {

        yield break;
    }
}