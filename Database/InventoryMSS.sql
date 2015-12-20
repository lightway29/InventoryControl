CREATE DATABASE  IF NOT EXISTS `InventoryMSS` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `InventoryMSS`;
-- MySQL dump 10.13  Distrib 5.6.19, for osx10.7 (i386)
--
-- Host: localhost    Database: InventoryMSS
-- ------------------------------------------------------
-- Server version	5.6.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `materialorderheader`
--

DROP TABLE IF EXISTS `materialorderheader`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `materialorderheader` (
  `orderid` int(11) NOT NULL AUTO_INCREMENT,
  `orderdate` date DEFAULT NULL,
  `supplierid` int(11) DEFAULT NULL,
  `deliverydate` date DEFAULT NULL,
  `totalqty` double DEFAULT NULL,
  `memo` text,
  PRIMARY KEY (`orderid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materialorderheader`
--

LOCK TABLES `materialorderheader` WRITE;
/*!40000 ALTER TABLE `materialorderheader` DISABLE KEYS */;
INSERT INTO `materialorderheader` VALUES (1,'2015-12-19',1,'2015-12-08',3,'rffr');
/*!40000 ALTER TABLE `materialorderheader` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rawmaterial`
--

DROP TABLE IF EXISTS `rawmaterial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rawmaterial`
--

LOCK TABLES `rawmaterial` WRITE;
/*!40000 ALTER TABLE `rawmaterial` DISABLE KEYS */;
INSERT INTO `rawmaterial` VALUES (1,'item1','fdfds',NULL,NULL,NULL,NULL),(2,'item2','fdfdfdfdf',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `rawmaterial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `suppliers` (
  `supplierid` int(11) NOT NULL AUTO_INCREMENT,
  `suppliername` varchar(100) DEFAULT NULL,
  `telephone` int(20) DEFAULT NULL,
  `address` text,
  PRIMARY KEY (`supplierid`),
  UNIQUE KEY `UK_SUPPLIER` (`suppliername`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (5,'fdfer',423,'fdsdf');
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `userid` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `username` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  `usertype` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`userid`),
  UNIQUE KEY `UK_USERNAME` (`username`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (2,'admin','admin','123','Admin'),(3,'pqr','pqrst','123','User');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-12-20 12:08:21
