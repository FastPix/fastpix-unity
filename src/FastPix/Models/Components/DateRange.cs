

#nullable enable
namespace fastpix.io.Models.Components
{
    using Newtonsoft.Json;
    using System;
    using UnityEngine;
    
    /// <summary>
    /// Date range with start and end dates.
    /// </summary>
    [Serializable]
    public class DateRange
    {

        [SerializeField]
        [JsonProperty("startDate")]
        public string? StartDate { get; set; }

        [SerializeField]
        [JsonProperty("endDate")]
        public string? EndDate { get; set; }
    }
}