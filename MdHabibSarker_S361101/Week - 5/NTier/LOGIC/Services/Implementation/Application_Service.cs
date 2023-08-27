using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using DAL.Entities;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Application;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service Allows us to Add, Fetch and Update Application Data
    /// </summary>
    public class Application_Service : IApplication_Service
    {
        //private ICRUD _crud = new CRUD();
        private IApplication_Operations _application_Operations = new Application_Operations();

        /// <summary>
        /// Adds both an applicant and application at the same time, which is linked to the applicant added.
        /// </summary>
        /// <param name="grade_id"></param>
        /// <param name="application_status_id"></param>
        /// <param name="school_year"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="birthday"></param>
        /// <param name="email"></param>
        /// <param name="phone_number"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<ApplicationApplicant_ResultSet>> AddApplicationAndApplicant(Int64 grade_id, Int64 application_status_id, Int32 school_year, string name, string surname, DateTime birthday, string email, string phone_number)
        {
            Generic_ResultSet<ApplicationApplicant_ResultSet> result = new Generic_ResultSet<ApplicationApplicant_ResultSet>();
            result.result_set = new ApplicationApplicant_ResultSet();
            try
            {
                //INIT NEW DB ENTITY OF Application but with applicant
                Application ApplicationAdded = await _application_Operations.AddFullApplication(grade_id, application_status_id, school_year, name, surname, birthday, email, phone_number);
                //MANUAL MAPPING OF RESULTS FROM DB
                result.result_set.applicant_ResultSet = new Models.Applicant.Applicant_ResultSet
                {
                    id = ApplicationAdded.ApplicantID,
                    name = ApplicationAdded.Applicant.Applicant_Name,
                    surname = ApplicationAdded.Applicant.Applicant_Surname,
                    birthday = ApplicationAdded.Applicant.Applicant_BirthDate,
                    email = ApplicationAdded.Applicant.Contact_Email,
                    phone_number = ApplicationAdded.Applicant.Contact_Number,
                    submission_date = ApplicationAdded.Applicant.Applicant_CreationDate
                };
                result.result_set.application_ResultSet = new Application_ResultSet
                {
                    id = ApplicationAdded.ApplicationID,
                    applicant_id = ApplicationAdded.ApplicantID,
                    grade_id = ApplicationAdded.GradeID,
                    status_id = ApplicationAdded.ApplicationStatusID,
                    school_year = ApplicationAdded.SchoolYear,
                    submission_date = ApplicationAdded.Application_CreationDate
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = "The supplied application and applicant were added successfully";
                result.internalMessage = "LOGIC.Services.Implementation.Application_Service: AddApplicationAndApplicant() method executed successfully.";
                result.result_set = result.result_set;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for your child. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Application_Service: AddApplicationAndApplicant(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
         
        /// <summary>
        /// Fetches an application by supplying the specific applications primary key value
        /// </summary>
        /// <param name="application_id"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Application_ResultSet>>GetApplicationById(Int64 application_id)
        {
            Generic_ResultSet<Application_ResultSet> result = new Generic_ResultSet<Application_ResultSet>();
            try
            {
                //GET Applicant FROM DB
                Application Application = await _crud.Read<Application>(application_id);

                //MANUAL MAPPING OF RETURNED Application VALUES TO OUR Application_ResultSet
                Application_ResultSet appplicationReturned = new Application_ResultSet
                {
                   id= Application.ApplicationID,
                   applicant_id= Application.ApplicantID,
                   grade_id= Application.GradeID,
                   status_id=Application.ApplicationStatusID,
                   school_year= Application.SchoolYear,
                   submission_date= Application.Application_CreationDate
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = "Your application was located successfully";
                result.internalMessage = "LOGIC.Services.Implementation.Application_Service: GetApplicationById() method executed successfully.";
                result.result_set = appplicationReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to find the application you are looking for.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Application_Service: GetApplicationById(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
        
        /// <summary>
        /// Updates an application with the new value/values provided
        /// </summary>
        /// <param name="application_id"></param>
        /// <param name="grade_id"></param>
        /// <param name="application_status_id"></param>
        /// <param name="school_year"></param>
        /// <param name="applicant_id"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Application_ResultSet>> UpdateApplication(Int64 application_id, Int64 grade_id, Int64 application_status_id, Int32 school_year, Int64 applicant_id)
        {
            Generic_ResultSet<Application_ResultSet> result = new Generic_ResultSet<Application_ResultSet>();
            try
            {
                //SETUP DB ENTITY OF Application TO UPDATE
                Application Application = new Application
                {
                    ApplicationID = application_id,
                    ApplicantID = applicant_id,
                    GradeID = grade_id,
                    ApplicationStatusID = application_status_id,
                    SchoolYear = school_year,
                    Application_ModifiedDate = DateTime.UtcNow
                };

                //ADD Grade TO DB
                Application = await _crud.Update<Application>(Application, application_id);

                //MANUAL MAPPING OF RETURNED Grade VALUES TO OUR Grade_ResultSet
                Application_ResultSet applicationUpdated = new Application_ResultSet
                {
                   id= Application.ApplicationID,
                   applicant_id = Application.ApplicantID,
                   grade_id= Application.GradeID,
                   status_id= Application.ApplicationStatusID,
                   school_year= Application.SchoolYear,
                   submission_date= Application.Application_CreationDate
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = "The supplied application was updated successfully";
                result.internalMessage = "LOGIC.Services.Implementation.Application_Service: UpdateApplication() method executed successfully.";
                result.result_set = applicationUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the application supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Application_Service: UpdateApplication(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Obtains all the applications for the specified applicant - BONUS METHOD
        /// </summary>
        /// <param name="applicant_id"></param>
        /// <returns></returns>
        //BONUS METHOD
        public async Task<Generic_ResultSet<List<Application_ResultSet>>> GetApplicationsByApplicantId(Int64 applicant_id)
        {
            Generic_ResultSet<List<Application_ResultSet>> result = new Generic_ResultSet<List<Application_ResultSet>>();
            result.result_set = new List<Application_ResultSet>();
            try
            {
                //GET Applicant FROM DB
                List<Application> Applications = await _application_Operations.GetApplicationsByApplicantId(applicant_id);

                //MANUAL MAPPING OF RETURNED Application VALUES TO OUR Application_ResultSet
                Applications.ForEach(app => {
                    result.result_set.Add(new Application_ResultSet
                    {
                        applicant_id= app.ApplicantID,
                        grade_id=app.GradeID,
                        id=app.ApplicationID,
                        school_year=app.SchoolYear,
                        status_id=app.ApplicationStatusID,
                        submission_date=app.Application_CreationDate
                    });
                });
               
                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = "Your applications were located successfully";
                result.internalMessage = "LOGIC.Services.Implementation.Application_Service: GetApplicationsByApplicantId() method executed successfully.";
                result.result_set = result.result_set;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to find the applications you were looking for.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Application_Service: GetApplicationsByApplicantId(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
