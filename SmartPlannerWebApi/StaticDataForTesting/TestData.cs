﻿using SmartPlannerWebApi.Models;

namespace SmartPlannerWebApi.StaticDataForTesting
{
    public static class TestData
    {
        public static Guid UserId = Guid.Parse("22c98a74-2913-4284-8b9c-b3e528838ba1");
        public static List<Note> Notes { get; set; }
    }
}
