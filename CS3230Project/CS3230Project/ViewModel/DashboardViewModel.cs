﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.DAL;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     the dashboard view model
    /// </summary>
    public class DashboardViewModel
    {

        /// <summary>
        /// Retrieves the name and title.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns>the title and name of the given employeeId</returns>
        public string RetrieveTitleAndName(string employeeId)
        {
            var employeeDal = new EmployeeDal();

            return employeeDal.RetrieveTitleAndName(employeeId);
        }
    }
}