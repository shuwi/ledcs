/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50721
Source Host           : localhost:3306
Source Database       : ledscreen

Target Server Type    : MYSQL
Target Server Version : 50721
File Encoding         : 65001

Date: 2018-05-03 15:22:51
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for job
-- ----------------------------
DROP TABLE IF EXISTS `job`;
CREATE TABLE `job` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `jname` varchar(255) NOT NULL COMMENT '工种名',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for led_area
-- ----------------------------
DROP TABLE IF EXISTS `led_area`;
CREATE TABLE `led_area` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `led_id` int(11) NOT NULL COMMENT 'LED屏id',
  `left_begin` int(11) NOT NULL COMMENT '区域原点横坐标',
  `top_begin` int(11) NOT NULL COMMENT '区域原点的纵坐标',
  `width` int(11) NOT NULL COMMENT '区域宽度',
  `height` int(11) NOT NULL COMMENT '区域高度',
  `area_type` int(11) NOT NULL COMMENT '区域类型（1：多行文本输入，2：单行文本输入，3：数字时钟）',
  `module_type` varchar(11) NOT NULL COMMENT '输出模板类型（1：工种实时信息，2：人员进出场实时信息，3：统计数据）',
  `multi_nAlignment` int(11) DEFAULT NULL COMMENT '水平对齐样式，0.左对齐  1.右对齐  2.水平居中  （注意：只对字符串和txt文件有效）',
  `multi_IsVCenter` int(11) DEFAULT NULL COMMENT '是否垂直居中  0.置顶（默认） 1.垂直居中',
  `font_size` int(11) DEFAULT NULL COMMENT '字体大小',
  `font_bold` int(11) DEFAULT NULL COMMENT '是否加粗默认不加粗0，加粗1',
  `in_style` int(11) DEFAULT NULL COMMENT '进场动画',
  `delay_time` int(11) DEFAULT NULL COMMENT '页面留停时间(1-65535)',
  `speed` int(11) DEFAULT NULL COMMENT '动画的显示速度',
  `area_no` int(11) DEFAULT NULL COMMENT '区域号',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for led_info
-- ----------------------------
DROP TABLE IF EXISTS `led_info`;
CREATE TABLE `led_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'LED屏id',
  `led_ip` varchar(50) NOT NULL COMMENT 'led屏ip地址',
  `width` int(11) NOT NULL COMMENT '信息显示宽度',
  `height` int(11) NOT NULL COMMENT '信息显示的高',
  `project_name` varchar(200) DEFAULT NULL COMMENT '项目名称',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for led_module
-- ----------------------------
DROP TABLE IF EXISTS `led_module`;
CREATE TABLE `led_module` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `module_type` varchar(110) NOT NULL COMMENT '输出模板类型（1：工种实时信息，2：人员进出场实时信息，3：统计数据）',
  `module_text` longtext COMMENT '模板内容',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for project
-- ----------------------------
DROP TABLE IF EXISTS `project`;
CREATE TABLE `project` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL DEFAULT '项目名称',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for setting_info
-- ----------------------------
DROP TABLE IF EXISTS `setting_info`;
CREATE TABLE `setting_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `port` varchar(255) DEFAULT NULL,
  `baud_rate` varchar(255) DEFAULT NULL,
  `odd_even_valid` varchar(20) DEFAULT NULL,
  `tag` int(11) DEFAULT NULL COMMENT '进场串口tag=1；出场串口tag=2',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for worker
-- ----------------------------
DROP TABLE IF EXISTS `worker`;
CREATE TABLE `worker` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `identityId` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `contact` varchar(255) NOT NULL,
  `job` varchar(255) NOT NULL,
  `groupname` varchar(255) NOT NULL,
  `addtime` varchar(255) NOT NULL,
  `checkinState` int(2) NOT NULL,
  `checkinTime` datetime NOT NULL,
  `identityPhoto` longtext NOT NULL,
  `identityInfo` varchar(255) DEFAULT NULL,
  `screenConfigInfo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2285 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for workerinout
-- ----------------------------
DROP TABLE IF EXISTS `workerinout`;
CREATE TABLE `workerinout` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `identityId` varchar(255) NOT NULL,
  `checkinState` int(2) NOT NULL COMMENT '1：检入；0：检出',
  `checkinTime` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
