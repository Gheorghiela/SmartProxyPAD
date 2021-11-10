﻿using Common.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SyncNode.Services
{
    public class SyncWorkJobService : IHostedService
    {
        private readonly ConcurrentDictionary<Guid, SyncEntity> documents =
            new ConcurrentDictionary<Guid, SyncEntity>();

        private Timer _timer;

        public void AddItem(SyncEntity entity)
        {
            SyncEntity document = null;
            bool isPresent = documents.TryGetValue(entity.Id, out document);

            if (!isPresent || (isPresent && entity.LastChangeAt > document.LastChangeAt))
            {
                documents[entity.Id] = entity;
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoSendWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void DoSendWork(object state)
        {

        }
    }
}
