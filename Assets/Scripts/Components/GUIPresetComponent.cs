﻿// Copyright 2018-2019 TAP, Inc. All Rights Reserved.

using System;
using Unity.Entities;

[Serializable]
public struct GUIPresetComponent : ISharedComponentData, IEquatable<GUIPresetComponent> {
    public readonly GUIPreset preset;

    public GUIPresetComponent(GUIPreset inPreset) {
        preset = inPreset;
    }

    public bool Equals(GUIPresetComponent other) {
        return other.preset == preset;
    }

    public override int GetHashCode() {
        return (null == preset) ? 0 : preset.GetHashCode();
    }
}
