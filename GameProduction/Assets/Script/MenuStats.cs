using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuStats
{
    private static float bgmVol, sfxVol;
    private static int isTutorial;
    public static float BgmVol
    {
        get
        {
            return bgmVol;
        }
        set
        {
            bgmVol = value;
        }
    }

    public static float SfxVol
    {
        get
        {
            return sfxVol;
        }
        set
        {
            sfxVol = value;
        }
    }

    public static int IsTutorial
    {
        get
        {
            return isTutorial;
        }
        set
        {
            isTutorial = value;
        }
    }

}
