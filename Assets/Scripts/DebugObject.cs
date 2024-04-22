using Mir.Serialization;
using UnityEngine;

namespace Mir
{

    /// <summary>
    /// 
    /// /// This class is used for testing experimental codes
    /// </summary>

    public class DebugObject : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.developerConsoleEnabled = true;
            Debug.developerConsoleVisible = true;

            //Debug.LogError("Hata ayýklama objesi devrede.");
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
