﻿// Copyright 2018-2019 TAP, Inc. All Rights Reserved.

using System;
using Unity.Entities;

[Serializable]
public struct EffectSpawnComponent : IComponentData {
    public Entity preset;
}

[Serializable]
public struct EffectSpawnExistComponent : IComponentData {
    
}
