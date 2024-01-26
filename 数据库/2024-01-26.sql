/*
 Navicat Premium Data Transfer

 Source Server         : 159.75.114.64
 Source Server Type    : MySQL
 Source Server Version : 80024
 Source Host           : 159.75.114.64:3306
 Source Schema         : xunxian

 Target Server Type    : MySQL
 Target Server Version : 80024
 File Encoding         : 65001

 Date: 26/01/2024 09:22:31
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for admin
-- ----------------------------
DROP TABLE IF EXISTS `admin`;
CREATE TABLE `admin`  (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT COMMENT '管理员ID',
  `is_admin` tinyint(1) NOT NULL DEFAULT 0,
  `username` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '' COMMENT '管理员用户名',
  `fullname` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `password` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '' COMMENT '管理员密码',
  `login_times` int UNSIGNED NOT NULL DEFAULT 0 COMMENT '登陆次数',
  `last_login_ip` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '' COMMENT '上次登陆ip',
  `last_login_time` datetime NOT NULL DEFAULT '0000-00-00 00:00:00' COMMENT '上次登陆时间',
  `status` tinyint(1) NOT NULL DEFAULT 1 COMMENT '1可用0禁用',
  `create_time` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `update_time` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of admin
-- ----------------------------
INSERT INTO `admin` VALUES (1, 1, 'admin', '王小明', '1011167e1b0ea796e242e8eb87fad5f9', 294, '127.0.0.1', '2024-01-07 12:14:08', 1, '2023-01-14 02:06:37', '2023-01-14 01:55:35', NULL);
INSERT INTO `admin` VALUES (2, 1, 'smallchen', '王小明', '1852dd3122f7aabd11d07bbfa91da5c3', 0, '', '0000-00-00 00:00:00', 1, '2024-01-07 11:38:37', '2024-01-07 12:00:01', NULL);

-- ----------------------------
-- Table structure for admin_auth_group
-- ----------------------------
DROP TABLE IF EXISTS `admin_auth_group`;
CREATE TABLE `admin_auth_group`  (
  `id` mediumint UNSIGNED NOT NULL AUTO_INCREMENT,
  `title` char(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `status` tinyint(1) NOT NULL DEFAULT 1,
  `rules` varchar(2000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of admin_auth_group
-- ----------------------------
INSERT INTO `admin_auth_group` VALUES (1, '超级管理员', 1, '1,2,3,10,11,12,4,15,16,7,17,18,5,20,21,22,23,6', '2023-01-13 21:11:49', '2024-01-07 11:04:23', NULL);

-- ----------------------------
-- Table structure for admin_auth_group_access
-- ----------------------------
DROP TABLE IF EXISTS `admin_auth_group_access`;
CREATE TABLE `admin_auth_group_access`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `uid` int NOT NULL,
  `group_id` int UNSIGNED NOT NULL,
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `uid`(`uid`) USING BTREE,
  INDEX `group_id`(`group_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 11 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of admin_auth_group_access
-- ----------------------------
INSERT INTO `admin_auth_group_access` VALUES (10, 2, 1, '2024-01-07 12:07:27', '2024-01-07 12:07:27', NULL);

-- ----------------------------
-- Table structure for admin_auth_rule
-- ----------------------------
DROP TABLE IF EXISTS `admin_auth_rule`;
CREATE TABLE `admin_auth_rule`  (
  `id` mediumint UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` char(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `title` char(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `type` tinyint(1) NOT NULL DEFAULT 1,
  `status` tinyint(1) NOT NULL DEFAULT 1,
  `condition` char(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `pid` int NOT NULL DEFAULT 0,
  `css` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `sort` int NOT NULL DEFAULT 50,
  `is_show` tinyint NOT NULL DEFAULT 1,
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `name`(`name`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 32 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of admin_auth_rule
-- ----------------------------
INSERT INTO `admin_auth_rule` VALUES (1, '#', '系统设置', 1, 1, '', 0, '', 0, 1, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (2, 'config/config', '系统配置', 1, 1, '', 1, '', 0, 1, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (3, 'task/index', '系统任务', 1, 1, '', 1, '', 1, 1, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (4, 'role/index', '权限管理', 1, 1, '', 1, '', 2, 1, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (5, 'admin/index', '用户管理', 1, 1, '', 1, '', 3, 1, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (6, 'config/clear', '清理缓存', 1, 1, '', 1, '', 4, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (7, 'role/auth', '配置权限', 1, 1, '', 4, '', 5, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (8, '#', '应用管理', 1, 1, '', 0, '', 1, 1, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (9, 'tags/index', '标签管理', 1, 1, '', 8, '', 1, 1, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (10, 'task/status', '修改状态', 1, 1, '', 3, '', 1, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (11, 'task/update', '新增修改', 1, 1, '', 3, '', 2, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (12, 'task/delete', '删除', 1, 1, '', 3, '', 3, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (13, 'task/index', '列表', 1, 0, '', 3, '', 0, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (14, 'role/index', '列表', 1, 0, '', 4, '', 0, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (15, 'role/update', '新增修改', 1, 1, '', 4, '', 1, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (16, 'role/delete', '删除', 1, 1, '', 4, '', 2, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (17, 'role/auth', '配置权限', 1, 1, '', 7, '', 3, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (18, 'role/getnodes', '加载权限', 1, 1, '', 7, '', 4, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (19, 'admin/index', '列表', 1, 0, '', 5, '', 0, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (20, 'admin/status', '修改状态', 1, 1, '', 5, '', 1, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (21, 'admin/update', '新增修改', 1, 1, '', 5, '', 2, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (22, 'admin/delete', '删除', 1, 1, '', 5, '', 3, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (23, 'admin/password', '修改密码', 1, 1, '', 5, '', 4, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (24, 'tags/index', '列表', 1, 0, '', 9, '', 0, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (25, 'tags/update', '新增修改', 1, 1, '', 9, '', 1, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (26, 'tags/delete', '删除', 1, 1, '', 9, '', 2, 0, '2023-01-14 03:15:11', '2023-01-14 03:15:11', NULL);
INSERT INTO `admin_auth_rule` VALUES (27, 'dict/index', '数据字典', 1, 1, '', 8, '', 2, 1, '2023-07-12 11:00:07', '2023-07-12 11:00:08', NULL);
INSERT INTO `admin_auth_rule` VALUES (28, 'dict/update', '新增修改', 1, 1, '', 27, '', 1, 0, '2023-07-12 11:08:52', '2023-07-12 11:08:54', NULL);
INSERT INTO `admin_auth_rule` VALUES (29, 'dict/status', '修改状态', 1, 1, '', 27, '', 2, 0, '2023-07-12 11:09:12', '2023-07-12 11:09:14', NULL);
INSERT INTO `admin_auth_rule` VALUES (30, 'dict/delete', '删除', 1, 1, '', 27, '', 3, 0, '2023-07-12 11:09:35', '2023-07-12 11:09:36', NULL);
INSERT INTO `admin_auth_rule` VALUES (31, 'dict/refresh', '重载', 1, 1, '', 27, '', 4, 0, '2023-07-12 11:10:03', '2023-07-12 11:10:04', NULL);

-- ----------------------------
-- Table structure for config
-- ----------------------------
DROP TABLE IF EXISTS `config`;
CREATE TABLE `config`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '配置名称',
  `type` tinyint NOT NULL DEFAULT 0 COMMENT '配置类型',
  `title` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '配置说明',
  `group` tinyint NOT NULL DEFAULT 0 COMMENT '配置分组',
  `extra` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '配置值',
  `data` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `desc` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '配置说明',
  `status` smallint NOT NULL DEFAULT 0,
  `sort` smallint NOT NULL COMMENT '排序',
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `name`(`name`) USING BTREE,
  INDEX `type`(`type`) USING BTREE,
  INDEX `group`(`group`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '系统配置表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of config
-- ----------------------------
INSERT INTO `config` VALUES (1, 'site_title', 1, '网站标题', 1, '', '修仙的女儿', '网站标题', 1, 0, '2023-05-10 16:42:50', '2023-05-10 16:42:50', NULL);
INSERT INTO `config` VALUES (2, 'site_status', 4, '系统状态', 2, '0:关闭,1:开启', '1', '站点状态', 1, 0, '2023-05-10 16:42:50', '2023-05-10 16:42:50', NULL);
INSERT INTO `config` VALUES (3, 'upload_file_size', 2, '上传文件大小', 3, '', '2', '上传文件大小最大为 ？ 兆', 1, 0, '2023-06-01 09:19:37', '2023-06-01 09:19:39', NULL);
INSERT INTO `config` VALUES (4, 'upload_file_ext', 1, '上传文件格式', 3, '', 'gif,png,jpg,jpeg', '上传文件格式限制', 1, 0, '2023-06-01 09:20:25', '2023-06-01 09:20:27', NULL);
INSERT INTO `config` VALUES (5, 'register_status', 4, '开放注册', 2, '0:关闭,1:开放', '1', '是否开放注册', 1, 0, '2023-08-30 09:14:13', '2023-08-30 09:14:15', NULL);

-- ----------------------------
-- Table structure for dict
-- ----------------------------
DROP TABLE IF EXISTS `dict`;
CREATE TABLE `dict`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `status` smallint NOT NULL DEFAULT 1,
  `desc` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `type` tinyint NOT NULL COMMENT '1:文本;2整数;3小数;4真假;5数组;6枚举',
  `data` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `name`(`name`) USING BTREE,
  INDEX `status`(`status`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '数据字典' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dict
-- ----------------------------
INSERT INTO `dict` VALUES (1, '测试', 'test', 1, '测试', 2, '1', '2024-01-07 12:12:02', '2024-01-07 12:12:07', NULL);

-- ----------------------------
-- Table structure for feedback
-- ----------------------------
DROP TABLE IF EXISTS `feedback`;
CREATE TABLE `feedback`  (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `member_uid` char(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `member_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `desc` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `reply` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `member_uid`(`member_uid`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '反馈表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of feedback
-- ----------------------------

-- ----------------------------
-- Table structure for log_exception
-- ----------------------------
DROP TABLE IF EXISTS `log_exception`;
CREATE TABLE `log_exception`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `uid` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `file` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `line` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `message` varchar(2000) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '异常日志' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of log_exception
-- ----------------------------

-- ----------------------------
-- Table structure for member
-- ----------------------------
DROP TABLE IF EXISTS `member`;
CREATE TABLE `member`  (
  `uid` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `account` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '账号',
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '密码',
  `nickname` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '角色名',
  `sex` int NOT NULL DEFAULT 0 COMMENT '性别：1男2女',
  `steam_id` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT 'STEAMID',
  `account_status` smallint NOT NULL DEFAULT 1 COMMENT '账号状态',
  `character_status` smallint NOT NULL DEFAULT 1 COMMENT '角色状态',
  `level_id` int NOT NULL DEFAULT 0 COMMENT '境界ID',
  `data_exp` int NOT NULL DEFAULT 0 COMMENT '经验',
  `data_insight` int NOT NULL DEFAULT 1 COMMENT '悟性',
  `data_fortune` int NOT NULL DEFAULT 0 COMMENT '运势',
  `data_physical` int NOT NULL DEFAULT 0 COMMENT '体力',
  `data_physical_max` int NOT NULL DEFAULT 0 COMMENT '最大体力',
  `data_gold_coin` int NOT NULL DEFAULT 0 COMMENT '金币',
  `data_spirit_stone` int NOT NULL DEFAULT 0 COMMENT '灵石',
  `equip_super_id` int NOT NULL DEFAULT 0 COMMENT '装备-法宝ID',
  `equip_head_id` int NOT NULL DEFAULT 0 COMMENT '装备-头部ID',
  `equip_weapon_id` int NOT NULL DEFAULT 0 COMMENT '装备-武器ID',
  `equip_tops_id` int NOT NULL DEFAULT 0 COMMENT '装备-上衣ID',
  `equip_pants_id` int NOT NULL DEFAULT 0 COMMENT '装备-裤子ID',
  `equip_shoes_id` int NOT NULL DEFAULT 0 COMMENT '装备-鞋子ID',
  `equip_jewelry_id` int NOT NULL DEFAULT 0 COMMENT '装备-饰品ID',
  `mask_title_id` int NOT NULL DEFAULT 0 COMMENT '称号ID',
  `mask_title_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '称号名称',
  `world_blood` int NOT NULL DEFAULT 0 COMMENT '血量',
  `world_blood_max` int NOT NULL DEFAULT 0 COMMENT '最大血量',
  `world_attack_physics` int NOT NULL DEFAULT 0 COMMENT '物理攻击',
  `world_attack_magic` int NOT NULL DEFAULT 0 COMMENT '法术攻击',
  `world_defense_physics` int NOT NULL DEFAULT 0 COMMENT '物理防御',
  `world_defense_magic` int NOT NULL DEFAULT 0 COMMENT '法术防御',
  `world_speed` int NOT NULL DEFAULT 1 COMMENT '敏捷',
  `world_critical_rate` int NOT NULL DEFAULT 0 COMMENT '暴击率',
  `world_critical_data` int NOT NULL DEFAULT 0 COMMENT '暴击伤害',
  `world_sure` int NOT NULL DEFAULT 0 COMMENT '命中率',
  `world_evade` int NOT NULL DEFAULT 0 COMMENT '闪避率',
  `world_online_time` int NOT NULL DEFAULT 0 COMMENT '在线时间',
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`uid`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '玩家表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of member
-- ----------------------------

-- ----------------------------
-- Table structure for member_apply
-- ----------------------------
DROP TABLE IF EXISTS `member_apply`;
CREATE TABLE `member_apply`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `type` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `from_member_uid` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `to_member_uid` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `title` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `apply_sr` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `reply_str` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `status` smallint NOT NULL DEFAULT 0 COMMENT '状态：0挂起；1成功；-1失败',
  `other` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '申请类表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of member_apply
-- ----------------------------

-- ----------------------------
-- Table structure for member_friend
-- ----------------------------
DROP TABLE IF EXISTS `member_friend`;
CREATE TABLE `member_friend`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `member_uid` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `type` char(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'friend',
  `friend_member_uid` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `favors` int NOT NULL DEFAULT 0,
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '用户好感度' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of member_friend
-- ----------------------------

-- ----------------------------
-- Table structure for member_garden
-- ----------------------------
DROP TABLE IF EXISTS `member_garden`;
CREATE TABLE `member_garden`  (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `member_uid` char(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `position` int NOT NULL DEFAULT 0,
  `level` int NOT NULL DEFAULT 0,
  `status` smallint NOT NULL DEFAULT 0 COMMENT '0未种植；1已种植',
  `end_time` datetime NULL DEFAULT NULL,
  `result` int NOT NULL DEFAULT 3,
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `member_uid`(`member_uid`) USING BTREE,
  INDEX `status`(`status`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '用户花园表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of member_garden
-- ----------------------------

-- ----------------------------
-- Table structure for member_package
-- ----------------------------
DROP TABLE IF EXISTS `member_package`;
CREATE TABLE `member_package`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `stuff_id` int NOT NULL DEFAULT 0,
  `stock` int NOT NULL DEFAULT 1,
  `stuff_key` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `stuff_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `stuff_desc` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `stuff_data` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '{}',
  `stuff_sale_money` int NOT NULL DEFAULT 1,
  `stuff_is_accum` tinyint NOT NULL DEFAULT 0,
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '背包' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of member_package
-- ----------------------------

-- ----------------------------
-- Table structure for member_title
-- ----------------------------
DROP TABLE IF EXISTS `member_title`;
CREATE TABLE `member_title`  (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `member_uid` char(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `title_id` int NOT NULL,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `color` char(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `member_uid`(`member_uid`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '用户称号表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of member_title
-- ----------------------------

-- ----------------------------
-- Table structure for member_world_channal
-- ----------------------------
DROP TABLE IF EXISTS `member_world_channal`;
CREATE TABLE `member_world_channal`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `member_uid` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `channal_key` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '玩家通道订阅表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of member_world_channal
-- ----------------------------

-- ----------------------------
-- Table structure for stuff
-- ----------------------------
DROP TABLE IF EXISTS `stuff`;
CREATE TABLE `stuff`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `cate_id_1` int NOT NULL DEFAULT 0,
  `cate_id_2` int NOT NULL DEFAULT 0,
  `key` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `desc` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `data` varchar(2000) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '{}',
  `status` smallint NOT NULL DEFAULT 1,
  `buy_money` int NOT NULL DEFAULT 1,
  `sale_money` int NOT NULL DEFAULT 1,
  `stock` int NOT NULL DEFAULT 0,
  `is_show` tinyint NOT NULL DEFAULT 1,
  `is_accum` tinyint NOT NULL DEFAULT 0 COMMENT '是否累计',
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `cate_id_1`(`cate_id_1`) USING BTREE,
  INDEX `cate_id_2`(`cate_id_2`) USING BTREE,
  INDEX `is_show`(`is_show`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '商店表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of stuff
-- ----------------------------

-- ----------------------------
-- Table structure for system_crontab
-- ----------------------------
DROP TABLE IF EXISTS `system_crontab`;
CREATE TABLE `system_crontab`  (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `title` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '任务标题',
  `type` tinyint(1) NOT NULL DEFAULT 1 COMMENT '任务类型 (1 command, 2 class, 3 url, 4 eval)',
  `rule` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '任务执行表达式',
  `target` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '' COMMENT '调用任务字符串',
  `parameter` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '任务调用参数',
  `running_times` int NOT NULL DEFAULT 0 COMMENT '已运行次数',
  `last_running_time` int NOT NULL DEFAULT 0 COMMENT '上次运行时间',
  `remark` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '备注',
  `sort` int NOT NULL DEFAULT 0 COMMENT '排序，越大越前',
  `status` tinyint NOT NULL DEFAULT 0 COMMENT '任务状态状态[0:禁用;1启用]',
  `create_time` int NOT NULL DEFAULT 0 COMMENT '创建时间',
  `update_time` int NOT NULL DEFAULT 0 COMMENT '更新时间',
  `singleton` tinyint(1) NOT NULL DEFAULT 1 COMMENT '是否单次执行 (0 是 1 不是)',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `title`(`title`) USING BTREE,
  INDEX `create_time`(`create_time`) USING BTREE,
  INDEX `status`(`status`) USING BTREE,
  INDEX `type`(`type`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '定时器任务表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of system_crontab
-- ----------------------------
INSERT INTO `system_crontab` VALUES (1, '测试', 3, '0 1 0 0 0 0', 'http://www.baidu.com', '{}', 0, 0, '', 50, 1, 1704609938, 1704609938, 1);
INSERT INTO `system_crontab` VALUES (2, '测试2', 3, '30 0 0 0 0 0', 'http://blog.abug.cc', '{}', 0, 0, 'ch', 50, 1, 1704611711, 1704611711, 1);

-- ----------------------------
-- Table structure for system_crontab_log
-- ----------------------------
DROP TABLE IF EXISTS `system_crontab_log`;
CREATE TABLE `system_crontab_log`  (
  `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  `crontab_id` bigint UNSIGNED NOT NULL COMMENT '任务id',
  `target` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '任务调用目标字符串',
  `parameter` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '任务调用参数',
  `exception` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL COMMENT '任务执行或者异常信息输出',
  `return_code` tinyint(1) NOT NULL DEFAULT 0 COMMENT '执行返回状态[0成功; 1失败]',
  `running_time` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '执行所用时间',
  `create_time` int NOT NULL DEFAULT 0 COMMENT '创建时间',
  `update_time` int NOT NULL DEFAULT 0 COMMENT '更新时间',
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `create_time`(`create_time`) USING BTREE,
  INDEX `crontab_id`(`crontab_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '定时器任务执行日志表' ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of system_crontab_log
-- ----------------------------

-- ----------------------------
-- Table structure for tags
-- ----------------------------
DROP TABLE IF EXISTS `tags`;
CREATE TABLE `tags`  (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `key` char(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' COMMENT '键',
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' COMMENT '标题',
  `content` longtext CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '内容',
  `create_time` datetime NOT NULL COMMENT '创建时间',
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `key`(`key`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '标签表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tags
-- ----------------------------

-- ----------------------------
-- Table structure for title_main
-- ----------------------------
DROP TABLE IF EXISTS `title_main`;
CREATE TABLE `title_main`  (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `color` char(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `is_special` tinyint NOT NULL DEFAULT 0,
  `get_type` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `special_effect` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '称号表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of title_main
-- ----------------------------

-- ----------------------------
-- Table structure for uploads
-- ----------------------------
DROP TABLE IF EXISTS `uploads`;
CREATE TABLE `uploads`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `path` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' COMMENT '图片路径',
  `hash` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '' COMMENT '文件hash值',
  `disk` char(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `type` char(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `hash`(`hash`) USING BTREE,
  INDEX `disk`(`disk`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci COMMENT = '文件表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of uploads
-- ----------------------------

-- ----------------------------
-- Table structure for world_channel
-- ----------------------------
DROP TABLE IF EXISTS `world_channel`;
CREATE TABLE `world_channel`  (
  `key` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `status` smallint NOT NULL DEFAULT 1,
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`key`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '聊天通道' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of world_channel
-- ----------------------------

-- ----------------------------
-- Table structure for world_chat
-- ----------------------------
DROP TABLE IF EXISTS `world_chat`;
CREATE TABLE `world_chat`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `channel` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `member_uid` char(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `message_type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `message_data` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `create_time` datetime NULL DEFAULT NULL,
  `update_time` datetime NULL DEFAULT NULL,
  `delete_time` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '世界聊天表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of world_chat
-- ----------------------------

SET FOREIGN_KEY_CHECKS = 1;
