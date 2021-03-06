﻿// Copyright 2018-2019 TAP, Inc. All Rights Reserved.

using System;
using Unity.Entities;
using GlobalDefine;

public class InventorySystem : ComponentSystem {
    private TablePreset _tablePreset;
    private Entity _playerEntity = Entity.Null;
    private InventoryComponent _inventoryComp;


    protected override void OnStartRunning() {
        Entities.ForEach((TablePresetComponent presetComp) => {
            _tablePreset = presetComp.preset;
        });

        Entities.ForEach((Entity entity, ref ReactiveComponent reactiveComp, ref InventoryComponent inventoryComp) => {
            if (EntityType.Player != reactiveComp.type) {
                return;
            }

            _playerEntity = entity;
            _inventoryComp = inventoryComp;
        });
    }


    protected override void OnUpdate() {
        if(_playerEntity.Equals(Entity.Null)) {
            return;
        }

        if (false == EntityManager.HasComponent<PendingItemComponent>(_playerEntity)) {
            return;
        }

        PendingItemComponent pendingItemComp = EntityManager.GetComponentData<PendingItemComponent>(_playerEntity);
        Int64 pendingItemID = pendingItemComp.pendingItemID;
        EntityManager.RemoveComponent<PendingItemComponent>(_playerEntity);

        //
        UInt16 slotIndex = 0;
        if (_inventoryComp.IsEmptySlot1()) {
            slotIndex = 1;
        }
        else if (_inventoryComp.IsEmptySlot2()) {
            slotIndex = 2;
        }
        else if (_inventoryComp.IsEmptySlot3()) {
            slotIndex = 3;
        }
        else {
            // condition - time
            if ((_inventoryComp.item1.addedTime < _inventoryComp.item2.addedTime) && 
                (_inventoryComp.item1.addedTime < _inventoryComp.item3.addedTime)) {
                    slotIndex = 1;
            }
            else if (_inventoryComp.item2.addedTime < _inventoryComp.item3.addedTime) {
                    slotIndex = 2;
            }
            else {
                slotIndex = 3;
            }
        }

        ItemPresetData data;
        if (_tablePreset.itemDatas.TryGetValue(pendingItemID, out data)) {
            switch (slotIndex) {
                case 1:
                    _inventoryComp.SetSlot1(pendingItemID, data); break;
                case 2:
                    _inventoryComp.SetSlot2(pendingItemID, data); break;
                case 3:
                    _inventoryComp.SetSlot3(pendingItemID, data); break;
            }
        }

        EntityManager.SetComponentData<InventoryComponent>(_playerEntity, _inventoryComp);
    }
}
