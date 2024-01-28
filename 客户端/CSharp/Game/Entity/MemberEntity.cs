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
        public string Uid { get; set; } = "";

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; } = "";

        /// <summary>
        /// 角色名
        /// </summary>
        public string Nickname { get; set; } = "未设置";
        /// <summary>
        /// 性别：1男，2女
        /// </summary>
        public int Sex { get; set; } = 1;

        /// <summary>
        /// Steam ID
        /// </summary>
        public string SteamId { get; set; } = "";

        /// <summary>
        /// 账号状态：1正常，0禁用
        /// </summary>
        public int AccountStatus { get; set; } = 1;

        /// <summary>
        /// 角色状态：1正常
        /// </summary>
        public int CharacterStatus { get; set; } = 1;

        /// <summary>
        /// 经验
        /// </summary>
        public int DataExp { get; set; } = 0;
        /// <summary>
        /// 运势：0-10
        /// </summary>
        public string DataFortune { get; set; } = "正常";

        /// <summary>
        /// 体力
        /// </summary>
        public int DataPhysical { get; set; } = 0;
        /// <summary>
        /// 最大体力
        /// </summary>
        public int DataPhysicalMax { get; set; } = 0;
        /// <summary>
        /// 境界ID
        /// </summary>
        public int LevelId { get; set; } = 0;
        /// <summary>
        /// 境界名称
        /// </summary>
        public string LevelTitle { get; set; } = "凡人境";

        /// <summary>
        /// 悟性
        /// </summary>
        public int DataInsight { get; set; } = 0;

        /// <summary>
        /// 金币
        /// </summary>
        public int DataGoldCoin { get; set; } = 0;

        /// <summary>
        /// 灵石
        /// </summary>
        public int DataSpiritStone { get; set; } = 0;

        /// <summary>
        /// 装备-法宝ID
        /// </summary>
        public int EquipSuperId { get; set; } = 0;

        /// <summary>
        /// 装备-头部ID
        /// </summary>
        public int EquipHeadId { get; set; } = 0;

        /// <summary>
        /// 装备-武器ID
        /// </summary>
        public int EquipWeaponId { get; set; } = 0;

        /// <summary>
        /// 装备-上衣ID
        /// </summary>
        public int EquipTopsId { get; set; } = 0;

        /// <summary>
        /// 装备-裤子ID
        /// </summary>
        public int EquipPantsId { get; set; } = 0;

        /// <summary>
        /// 装备-鞋子ID
        /// </summary>
        public int EquipShoesId { get; set; } = 0;

        /// <summary>
        /// 装备-饰品ID
        /// </summary>
        public int EquipJewelryId { get; set; } = 0;

        /// <summary>
        /// 称号ID
        /// </summary>
        public int MaskTitleId { get; set; } = 0;

        /// <summary>
        /// 称号
        /// </summary>
        public int MaskTitleName { get; set; } = 0;

        /// <summary>
        /// 血量
        /// </summary>
        public int WorldBlood { get; set; } = 0;

        /// <summary>
        /// 最大血量
        /// </summary>
        public int WorldBloodMax { get; set; } = 0;

        /// <summary>
        /// 物理攻击
        /// </summary>
        public int WorldAttackPhysics { get; set; } = 0;

        /// <summary>
        /// 法术攻击
        /// </summary>
        public int WorldAttackMagic { get; set; } = 0;

        /// <summary>
        /// 物理防御
        /// </summary>
        public int WorldDefensePhysics { get; set; } = 0;

        /// <summary>
        /// 法术防御
        /// </summary>
        public int WorldDefenseMagic { get; set; } = 0;

        /// <summary>
        /// 敏捷
        /// </summary>
        public int WorldSpeed { get; set; } = 1;

        /// <summary>
        /// 暴击率
        /// </summary>
        public int WorldCriticalRate { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public int WorldCriticalData { get; set; } = 0;

        /// <summary>
        /// 暴击伤害
        /// </summary>
        public int WorldSure { get; set; } = 0;

        /// <summary>
        /// 闪避
        /// </summary>
        public int WorldEvade { get; set; } = 0;

        /// <summary>
        /// 在线
        /// </summary>
        public int WorldOnlineTime { get; set; } = 0;

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Parse("2024-01-28 14:52:26");

        /// <summary>
        /// 上次刷新
        /// </summary>
        public DateTime UpdateTime { get; set; } = DateTime.Parse("2024-01-28 14:52:26");
    }
}
