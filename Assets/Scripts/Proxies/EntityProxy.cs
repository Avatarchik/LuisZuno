﻿// Copyright 2018-2019 TAP, Inc. All Rights Reserved.

using System.Linq;
using UnityEngine;
using Unity.Entities;
using UnityEngine.Serialization;

[RequiresEntityConversion]
public class EntityProxy : MonoBehaviour, IConvertGameObjectToEntity {
    public SpritePreset preset = null;
    [FormerlySerializedAs("Reactive")] public ReactiveComponent reactive;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        SetupComponents(entity, dstManager, conversionSystem);
    }

    protected virtual void SetupComponents(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        if (null != preset) {
            dstManager.AddSharedComponentData(entity, new SpritePresetComponent(preset));
            dstManager.AddComponentData(entity, new SpriteAnimComponent() {
                nameHash = preset.datas.Keys.First()
            });
        }

        dstManager.AddComponentData(entity, new ReactiveComponent(ref reactive));

        dstManager.AddComponentData(entity, new TargetComponent() {
            lastTargetIndex = int.MinValue,
            targetIndex = int.MaxValue,
            targetDistance = float.PositiveInfinity,
        });
    }
}
