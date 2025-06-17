using System.Collections.Generic;
using UnityEngine;

public class CurseManager : MonoBehaviour
{
    private List<CurseEffect> activeCurses = new List<CurseEffect>();
    private PlayerStats stats;

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        for (int i = activeCurses.Count - 1; i >= 0; i--)
        {
            if (activeCurses[i].Update(Time.deltaTime))
            {
                activeCurses.RemoveAt(i);
            }
        }
    }

    public void ApplyCurse(CurseData data)
    {
        CurseEffect newCurse = new CurseEffect(data, stats);
        activeCurses.Add(newCurse);
    }
}
