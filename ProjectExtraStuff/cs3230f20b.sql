-- phpMyAdmin SQL Dump
-- version 4.9.7
-- https://www.phpmyadmin.net/
--
-- Host: 160.10.25.16:3306
-- Generation Time: Nov 23, 2020 at 09:11 AM
-- Server version: 5.7.32-log
-- PHP Version: 7.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cs3230f20b`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`ddupree2`@`%` PROCEDURE `login_verifyLogin` (IN `id` VARCHAR(30), IN `pass` VARCHAR(20))  NO SQL
select eID
from login 
where eID = id and password = SHA(pass)$$

$$

$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `address`
--

CREATE TABLE `address` (
  `addressID` int(11) NOT NULL,
  `addr1` varchar(45) NOT NULL,
  `addr2` varchar(45) DEFAULT NULL,
  `city` varchar(45) NOT NULL,
  `state` varchar(45) NOT NULL,
  `zip` int(11) NOT NULL,
  `contactNum` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `address`
--

INSERT INTO `address` (`addressID`, `addr1`, `addr2`, `city`, `state`, `zip`, `contactNum`) VALUES
(1, '123 wallaby way', NULL, 'Fayetteville', 'GA', 30213, '3455443445'),
(2, '184 sydney way', NULL, 'Carrollton', 'GA', 30245, '2938473245'),
(3, '475 carpenter trail', NULL, 'Wyndon', 'GA', 32456, '2343418574'),
(4, '687 magic lane', NULL, 'Fillabank', 'GA', 30012, '6473849399'),
(5, '675 MLK Blvd', NULL, 'Atlanta', 'GA', 30013, '4043327465'),
(6, '144 peachtree st', NULL, 'Atlanta', 'GA', 30034, '4043772849'),
(33, '123 willow lane', NULL, 'Franklin City', 'CA', 23444, '2143424434'),
(34, '105 Mary Way', NULL, 'GoergeTown', 'MS', 12334, '1232322242'),
(36, 'merry lane', NULL, 'adaf', 'CA', 16516, '1632159122'),
(37, 'jaklfd;jakl', NULL, 'kaj;dfklal;lkj', 'CA', 32229, '6666665555'),
(38, '21312 fds', '12313', '21312', 'MT', 21321, '2323123123'),
(39, '323', '313', '12311312', 'MO', 23213, '2132313312'),
(40, 'dsds', 'sad', 'sdf', 'MT', 22333, '2343242342'),
(41, '122 Darrius Address', NULL, 'Darrius\'s City', 'MO', 12223, '1223231232');

-- --------------------------------------------------------

--
-- Table structure for table `administrator`
--

CREATE TABLE `administrator` (
  `adminID` varchar(20) NOT NULL,
  `eID` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `administrator`
--

INSERT INTO `administrator` (`adminID`, `eID`) VALUES
('8847736251', '4657748329'),
('1128374635', '6857664382');

-- --------------------------------------------------------

--
-- Table structure for table `appointment`
--

CREATE TABLE `appointment` (
  `appointmentdate` datetime NOT NULL,
  `reason` varchar(300) NOT NULL,
  `doctorID` varchar(20) NOT NULL,
  `patientID` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `appointment`
--

INSERT INTO `appointment` (`appointmentdate`, `reason`, `doctorID`, `patientID`) VALUES
('2020-07-13 21:04:58', 'HElp', '1239485746', '908434301'),
('2020-10-10 12:00:00', 'Help me I\'m sick', '3352435465', '908434301'),
('2020-10-14 08:30:00', 'ds', '3352435465', '15047899'),
('2020-10-14 20:56:10', 'This is a test reason', '3352435465', '15047899'),
('2020-10-15 20:51:46', 'This is a test reason', '3352435465', '15047899'),
('2020-10-21 07:00:00', 'asds', '3352435465', '908434301'),
('2020-10-21 07:30:00', 'sdda', '3352435465', '908434301'),
('2020-10-21 09:00:00', 'asds', '3352435465', '908434301'),
('2020-10-24 20:50:12', 'Help I\'m in pain', '1239485746', '908434301'),
('2020-10-24 20:58:23', 'test', '3352435465', '573186703'),
('2020-10-24 20:58:28', 'sadda', '3352435465', '573186703'),
('2020-10-26 18:04:44', 'asdsda', '1239485746', '908434301'),
('2020-10-27 07:30:00', 'ewq', '3352435465', '908434301'),
('2020-10-31 07:30:00', 'asd updated', '3352435465', '908434301'),
('2020-11-03 13:00:00', 'surgery complications', '1239485746', '982890231'),
('2020-11-06 07:30:00', 'sda', '3352435465', '982890231'),
('2020-11-11 09:30:00', 'asda', '3352435465', '982890231'),
('2020-11-14 07:30:00', 'aS', '3352435465', '451537611'),
('2020-11-15 07:00:00', 'aasdasd', '3352435465', '960855467'),
('2020-11-16 11:30:00', 'werty', '3352435465', '960855467'),
('2020-11-19 16:00:00', 'l;kjjdlks\r\nasdfa\r\nasdf\r\n45564456465441\r\n34854', '3352435465', '15047899'),
('2020-11-20 07:00:00', 'fsdg', '1239485746', '451537611'),
('2020-11-20 07:00:00', 'bad news', '3352435465', '908434301'),
('2020-11-22 07:30:00', 'I\'m sick', '3352435465', '753444088'),
('2021-01-20 08:00:00', 'test 2332', '1239485746', '573186703'),
('2021-02-06 09:00:00', 'Update', '1239485746', '573186703');

-- --------------------------------------------------------

--
-- Table structure for table `doctor`
--

CREATE TABLE `doctor` (
  `doctorID` varchar(20) NOT NULL,
  `eID` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `doctor`
--

INSERT INTO `doctor` (`doctorID`, `eID`) VALUES
('3352435465', '9458674632'),
('1239485746', '9938273645');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `eID` varchar(20) NOT NULL,
  `fname` varchar(45) NOT NULL,
  `lname` varchar(45) NOT NULL,
  `addressID` int(11) NOT NULL,
  `dob` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`eID`, `fname`, `lname`, `addressID`, `dob`) VALUES
('1928374625', 'Jane', 'Mary', 1, '1992-02-03'),
('4657748329', 'Anthony', 'Miller', 6, '1992-02-03'),
('6857664382', 'Jessica', 'Jewels', 5, '1992-02-03'),
('8473624958', 'Michael', 'Ryan', 2, '1992-02-03'),
('9458674632', 'Josh', 'Abel', 3, '1992-02-03'),
('9938273645', 'Marissa', 'Ann', 4, '1992-02-03');

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `password` varchar(40) NOT NULL,
  `eID` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`password`, `eID`) VALUES
('1b346866060b7f594488cf03ab2ae7c8af9af0c6', '1928374625'),
('2023c22805b5ab2204ecc5c52842e09aff5b7eef', '4657748329'),
('56afb6e6da10c5067a7bddd7dc92893bfee8f70c', '6857664382'),
('a414a9794d8157a1c464d6cac96052268fed5eb0', '8473624958'),
('e14d8049fe2f606777d41018f6bf15687afde583', '9458674632'),
('a2add38a7f86eee017e0a044eb4a5cb71c5f3364', '9938273645');

-- --------------------------------------------------------

--
-- Table structure for table `nurse`
--

CREATE TABLE `nurse` (
  `nurseID` varchar(20) NOT NULL,
  `eID` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `nurse`
--

INSERT INTO `nurse` (`nurseID`, `eID`) VALUES
('77283746253', '1928374625'),
('88374635241', '8473624958');

-- --------------------------------------------------------

--
-- Table structure for table `patient`
--

CREATE TABLE `patient` (
  `patientID` varchar(20) NOT NULL,
  `lname` varchar(45) NOT NULL,
  `fname` varchar(45) NOT NULL,
  `addressID` int(11) NOT NULL,
  `sex` varchar(25) NOT NULL,
  `ssn` varchar(9) NOT NULL,
  `dob` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `patient`
--

INSERT INTO `patient` (`patientID`, `lname`, `fname`, `addressID`, `sex`, `ssn`, `dob`) VALUES
('15047899', 'Perry', 'Mike', 36, 'Male', '777777777', '2020-10-04'),
('451537611', 'asd', 'sad', 38, 'Female', '123123123', '2020-11-11'),
('573186703', 'Perrys', 'Mike', 37, 'Male', '888888889', '2020-10-01'),
('753444088', 'Dupree\'s', 'Darrius', 41, 'Male', '288293938', '2020-10-30'),
('848219723', 'asd', 'asd', 39, 'Female', '112312312', '2020-11-11'),
('908434301', 'Perrys', 'Mike', 33, 'Male', '123124324', '2020-10-04'),
('960855467', 'Name', 'Test', 40, 'Male', '888377366', '2020-11-15'),
('982890231', 'Kay', 'Mary', 34, 'Female', '123234335', '2018-08-15');

-- --------------------------------------------------------

--
-- Table structure for table `specialty`
--

CREATE TABLE `specialty` (
  `specialty` varchar(50) NOT NULL,
  `doctorID` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `specialty`
--

INSERT INTO `specialty` (`specialty`, `doctorID`) VALUES
('Cardiology', '1239485746'),
('General', '3352435465');

-- --------------------------------------------------------

--
-- Table structure for table `test`
--

CREATE TABLE `test` (
  `testCode` int(11) NOT NULL,
  `testName` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `test`
--

INSERT INTO `test` (`testCode`, `testName`) VALUES
(74, 'hepatitis A'),
(94, 'hepatitis B'),
(48, 'LDL'),
(83, 'Mineral Tests'),
(34, 'WBC');

-- --------------------------------------------------------

--
-- Table structure for table `testResults`
--

CREATE TABLE `testResults` (
  `testdate` date DEFAULT NULL,
  `results` varchar(100) DEFAULT NULL,
  `appointmentdate` datetime NOT NULL,
  `patientID` varchar(20) NOT NULL,
  `testCode` int(11) NOT NULL,
  `AbnormalStatus` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `testResults`
--

INSERT INTO `testResults` (`testdate`, `results`, `appointmentdate`, `patientID`, `testCode`, `AbnormalStatus`) VALUES
(NULL, NULL, '2020-07-13 21:04:58', '908434301', 48, NULL),
(NULL, NULL, '2020-07-13 21:04:58', '908434301', 74, NULL),
(NULL, NULL, '2020-07-13 21:04:58', '908434301', 94, NULL),
(NULL, NULL, '2020-10-21 07:30:00', '908434301', 48, NULL),
(NULL, NULL, '2020-10-21 07:30:00', '908434301', 74, NULL),
(NULL, NULL, '2020-10-21 07:30:00', '908434301', 94, NULL),
('2020-11-12', '3233', '2020-10-24 20:58:23', '573186703', 34, 0),
('2020-11-12', '323', '2020-10-24 20:58:23', '573186703', 48, 1),
('2020-11-12', 'werrttr', '2020-10-24 20:58:23', '573186703', 74, 1),
('2020-11-28', '333', '2020-10-24 20:58:23', '573186703', 83, 1),
('2020-11-12', '3', '2020-10-24 20:58:28', '573186703', 48, 1),
('2020-11-25', 'asd', '2020-11-15 07:00:00', '960855467', 48, 0),
('2020-11-15', 'asd', '2020-11-15 07:00:00', '960855467', 74, 1),
('2020-11-28', 'asd', '2020-11-15 07:00:00', '960855467', 94, 0),
('2020-11-19', 'goodish', '2020-11-16 11:30:00', '960855467', 48, 1),
('2020-11-16', 'bad', '2020-11-16 11:30:00', '960855467', 94, 0),
('2020-12-03', 'updated', '2020-11-22 07:30:00', '753444088', 74, 1),
('2020-11-22', 'sdsd', '2020-11-22 07:30:00', '753444088', 83, 0);

-- --------------------------------------------------------

--
-- Table structure for table `visit`
--

CREATE TABLE `visit` (
  `systolicNum` int(11) NOT NULL,
  `diastolicNum` int(11) NOT NULL,
  `heartrate` int(11) NOT NULL,
  `respirationrate` int(11) NOT NULL,
  `bodytemp` double NOT NULL,
  `weight` double NOT NULL,
  `other` varchar(300) NOT NULL,
  `nurseID` varchar(20) NOT NULL,
  `appointmentdate` datetime NOT NULL,
  `patientID` varchar(20) NOT NULL,
  `diagnosis` varchar(100) NOT NULL,
  `FinalDiagnosis` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `visit`
--

INSERT INTO `visit` (`systolicNum`, `diastolicNum`, `heartrate`, `respirationrate`, `bodytemp`, `weight`, `other`, `nurseID`, `appointmentdate`, `patientID`, `diagnosis`, `FinalDiagnosis`) VALUES
(0, 0, 0, 0, 0, 145.73, '', '77283746253', '2020-07-13 21:04:58', '908434301', '', 0),
(104, 20, 45, 95, 98.7, 234.43, '', '77283746253', '2020-10-10 12:00:00', '908434301', 'Final', 1),
(12, 12, 12, 12, 12, 234.3, '1212', '77283746253', '2020-10-14 08:30:00', '15047899', '2121', 0),
(43, 34, 33, 23, 23, 145.32, 'wda', '88374635241', '2020-10-14 20:56:10', '15047899', 'asdw', 1),
(145, 20, 74, 92, 98.8, 193.43, '', '88374635241', '2020-10-15 20:51:46', '15047899', '', 0),
(12, 12, 12, 12, 12, 122.1, '12', '77283746253', '2020-10-21 07:00:00', '908434301', '12', 0),
(0, 0, 0, 0, 0, 192.32, '', '77283746253', '2020-10-21 07:30:00', '908434301', '', 0),
(140, 20, 60, 96, 97.8, 123.22, 'asd', '88374635241', '2020-10-24 20:50:12', '908434301', 'sds', 1),
(140, 30, 75, 95, 97.5, 120.32, 'nothing', '77283746253', '2020-10-24 20:58:23', '573186703', 'no diagnosis\r\nFinal', 0),
(145, 40, 65, 97, 98.8, 122.21, '', '88374635241', '2020-10-24 20:58:28', '573186703', '', 0),
(12, 12, 2, 12, 12, 123.23, '212', '77283746253', '2020-10-31 07:30:00', '908434301', '1212', 0),
(12, 21, 12, 132, 12, 123.33, '21', '77283746253', '2020-11-03 13:00:00', '982890231', '21', 1),
(12, 1212, 12, 2, 2, 114.42, '212', '77283746253', '2020-11-06 07:30:00', '982890231', '121', 1),
(12, 12, 12, 12, 12, 143.65, '12', '77283746253', '2020-11-11 09:30:00', '982890231', '21', 1),
(12, 2, 12, 12, 12, 176.34, '2121', '77283746253', '2020-11-15 07:00:00', '960855467', '1212', 0),
(45, 122, 45, 45454, 54.2, 192.32, 'opij', '77283746253', '2020-11-16 11:30:00', '960855467', 'lk;;kl;lkasdjflkasdj;', 1),
(1, 2, 3, 4, 5, 67.1, 'He\'s sick', '88374635241', '2020-11-22 07:30:00', '753444088', 'help him', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`addressID`),
  ADD UNIQUE KEY `addr1_zipUNIQUE` (`addr1`,`zip`);

--
-- Indexes for table `administrator`
--
ALTER TABLE `administrator`
  ADD PRIMARY KEY (`adminID`),
  ADD KEY `fk_administrator_employee1` (`eID`);

--
-- Indexes for table `appointment`
--
ALTER TABLE `appointment`
  ADD PRIMARY KEY (`appointmentdate`,`patientID`),
  ADD KEY `fk_appointment_doctor1_idx` (`doctorID`),
  ADD KEY `fk_appointment_patient1_idx` (`patientID`);

--
-- Indexes for table `doctor`
--
ALTER TABLE `doctor`
  ADD PRIMARY KEY (`doctorID`),
  ADD KEY `fk_doctor_employee1` (`eID`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`eID`),
  ADD KEY `fk_employee_address1_idx` (`addressID`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`eID`),
  ADD KEY `fk_table1_employee_idx` (`eID`);

--
-- Indexes for table `nurse`
--
ALTER TABLE `nurse`
  ADD PRIMARY KEY (`nurseID`),
  ADD KEY `fk_nurse_employee1` (`eID`);

--
-- Indexes for table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`patientID`),
  ADD KEY `fk_patient_address1_idx` (`addressID`);

--
-- Indexes for table `specialty`
--
ALTER TABLE `specialty`
  ADD PRIMARY KEY (`specialty`,`doctorID`),
  ADD KEY `fk_specialty_doctor1_idx` (`doctorID`);

--
-- Indexes for table `test`
--
ALTER TABLE `test`
  ADD PRIMARY KEY (`testCode`),
  ADD UNIQUE KEY `testName_UNIQUE` (`testName`),
  ADD UNIQUE KEY `testCode_UNIQUE` (`testCode`);

--
-- Indexes for table `testResults`
--
ALTER TABLE `testResults`
  ADD PRIMARY KEY (`appointmentdate`,`patientID`,`testCode`) USING BTREE,
  ADD KEY `fk_testResults_visit1_idx` (`appointmentdate`,`patientID`),
  ADD KEY `fk_testResults_test1_idx` (`testCode`);

--
-- Indexes for table `visit`
--
ALTER TABLE `visit`
  ADD PRIMARY KEY (`appointmentdate`,`patientID`),
  ADD KEY `fk_visit_appointment1_idx` (`appointmentdate`,`patientID`),
  ADD KEY `fk_vitals_nurse1_idx` (`nurseID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `address`
