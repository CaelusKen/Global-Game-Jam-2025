using UnityEngine;

public interface IInteractable
{
    public string InteractionPrompt { get; }

    public bool Interact(PlayerInteractor interactor);
}
