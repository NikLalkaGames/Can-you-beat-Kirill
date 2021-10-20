using UnityEngine;

namespace Items.Interaction.Base.Interfaces
{
    public interface IPointerBehaviour
    {
        void OnControlledByPointer(Transform controlledByPointerItem);
    }
}