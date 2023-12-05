﻿using HAN.OOSE.ICDE.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    public abstract class BaseEntityController<T> : ControllerBase where T : Entity
    {
        protected readonly ILogger<BaseEntityController<T>> _logger;

        public BaseEntityController(ILogger<BaseEntityController<T>> logger)
        {
            this._logger = logger;
        }
    }
}
