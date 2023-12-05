using FMODUnity;
using UnityEngine;

namespace Mir.Audio.Oba
{
    public class MusicEvents : MonoBehaviour
    {
        [field: Header("SFX")]
        [field: SerializeField] public EventReference playerLowHealth { get; private set; }
        [field: SerializeField] public EventReference playerDeath { get; private set; }

        public static MusicEvents instance {  get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Found more than one Music Events in the scene.");
            }
            instance = this;
        }
    }
}