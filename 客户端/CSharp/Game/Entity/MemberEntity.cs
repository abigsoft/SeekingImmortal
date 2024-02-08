using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entity
{
    public class MemberEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; set; } = "";

        /// <summary>
        /// 账号
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; } = "";

        /// <summary>
        /// 角色名
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; } = "未设置";

        /// <summary>
        /// 性别：1男，2女
        /// </summary>
        [JsonProperty("sex")]
        public int Sex { get; set; } = 1;

        /// <summary>
        /// Steam ID
        /// </summary>
        [JsonProperty("steam_id")]
        public string SteamId { get; set; } = "";

        /// <summary>
        /// 账号状态：1正常，0禁用
        /// </summary>
        [JsonProperty("account_status")]
        public int AccountStatus { get; set; } = 1;

        /// <summary>
        /// 角色状态：1正常
        /// </summary>
        [JsonProperty("character_status")]
        public int CharacterStatus { get; set; } = 1;

        /// <summary>
        /// 经验
        /// </summary>
        [JsonProperty("data_exp")]
        public int DataExp { get; set; } = 0;

        /// <summary>
        /// 运势：0-10
        /// </summary>
        [JsonProperty("data_fortune")]
        public string DataFortune { get; set; } = "正常";

        /// <summary>
        /// 体力
        /// </summary>
        [JsonProperty("data_physical")]
        public int DataPhysical { get; set; } = 0;

        /// <summary>
        /// 最大体力
        /// </summary>
        [JsonProperty("data_physical_max")]
        public int DataPhysicalMax { get; set; } = 0;

        /// <summary>
        /// 境界ID
        /// </summary>
        [JsonProperty("level_id")]
        public int LevelId { get; set; } = 0;

        /// <summary>
        /// 境界名称
        /// </summary>
        [JsonProperty("level_title")]
        public string LevelTitle { get; set; } = "凡人境";

        /// <summary>
        /// 悟性
        /// </summary>
        [JsonProperty("data_insight")]
        public int DataInsight { get; set; } = 0;

        /// <summary>
        /// 金币
        /// </summary>
        [JsonProperty("data_gold_coin")]
        public int DataGoldCoin { get; set; } = 0;

        /// <summary>
        /// 灵石
        /// </summary>
        [JsonProperty("data_spirit_stone")]
        public int DataSpiritStone { get; set; } = 0;

        /// <summary>
        /// 装备-法宝ID
        /// </summary>
        [JsonProperty("equip_super_id")]
        public int EquipSuperId { get; set; } = 0;

        /// <summary>
        /// 装备-头部ID
        /// </summary>
        [JsonProperty("equip_head_id")]
        public int EquipHeadId { get; set; } = 0;

        /// <summary>
        /// 装备-武器ID
        /// </summary>
        [JsonProperty("equip_weapon_id")]
        public int EquipWeaponId { get; set; } = 0;

        /// <summary>
        /// 装备-上衣ID
        /// </summary>
        [JsonProperty("equip_tops_id")]
        public int EquipTopsId { get; set; } = 0;

        /// <summary>
        /// 装备-裤子ID
        /// </summary>
        [JsonProperty("equip_pants_id")]
        public int EquipPantsId { get; set; } = 0;

        /// <summary>
        /// 装备-鞋子ID
        /// </summary>
        [JsonProperty("equip_shoes_id")]
        public int EquipShoesId { get; set; } = 0;

        /// <summary>
        /// 装备-饰品ID
        /// </summary>
        [JsonProperty("equip_jewelry_id")]
        public int EquipJewelryId { get; set; } = 0;

        /// <summary>
        /// 称号ID
        /// </summary>
        [JsonProperty("mask_title_id")]
        public int MaskTitleId { get; set; } = 0;

        /// <summary>
        /// 称号
        /// </summary>
        [JsonProperty("mask_title_name")]
        public string MaskTitleName { get; set; } = String.Empty;

        /// <summary>
        /// 血量
        /// </summary>
        [JsonProperty("world_blood")]
        public int WorldBlood { get; set; } = 0;

        /// <summary>
        /// 最大血量
        /// </summary>
        [JsonProperty("world_blood_max")]
        public int WorldBloodMax { get; set; } = 0;

        /// <summary>
        /// 物理攻击
        /// </summary>
        [JsonProperty("world_attack_physics")]
        public int WorldAttackPhysics { get; set; } = 0;

        /// <summary>
        /// 法术攻击
        /// </summary>
        [JsonProperty("world_attack_magic")]
        public int WorldAttackMagic { get; set; } = 0;

        /// <summary>
        /// 物理防御
        /// </summary>
        [JsonProperty("world_defense_physics")]
        public int WorldDefensePhysics { get; set; } = 0;

        /// <summary>
        /// 法术防御
        /// </summary>
        [JsonProperty("world_defense_magic")]
        public int WorldDefenseMagic { get; set; } = 0;

        /// <summary>
        /// 敏捷
        /// </summary>
        [JsonProperty("world_speed")]
        public int WorldSpeed { get; set; } = 1;

        /// <summary>
        /// 暴击率
        /// </summary>
        [JsonProperty("world_critical_rate")]
        public int WorldCriticalRate { get; set; } = 0;

        /// <summary>
        /// 暴击伤害
        /// </summary>
        [JsonProperty("world_critical_data")]
        public int WorldCriticalData { get; set; } = 0;

        /// <summary>
        /// 命中
        /// </summary>
        [JsonProperty("world_sure")]
        public int WorldSure { get; set; } = 0;

        /// <summary>
        /// 闪避
        /// </summary>
        [JsonProperty("world_evade")]
        public int WorldEvade { get; set; } = 0;

        /// <summary>
        /// 在线时间
        /// </summary>
        [JsonProperty("world_online_time")]
        public int WorldOnlineTime { get; set; } = 0;

        /// <summary>
        /// 属性点
        /// </summary>
        [JsonProperty("data_dot")]
        public int DataDot { get; set; } = 0;

        /// <summary>
        /// 注册时间
        /// </summary>
        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; } = DateTime.Parse("2024-01-28 14:52:26");

        /// <summary>
        /// 上次更新时间
        /// </summary>
        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; } = DateTime.Parse("2024-01-28 14:52:26");
    }
}
