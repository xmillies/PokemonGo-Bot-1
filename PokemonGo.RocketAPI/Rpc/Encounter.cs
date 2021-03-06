﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POGOProtos.Enums;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;
using POGOProtos.Networking.Responses;

namespace PokemonGo.RocketAPI.Rpc
{
    public class Encounter : BaseRpc
    {
        public Encounter(Client client) : base(client) { }

        public EncounterResponse EncounterPokemon(ulong encounterId, string spawnPointGuid)
        {
            var message = new EncounterMessage
            {
                EncounterId = encounterId,
                SpawnPointId = spawnPointGuid,
                PlayerLatitude = Client.CurrentLatitude,
                PlayerLongitude = Client.CurrentLongitude
            };
            
            return  PostProtoPayload<Request, EncounterResponse>(RequestType.Encounter, message);
        }

        public UseItemCaptureResponse UseCaptureItem(ulong encounterId, ItemId itemId, string spawnPointId)
        {
            var message = new UseItemCaptureMessage
            {
                EncounterId = encounterId,
                ItemId = itemId,
                SpawnPointId = spawnPointId
            };
            
            return PostProtoPayload<Request, UseItemCaptureResponse>(RequestType.UseItemCapture, message);
        }

        public UseItemEncounterResponse UseItemEncounter(ulong encounterId, ItemId item, string spawnPointId)
        {
            var message = new UseItemEncounterMessage()
            {
                Item = item,
                EncounterId = encounterId,
                SpawnPointGuid = spawnPointId,
            };

            return PostProtoPayload<Request, UseItemEncounterResponse>(RequestType.UseItemEncounter, message);
        }

        public CatchPokemonResponse CatchPokemon(ulong encounterId, string spawnPointGuid, ItemId pokeballItemId, bool forceHit, double normalizedRecticleSize = 1.950, double spinModifier = 1, double normalizedHitPos = 1)
        {            
            var message = new CatchPokemonMessage   // We need to make this here more random, that we sometimes dont hit orso
            {
                EncounterId = encounterId,
                Pokeball = pokeballItemId,
                SpawnPointId = spawnPointGuid,
                HitPokemon = forceHit,
                NormalizedReticleSize = normalizedRecticleSize,
                SpinModifier = spinModifier,
                NormalizedHitPosition = normalizedHitPos
            };
            
            return  PostProtoPayload<Request, CatchPokemonResponse>(RequestType.CatchPokemon, message);
        }

        public IncenseEncounterResponse EncounterIncensePokemon(ulong encounterId, string encounterLocation)
        {
            var message = new IncenseEncounterMessage()
            {
                EncounterId = encounterId,
                EncounterLocation = encounterLocation
            };

            return PostProtoPayload<Request, IncenseEncounterResponse>(RequestType.IncenseEncounter, message);
        }

        public DiskEncounterResponse EncounterLurePokemon(ulong encounterId, string fortId)
        {
            var message = new DiskEncounterMessage()
            {
                EncounterId = encounterId,
                FortId = fortId,
                PlayerLatitude = Client.CurrentLatitude,
                PlayerLongitude = Client.CurrentLongitude
            };

            return PostProtoPayload<Request, DiskEncounterResponse>(RequestType.DiskEncounter, message);
        }

        public EncounterTutorialCompleteResponse EncounterTutorialComplete(PokemonId pokemonId)
        {
            var message = new EncounterTutorialCompleteMessage()
            {
                PokemonId = pokemonId
            };

            return PostProtoPayload<Request, EncounterTutorialCompleteResponse>(RequestType.EncounterTutorialComplete, message);
        }
    }
}
