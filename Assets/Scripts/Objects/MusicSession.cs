using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMusicSession", menuName = "Data/New Music Session")]
[Serializable]
public class MusicSession : ScriptableObject
{
    public List<AudioClip> clips;
    
    
}

