﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psicologia.Domain.Entities.Endereco;

namespace Psicologia.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}
