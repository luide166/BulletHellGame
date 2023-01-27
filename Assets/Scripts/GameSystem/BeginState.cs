using System.Collections;
using System.Threading;
using UnityEngine;

internal class BeginState : State
{
    private RoundSystem roundSystem;

    public BeginState(RoundSystem roundSystem)
    {
        this.roundSystem = roundSystem;
    }

    public override IEnumerator StartState()
    {
        //configurar o spawner
        //configurar a interface
        //não deixar as torres Atirarem
        //configurar a vida do Jogador

        roundSystem.waveSpawner.StartSpawner();
        UIManager.instance.ChangeRoundText(roundSystem.roundCount);

        yield return new WaitForSeconds(2);
        roundSystem.SetState(new PreRoundState(roundSystem));
        Debug.Log(this.ToString());
    }

}