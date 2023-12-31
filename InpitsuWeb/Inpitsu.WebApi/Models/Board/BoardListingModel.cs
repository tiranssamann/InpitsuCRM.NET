﻿using System.Collections.Generic;

using Inpitsu.WebAPI.Models.Task;

namespace Inpitsu.WebAPI.Models.Board
{
    public class BoardListingModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public IEnumerable<TaskListingModel> Tasks { get; set; } = new List<TaskListingModel>();
    }
}
