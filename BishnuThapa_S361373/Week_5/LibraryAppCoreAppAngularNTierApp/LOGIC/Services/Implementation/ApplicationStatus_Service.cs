using DAL.Entities;
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.ApplicationStatus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{

    /// <summary>
    /// This service allows us to Add, Fetch and Update Application Status Data
    /// </summary>
    public class ApplicationStatus_Service : IApplicationStatus_Service
    {
        //Reference to our crud functions
        private ICRUD _crud = new CRUD();

        /// <summary>
        /// Adds a new application status to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<ApplicationStatus_ResultSet>> AddApplicationStatus(string name)
        {
            Generic_ResultSet<ApplicationStatus_ResultSet> result = new Generic_ResultSet<ApplicationStatus_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF ApplicationStatus
                ApplicationStatus ApplicationStatus = new ApplicationStatus
                {
                    ApplicationStatus_Name = name
                };

                //ADD ApplicationStatus TO DB
                ApplicationStatus = await _crud.Create<ApplicationStatus>(ApplicationStatus);

                //MANUAL MAPPING OF RETURNED ApplicationStatus VALUES TO OUR ApplicationStatus_ResultSet
                ApplicationStatus_ResultSet statusAdded = new ApplicationStatus_ResultSet
                {
                    name = ApplicationStatus.ApplicationStatus_Name,
                    status_id = ApplicationStatus.ApplicationStatusID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied application status {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.ApplicationStatus_Service: AddApplicationStatus() method executed successfully.";
                result.result_set = statusAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the application status supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.ApplicationStatus_Service: AddApplicationStatus(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Obtains all the Application Statuses that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<ApplicationStatus_ResultSet>>> GetAllApplicationStatuses()
        {
            Generic_ResultSet<List<ApplicationStatus_ResultSet>> result = new Generic_ResultSet<List<ApplicationStatus_ResultSet>>();
            try
            {
                //GET ALL APPLICATION STATUSES
                List<ApplicationStatus> ApplicationStatuses = await _crud.ReadAll<ApplicationStatus>();
                //MAP DB ApplicationStatus RESULTS
                result.result_set = new List<ApplicationStatus_ResultSet>();
                ApplicationStatuses.ForEach(s =>
                {
                    result.result_set.Add(new ApplicationStatus_ResultSet
                    {
                        status_id = s.ApplicationStatusID,
                        name = s.ApplicationStatus_Name,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All application statuses obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.ApplicationStatus_Service: GetAllApplicationStatuses() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required application statuses from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.ApplicationStatus_Service: GetAllApplicationStatuses(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an application statuses name.
        /// </summary>
        /// <param name="status_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<ApplicationStatus_ResultSet>> UpdateApplicationStatus(Int64 status_id, string name)
        {
            Generic_ResultSet<ApplicationStatus_ResultSet> result = new Generic_ResultSet<ApplicationStatus_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF ApplicationStatus
                ApplicationStatus ApplicationStatus = new ApplicationStatus
                {
                    ApplicationStatusID = status_id,
                    ApplicationStatus_Name = name,
                    ApplicationtStatus_ModifiedDate = DateTime.UtcNow
                };

                //UPDATE ApplicationStatus IN DB
                ApplicationStatus = await _crud.Update<ApplicationStatus>(ApplicationStatus, status_id);

                //MANUAL MAPPING OF RETURNED ApplicationStatus VALUES TO OUR ApplicationStatus_ResultSet
                ApplicationStatus_ResultSet statusUpdated = new ApplicationStatus_ResultSet
                {
                    name = ApplicationStatus.ApplicationStatus_Name,
                    status_id = ApplicationStatus.ApplicationStatusID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied application status {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.ApplicationStatus_Service: UpdateApplicationStatus() method executed successfully.";
                result.result_set = statusUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the application status supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.ApplicationStatus_Service: UpdateApplicationStatus(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
