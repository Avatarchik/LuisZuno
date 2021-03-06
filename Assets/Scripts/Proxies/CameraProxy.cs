﻿// Copyright 2018-2019 TAP, Inc. All Rights Reserved.

using UnityEngine;
using Unity.Entities;

[RequiresEntityConversion]
public class CameraProxy : MonoBehaviour, IConvertGameObjectToEntity {
    public Camera preset = null;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {
        if (null != preset) {
            dstManager.AddSharedComponentData(entity, new CameraPresetComponent(preset));
            dstManager.AddComponentData(entity, new CameraComopnent());
        }
    }
}
