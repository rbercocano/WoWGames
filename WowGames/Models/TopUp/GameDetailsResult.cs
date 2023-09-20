using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.TopUp
{
    public class GameDetailsResult
    {
        [JsonProperty("help_image_url")]
        public string HelpImgUrl { get; set; }
        [JsonProperty("game")]
        public Game Game { get; set; }
        [JsonProperty("denominations")]
        public List<Denomination> Denominations { get; set; }
        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }

    public class Game
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
    }
    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    public class Denomination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
    }
}
