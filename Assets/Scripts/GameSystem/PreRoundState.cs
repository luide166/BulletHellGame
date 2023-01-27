using System.Collections;
using UnityEngine;

internal class PreRoundState : State
{
    private RoundSystem roundSystem;

    public PreRoundState(RoundSystem roundSystem)
    {
        this.roundSystem = roundSystem;
    }

    public override IEnumerator StartState()
    {
        roundSystem.waveSpawner.PrepareNextRoundSpawner();

        yield return new WaitForSeconds(2);
        roundSystem.waveSpawner.canSpawn = true;
        roundSystem.SetState(new RoundState(roundSystem));
    }

    public override IEnumerator PlayButton()
    {
        roundSystem.waveSpawner.canSpawn = true;
        return base.PlayButton();
    }
}