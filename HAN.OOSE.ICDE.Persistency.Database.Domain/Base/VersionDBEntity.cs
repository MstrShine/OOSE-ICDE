﻿namespace HAN.OOSE.ICDE.Persistency.Database.Domain.Base
{
    public abstract class VersionDBEntity : DBEntity
    {
        public Guid VersionCollection { get; set; }

        public User Author { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
