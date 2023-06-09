﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fenrir.EventBehaviour;
using Fenrir.Resources;

namespace Fenrir.Managers
{
    public class DataManager : EventBehaviour<DataManager>
    {
        public LevelDataCapsule levelCapsule;
        public AdManager adManager;
        public GameConfiguration GameConfiguration;
        public SoundManager SoundManager;
    }
}
