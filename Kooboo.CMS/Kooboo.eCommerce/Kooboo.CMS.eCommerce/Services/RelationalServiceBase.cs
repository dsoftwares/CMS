﻿#region License
// 
// Copyright (c) 2013, Kooboo team
// 
// Licensed under the BSD License
// See the file LICENSE.txt for details.
// 
#endregion
using Kooboo.CMS.Common.Persistence;
using Kooboo.CMS.Common.Persistence.Relational;
using Kooboo.CMS.eCommerce.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kooboo.CMS.eCommerce.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="EntityType">The type of the ntity type.</typeparam>
    /// <typeparam name="ProviderType">The type of the rovider type.</typeparam>
    public abstract class RelationalServiceBase<EntityType, ProviderType>
        where ProviderType : IProvider<EntityType>
    {
        #region Properties
        public ProviderType Provider { get; private set; }
        public IEventPublisher EventPublisher { get; private set; }
        #endregion

        #region .ctor
        public RelationalServiceBase(ProviderType provider, IEventPublisher eventPublisher)
        {
            this.Provider = provider;
            this.EventPublisher = eventPublisher;
        }
        #endregion

        #region Methods
        public virtual void Add(EntityType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entity is ISaveObservable)
            {
                ((ISaveObservable)entity).OnSaving();
            }
            EventPublisher.PreAdd(entity);

            Provider.Add(entity);

            EventPublisher.Added(entity);

            if (entity is ISaveObservable)
            {
                ((ISaveObservable)entity).OnSaved();
            }
        }

        public virtual void Update(EntityType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entity is ISaveObservable)
            {
                ((ISaveObservable)entity).OnSaving();
            }

            EventPublisher.PreUpdate(entity);

            Provider.Update(entity);

            EventPublisher.Updated(entity);

            if (entity is ISaveObservable)
            {
                ((ISaveObservable)entity).OnSaved();
            }
        }

        public virtual void Delete(EntityType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            EventPublisher.PreDelete(entity);

            Provider.Delete(entity);

            EventPublisher.Deleted(entity);
        }
        #endregion
    }
}
