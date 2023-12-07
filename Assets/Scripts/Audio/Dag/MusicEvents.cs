using FMODUnity;
using UnityEngine;

namespace Mir.Audio.Dag
{
    public class MusicEvents : MonoBehaviour
    {
        [field: Header("Music")]
        [field: SerializeField] public EventReference bossFight { get; private set; }

        public static MusicEvents instance { get; private set; }

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