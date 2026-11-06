using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VFXLauncher : MonoBehaviour
{
    [Serializable]
    class VFX
    {
        public string name;
        public VFXID ID;
        public ParticleSystem ps;
    }

    [SerializeField] List<VFX> _effects;
    
    public void Launch(VFXID id)
    {
        // LINQ
        var found = _effects.FirstOrDefault(i => i.ID == id);

        if (found == null)
        {
            // Log de securité&
            return;
        }
        found.ps.Play();

        return;
        /*
        foreach (var effect in _effects)
        {
            if (effect.name == name)
            {
                effect.ps.Play();
                return;
            }
        }*/
    }
}