DROP TABLE IF EXISTS `address` ;

CREATE TABLE IF NOT EXISTS `address` (
  `addressID` INT NOT NULL AUTO_INCREMENT,
  `addr1` VARCHAR(45) NOT NULL,
  `addr2` VARCHAR(45) NULL,
  `city` VARCHAR(45) NOT NULL,
  `state` VARCHAR(45) NOT NULL,
  `zip` INT NOT NULL,
  `contactNum` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`addressID`),
  UNIQUE INDEX `addr1_zipUNIQUE` (`addr1` ASC, `zip` ASC)
);


DROP TABLE IF EXISTS `employee` ;

CREATE TABLE IF NOT EXISTS `employee` (
  `eID` VARCHAR(20) NOT NULL,
  `fname` VARCHAR(45) NOT NULL,
  `lname` VARCHAR(45) NOT NULL,
  `addressID` INT NOT NULL,
  PRIMARY KEY (`eID`),
  INDEX `fk_employee_address1_idx` (`addressID` ASC),
  CONSTRAINT `fk_employee_address1`
    FOREIGN KEY (`addressID`)
    REFERENCES `address` (`addressID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);



DROP TABLE IF EXISTS `login` ;

CREATE TABLE IF NOT EXISTS `login` (
  `password` VARCHAR(30) NOT NULL,
  `eID` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`eID`),
  INDEX `fk_table1_employee_idx` (`eID` ASC),
  CONSTRAINT `fk_table1_employee`
    FOREIGN KEY (`eID`)
    REFERENCES `employee` (`eID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);




DROP TABLE IF EXISTS `nurse` ;

CREATE TABLE IF NOT EXISTS `nurse` (
  `nurseID` VARCHAR(20) NOT NULL,
  `eID` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`nurseID`),
  CONSTRAINT `fk_nurse_employee1`
    FOREIGN KEY (`eID`)
    REFERENCES `employee` (`eID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);



DROP TABLE IF EXISTS `administrator` ;

CREATE TABLE IF NOT EXISTS `administrator` (
  `adminID` VARCHAR(20) NOT NULL,
  `eID` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`adminID`),
  CONSTRAINT `fk_administrator_employee1`
    FOREIGN KEY (`eID`)
    REFERENCES `employee` (`eID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);


DROP TABLE IF EXISTS `doctor` ;

CREATE TABLE IF NOT EXISTS `doctor` (
  `doctorID` VARCHAR(20) NOT NULL,
  `eID` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`doctorID`),
  CONSTRAINT `fk_doctor_employee1`
    FOREIGN KEY (`eID`)
    REFERENCES `employee` (`eID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);


DROP TABLE IF EXISTS `patient` ;

CREATE TABLE IF NOT EXISTS `patient` (
  `patientID` VARCHAR(20) NOT NULL,
  `lname` VARCHAR(45) NOT NULL,
  `fname` VARCHAR(45) NOT NULL,
  `address_addressID` INT NOT NULL,
  PRIMARY KEY (`patientID`),
  INDEX `fk_patient_address1_idx` (`address_addressID` ASC),
  CONSTRAINT `fk_patient_address1`
    FOREIGN KEY (`address_addressID`)
    REFERENCES `address` (`addressID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);

DROP TABLE IF EXISTS `appointment` ;

CREATE TABLE IF NOT EXISTS `appointment` (
  `appointmentdate` DATETIME NOT NULL,
  `reason` VARCHAR(300) NOT NULL,
  `doctorID` VARCHAR(20) NOT NULL,
  `patientID` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`appointmentdate`, `patientID`),
  INDEX `fk_appointment_doctor1_idx` (`doctorID` ASC),
  INDEX `fk_appointment_patient1_idx` (`patientID` ASC),
  CONSTRAINT `fk_appointment_doctor1`
    FOREIGN KEY (`doctorID`)
    REFERENCES `doctor` (`doctorID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_appointment_patient1`
    FOREIGN KEY (`patientID`)
    REFERENCES `patient` (`patientID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);



DROP TABLE IF EXISTS `visit` ;

CREATE TABLE IF NOT EXISTS `visit` (
  `systolicNum` INT NOT NULL,
  `diastolicNum` INT NOT NULL,
  `heartrate` INT NOT NULL,
  `respirationrate` INT NOT NULL,
  `bodytemp` DOUBLE NOT NULL,
  `other` VARCHAR(300) NOT NULL,
  `nurseID` VARCHAR(20) NOT NULL,
  `appointmentdate` DATETIME NOT NULL,
  `patientID` VARCHAR(20) NOT NULL,
  `diagnosis` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`appointmentdate`, `patientID`),
  INDEX `fk_visit_appointment1_idx` (`appointmentdate` ASC, `patientID` ASC),
  INDEX `fk_vitals_nurse1_idx` (`nurseID` ASC),
  CONSTRAINT `fk_vitals_nurse1`
    FOREIGN KEY (`nurseID`)
    REFERENCES `nurse` (`nurseID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_visit_appointment1`
    FOREIGN KEY (`appointmentdate` , `patientID`)
    REFERENCES `appointment` (`appointmentdate` , `patientID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);

DROP TABLE IF EXISTS `test` ;

CREATE TABLE IF NOT EXISTS `test` (
  `testCode` INT NOT NULL,
  `testName` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`testCode`),
  UNIQUE INDEX `testName_UNIQUE` (`testName` ASC),
  UNIQUE INDEX `testCode_UNIQUE` (`testCode` ASC));



DROP TABLE IF EXISTS `testResults` ;

CREATE TABLE IF NOT EXISTS `testResults` (
  `testdate` DATETIME NOT NULL,
  `results` VARCHAR(100) NOT NULL,
  `appointmentdate` DATETIME NOT NULL,
  `patientID` VARCHAR(20) NOT NULL,
  `testCode` INT NOT NULL,
  PRIMARY KEY (`testdate`, `appointmentdate`, `patientID`, `testCode`),
  INDEX `fk_testResults_visit1_idx` (`appointmentdate` ASC, `patientID` ASC),
  INDEX `fk_testResults_test1_idx` (`testCode` ASC),
  CONSTRAINT `fk_testResults_visit1`
    FOREIGN KEY (`appointmentdate` , `patientID`)
    REFERENCES `visit` (`appointmentdate` , `patientID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_testResults_test1`
    FOREIGN KEY (`testCode`)
    REFERENCES `test` (`testCode`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);


DROP TABLE IF EXISTS `specialty` ;

CREATE TABLE IF NOT EXISTS `specialty` (
  `specialty` VARCHAR(50) NOT NULL,
  `doctorID` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`specialty`, `doctorID`),
  INDEX `fk_specialty_doctor1_idx` (`doctorID` ASC),
  CONSTRAINT `fk_specialty_doctor1`
    FOREIGN KEY (`doctorID`)
    REFERENCES `doctor` (`doctorID`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);



-- -----------------------------------------------------
-- Data for table `project1Revised`.`address`
-- -----------------------------------------------------

INSERT INTO `address` (`addressID`, `addr1`, `addr2`, `city`, `state`, `zip`, `contactNum`) VALUES (1, '123 wallaby way', NULL, 'Fayetteville', 'GA', 30213, '3455443445');
INSERT INTO `address` (`addressID`, `addr1`, `addr2`, `city`, `state`, `zip`, `contactNum`) VALUES (2, '184 sydney way', NULL, 'Carrollton', 'GA', 30245, '2938473245');
INSERT INTO `address` (`addressID`, `addr1`, `addr2`, `city`, `state`, `zip`, `contactNum`) VALUES (3, '475 carpenter trail', NULL, 'Wyndon', 'GA', 32456, '2343418574');
INSERT INTO `address` (`addressID`, `addr1`, `addr2`, `city`, `state`, `zip`, `contactNum`) VALUES (4, '687 magic lane', NULL, 'Fillabank', 'GA', 30012, '6473849399');
INSERT INTO `address` (`addressID`, `addr1`, `addr2`, `city`, `state`, `zip`, `contactNum`) VALUES (5, '675 MLK Blvd', NULL, 'Atlanta', 'GA', 30013, '4043327465');
INSERT INTO `address` (`addressID`, `addr1`, `addr2`, `city`, `state`, `zip`, `contactNum`) VALUES (6, '144 peachtree st', NULL, 'Atlanta', 'GA', 30034, '4043772849');
INSERT INTO `address` (`addressID`, `addr1`, `addr2`, `city`, `state`, `zip`, `contactNum`) VALUES (7, '456 sneak lane', NULL, 'Newnan', 'GA', 30216, '4703392847');
INSERT INTO `address` (`addressID`, `addr1`, `addr2`, `city`, `state`, `zip`, `contactNum`) VALUES (8, '233 avery mt', NULL, 'Newnan', 'GA', 30216, '2340039485');




-- -----------------------------------------------------
-- Data for table `project1Revised`.`employee`
-- -----------------------------------------------------


INSERT INTO .`employee` (`eID`, `fname`, `lname`, `addressID`) VALUES ('1928374625', 'Jane', 'Mary', 1);
INSERT INTO `employee` (`eID`, `fname`, `lname`, `addressID`) VALUES ('8473624958', 'Michael', 'Ryan', 2);
INSERT INTO `employee` (`eID`, `fname`, `lname`, `addressID`) VALUES ('9458674632', 'Josh', 'Abel', 3);
INSERT INTO `employee` (`eID`, `fname`, `lname`, `addressID`) VALUES ('9938273645', 'Marissa', 'Ann', 4);
INSERT INTO `employee` (`eID`, `fname`, `lname`, `addressID`) VALUES ('6857664382', 'Jessica', 'Jewels', 5);
INSERT INTO `employee` (`eID`, `fname`, `lname`, `addressID`) VALUES ('4657748329', 'Anthony', 'Miller', 6);



-- -----------------------------------------------------
-- Data for table `project1Revised`.`login`
-- -----------------------------------------------------

INSERT INTO `login` (`password`, `eID`) VALUES ('3js73h9', '9938273645');
INSERT INTO `login` (`password`, `eID`) VALUES ('d77ejs', '8473624958');
INSERT INTO `login` (`password`, `eID`) VALUES ('e8ddis0', '9458674632');
INSERT INTO `login` (`password`, `eID`) VALUES ('0fmmd7', '1928374625');
INSERT INTO `login` (`password`, `eID`) VALUES ('kd83n2k', '6857664382');
INSERT INTO `login` (`password`, `eID`) VALUES ('nd8si09', '4657748329');




-- -----------------------------------------------------
-- Data for table `project1Revised`.`nurse`
-- -----------------------------------------------------

INSERT INTO `nurse` (`nurseID`, `eID`) VALUES ('77283746253', '1928374625');
INSERT INTO `nurse` (`nurseID`, `eID`) VALUES ('88374635241', '8473624958');




-- -----------------------------------------------------
-- Data for table `project1Revised`.`administrator`
-- -----------------------------------------------------

INSERT INTO `administrator` (`adminID`, `eID`) VALUES ('1128374635', '6857664382');
INSERT INTO `administrator` (`adminID`, `eID`) VALUES ('8847736251', '4657748329');




-- -----------------------------------------------------
-- Data for table `project1Revised`.`doctor`
-- -----------------------------------------------------

INSERT INTO `doctor` (`doctorID`, `eID`) VALUES ('3352435465', '9458674632');
INSERT INTO `doctor` (`doctorID`, `eID`) VALUES ('1239485746', '9938273645');




-- -----------------------------------------------------
-- Data for table `project1Revised`.`patient`
-- -----------------------------------------------------

INSERT INTO `patient` (`patientID`, `lname`, `fname`, `address_addressID`) VALUES ('1733827364', 'William', 'James', 7);
INSERT INTO `patient` (`patientID`, `lname`, `fname`, `address_addressID`) VALUES ('1234567890', 'Aubry', 'Holland', 8);




-- -----------------------------------------------------
-- Data for table `project1Revised`.`appointment`
-- -----------------------------------------------------

INSERT INTO `appointment` (`appointmentdate`, `reason`, `doctorID`, `patientID`) VALUES ('2020-10-15 10:30:00', 'Fractured Leg', '3352435465', '1733827364');
INSERT INTO `appointment` (`appointmentdate`, `reason`, `doctorID`, `patientID`) VALUES ('2020-10-17 08:30:00', 'Chest Pains', '1239485746', '1234567890');



-- -----------------------------------------------------
-- Data for table `project1Revised`.`visit`
-- -----------------------------------------------------

INSERT INTO `visit` (`systolicNum`, `diastolicNum`, `heartrate`, `respirationrate`, `bodytemp`, `other`, `nurseID`, `appointmentdate`, `patientID`, `diagnosis`) VALUES (100, 70, 72, 12, 98.5, 'none', '77283746253', '2020-10-15 10:30:00', '1733827364', 'fractured leg');
INSERT INTO `visit` (`systolicNum`, `diastolicNum`, `heartrate`, `respirationrate`, `bodytemp`, `other`, `nurseID`, `appointmentdate`, `patientID`, `diagnosis`) VALUES (110, 66, 65, 16, 97.3, 'none', '88374635241', '2020-10-17 08:30:00', '1234567890', 'Heart murmer');



-- -----------------------------------------------------
-- Data for table `project1Revised`.`test`
-- -----------------------------------------------------

INSERT INTO `test` (`testCode`, `testName`) VALUES (34, 'WBC');
INSERT INTO `test` (`testCode`, `testName`) VALUES (48, 'LDL');
INSERT INTO `test` (`testCode`, `testName`) VALUES (74, 'hepatitis A');
INSERT INTO `test` (`testCode`, `testName`) VALUES (94, 'hepatitis B');
INSERT INTO `test` (`testCode`, `testName`) VALUES (83, 'Mineral Tests');



-- -----------------------------------------------------
-- Data for table `project1Revised`.`testResults`
-- -----------------------------------------------------

INSERT INTO `testResults` (`testdate`, `results`, `appointmentdate`, `patientID`, `testCode`) VALUES ('2020-10-15 12:15:00', 'Elevated', '2020-10-15 10:30:00', '1733827364', 34);
INSERT INTO `testResults` (`testdate`, `results`, `appointmentdate`, `patientID`, `testCode`) VALUES ('2020-10-17 09:22:00', 'Normal', '2020-10-17 08:30:00', '1234567890', 48);



-- -----------------------------------------------------
-- Data for table `project1Revised`.`specialty`
-- -----------------------------------------------------

INSERT INTO `specialty` (`specialty`, `doctorID`) VALUES ('General', '3352435465');
INSERT INTO `specialty` (`specialty`, `doctorID`) VALUES ('Cardiology', '1239485746');