--
ALTER TABLE `address`
  MODIFY `addressID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=42;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `administrator`
--
ALTER TABLE `administrator`
  ADD CONSTRAINT `fk_administrator_employee1` FOREIGN KEY (`eID`) REFERENCES `employee` (`eID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `appointment`
--
ALTER TABLE `appointment`
  ADD CONSTRAINT `fk_appointment_doctor1` FOREIGN KEY (`doctorID`) REFERENCES `doctor` (`doctorID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_appointment_patient1` FOREIGN KEY (`patientID`) REFERENCES `patient` (`patientID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `doctor`
--
ALTER TABLE `doctor`
  ADD CONSTRAINT `fk_doctor_employee1` FOREIGN KEY (`eID`) REFERENCES `employee` (`eID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `employee`
--
ALTER TABLE `employee`
  ADD CONSTRAINT `fk_employee_address1` FOREIGN KEY (`addressID`) REFERENCES `address` (`addressID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `login`
--
ALTER TABLE `login`
  ADD CONSTRAINT `fk_table1_employee` FOREIGN KEY (`eID`) REFERENCES `employee` (`eID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `nurse`
--
ALTER TABLE `nurse`
  ADD CONSTRAINT `fk_nurse_employee1` FOREIGN KEY (`eID`) REFERENCES `employee` (`eID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `patient`
--
ALTER TABLE `patient`
  ADD CONSTRAINT `fk_patient_address1` FOREIGN KEY (`addressID`) REFERENCES `address` (`addressID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `specialty`
--
ALTER TABLE `specialty`
  ADD CONSTRAINT `fk_specialty_doctor1` FOREIGN KEY (`doctorID`) REFERENCES `doctor` (`doctorID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `testResults`
--
ALTER TABLE `testResults`
  ADD CONSTRAINT `fk_testResults_test1` FOREIGN KEY (`testCode`) REFERENCES `test` (`testCode`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_testResults_visit1` FOREIGN KEY (`appointmentdate`,`patientID`) REFERENCES `visit` (`appointmentdate`, `patientID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `visit`
--
ALTER TABLE `visit`
  ADD CONSTRAINT `fk_visit_appointment1` FOREIGN KEY (`appointmentdate`,`patientID`) REFERENCES `appointment` (`appointmentdate`, `patientID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_vitals_nurse1` FOREIGN KEY (`nurseID`) REFERENCES `nurse` (`nurseID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
