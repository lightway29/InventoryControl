/*
Navicat MySQL Data Transfer

Source Server         : MySQL_Local
Source Server Version : 50617
Source Host           : localhost:3306
Source Database       : inventory

Target Server Type    : MYSQL
Target Server Version : 50617
File Encoding         : 65001

Date: 2015-12-20 10:55:29
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `materialorderheader`
-- ----------------------------
DROP TABLE IF EXISTS `materialorderheader`;
CREATE TABLE `materialorderheader` (
  `orderid` int(11) NOT NULL AUTO_INCREMENT,
  `orderdate` date DEFAULT NULL,
  `supplierid` int(11) DEFAULT NULL,
  `deliverydate` date DEFAULT NULL,
  `totalqty` double DEFAULT NULL,
  `memo` text,
  PRIMARY KEY (`orderid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of materialorderheader
-- ----------------------------
INSERT INTO `materialorderheader` VALUES ('1', '2015-12-19', '1', '2015-12-08', '3', 'rffr');

-- ----------------------------
-- Table structure for `rawmaterial`
-- ----------------------------
DROP TABLE IF EXISTS `rawmaterial`;
CREATE TABLE `rawmaterial` (
  `materialid` int(11) NOT NULL AUTO_INCREMENT,
  `materialname` varchar(100) DEFAULT NULL,
  `description` text,
  `reorderlevel` varchar(100) DEFAULT NULL,
  `buyingprice` double DEFAULT NULL,
  `issueqty` double DEFAULT NULL,
  `materialtype` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`materialid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of rawmaterial
-- ----------------------------
INSERT INTO `rawmaterial` VALUES ('1', 'item1', 'fdfds', null, null, null, null);
INSERT INTO `rawmaterial` VALUES ('2', 'item2', 'fdfdfdfdf', null, null, null, null);

-- ----------------------------
-- Table structure for `suppliers`
-- ----------------------------
DROP TABLE IF EXISTS `suppliers`;
CREATE TABLE `suppliers` (
  `supplierid` int(11) NOT NULL AUTO_INCREMENT,
  `suppliername` varchar(100) DEFAULT NULL,
  `telephone` int(20) DEFAULT NULL,
  `address` text,
  PRIMARY KEY (`supplierid`),
  UNIQUE KEY `UK_SUPPLIER` (`suppliername`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of suppliers
-- ----------------------------
INSERT INTO `suppliers` VALUES ('5', 'fdfer', '423', 'fdsdf');

-- ----------------------------
-- Table structure for `users`
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `userid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `username` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  `usertype` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`userid`),
  UNIQUE KEY `UK_USERNAME` (`username`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('2', 'admin', 'admin', '123', 'Admin');
INSERT INTO `users` VALUES ('3', 'pqr', 'pqrst', '123', 'User');
