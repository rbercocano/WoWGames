using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowGames.Models.TopUp
{
    public class GamesListResult
    {
        [JsonProperty("game_list")]
        public List<GameList> GameList { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
    public class GameList
    {
        [JsonProperty("game_category")]
        public string GameCategory { get; set; }
        [JsonProperty("game_code")]
        public string GameCode { get; set; }
        [JsonProperty("game_name")]
        public string GameName { get; set; }
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }
        [JsonProperty("game_status")]
        public string Status { get; set; }
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
        [JsonProperty("product_name")]
        public string Product { get; set; }
        [JsonProperty("category_name")]
        public string Category { get; set; }
    }
}
