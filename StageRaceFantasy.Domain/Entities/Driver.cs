﻿using System.Collections.Generic;

namespace StageRaceFantasy.Domain.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<RaceEntryDriver> RaceEntryDrivers { get; set; }
    }
}