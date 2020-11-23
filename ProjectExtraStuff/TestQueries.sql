--Test Queries will go here

--test query 1
SELECT DISTINCT visit.appointmentdate, visit.systolicNum, visit.diastolicNum, visit.heartrate, visit.respirationrate, visit.bodytemp, visit.weight, visit.other, visit.nurseID, CONCAT(n.fname, " ", n.lname) as nurseName, appointment.doctorID, CONCAT(d.fname, " ", d.lname) as doctorName, GROUP_CONCAT( DISTINCT test.testName SEPARATOR ", ") as orderedTest, GROUP_CONCAT(testResults.results SEPARATOR ', ') as testResults, visit.diagnosis 
FROM visit, employee n, employee d, appointment, testResults LEFT JOIN test ON testResults.testCode = test.testCode 
WHERE visit.patientID = '908434301' AND visit.nurseID = (SELECT nurse.nurseID FROM nurse WHERE nurse.eID = n.eID) AND testResults.appointmentdate = visit.appointmentdate AND visit.appointmentdate = appointment.appointmentdate AND appointment.doctorID = (SELECT doctor.doctorID FROM doctor WHERE doctor.eID = d.eID)
GROUP BY visit.appointmentdate, visit.systolicNum, visit.diastolicNum, visit.nurseID, nurseName, appointment.doctorID, doctorName, visit.diagnosis


--test query 2
SELECT testResults.patientID, CONCAT(patient.fname, " ", patient.lname) as patientName, testResults.testdate, COUNT(testResults.testCode) as totalTestForDay
FROM testResults, patient
WHERE testResults.patientID = patient.patientID
GROUP BY testResults.patientID, patientName, testResults.testdate
HAVING COUNT(testResults.testCode) >= 2 AND COUNT(testResults.testdate) > 1
ORDER BY testResults.patientID, testResults.testdate
