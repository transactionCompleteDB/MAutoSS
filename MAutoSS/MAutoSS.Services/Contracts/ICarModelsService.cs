﻿using MAutoSS.DataModels;
using System.Collections.Generic;

namespace MAutoSS.Services.Contracts
{
    public interface ICarModelsService
    {
        IEnumerable<CarModel> GetAllCarModels();
    }
}